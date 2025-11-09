using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class ReporteCliente : Form
    {
        private string CS => ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public ReporteCliente()
        {
            InitializeComponent();

            ConfigurarGrid();
            CargarTurnos();
            CargarEstadosCuotas();

            B_Buscar.Click -= B_Buscar_Click;
            B_Buscar.Click += B_Buscar_Click;
            ConfigurarDataGridView(dataGridView_Clientes);
        }


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


        private void ConfigurarGrid()
        {
            var dgv = dataGridView_Clientes;

            // ocultas
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIdAlumno", HeaderText = "ID Alumno", DataPropertyName = "id_alumno", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIdCuota", HeaderText = "ID Cuota", DataPropertyName = "id_cuota", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIdTurno", HeaderText = "ID Turno", DataPropertyName = "id_turno", Visible = false });

            // visibles
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDni", HeaderText = "DNI", DataPropertyName = "dni", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTurno", HeaderText = "Turno", DataPropertyName = "turno", Width = 110 });

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAnio", HeaderText = "Año", DataPropertyName = "anio", Width = 60 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMes", HeaderText = "Mes", DataPropertyName = "mes", Width = 60 });

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEstado", HeaderText = "Estado", DataPropertyName = "estado_texto", Width = 90 });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVenc",
                HeaderText = "Vencimiento",
                DataPropertyName = "fecha_vencimiento",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 110
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaPago",
                HeaderText = "Fecha de pago",
                DataPropertyName = "fecha_pago",
                DefaultCellStyle = { Format = "dd/MM/yyyy", NullValue = "—" },
                Width = 110
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMonto",
                HeaderText = "Monto",
                DataPropertyName = "monto",
                DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 90
            });
        }

        private void CargarTurnos()
        {
            cb_turno.DataSource = null;
            cb_turno.Items.Clear();
            cb_turno.DropDownStyle = ComboBoxStyle.DropDownList;

            var dt = new DataTable();
            dt.Columns.Add("id_turno", typeof(int));
            dt.Columns.Add("descripcion", typeof(string));
            dt.Rows.Add(0, "Todos");

            const string sql = @"SELECT id_turno, descripcion FROM dbo.Turno ORDER BY descripcion;";
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                var t = new DataTable();
                da.Fill(t);
                foreach (DataRow r in t.Rows)
                    dt.Rows.Add(Convert.ToInt32(r["id_turno"]), r["descripcion"].ToString());
            }

            cb_turno.DisplayMember = "descripcion";
            cb_turno.ValueMember = "id_turno";
            cb_turno.DataSource = dt;
            cb_turno.SelectedIndex = 0;
        }

        private void CargarEstadosCuotas()
        {
            var dt = new DataTable();
            dt.Columns.Add("valor", typeof(string));
            dt.Columns.Add("texto", typeof(string));
            dt.Rows.Add("AL_DIA", "Al día");
            dt.Rows.Add("VENCIDA", "Vencidas");

            cb_cuotas.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_cuotas.DisplayMember = "texto";
            cb_cuotas.ValueMember = "valor";
            cb_cuotas.DataSource = dt;
            cb_cuotas.SelectedIndex = 0;
        }

        // ================== Buscar ==================
        private void B_Buscar_Click(object sender, EventArgs e)
        {
            if (cb_cuotas.SelectedValue == null || cb_turno.SelectedValue == null)
                return;

            string estado = cb_cuotas.SelectedValue.ToString();      // "AL_DIA" | "VENCIDA"
            int idTurno = Convert.ToInt32(cb_turno.SelectedValue);   // 0 = Todos

            var tabla = ObtenerClientesPorFiltro(estado, idTurno == 0 ? (int?)null : idTurno);
            dataGridView_Clientes.DataSource = tabla;
        }

        private DataTable ObtenerClientesPorFiltro(string estadoCodigo, int? idTurno)
        {
            const string sql = @"
WITH pagos AS (
    SELECT c.id_cuota,
           SUM(p.monto)             AS total_pagado,
           MAX(CAST(p.fecha_pago AS date)) AS fecha_pago
    FROM dbo.Cuota c
    LEFT JOIN dbo.Pago p ON p.id_cuota = c.id_cuota
    GROUP BY c.id_cuota
),
cuotas AS (
    SELECT
        a.id_alumno,
        a.nombre,
        a.dni,
        a.id_turno,
        t.descripcion                  AS turno,
        c.id_cuota,
        c.anio,
        c.mes,
        c.monto,
        c.fecha_vencimiento,
        pg.fecha_pago,
        CASE
            WHEN (c.monto - ISNULL(SUM(p.monto), 0)) <= 0 THEN 'AL_DIA'
            WHEN c.fecha_vencimiento < CONVERT(date, GETDATE()) THEN 'VENCIDA'
            ELSE 'PENDIENTE'
        END AS estado_codigo
    FROM dbo.Cuota c
    JOIN dbo.Alumno a ON a.id_alumno = c.id_alumno
    JOIN dbo.Turno  t ON t.id_turno  = a.id_turno
    LEFT JOIN dbo.Pago p ON p.id_cuota = c.id_cuota
    LEFT JOIN pagos pg ON pg.id_cuota = c.id_cuota
    GROUP BY a.id_alumno, a.nombre, a.dni, a.id_turno, t.descripcion,
             c.id_cuota, c.anio, c.mes, c.monto, c.fecha_vencimiento, pg.fecha_pago
)
SELECT
    id_alumno,
    nombre,
    dni,
    id_turno,
    turno,
    id_cuota,
    anio,
    mes,
    monto,
    fecha_vencimiento,
    fecha_pago,
    CASE estado_codigo 
        WHEN 'AL_DIA'  THEN N'Al día'
        WHEN 'VENCIDA' THEN N'Vencida'
        ELSE N'Pendiente'
    END AS estado_texto
FROM cuotas
WHERE estado_codigo = @estado
  AND (@id_turno IS NULL OR id_turno = @id_turno)
ORDER BY nombre, anio DESC, mes DESC;";

            var dt = new DataTable();
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@estado", SqlDbType.VarChar, 20).Value = estadoCodigo;
                if (idTurno.HasValue)
                    da.SelectCommand.Parameters.Add("@id_turno", SqlDbType.Int).Value = idTurno.Value;
                else
                    da.SelectCommand.Parameters.Add("@id_turno", SqlDbType.Int).Value = DBNull.Value;

                da.Fill(dt);
            }
            return dt;
        }
    }
}
