using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class EstadoCuotasControl : UserControl
    {
        private readonly string _cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public EstadoCuotasControl()
        {
            InitializeComponent();
            ConfigurarDataGridView(dataGridView_Cuotas);

            // Quitar “Estado”
            label1.Visible = false;
            comboBox2.Visible = false;

            ConfigurarGrid();
            CargarCombos();

            // Eventos de filtro/búsqueda
            B_BuscarCuotasDni.Click += (s, e) => Buscar();
            comboBoxMes.SelectedIndexChanged += (s, e) => Buscar();
            comboBoxAnio.SelectedIndexChanged += (s, e) => Buscar();
            txtPersona.TextChanged += (s, e) => Buscar();
            txtPersona.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Buscar(); } };

            // NUEVO: botón limpiar (restaura lista completa y borra el DNI/nombre)
            if (BLimpiar != null) BLimpiar.Click += BLimpiar_Click;

            this.Load += (s, e) =>
            {
                CentrarElementos();
                this.Resize += (s2, e2) => CentrarElementos();
            };

            Buscar();
        }

        // =======================
        //  Estilos del DataGrid
        // =======================
        private void ConfigurarDataGridView(DataGridView dgv)
        {

            Color verdeEncabezado = ColorTranslator.FromHtml("#014A16"); // verde bosque apagado
            Color verdeSeleccion = ColorTranslator.FromHtml("#7BAE7F"); // verde medio selección
            Color verdeAlterna = ColorTranslator.FromHtml("#EDFFEF"); // verde muy claro alternado
            Color grisBorde = ColorTranslator.FromHtml("#C8D3C4"); // gris verdoso claro
            Color hoverSuave = ColorTranslator.FromHtml("#DCEFE6"); // verde pastel para hover

            // --- Comportamiento ---
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

            // --- Autoajuste ---
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // --- Estética general ---
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = grisBorde;

            // Encabezado
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = verdeEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 36;

            // Celdas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = verdeSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);

            // Filas alternadas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = verdeAlterna;

            // --- Sin selección inicial ---
            dgv.ClearSelection();
            dgv.DataBindingComplete += (s, e) => ((DataGridView)s).ClearSelection();

            // --- Hover suave (efecto al pasar el mouse) ---
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
                    fila.DefaultCellStyle.BackColor = (e.RowIndex % 2 == 0) ? originalBackColor : originalAltColor;
                }
            };

            // --- Doble buffer (scroll suave) ---
            try
            {
                typeof(DataGridView)
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(dgv, true, null);
            }
            catch { }
        }

        #region UI
        private void ConfigurarGrid()
        {
            var dgv = dataGridView_Cuotas;

            // Historial de pagos (una fila por pago/cuota pagada)
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre", FillWeight = 24 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDni", HeaderText = "DNI", DataPropertyName = "dni", FillWeight = 12, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTurno", HeaderText = "Turno", DataPropertyName = "turno", FillWeight = 12 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAnio", HeaderText = "Año", DataPropertyName = "anio", FillWeight = 8, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMes", HeaderText = "Mes", DataPropertyName = "mes", FillWeight = 8, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFechaPago", HeaderText = "Fecha de pago", DataPropertyName = "fecha_pago", FillWeight = 16, DefaultCellStyle = { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter } });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMontoPago", HeaderText = "Monto pagado", DataPropertyName = "monto_pago", FillWeight = 12, DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight } });
        }

        private void CargarCombos()
        {
            // Mes
            var ci = new CultureInfo("es-AR");
            var meses = Enumerable.Range(1, 12)
                .Select(m => new
                {
                    Value = m,
                    Text = ci.TextInfo.ToTitleCase(new DateTime(2000, m, 1).ToString("MMMM", ci))
                })
                .ToList();

            // Insertamos “Todos” = 0
            meses.Insert(0, new { Value = 0, Text = "Todos" });

            comboBoxMes.DisplayMember = "Text";
            comboBoxMes.ValueMember = "Value";
            comboBoxMes.DataSource = meses;

            // Año (rango razonable)
            int y = DateTime.Today.Year;
            var anios = Enumerable.Range(y - 6, 8).ToList(); // [y-6, …, y+1]
            anios.Insert(0, 0); // 0 = Todos

            comboBoxAnio.DataSource = anios;
            comboBoxAnio.SelectedItem = y;

            comboBoxMes.SelectedValue = DateTime.Today.Month;
        }

        private void CentrarElementos()
        {
            int ancho = this.Width;

            // Controles en fila: Persona | txt | "Cuota correspondiente..." | Mes | "Año" | Año | Buscar
            int totalFiltros = lblPersona.Width + txtPersona.Width + label2.Width + comboBoxMes.Width +
                               lblAnio.Width + comboBoxAnio.Width + B_BuscarCuotasDni.Width + 80; // márgenes
            int inicio = Math.Max(20, (ancho - totalFiltros) / 2);

            lblPersona.Left = inicio;
            txtPersona.Left = lblPersona.Right + 10;

            label2.Left = txtPersona.Right + 30;
            comboBoxMes.Left = label2.Right + 10;

            lblAnio.Left = comboBoxMes.Right + 30;
            comboBoxAnio.Left = lblAnio.Right + 10;

            B_BuscarCuotasDni.Left = comboBoxAnio.Right + 30;

            // NUEVO: ubicar BLimpiar a la derecha del botón Buscar si existe
            if (BLimpiar != null)
            {
                BLimpiar.Left = B_BuscarCuotasDni.Right + 10;
                BLimpiar.Top = B_BuscarCuotasDni.Top;
            }
        }
        #endregion

        #region Datos
        private DataTable BuscarPagos(string textoPersona, int mes, int anio)
        {
            // 0 = Todos (no filtra)
            string sql = @"
DECLARE @texto nvarchar(100) = @pTexto;
DECLARE @mes   tinyint       = @pMes;   -- 0 = Todos
DECLARE @anio  int           = @pAnio;  -- 0 = Todos

WITH alumnos AS (
    SELECT a.id_alumno, a.nombre, a.dni, t.descripcion AS turno
    FROM dbo.Alumno a
    LEFT JOIN dbo.Turno t ON t.id_turno = a.id_turno
    WHERE
        (@texto = N'')
        OR (CAST(a.dni AS nvarchar(12)) LIKE @texto + N'%' OR a.nombre LIKE N'%' + @texto + N'%')
)
SELECT 
    a.id_alumno,
    a.nombre,
    a.dni,
    a.turno,
    c.anio,
    c.mes,
    p.fecha_pago,
    p.monto AS monto_pago
FROM alumnos a
JOIN dbo.Cuota c ON c.id_alumno = a.id_alumno
JOIN dbo.Pago  p ON p.id_cuota  = c.id_cuota
WHERE
    (@mes  = 0 OR c.mes  = @mes)
    AND (@anio = 0 OR c.anio = @anio)
ORDER BY a.nombre, p.fecha_pago DESC;";

            var tabla = new DataTable();
            using (var cn = new SqlConnection(_cs))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@pTexto", SqlDbType.NVarChar, 100).Value = (textoPersona ?? "").Trim();
                da.SelectCommand.Parameters.Add("@pMes", SqlDbType.TinyInt).Value = (byte)Math.Max(0, mes);
                da.SelectCommand.Parameters.Add("@pAnio", SqlDbType.Int).Value = Math.Max(0, anio);
                da.Fill(tabla);
            }
            return tabla;
        }

        #endregion

        #region Acciones
        private void Buscar()
        {
            string persona = txtPersona?.Text?.Trim() ?? string.Empty;

            int mes = 0;
            if (comboBoxMes.SelectedValue is int m) mes = m;

            int anio = 0;
            if (comboBoxAnio.SelectedItem is int y) anio = y;

            var tabla = BuscarPagos(persona, mes, anio);
            dataGridView_Cuotas.DataSource = tabla;

            // limpia la selección visual luego de cargar
            dataGridView_Cuotas.ClearSelection();
        }

        // =========================
        // NUEVO: Limpiar filtros
        // =========================
        private void BLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFiltros();
            Buscar();                 // recarga toda la lista (sin filtros)
            dataGridView_Cuotas.ClearSelection();
            txtPersona.Focus();
        }

        private void LimpiarFiltros()
        {
            // “cliente cargado por DNI/nombre”: vaciamos el textbox
            if (txtPersona != null) txtPersona.Text = string.Empty;

            // Mes y Año a “Todos” (0)
            if (comboBoxMes != null && comboBoxMes.DataSource != null)
            {
                // si existe el valor 0, seleccionarlo; si no, dejar como está
                if (comboBoxMes.Items.Count > 0)
                {
                    try { comboBoxMes.SelectedValue = 0; } catch { /* ignora si el DS aún no está listo */ }
                }
            }

            if (comboBoxAnio != null && comboBoxAnio.DataSource != null)
            {
                // insertar 0 ya se hizo en CargarCombos; acá seleccionamos 0 si está
                if (comboBoxAnio.Items.Contains(0))
                    comboBoxAnio.SelectedItem = 0;
            }
        }
        #endregion
    }
}
