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
        private const int GRACIA_DIAS = 15;

        private readonly string _cs;

        public int CurrentAdminId { get; set; }

        private DataTable _estadoAlumno = new DataTable();
        private int? _alumnoIdActual = null;
        private DateTime? _fechaAltaAlumno = null;

        // Próximo período a pagar (inicio)
        private DateTime? _siguientePeriodo = null;

        private bool IsDesignMode =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;

        private bool _colsCoberturaReady = false;

        public CobrosControl(int currentAdminId = 0)
        {
            InitializeComponent();

            if (IsDesignMode) return; // nada de DB ni eventos en diseñador

            var csCfg = ConfigurationManager.ConnectionStrings["BaseDatos"];
            if (csCfg == null || string.IsNullOrWhiteSpace(csCfg.ConnectionString))
                throw new InvalidOperationException("Falta la cadena de conexión 'BaseDatos' en app.config.");

            _cs = csCfg.ConnectionString;

            CurrentAdminId = (currentAdminId > 0)
                ? currentAdminId
                : (UserSession.IsLogged ? UserSession.IdUsuario : 0);

            // Config de grilla/UI
            dgvPendientes.AutoGenerateColumns = false;
            ConfigurarDataGridView(dgvPendientes);
            ConfigurarColumnasCobertura(dgvPendientes);
            ApplyTheme();

            // Eventos
            if (btnBuscar != null)
                btnBuscar.Click += (s, e) => BuscarPorDni();

            if (txtDni != null)
                txtDni.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; BuscarPorDni(); }
                };

            if (btnPagar != null)
                btnPagar.Click += (s, e) => RegistrarPago();

            if (BCancelar != null)
                BCancelar.Click += (s, e) => CancelarSeleccion();

            // Vista inicial
            AplicarBajasPorMora15Dias();
            CargarCoberturaGlobal();
            SetControlesPago(false);
        }

        // ========= UI =========
        private void ApplyTheme()
        {
            Color primary = Color.FromArgb(0, 100, 0);
            Color header = Color.FromArgb(0, 64, 0);
            Color text = Color.FromArgb(40, 40, 40);

            if (lblTitulo != null) lblTitulo.ForeColor = header;
            foreach (var lbl in new[] { lblDni, lblAlumno, lblMonto, lblSiguiente })
                if (lbl != null) lbl.ForeColor = text;

            foreach (var b in new[] { btnBuscar, btnPagar })
            {
                if (b == null) continue;
                b.FlatStyle = FlatStyle.Flat;
                b.UseVisualStyleBackColor = false;
                b.BackColor = primary;
                b.ForeColor = Color.White;
                b.FlatAppearance.BorderSize = 0;
            }
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

            try
            {
                typeof(DataGridView)
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(dgv, true, null);
            }
            catch { }
        }

        private void ConfigurarColumnasCobertura(DataGridView dgv)
        {
            if (_colsCoberturaReady) return;

            dgv.AutoGenerateColumns = false;

            // limpiar cualquier cosa del diseñador
            dgv.DataSource = null;
            dgv.Columns.Clear();

            var colNombre = new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                FillWeight = 35
            };
            var colDni = new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "dni",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            var colVence = new DataGridViewTextBoxColumn
            {
                Name = "colVence",
                HeaderText = "Vencimiento",
                DataPropertyName = "vence_cubre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            var colPlazo = new DataGridViewTextBoxColumn
            {
                Name = "colPlazo",
                HeaderText = "Plazo de Pago",
                DataPropertyName = "dias_texto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            var colEstado = new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "estado_texto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            dgv.Columns.AddRange(colNombre, colDni, colVence, colPlazo, colEstado);

            _colsCoberturaReady = true;
        }

        private void SetControlesPago(bool enabled)
        {
            if (txtMonto != null) txtMonto.Enabled = enabled;
            if (btnPagar != null)
            {
                btnPagar.Enabled = true;                  // visual siempre activo
                btnPagar.Tag = enabled ? null : "locked"; // bloqueo lógico
                btnPagar.Cursor = enabled ? Cursors.Hand : Cursors.No;
            }
        }

        // ========= Helpers generales =========
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

        // ========= Bajas/Reactivaciones por C# =========
        private void AplicarBajasPorMora15Dias()
        {
            try
            {
                using (var cn = new SqlConnection(_cs))
                {
                    cn.Open();

                    string sql = @"
;WITH Ult AS (
  SELECT a.id_alumno, a.fecha_alta, a.activo_desde, a.estado, a.activo,
         MAX(p.fecha_pago) AS ultima_pago
  FROM dbo.Alumno a
  LEFT JOIN dbo.Cuota c ON c.id_alumno = a.id_alumno
  LEFT JOIN dbo.Pago  p ON p.id_cuota   = c.id_cuota
       AND (a.activo_desde IS NULL OR p.fecha_pago >= a.activo_desde)
  GROUP BY a.id_alumno, a.fecha_alta, a.activo_desde, a.estado, a.activo
),
Venc AS (
  SELECT id_alumno,
         CASE 
           WHEN ultima_pago IS NULL 
             THEN CAST(DATEADD(month, 1, COALESCE(CAST(activo_desde AS date), CAST(fecha_alta AS date), CAST(GETDATE() AS date))) AS date)
           ELSE CAST(DATEADD(month, 1, CAST(ultima_pago AS date)) AS date)
         END AS fecha_vencimiento,
         CASE 
           WHEN activo IS NOT NULL THEN activo
           WHEN estado IS NOT NULL THEN estado
           ELSE 0
         END AS ActivoLogico
  FROM Ult
)
UPDATE a
   SET a.estado     = CASE WHEN COL_LENGTH('dbo.Alumno','estado') IS NULL THEN a.estado ELSE 0 END,
       a.activo     = CASE WHEN COL_LENGTH('dbo.Alumno','activo') IS NULL THEN a.activo ELSE 0 END,
       a.fecha_baja = COALESCE(a.fecha_baja, CAST(GETDATE() AS date))
FROM dbo.Alumno a
JOIN Venc v ON v.id_alumno = a.id_alumno
WHERE v.ActivoLogico = 1
  AND DATEADD(day, 15, v.fecha_vencimiento) < CAST(GETDATE() AS date);";

                    using (var cmd = new SqlCommand(sql, cn))
                        cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // silencioso para no romper UX
            }
        }

        private void ReactivarAlumno(int idAlumno, DateTime fechaReactivacion)
        {
            try
            {
                using (var cn = new SqlConnection(_cs))
                using (var cmd = new SqlCommand(@"
UPDATE dbo.Alumno
   SET estado       = CASE WHEN COL_LENGTH('dbo.Alumno','estado') IS NULL THEN estado ELSE 1 END,
       activo       = CASE WHEN COL_LENGTH('dbo.Alumno','activo') IS NULL THEN activo ELSE 1 END,
       activo_desde = CASE WHEN COL_LENGTH('dbo.Alumno','activo_desde') IS NULL 
                           THEN NULL ELSE @fec END,
       fecha_baja   = CASE WHEN COL_LENGTH('dbo.Alumno','fecha_baja') IS NULL 
                           THEN fecha_baja ELSE NULL END
 WHERE id_alumno = @id;", cn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                    cmd.Parameters.Add("@fec", SqlDbType.Date).Value = fechaReactivacion.Date;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }

        // ========= Búsqueda y pago =========
        private void BuscarPorDni()
        {
            ResetUI();
            int dni;
            if (!int.TryParse(txtDni.Text.Trim(), out dni))
            {
                MessageBox.Show("Ingresá un DNI numérico.", "Dato inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDni.Focus();
                return;
            }

            AplicarBajasPorMora15Dias();

            var tupla = ObtenerAlumnoActivoPorDni(dni);
            int? idAlumno = tupla.idAlumno;
            string nombre = tupla.nombre;
            DateTime? fechaBase = tupla.fechaBase; // (activo_desde ?? fecha_alta)

            if (idAlumno == null)
            {
                lblAlumnoNombre.Text = "No se encontró un alumno activo con ese DNI.";
                SetControlesPago(false);
                CargarCoberturaGlobal();
                return;
            }

            _alumnoIdActual = idAlumno;
            _fechaAltaAlumno = fechaBase;

            lblAlumnoNombre.Text = string.Format("{0}  •  Alta/React.: {1:dd/MM/yyyy}", nombre, fechaBase);

            decimal sugerido = ObtenerMontoMensualPreferido(_alumnoIdActual.Value);
            if (sugerido > 0) txtMonto.Text = sugerido.ToString("N2", new CultureInfo("es-AR"));

            _estadoAlumno = ObtenerEstadoAlumnoHoy(_alumnoIdActual.Value);
            dgvPendientes.DataSource = _estadoAlumno;

            // ====== Último pago REAL + último período pagado (anio/mes) + próximo período ======
            if (_estadoAlumno.Rows.Count > 0)
            {
                DateTime baseCob = fechaBase.GetValueOrDefault(DateTime.Today);
                DateTime? ultimoPagoReal = null;
                int? anioUlt = null, mesUlt = null;

                using (var cn = new SqlConnection(_cs))
                using (var cmd = new SqlCommand(@"
                    SELECT TOP 1 c.anio, c.mes, MAX(p.fecha_pago) AS ultimo_pago
                    FROM dbo.Pago p
                    JOIN dbo.Cuota c ON c.id_cuota = p.id_cuota
                    WHERE c.id_alumno = @id
                      AND p.fecha_pago >= @base
                    GROUP BY c.anio, c.mes
                    ORDER BY c.anio DESC, c.mes DESC;", cn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = _alumnoIdActual.Value;
                    cmd.Parameters.Add("@base", SqlDbType.Date).Value = baseCob.Date;
                    cn.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            anioUlt = rd.GetInt32(0);
                            mesUlt = Convert.ToInt32(rd.GetByte(1));
                            if (!rd.IsDBNull(2)) ultimoPagoReal = rd.GetDateTime(2).Date;
                        }
                    }
                }

                // Si nunca pagó aún (desde esta alta/reactivación)
                if (anioUlt == null || mesUlt == null)
                {
                    DateTime periodoInicio0 = ComposePeriodStart(baseCob, baseCob.Year, baseCob.Month);
                    DateTime coberturaHasta0 = periodoInicio0.AddMonths(1);
                    DateTime plazoHasta0 = coberturaHasta0.AddDays(GRACIA_DIAS);

                    _siguientePeriodo = periodoInicio0; // primer período

                    lblProximoPeriodo.Text =
                        $"Último pago registrado: — (sin pagos previos)\n" +
                        $"Cobertura: {periodoInicio0:dd/MM/yyyy} → {coberturaHasta0:dd/MM/yyyy}\n" +
                        $"Próximo vencimiento: {coberturaHasta0:dd/MM/yyyy}\n" +
                        $"Plazo hasta: {plazoHasta0:dd/MM/yyyy}";
                    if (lblSiguiente != null)
                        lblSiguiente.Text = $"Siguiente cuota: {_siguientePeriodo:dd/MM/yyyy} → {_siguientePeriodo.Value.AddMonths(1):dd/MM/yyyy}";
                }
                else
                {
                    // Último período realmente pagado (por anio/mes)
                    DateTime periodoInicio = ComposePeriodStart(baseCob, anioUlt.Value, mesUlt.Value);
                    DateTime coberturaHasta = periodoInicio.AddMonths(1);
                    DateTime plazoHasta = coberturaHasta.AddDays(GRACIA_DIAS);

                    // Próximo período a pagar es el siguiente al último período cubierto
                    _siguientePeriodo = coberturaHasta;

                    string ultimoPagoTxt = ultimoPagoReal.HasValue
                        ? ultimoPagoReal.Value.ToString("dd/MM/yyyy")
                        : "—";

                    lblProximoPeriodo.Text =
                        $"Último pago registrado: {ultimoPagoTxt}\n" +
                        $"Cobertura: {periodoInicio:dd/MM/yyyy} → {coberturaHasta:dd/MM/yyyy}\n" +
                        $"Próximo vencimiento: {coberturaHasta:dd/MM/yyyy}\n" +
                        $"Plazo hasta: {plazoHasta:dd/MM/yyyy}";
                    if (lblSiguiente != null)
                        lblSiguiente.Text = $"Siguiente cuota: {_siguientePeriodo:dd/MM/yyyy} → {_siguientePeriodo.Value.AddMonths(1):dd/MM/yyyy}";
                }
            }
            else
            {
                lblProximoPeriodo.Text = "—";
                _siguientePeriodo = null;
                if (lblSiguiente != null) lblSiguiente.Text = "—";
            }
            // ======================================================================

            SetControlesPago(true);
            txtMonto.Focus();

            CargarCoberturaGlobal();
        }

        private void RegistrarPago()
        {
            if (Equals(btnPagar.Tag, "locked"))
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            if (_alumnoIdActual == null)
            {
                MessageBox.Show("Buscá un alumno por DNI antes de registrar el pago.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (CurrentAdminId <= 0)
            {
                MessageBox.Show("No se detectó un administrador en sesión. Cerrá y logueate.",
                    "Sesión requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal monto;
            if (!decimal.TryParse(txtMonto.Text.Trim(), NumberStyles.Any, new CultureInfo("es-AR"), out monto) || monto <= 0)
            {
                MessageBox.Show("Ingresá un monto válido mayor a 0.",
                    "Dato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMonto.Focus();
                return;
            }

            // Determinar el período a pagar (inicio del período)
            DateTime periodoInicio;
            if (_siguientePeriodo.HasValue)
            {
                periodoInicio = _siguientePeriodo.Value.Date;
            }
            else
            {
                // fallback: si por algún motivo no se precalculó
                DateTime baseCob = _fechaAltaAlumno.GetValueOrDefault(DateTime.Today);
                periodoInicio = ComposePeriodStart(baseCob, baseCob.Year, baseCob.Month);
            }

            int anio = periodoInicio.Year;
            int mes = periodoInicio.Month;

            DateTime vto = periodoInicio.AddMonths(1).Date; // cubre hasta

            string periodoTxt = $"{NombreMes(mes)} {anio}";

            if (MessageBox.Show(
                    $"¿Confirmás registrar el pago de {periodoTxt} por ${monto:N2}?\n" +
                    $"Cobertura: {periodoInicio:dd/MM/yyyy} → {vto:dd/MM/yyyy}",
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
                        // Evitar doble pago del MISMO período
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
                                MessageBox.Show($"La cuota de {periodoTxt} ya está paga.",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BuscarPorDni();
                                return;
                            }
                        }

                        int idCuota = AsegurarCuotaConVto(cn, tx, _alumnoIdActual.Value, anio, mes, monto, vto);

                        string insertSql = tieneIdAdmin
                            ? @"INSERT INTO dbo.Pago (fecha_pago, monto, id_cuota, id_admin)
                               VALUES (@fp, @m, @c, @a);"
                            : @"INSERT INTO dbo.Pago (fecha_pago, monto, id_cuota)
                               VALUES (@fp, @m, @c);";

                        using (var cmd = new SqlCommand(insertSql, cn, tx))
                        {
                            // >>> fecha_pago = HOY (fecha real de pago)
                            cmd.Parameters.Add("@fp", SqlDbType.Date).Value = DateTime.Today;
                            var pMonto = cmd.Parameters.Add("@m", SqlDbType.Decimal); pMonto.Precision = 10; pMonto.Scale = 2; pMonto.Value = monto;
                            cmd.Parameters.Add("@c", SqlDbType.Int).Value = idCuota;
                            if (tieneIdAdmin) cmd.Parameters.Add("@a", SqlDbType.Int).Value = CurrentAdminId;
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                MessageBox.Show("Pago registrado correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tras pagar, adelanto el puntero para el siguiente ciclo
                _siguientePeriodo = _siguientePeriodo?.AddMonths(1);

                CancelarSeleccion(); // limpia y refresca
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al registrar el pago:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========= Consultas =========
        private (int? idAlumno, string nombre, DateTime? fechaBase) ObtenerAlumnoActivoPorDni(int dni)
        {
            bool tieneActivo = ColumnaExiste("dbo.Alumno", "activo");
            bool tieneEstado = ColumnaExiste("dbo.Alumno", "estado");
            bool tieneActDesde = ColumnaExiste("dbo.Alumno", "activo_desde");

            string selectBase = @"
SELECT TOP 1 
       id_alumno, 
       nombre, 
       {0} AS fecha_base
FROM dbo.Alumno
WHERE dni = @dni AND {1};";

            // condición de "activo"
            string condActivo = tieneActivo
                ? "activo = 1"
                : (tieneEstado
                    ? "(TRY_CAST(estado AS int) = 1 OR UPPER(LTRIM(RTRIM(CAST(estado AS nvarchar(20))))) IN ('A','ACTIVO','TRUE','SI','S'))"
                    : "1=1");

            // campo de fecha base: activo_desde tiene prioridad si existe
            string campoFechaBase = tieneActDesde ? "COALESCE(activo_desde, fecha_alta)" : "fecha_alta";

            string sql = string.Format(selectBase, campoFechaBase, condActivo);

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

        private DataTable ObtenerCoberturaGlobal()
        {
            const string sql = @"
;WITH Ult AS (
  SELECT a.id_alumno, a.nombre, a.dni, a.fecha_alta, a.activo_desde,
         CASE 
           WHEN COL_LENGTH('dbo.Alumno','activo') IS NOT NULL THEN a.activo
           WHEN COL_LENGTH('dbo.Alumno','estado') IS NOT NULL THEN a.estado
           ELSE 0
         END AS ActivoLogico,
         MAX(p.fecha_pago) AS ultima_pago
  FROM dbo.Alumno a
  LEFT JOIN dbo.Cuota c ON c.id_alumno = a.id_alumno
  LEFT JOIN dbo.Pago  p ON p.id_cuota   = c.id_cuota
       AND (a.activo_desde IS NULL OR p.fecha_pago >= a.activo_desde)
  GROUP BY a.id_alumno, a.nombre, a.dni, a.fecha_alta, a.activo_desde,
           CASE 
             WHEN COL_LENGTH('dbo.Alumno','activo') IS NOT NULL THEN a.activo
             WHEN COL_LENGTH('dbo.Alumno','estado') IS NOT NULL THEN a.estado
             ELSE 0
           END
),
Calc AS (
  SELECT id_alumno, nombre, dni,
         CASE 
           WHEN ultima_pago IS NULL 
             THEN CAST(DATEADD(month,1,COALESCE(CAST(activo_desde AS date), CAST(fecha_alta AS date), CAST(GETDATE() AS date))) AS date)
           ELSE CAST(DATEADD(month,1,CAST(ultima_pago AS date)) AS date)
         END AS fecha_vto,
         ActivoLogico
  FROM Ult
)
SELECT 
  id_alumno,
  nombre,
  dni,
  -- Leyenda: si pasó la gracia => texto; si no, mostrar fecha de vencimiento
  CASE 
    WHEN CAST(GETDATE() AS date) > DATEADD(day, @gracia, fecha_vto)
      THEN 'Venció el plazo de 15 días'
    ELSE FORMAT(fecha_vto, 'dd/MM/yyyy')
  END AS vence_cubre,
  'No pagada' AS estado_texto,
  -- días hasta fin de gracia (negativo = vencido hace X días)
  DATEDIFF(day, CAST(GETDATE() AS date), DATEADD(day, @gracia, fecha_vto)) AS dias_restantes
FROM Calc
WHERE ActivoLogico = 1
  -- MOSTRAR SOLO NO PAGADAS: hoy ya está en el período que debe pagar
  AND CAST(GETDATE() AS date) >= fecha_vto
ORDER BY nombre;";

            var t = new DataTable();
            using (var cn = new SqlConnection(_cs))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@gracia", SqlDbType.Int).Value = GRACIA_DIAS;
                da.Fill(t);
            }

            // Convertimos dias_restantes en texto amigable para la columna "Plazo"
            if (!t.Columns.Contains("dias_texto"))
                t.Columns.Add("dias_texto", typeof(string));

            foreach (DataRow r in t.Rows)
            {
                int d = (r["dias_restantes"] == DBNull.Value) ? 0 : Convert.ToInt32(r["dias_restantes"]);
                r["dias_texto"] = d >= 0 ? $"{d} día{(d == 1 ? "" : "s")}"
                                         : $"Vencido hace {Math.Abs(d)} día{(Math.Abs(d) == 1 ? "" : "s")}";
            }

            return t;
        }

        private DataTable ObtenerEstadoAlumnoHoy(int idAlumno)
        {
            const string sql = @"
;WITH Ult AS (
  SELECT a.id_alumno, a.nombre, a.dni, a.fecha_alta, a.activo_desde,
         MAX(p.fecha_pago) AS ultima_pago
  FROM dbo.Alumno a
  LEFT JOIN dbo.Cuota c ON c.id_alumno = a.id_alumno
  LEFT JOIN dbo.Pago  p ON p.id_cuota   = c.id_cuota
       AND (a.activo_desde IS NULL OR p.fecha_pago >= a.activo_desde)
  WHERE a.id_alumno = @id
  GROUP BY a.id_alumno, a.nombre, a.dni, a.fecha_alta, a.activo_desde
),
Calc AS (
  SELECT nombre, dni,
         CASE 
           WHEN ultima_pago IS NULL 
             THEN CAST(DATEADD(month,1,COALESCE(CAST(activo_desde AS date), CAST(fecha_alta AS date), CAST(GETDATE() AS date))) AS date)
           ELSE CAST(DATEADD(month,1,CAST(ultima_pago AS date)) AS date)
         END AS fecha_vto
  FROM Ult
)
SELECT 
  nombre,
  dni,
  'No pagada' AS estado_texto,
  CASE 
    WHEN CAST(GETDATE() AS date) > DATEADD(day,@gracia, fecha_vto)
      THEN 'Venció el plazo de 15 días'
    ELSE FORMAT(fecha_vto, 'dd/MM/yyyy')
  END AS vence_cubre,
  DATEDIFF(day, CAST(GETDATE() AS date), DATEADD(day,@gracia, fecha_vto)) AS dias_restantes
FROM Calc;";

            var t = new DataTable();
            using (var cn = new SqlConnection(_cs))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                da.SelectCommand.Parameters.Add("@gracia", SqlDbType.Int).Value = GRACIA_DIAS;
                da.Fill(t);
            }

            if (!t.Columns.Contains("dias_texto"))
                t.Columns.Add("dias_texto", typeof(string));
            foreach (DataRow r in t.Rows)
            {
                int d = (r["dias_restantes"] == DBNull.Value) ? 0 : Convert.ToInt32(r["dias_restantes"]);
                r["dias_texto"] = d >= 0 ? $"{d} día{(d == 1 ? "" : "s")}"
                                         : $"Vencido hace {Math.Abs(d)} día{(Math.Abs(d) == 1 ? "" : "s")}";
            }

            return t;
        }

        private void CargarCoberturaGlobal()
        {
            if (IsDesignMode) return;

            var tabla = ObtenerCoberturaGlobal();
            dgvPendientes.DataSource = tabla;

            dgvPendientes.CellFormatting -= DgvImpagos_CellFormatting;
            dgvPendientes.CellFormatting += DgvImpagos_CellFormatting;

            int impagos = tabla.Rows.Count;
            lblTotal.Text = $"No pagas: {impagos}";
        }

        private void DgvImpagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var grid = (DataGridView)sender;
            if (!grid.Columns.Contains("colEstado")) return;

            // Estado en rojo
            if (grid.Columns[e.ColumnIndex].Name == "colEstado")
            {
                grid.Rows[e.RowIndex].Cells["colEstado"].Style.Font = new Font(grid.Font, FontStyle.Bold);
                grid.Rows[e.RowIndex].Cells["colEstado"].Style.ForeColor = Color.FromArgb(120, 0, 0);
            }

            // Si dias_restantes < 0, toda la fila en un rojo tenue
            if (grid.Columns.Contains("colPlazo") && grid.Columns.Contains("colVence"))
            {
                var row = grid.Rows[e.RowIndex];
                var drv = row.DataBoundItem as DataRowView;
                if (drv != null && drv.Row.Table.Columns.Contains("dias_restantes"))
                {
                    int d = drv.Row["dias_restantes"] == DBNull.Value ? 0 : Convert.ToInt32(drv.Row["dias_restantes"]);
                    if (d < 0)
                    {
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(150, 0, 0);
                        row.Cells["colVence"].Style.Font = new Font(grid.Font, FontStyle.Bold);
                    }
                }
            }
        }

        // ========= Otros =========
        private static string NombreMes(int mes)
        {
            var cultura = new CultureInfo("es-AR");
            return cultura.TextInfo.ToTitleCase(new DateTime(2000, mes, 1).ToString("MMMM", cultura));
        }

        private static DateTime ComposePeriodStart(DateTime baseCob, int anio, int mes)
        {
            int dia = Math.Min(baseCob.Day, DateTime.DaysInMonth(anio, mes));
            return new DateTime(anio, mes, dia);
        }

        private void ResetUI()
        {
            _alumnoIdActual = null;
            _fechaAltaAlumno = null;
            _siguientePeriodo = null;
            if (lblAlumnoNombre != null) lblAlumnoNombre.Text = "—";
            if (lblProximoPeriodo != null) lblProximoPeriodo.Text = "—";
            if (lblTotal != null) lblTotal.Text = "—";
            if (lblSiguiente != null) lblSiguiente.Text = "—";
            SetControlesPago(false);
            if (txtMonto != null) txtMonto.Clear();
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
                        decimal m1Parsed;
                        if (r != null && r != DBNull.Value &&
                            decimal.TryParse(r.ToString(), out m1Parsed) && m1Parsed > 0)
                            return m1Parsed;
                    }
                }

                using (var cmd2 = new SqlCommand(
                    @"SELECT TOP 1 monto FROM dbo.Cuota WHERE id_alumno = @id ORDER BY id_cuota DESC;", cn))
                {
                    cmd2.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                    object r2 = cmd2.ExecuteScalar();
                    decimal m2Parsed;
                    if (r2 != null && r2 != DBNull.Value &&
                        decimal.TryParse(r2.ToString(), out m2Parsed) && m2Parsed > 0)
                        return m2Parsed;
                }
            }

            return -1m;
        }

        private void CancelarSeleccion()
        {
            try
            {
                if (txtDni != null) txtDni.Clear();
                ResetUI();
                _estadoAlumno = new DataTable();
                _alumnoIdActual = null;
                dgvPendientes.DataSource = null;
                CargarCoberturaGlobal();
                dgvPendientes.ClearSelection();
                txtDni?.Focus();
            }
            catch { }
        }
    }
}
