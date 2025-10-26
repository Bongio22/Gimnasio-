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
    public partial class EstadoCuotasControl : UserControl
    {
        private readonly string _cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public EstadoCuotasControl()
        {
            InitializeComponent();

            // Quitar “Estado”
            label1.Visible = false;
            comboBox2.Visible = false;

            ConfigurarGrid();
            CargarCombos();

            // Eventos
            B_BuscarCuotasDni.Click += (s, e) => Buscar();
            comboBoxMes.SelectedIndexChanged += (s, e) => Buscar();
            comboBoxAnio.SelectedIndexChanged += (s, e) => Buscar();
            txtPersona.TextChanged += (s, e) => Buscar();
            txtPersona.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; Buscar(); } };

            this.Load += (s, e) =>
            {
                CentrarElementos();
                this.Resize += (s2, e2) => CentrarElementos();
            };

            Buscar();
        }

        #region UI
        private void ConfigurarGrid()
        {
            var dgv = dataGridView_Cuotas;

            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.FixedSingle;

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

            // Grilla
            int margenLateral = 150;
            int margenSuperior = 290;
            int margenInferior = 120;

            dataGridView_Cuotas.Width = Math.Max(700, ancho - (margenLateral * 2));
            dataGridView_Cuotas.Left = margenLateral;
            dataGridView_Cuotas.Top = margenSuperior;
            dataGridView_Cuotas.Height = this.Height - margenSuperior - margenInferior;
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
    SELECT a.id_alumno, a.nombre, a.dni, t.descripcion AS turno,
           CASE 
             WHEN COLUMNPROPERTY(OBJECT_ID('dbo.Alumno'),'activo','ColumnId') IS NOT NULL THEN CAST(a.activo AS int)
             WHEN COLUMNPROPERTY(OBJECT_ID('dbo.Alumno'),'estado','ColumnId') IS NOT NULL 
                  THEN CASE WHEN TRY_CAST(a.estado AS int)=1 OR UPPER(LTRIM(RTRIM(CAST(a.estado AS nvarchar(20))))) IN ('A','ACTIVO','TRUE','SI','S') THEN 1 ELSE 0 END
             ELSE 1
           END AS es_activo
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
WHERE a.es_activo = 1
  AND (@mes  = 0 OR c.mes  = @mes)
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
        }
        #endregion
    }
}
