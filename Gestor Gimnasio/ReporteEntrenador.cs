using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class ReporteEntrenador : Form
    {
        // Cadena de conexión para este form
        private string CS => ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public ReporteEntrenador()
        {
            InitializeComponent();

            ConfigurarGrid();
            CargarEntrenadoresActivos();

            
            B_Buscar.Click -= B_Buscar_Click;
            B_Buscar.Click += B_Buscar_Click;

            ConfigurarDataGridView(dataGridView_Entrenadores);

        }

        // ================== UI: Grilla ==================
        private void ConfigurarGrid()
        {
            var dgv = dataGridView_Entrenadores;

            // IDs ocultos
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdAlumno",
                HeaderText = "ID Alumno",
                DataPropertyName = "id_alumno",
                Visible = false
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdTurno",
                HeaderText = "ID Turno",
                DataPropertyName = "id_turno",
                Visible = false
            });

            // Visibles
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "dni",
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTurno",
                HeaderText = "Turno",
                DataPropertyName = "turno"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaAlta",
                HeaderText = "Fecha de alta",
                DataPropertyName = "fecha_alta",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 120
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado alumno",
                DataPropertyName = "estado_alumno",
                Width = 110
            });
        }

        // ================== Combo: entrenadores activos ==================
        private void CargarEntrenadoresActivos()
        {
            // Limpiar por si el diseñador dejó algo
            cb_nombre_entrenador.DataSource = null;
            cb_nombre_entrenador.Items.Clear();
            cb_nombre_entrenador.Enabled = true;
            cb_nombre_entrenador.DropDownStyle = ComboBoxStyle.DropDownList;

            const string sql = @"
SELECT e.id_entrenador, e.nombre
FROM dbo.Entrenador e
WHERE e.estado = 1
ORDER BY e.nombre;";

            var dt = new DataTable();
            try
            {
                using (var cn = new SqlConnection(CS))
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No pude cargar los entrenadores.\n" + ex.Message,
                                "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dt.Rows.Count == 0)
            {
                cb_nombre_entrenador.Items.Add("— No hay entrenadores activos —");
                cb_nombre_entrenador.SelectedIndex = 0;
                cb_nombre_entrenador.Enabled = false;
                return;
            }

            cb_nombre_entrenador.DisplayMember = "nombre";
            cb_nombre_entrenador.ValueMember = "id_entrenador";
            cb_nombre_entrenador.DataSource = dt;
            cb_nombre_entrenador.SelectedIndex = 0;
        }

        // ================== Click Buscar ==================
        private void B_Buscar_Click(object sender, EventArgs e)
        {
            if (!cb_nombre_entrenador.Enabled || cb_nombre_entrenador.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná un entrenador activo.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idEntrenador = Convert.ToInt32(cb_nombre_entrenador.SelectedValue);

            var tabla = ObtenerAlumnosPorEntrenador_ViaTurnos(idEntrenador);
            dataGridView_Entrenadores.DataSource = tabla;

           
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
        private DataTable ObtenerAlumnosPorEntrenador_ViaTurnos(int idEntrenador)
        {
            const string sql = @"
SELECT
    a.id_alumno,
    a.nombre,
    a.dni,
    a.id_turno,
    t.descripcion AS turno,
    a.fecha_alta,
    CASE WHEN a.activo = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado_alumno
FROM dbo.Alumno a
JOIN dbo.Turno t              ON t.id_turno = a.id_turno
JOIN dbo.Turno_Entrenador te  ON te.id_turno = a.id_turno
JOIN dbo.Entrenador e         ON e.id_entrenador = te.id_entrenador
WHERE e.id_entrenador = @id_entrenador
  AND e.estado = 1     -- solo entrenadores activos
ORDER BY a.nombre;";

            var dt = new DataTable();
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@id_entrenador", SqlDbType.Int).Value = idEntrenador;
                da.Fill(dt);
            }
            return dt;
        }
    }
}
