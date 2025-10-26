using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class CobrosControl : UserControl
    {
        private readonly string _cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public int CurrentAdminId { get; set; }

        // Estado del alumno buscado
        private DataTable _estadoAlumno = new DataTable();
        private int? _alumnoIdActual = null;
        private DateTime? _fechaAltaAlumno = null;

        // Política: sin cuotas acumulables. Cada pago = 1 mes desde la fecha del pago.
        // (Si quisieras tolerancias/rebase, acá pondrías constantes.)

        public CobrosControl(int currentAdminId = 0)
        {
            InitializeComponent();
            CurrentAdminId = currentAdminId;

            dgvPendientes.AutoGenerateColumns = false;
            ApplyTheme();

            btnBuscar.Click += (s, e) => BuscarPorDni();
            txtDni.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BuscarPorDni(); } };
            btnPagar.Click += (s, e) => RegistrarPago();

            // Vista global al abrir (estado de cobertura)
            CargarCoberturaGlobal();
        }

        #region UI helpers
        private void ApplyTheme()
        {
            Color primary = Color.FromArgb(0, 100, 0);
            Color header = Color.FromArgb(0, 64, 0);
            Color text = Color.FromArgb(40, 40, 40);

            lblTitulo.ForeColor = header;
            foreach (var lbl in new[] { lblDni, lblAlumno, lblMonto, lblSiguiente })
                lbl.ForeColor = text;

            btnBuscar.BackColor = primary; btnBuscar.ForeColor = Color.White;
            btnPagar.BackColor = primary; btnPagar.ForeColor = Color.White;

            dgvPendientes.EnableHeadersVisualStyles = false;
            dgvPendientes.ColumnHeadersDefaultCellStyle.BackColor = header;
            dgvPendientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPendientes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvPendientes.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);
            dgvPendientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 248);

            // Sin selección visual
            dgvPendientes.DefaultCellStyle.SelectionBackColor = dgvPendientes.DefaultCellStyle.BackColor;
            dgvPendientes.DefaultCellStyle.SelectionForeColor = dgvPendientes.DefaultCellStyle.ForeColor;
            dgvPendientes.SelectionChanged += (s, e) => dgvPendientes.ClearSelection();
        }

        private void SetControlesPago(bool enabled)
        {
            txtMonto.Enabled = enabled;
            btnPagar.Enabled = enabled;
        }
        #endregion

        #region Util general
        private static int ToInt(object value, int fallback)
            => (value == null || value == DBNull.Value) ? fallback : Convert.ToInt32(value, CultureInfo.InvariantCulture);
        #endregion

        #region Util DB (helpers)
        private bool ColumnaExiste(string tabla, string columna)
        {
            const string q = @"SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(@t) AND name = @c;";
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(q, cn))
            {
                cmd.Parameters.Add("@t", SqlDbType.NVarChar, 256).Value = tabla;
                cmd.Parameters.Add("@c", SqlDbType.NVarChar, 128).Value = columna;
                cn.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

        // Asegura cuota para (anio, mes) con un VTO explícito (política: fechaPago + 1 mes)
        private int AsegurarCuotaConVto(SqlConnection cn, SqlTransaction tx, int idAlumno, int anio, int mes, decimal monto, DateTime vto)
        {
            // ¿Existe?
            using (var sel = new SqlCommand(
                @"SELECT id_cuota FROM dbo.Cuota WHERE id_alumno = @a AND anio = @y AND mes = @m;", cn, tx))
            {
                sel.Parameters.Add("@a", SqlDbType.Int).Value = idAlumno;
                sel.Parameters.Add("@y", SqlDbType.Int).Value = anio;
                sel.Parameters.Add("@m", SqlDbType.TinyInt).Value = mes;

                var r = sel.ExecuteScalar();
                if (r != null && r != DBNull.Value)
                {
                    // Actualizar monto/vto si hiciera falta (sin romper pagos previos)
                    using (var up = new SqlCommand(
                        @"UPDATE dbo.Cuota SET monto = CASE WHEN monto<=0 THEN @mon ELSE monto END,
                                                fecha_vencimiento = @vto
                          WHERE id_cuota = @id;", cn, tx))
                    {
                        up.Parameters.Add("@mon", SqlDbType.Decimal).Value = monto;
                        up.Parameters.Add("@vto", SqlDbType.Date).Value = vto.Date;
                        up.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(r);
                        up.ExecuteNonQuery();
                    }
                    return Convert.ToInt32(r);
                }
            }

            // Crear
            using (var ins = new SqlCommand(
                @"INSERT INTO dbo.Cuota (anio, mes, monto, fecha_vencimiento, id_alumno)
                  OUTPUT INSERTED.id_cuota
                  VALUES (@y, @m, @mon, @vto, @a);", cn, tx))
            {
                ins.Parameters.Add("@y", SqlDbType.Int).Value = anio;
                ins.Parameters.Add("@m", SqlDbType.TinyInt).Value = mes;
                var pMon = ins.Parameters.Add("@mon", SqlDbType.Decimal);
                pMon.Precision = 10; pMon.Scale = 2; pMon.Value = monto;
                ins.Parameters.Add("@vto", SqlDbType.Date).Value = vto.Date;
                ins.Parameters.Add("@a", SqlDbType.Int).Value = idAlumno;

                return Convert.ToInt32(ins.ExecuteScalar());
            }
        }
        #endregion

        #region Búsqueda y pago (modelo sin acumulación)
        private void BuscarPorDni()
        {
            ResetUI();

            if (!int.TryParse(txtDni.Text.Trim(), out var dni))
            {
                MessageBox.Show("Ingresá un DNI numérico.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            // Alumno activo (soporta 'activo' o 'estado')
            (int? idAlumno, string nombre, DateTime? fechaAlta) = ObtenerAlumnoActivoPorDni(dni);
            if (idAlumno == null)
            {
                lblAlumnoNombre.Text = "No se encontró un alumno activo con ese DNI.";
                SetControlesPago(false);
                CargarCoberturaGlobal();
                return;
            }

            _alumnoIdActual = idAlumno;
            _fechaAltaAlumno = fechaAlta;
            lblAlumnoNombre.Text = $"{nombre}  •  Alta: {fechaAlta:dd/MM/yyyy}";

            // No generamos cuotas por calendario
            // GenerarCuotasFaltantesHastaHoy(...)  // <-- ELIMINADO

            // Mostrar estado actual del alumno (cubre hasta / pagada o no)
            _estadoAlumno = ObtenerEstadoAlumnoHoy(_alumnoIdActual.Value);
            dgvPendientes.DataSource = _estadoAlumno;

            string estado = (_estadoAlumno.Rows.Count > 0) ? (_estadoAlumno.Rows[0]["estado_texto"]?.ToString() ?? "—") : "—";
            DateTime? vto = null;
            if (_estadoAlumno.Rows.Count > 0 && _estadoAlumno.Rows[0]["fecha_vencimiento"] != DBNull.Value)
                vto = Convert.ToDateTime(_estadoAlumno.Rows[0]["fecha_vencimiento"]);

            lblProximoPeriodo.Text = estado == "Pagada"
                ? $"Cubre hasta: {vto:dd/MM/yyyy}"
                : (vto.HasValue ? $"Sin cobertura (último vencimiento: {vto:dd/MM/yyyy})" : "Sin cobertura");

            SetControlesPago(true);
            txtMonto.Focus();

            // Refrescar vista global
            CargarCoberturaGlobal();
        }

        private void RegistrarPago()
        {
            if (_alumnoIdActual == null)
            {
                MessageBox.Show("Buscá un alumno por DNI antes de registrar el pago.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text.Trim(), NumberStyles.Any, new CultureInfo("es-AR"),
                    out var monto) || monto <= 0)
            {
                MessageBox.Show("Ingresá un monto válido mayor a 0.",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return;
            }

            // === NUEVO: período según FECHA DE PAGO (sin acumulación) ===
            var fechaPago = DateTime.Today;                  // o DateTime.Now.Date
            int anio = fechaPago.Year;
            int mes = fechaPago.Month;

            // vto = fechaPago + 1 mes (clamp al fin de mes, respetando el día del pago)
            DateTime tmp = fechaPago.AddMonths(1);
            int lastDay = DateTime.DaysInMonth(tmp.Year, tmp.Month);
            DateTime vto = new DateTime(tmp.Year, tmp.Month, Math.Min(fechaPago.Day, lastDay));

            string periodoTxt = $"{NombreMes(mes)} {anio}";
            if (MessageBox.Show(
                    $"¿Confirmás registrar el pago de {periodoTxt} por ${monto:N2}?\nCobertura: {fechaPago:dd/MM/yyyy} → {vto:dd/MM/yyyy}",
                    "Confirmar pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (var cn = new SqlConnection(_cs))
                {
                    cn.Open();
                    bool tieneIdAdmin = ColumnaExiste("dbo.Pago", "id_admin");

                    using (var tx = cn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        // Crear/Asegurar la cuota del mes lógico del pago con VTO explícito
                        int idCuota = AsegurarCuotaConVto(cn, tx, _alumnoIdActual.Value, anio, mes, monto, vto);

                        // Verificar que no esté ya paga (caso reintento)
                        using (var chk = new SqlCommand("SELECT 1 FROM dbo.Pago WHERE id_cuota = @c", cn, tx))
                        {
                            chk.Parameters.Add("@c", SqlDbType.Int).Value = idCuota;
                            if (chk.ExecuteScalar() != null)
                            {
                                tx.Rollback();
                                MessageBox.Show($"La cuota de {periodoTxt} ya está paga.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BuscarPorDni();
                                return;
                            }
                        }

                        // Insert pago
                        string insertSql = tieneIdAdmin
                            ? @"INSERT INTO dbo.Pago (monto, id_cuota, fecha_pago, id_admin)
                               VALUES (@m, @c, @fp, @a);"
                            : @"INSERT INTO dbo.Pago (monto, id_cuota, fecha_pago)
                               VALUES (@m, @c, @fp);";

                        using (var cmd = new SqlCommand(insertSql, cn, tx))
                        {
                            var pMonto = cmd.Parameters.Add("@m", SqlDbType.Decimal);
                            pMonto.Precision = 10; pMonto.Scale = 2; pMonto.Value = monto;
                            cmd.Parameters.Add("@c", SqlDbType.Int).Value = idCuota;
                            cmd.Parameters.Add("@fp", SqlDbType.Date).Value = fechaPago.Date;
                            if (tieneIdAdmin)
                                cmd.Parameters.Add("@a", SqlDbType.Int).Value = CurrentAdminId;

                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show("Pago registrado correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar alumno + global
                BuscarPorDni();
                CargarCoberturaGlobal();
                txtMonto.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al registrar el pago:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Consultas Alumno / Global (por cobertura real)
        private (int? idAlumno, string nombre, DateTime? fechaAlta) ObtenerAlumnoActivoPorDni(int dni)
        {
            bool tieneActivo = ColumnaExiste("dbo.Alumno", "activo");
            bool tieneEstado = ColumnaExiste("dbo.Alumno", "estado");

            string sql = tieneActivo
                ? @"SELECT TOP 1 id_alumno, nombre, fecha_alta
                    FROM dbo.Alumno WHERE dni = @dni AND activo = 1;"
                : tieneEstado
                    ? @"SELECT TOP 1 id_alumno, nombre, fecha_alta
                        FROM dbo.Alumno
                        WHERE dni = @dni AND
                              (TRY_CAST(estado AS int) = 1 OR
                               UPPER(LTRIM(RTRIM(CAST(estado AS nvarchar(20))))) IN ('A','ACTIVO','TRUE','SI','S'));"
                    : @"SELECT TOP 1 id_alumno, nombre, fecha_alta
                        FROM dbo.Alumno WHERE dni = @dni;";

            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return (rd.GetInt32(0),
                                rd.GetString(1),
                                rd.IsDBNull(2) ? (DateTime?)null : rd.GetDateTime(2).Date);
                }
            }
            return (null, null, null);
        }

        // Estado actual del alumno (sin generar cuotas por calendario)
        private DataTable ObtenerEstadoAlumnoHoy(int idAlumno)
        {
            const string sql = @"
;WITH UltPago AS (
  SELECT MAX(p.fecha_pago) AS ultima_pago
  FROM dbo.Pago p
  JOIN dbo.Cuota c ON c.id_cuota = p.id_cuota
  WHERE c.id_alumno = @id
)
SELECT 
  a.nombre,
  a.dni,
  CASE WHEN u.ultima_pago IS NULL THEN NULL ELSE DATEADD(month,1,u.ultima_pago) END AS fecha_vencimiento,
  CASE WHEN u.ultima_pago IS NOT NULL AND DATEADD(month,1,u.ultima_pago) > CAST(GETDATE() AS date)
       THEN 'Pagada' ELSE 'No pagada' END AS estado_texto
FROM dbo.Alumno a
LEFT JOIN UltPago u ON 1=1
WHERE a.id_alumno = @id;";

            var t = new DataTable();
            using (var cn = new SqlConnection(_cs))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                da.Fill(t);
            }
            return t;
        }

        // Global: quiénes hoy están/no están cubiertos (sin crear cuotas)
        private void CargarCoberturaGlobal()
        {
            var tabla = ObtenerCoberturaGlobal();

            // La grilla ya tiene columnas (Nombre, DNI, VTO, Estado)
            dgvPendientes.DataSource = tabla;

            // Estilo suave si no cubre
            dgvPendientes.CellFormatting -= DgvImpagos_CellFormatting;
            dgvPendientes.CellFormatting += DgvImpagos_CellFormatting;

            int noPagadas = tabla.AsEnumerable().Count(r => (r["estado_texto"]?.ToString() ?? "") == "No pagada");
            int pagadas = tabla.Rows.Count - noPagadas;
            lblTotal.Text = $"Pagadas: {pagadas}  •  No pagas: {noPagadas}";
        }

        private void DgvImpagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvPendientes.Columns[e.ColumnIndex].Name != "colEstado") return;

            var estado = dgvPendientes.Rows[e.RowIndex].Cells["colEstado"].Value?.ToString();
            if (estado == "No pagada")
            {
                var row = dgvPendientes.Rows[e.RowIndex];
                row.DefaultCellStyle.ForeColor = Color.FromArgb(120, 0, 0);
                row.Cells["colEstado"].Style.Font = new Font(dgvPendientes.Font, FontStyle.Bold);
            }
        }

        private DataTable ObtenerCoberturaGlobal()
        {
            // Filtro de activos: tolera 'activo' o 'estado'
            bool tieneActivo = ColumnaExiste("dbo.Alumno", "activo");
            bool tieneEstado = ColumnaExiste("dbo.Alumno", "estado");
            string filtroActivo = tieneActivo
                ? "a.activo = 1"
                : (tieneEstado
                    ? "(TRY_CAST(a.estado AS int) = 1 OR UPPER(LTRIM(RTRIM(CAST(a.estado AS nvarchar(20))))) IN ('A','ACTIVO','TRUE','SI','S'))"
                    : "1=1");

            string sql = @"
;WITH UltPago AS (
  SELECT c.id_alumno, MAX(p.fecha_pago) AS ultima_pago
  FROM dbo.Pago p
  JOIN dbo.Cuota c ON c.id_cuota = p.id_cuota
  GROUP BY c.id_alumno
),
Cobertura AS (
  SELECT 
      a.id_alumno,
      a.nombre,
      a.dni,
      u.ultima_pago,
      CASE 
        WHEN u.ultima_pago IS NULL THEN CAST(NULL AS date)
        ELSE DATEADD(month, 1, u.ultima_pago)
      END AS fecha_vencimiento,
      CASE 
        WHEN u.ultima_pago IS NOT NULL AND DATEADD(month,1,u.ultima_pago) > CAST(GETDATE() AS date)
          THEN 'Pagada'
        ELSE 'No pagada'
      END AS estado_texto
  FROM dbo.Alumno a
  LEFT JOIN UltPago u ON u.id_alumno = a.id_alumno
  WHERE " + filtroActivo + @"
)
SELECT id_alumno, nombre, dni, fecha_vencimiento, estado_texto
FROM Cobertura
ORDER BY nombre;";

            var t = new DataTable();
            using (var cn = new SqlConnection(_cs))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.Fill(t);
            }
            return t;
        }
        #endregion

        #region Utilidades varias
        private static string NombreMes(int mes)
        {
            var cultura = new CultureInfo("es-AR");
            return cultura.TextInfo.ToTitleCase(new DateTime(2000, mes, 1).ToString("MMMM", cultura));
        }

        private void ResetUI()
        {
            _alumnoIdActual = null;
            _fechaAltaAlumno = null;
            lblAlumnoNombre.Text = "—";
            lblProximoPeriodo.Text = "—";
            lblTotal.Text = "—";
            dgvPendientes.DataSource = null;
            SetControlesPago(false);
            txtMonto.Clear();
        }
        #endregion

        #region (OBSOLETO) Generación por calendario
        // Mantengo estos métodos por si los usabas en otro lado,
        // pero YA NO se llaman en este control.
        private void GenerarCuotasFaltantesHastaHoy(int idAlumno, DateTime fechaAlta) { /* obsoleto, no usar */ }

        private decimal ObtenerMontoMensualPreferido(int idAlumno)
        {
            // Se mantiene igual: si guardás monto_mensual en Alumno o traes el último monto.
            bool tieneMontoMensual = ColumnaExiste("dbo.Alumno", "monto_mensual");

            using (var cn = new SqlConnection(_cs))
            {
                cn.Open();

                if (tieneMontoMensual)
                {
                    using (var cmd = new SqlCommand("SELECT monto_mensual FROM dbo.Alumno WHERE id_alumno = @id;", cn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                        var r = cmd.ExecuteScalar();
                        if (r != null && r != DBNull.Value &&
                            decimal.TryParse(r.ToString(), out var m1) && m1 > 0)
                            return m1;
                    }
                }

                using (var cmd2 = new SqlCommand(
                           @"SELECT TOP 1 monto FROM dbo.Cuota WHERE id_alumno = @id ORDER BY id_cuota DESC;", cn))
                {
                    cmd2.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                    var r2 = cmd2.ExecuteScalar();
                    if (r2 != null && r2 != DBNull.Value &&
                        decimal.TryParse(r2.ToString(), out var m2) && m2 > 0)
                        return m2;
                }
            }

            return -1m; // sin referencia válida
        }
        #endregion
    }
}
