using System;
using System.ComponentModel;          // LicenseManager
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
        private readonly string _cs;

        public int CurrentAdminId { get; set; }

        private DataTable _estadoAlumno = new DataTable();
        private int? _alumnoIdActual = null;
        private DateTime? _fechaAltaAlumno = null;

        // Seguro para diseñador
        private bool IsDesignMode =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;

        public CobrosControl(int currentAdminId = 0)
        {
            InitializeComponent();

            if (IsDesignMode) return; // no DB ni eventos en diseñador

            var csCfg = ConfigurationManager.ConnectionStrings["BaseDatos"];
            if (csCfg == null || string.IsNullOrWhiteSpace(csCfg.ConnectionString))
                throw new InvalidOperationException("Falta la cadena de conexión 'BaseDatos' en app.config.");

            _cs = csCfg.ConnectionString;

            CurrentAdminId = (currentAdminId > 0)
                ? currentAdminId
                : (UserSession.IsLogged ? UserSession.IdUsuario : 0);

            // Configuración UI
            dgvPendientes.AutoGenerateColumns = false;
            ConfigurarDataGridView(dgvPendientes);
            ApplyTheme();

            // Eventos
            btnBuscar.Click += (s, e) => BuscarPorDni();
            txtDni.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BuscarPorDni(); }
            };
            btnPagar.Click += (s, e) => RegistrarPago();

            // Vista inicial
            CargarCoberturaGlobal();
            SetControlesPago(false);
        }

        // ========= UI =========
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
        }

        private void ConfigurarDataGridView(DataGridView dgv)
        {
            Color verdeEncabezado = ColorTranslator.FromHtml("#014A16");
            Color verdeSeleccion = ColorTranslator.FromHtml("#7BAE7F");
            Color verdeAlterna = ColorTranslator.FromHtml("#EDFFEF");
            Color grisBorde = ColorTranslator.FromHtml("#C8D3C4");
            Color hoverSuave = ColorTranslator.FromHtml("#DCEFE6");

            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.EnableHeadersVisualStyles = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = grisBorde;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = verdeEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 36;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = verdeSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = verdeAlterna;

            dgv.ClearSelection();
            dgv.DataBindingComplete += (s, e) => ((DataGridView)s).ClearSelection();

            // Hover suave
            Color originalBackColor = dgv.DefaultCellStyle.BackColor;
            Color originalAltColor = dgv.AlternatingRowsDefaultCellStyle.BackColor;
            int lastRow = -1;

            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex != lastRow)
                {
                    var fila = dgv.Rows[e.RowIndex];
                    fila.DefaultCellStyle.BackColor = hoverSuave;
                    lastRow = e.RowIndex;
                }
            };

            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var fila = dgv.Rows[e.RowIndex];
                    fila.DefaultCellStyle.BackColor =
                        (e.RowIndex % 2 == 0) ? originalBackColor : originalAltColor;
                }
            };

            // Doble buffer
            try
            {
                typeof(DataGridView)
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(dgv, true, null);
            }
            catch { }
        }

        private void SetControlesPago(bool enabled)
        {
            txtMonto.Enabled = enabled;
            btnPagar.Enabled = enabled;
        }

        // ========= Util general =========
        private static int ToInt(object value, int fallback)
        {
            return (value == null || value == DBNull.Value)
                ? fallback
                : Convert.ToInt32(value, CultureInfo.InvariantCulture);
        }

        // ========= DB helpers =========
        private bool ColumnaExiste(string tabla, string columna)
        {
            const string q = @"SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(@t) AND name = @c;";
            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(q, cn))
            {
                cmd.Parameters.Add("@t", SqlDbType.NVarChar, 256).Value = tabla;
                cmd.Parameters.Add("@c", SqlDbType.NVarChar, 128).Value = columna;
                cn.Open();
                object r = cmd.ExecuteScalar();
                return r != null;
            }
        }

        private void SetSessionContext(SqlConnection cn)
        {
            if (CurrentAdminId <= 0) return;
            using (var cmd = new SqlCommand("EXEC sys.sp_set_session_context @key=N'current_user_id', @value=@id", cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = CurrentAdminId;
                cmd.ExecuteNonQuery();
            }
        }

        private int AsegurarCuotaConVto(SqlConnection cn, SqlTransaction tx, int idAlumno, int anio, int mes, decimal monto, DateTime vto)
        {
            // ¿Existe?
            using (var sel = new SqlCommand(
                @"SELECT id_cuota FROM dbo.Cuota WHERE id_alumno = @a AND anio = @y AND mes = @m;", cn, tx))
            {
                sel.Parameters.Add("@a", SqlDbType.Int).Value = idAlumno;
                sel.Parameters.Add("@y", SqlDbType.Int).Value = anio;
                sel.Parameters.Add("@m", SqlDbType.TinyInt).Value = mes;

                object r = sel.ExecuteScalar();
                if (r != null && r != DBNull.Value)
                {
                    using (var up = new SqlCommand(
                        @"UPDATE dbo.Cuota
                          SET monto = CASE WHEN monto<=0 THEN @mon ELSE monto END,
                              fecha_vencimiento = @vto
                          WHERE id_cuota = @id;", cn, tx))
                    {
                        var pMon = up.Parameters.Add("@mon", SqlDbType.Decimal); pMon.Precision = 10; pMon.Scale = 2; pMon.Value = monto;
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
                var pMon = ins.Parameters.Add("@mon", SqlDbType.Decimal); pMon.Precision = 10; pMon.Scale = 2; pMon.Value = monto;
                ins.Parameters.Add("@vto", SqlDbType.Date).Value = vto.Date;
                ins.Parameters.Add("@a", SqlDbType.Int).Value = idAlumno;

                object nuevoId = ins.ExecuteScalar();
                return Convert.ToInt32(nuevoId);
            }
        }

        // ========= Búsqueda y pago =========
        private void BuscarPorDni()
        {
            ResetUI();

            if (!int.TryParse(txtDni.Text.Trim(), out int dni))
            {
                MessageBox.Show("Ingresá un DNI numérico.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            var tupla = ObtenerAlumnoActivoPorDni(dni);
            int? idAlumno = tupla.idAlumno;
            string nombre = tupla.nombre;
            DateTime? fechaAlta = tupla.fechaAlta;

            if (idAlumno == null)
            {
                lblAlumnoNombre.Text = "No se encontró un alumno activo con ese DNI.";
                SetControlesPago(false);
                CargarCoberturaGlobal();
                return;
            }

            _alumnoIdActual = idAlumno;
            _fechaAltaAlumno = fechaAlta;

            lblAlumnoNombre.Text = string.Format("{0}  •  Alta: {1:dd/MM/yyyy}", nombre, fechaAlta);

            // Monto sugerido
            decimal sugerido = ObtenerMontoMensualPreferido(_alumnoIdActual.Value);
            if (sugerido > 0) txtMonto.Text = sugerido.ToString("N2", new CultureInfo("es-AR"));

            // Estado individual
            _estadoAlumno = ObtenerEstadoAlumnoHoy(_alumnoIdActual.Value);
            dgvPendientes.DataSource = _estadoAlumno;

            // Leyenda
            string estado = (_estadoAlumno.Rows.Count > 0)
                ? (_estadoAlumno.Rows[0]["estado_texto"] == DBNull.Value ? "—" : _estadoAlumno.Rows[0]["estado_texto"].ToString())
                : "—";
            DateTime? vto = null;
            if (_estadoAlumno.Rows.Count > 0 && _estadoAlumno.Rows[0]["fecha_vencimiento"] != DBNull.Value)
                vto = Convert.ToDateTime(_estadoAlumno.Rows[0]["fecha_vencimiento"]);

            lblProximoPeriodo.Text = (estado == "Pagada")
                ? string.Format("Cubre hasta: {0:dd/MM/yyyy}", vto)
                : (vto.HasValue ? string.Format("Sin cobertura (último vencimiento: {0:dd/MM/yyyy})", vto) : "Sin cobertura");

            SetControlesPago(true);
            txtMonto.Focus();

            // Resumen global (no pisa el DataSource del estado individual)
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

            if (CurrentAdminId <= 0)
            {
                MessageBox.Show("No se detectó un administrador en sesión. Cerrá y volvete a iniciar sesión.",
                    "Sesión requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtMonto.Text.Trim(), NumberStyles.Any, new CultureInfo("es-AR"), out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingresá un monto válido mayor a 0.",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return;
            }

            // Período a cobrar = mes y año de HOY (tu app trabaja así)
            DateTime fechaPago = DateTime.Today;
            int anio = fechaPago.Year;
            int mes = fechaPago.Month;

            // vto: mismo día del mes siguiente (clamp a último día)
            DateTime siguienteMes = fechaPago.AddMonths(1);
            int lastDay = DateTime.DaysInMonth(siguienteMes.Year, siguienteMes.Month);
            DateTime vto = new DateTime(siguienteMes.Year, siguienteMes.Month, Math.Min(fechaPago.Day, lastDay));

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
                    SetSessionContext(cn);

                    bool tieneIdAdmin = ColumnaExiste("dbo.Pago", "id_admin");

                    using (var tx = cn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        // No permitir pagar dos veces el mismo período
                        using (var chkDup = new SqlCommand(
                            @"SELECT p.id_pago
                              FROM dbo.Pago p
                              JOIN dbo.Cuota c ON c.id_cuota = p.id_cuota
                              WHERE c.id_alumno = @al
                                AND c.anio = @y AND c.mes = @m;", cn, tx))
                        {
                            chkDup.Parameters.Add("@al", SqlDbType.Int).Value = _alumnoIdActual.Value;
                            chkDup.Parameters.Add("@y", SqlDbType.Int).Value = anio;
                            chkDup.Parameters.Add("@m", SqlDbType.TinyInt).Value = mes;

                            var dup = chkDup.ExecuteScalar();
                            if (dup != null)
                            {
                                tx.Rollback();
                                MessageBox.Show($"La cuota de {periodoTxt} ya está paga.", "Aviso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BuscarPorDni();
                                return;
                            }
                        }

                        // Asegurar cuota y registrar pago
                        int idCuota = AsegurarCuotaConVto(cn, tx, _alumnoIdActual.Value, anio, mes, monto, vto);

                        string insertSql = tieneIdAdmin
                            ? @"INSERT INTO dbo.Pago (fecha_pago, monto, id_cuota, id_admin)
                               VALUES (@fp, @m, @c, @a);"
                            : @"INSERT INTO dbo.Pago (fecha_pago, monto, id_cuota)
                               VALUES (@fp, @m, @c);";

                        using (var cmd = new SqlCommand(insertSql, cn, tx))
                        {
                            cmd.Parameters.Add("@fp", SqlDbType.Date).Value = fechaPago.Date;
                            var pMonto = cmd.Parameters.Add("@m", SqlDbType.Decimal); pMonto.Precision = 10; pMonto.Scale = 2; pMonto.Value = monto;
                            cmd.Parameters.Add("@c", SqlDbType.Int).Value = idCuota;
                            if (tieneIdAdmin) cmd.Parameters.Add("@a", SqlDbType.Int).Value = CurrentAdminId;

                            System.Diagnostics.Debug.WriteLine(
                                $"[RegistrarPago] alumno={_alumnoIdActual} cuota={idCuota} monto={monto} admin={CurrentAdminId}");

                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show("Pago registrado correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                BuscarPorDni();
                CargarCoberturaGlobal();
                txtMonto.Clear();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al registrar el pago:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========= Consultas Alumno / Global =========
        private (int? idAlumno, string nombre, DateTime? fechaAlta) ObtenerAlumnoActivoPorDni(int dni)
        {
            bool tieneActivo = ColumnaExiste("dbo.Alumno", "activo");
            bool tieneEstado = ColumnaExiste("dbo.Alumno", "estado");

            string sql = tieneActivo
                ? @"SELECT TOP 1 id_alumno, nombre, fecha_alta
                    FROM dbo.Alumno WHERE dni = @dni AND activo = 1;"
                : (tieneEstado
                    ? @"SELECT TOP 1 id_alumno, nombre, fecha_alta
                        FROM dbo.Alumno
                        WHERE dni = @dni AND
                              (TRY_CAST(estado AS int) = 1 OR
                               UPPER(LTRIM(RTRIM(CAST(estado AS nvarchar(20))))) IN ('A','ACTIVO','TRUE','SI','S'));"
                    : @"SELECT TOP 1 id_alumno, nombre, fecha_alta
                        FROM dbo.Alumno WHERE dni = @dni;");

            using (var cn = new SqlConnection(_cs))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return (
                            rd.GetInt32(0),
                            rd.GetString(1),
                            rd.IsDBNull(2) ? (DateTime?)null : rd.GetDateTime(2).Date
                        );
                    }
                }
            }

            return (null, null, null);
        }

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

        private void CargarCoberturaGlobal()
        {
            if (IsDesignMode) return;

            var tabla = ObtenerCoberturaGlobal();

            // Si NO estoy mostrando el estado individual, uso la global.
            if (_alumnoIdActual == null) dgvPendientes.DataSource = tabla;

            // Remarcar "No pagada" con cuidado de columnas nulas
            dgvPendientes.CellFormatting -= DgvImpagos_CellFormatting;
            dgvPendientes.CellFormatting += DgvImpagos_CellFormatting;

            int noPagadas = tabla.AsEnumerable().Count(r => (r["estado_texto"] == DBNull.Value ? "" : r["estado_texto"].ToString()) == "No pagada");
            int pagadas = tabla.Rows.Count - noPagadas;
            lblTotal.Text = $"Pagadas: {pagadas}  •  No pagas: {noPagadas}";
        }

        private void DgvImpagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = (DataGridView)sender;
            // Si no existe la columna "colEstado" salgo
            if (!grid.Columns.Contains("colEstado")) return;

            if (grid.Columns[e.ColumnIndex].Name != "colEstado") return;

            var estadoObj = grid.Rows[e.RowIndex].Cells["colEstado"].Value;
            var estado = estadoObj?.ToString();

            if (estado == "No pagada")
            {
                var row = grid.Rows[e.RowIndex];
                row.DefaultCellStyle.ForeColor = Color.FromArgb(120, 0, 0);
                row.Cells["colEstado"].Style.Font = new Font(grid.Font, FontStyle.Bold);
            }
        }

        private DataTable ObtenerCoberturaGlobal()
        {
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

        // ========= Utilidades varias =========
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
            // No tocar DataSource aquí para no borrar el global
            SetControlesPago(false);
            txtMonto.Clear();
        }

        private decimal ObtenerMontoMensualPreferido(int idAlumno)
        {
            bool tieneMontoMensual = ColumnaExiste("dbo.Alumno", "monto_mensual");

            using (var cn = new SqlConnection(_cs))
            {
                cn.Open();

                if (tieneMontoMensual)
                {
                    using (var cmd = new SqlCommand("SELECT monto_mensual FROM dbo.Alumno WHERE id_alumno = @id;", cn))
                    {
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                        object r = cmd.ExecuteScalar();
                        if (r != null && r != DBNull.Value &&
                            decimal.TryParse(r.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal m1) && m1 > 0)
                            return m1;
                    }
                }

                using (var cmd2 = new SqlCommand(
                    @"SELECT TOP 1 monto FROM dbo.Cuota WHERE id_alumno = @id ORDER BY id_cuota DESC;", cn))
                {
                    cmd2.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                    object r2 = cmd2.ExecuteScalar();
                    if (r2 != null && r2 != DBNull.Value &&
                        decimal.TryParse(r2.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal m2) && m2 > 0)
                        return m2;
                }
            }

            return -1m; // sin referencia válida
        }
    }
}
