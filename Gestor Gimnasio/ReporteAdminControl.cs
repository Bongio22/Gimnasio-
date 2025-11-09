using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class ReporteAdminControl : UserControl
    {
        private readonly string _cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public ReporteAdminControl()
        {
            InitializeComponent();
            this.Load += ReporteAdminControl_Load;
            ConfigurarDataGridView(dgv_lista_alumnos);
        }

        private void ReporteAdminControl_Load(object sender, EventArgs e)
        {
            if (!UserSession.IsLogged || UserSession.Rol != RolSistema.Administrador)
            {
                MessageBox.Show("Solo administradores pueden ver este reporte.");
                return;
            }

            CargarClientesDelAdmin(UserSession.IdUsuario);
        }

        private void CargarClientesDelAdmin(int adminId)
        {
            // 👉 Ya devuelvo el estado en texto desde SQL
            const string sql = @"
SELECT 
    a.id_alumno,
    a.nombre,
    a.dni,
    a.telefono,
    a.domicilio,
    a.correo,
    a.fecha_nac,
    CASE WHEN a.estado = 1 THEN 'Activo' ELSE 'Inactivo' END AS estado_texto,
    t.descripcion AS turno
FROM dbo.Alumno a
LEFT JOIN dbo.Turno t ON t.id_turno = a.id_turno
WHERE a.creado_por = @adminId
ORDER BY a.nombre;";

            try
            {
                using (var cn = new SqlConnection(_cs))
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.SelectCommand.Parameters.Add("@adminId", SqlDbType.Int).Value = adminId;
                    var dt = new DataTable();
                    da.Fill(dt);

                    dgv_lista_alumnos.DataSource = dt;
                    Estilos_Grid();   // (acentos en nombres de métodos pueden fallar en algunos entornos)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void Estilos_Grid()
        {
            var dgv = dgv_lista_alumnos;

            // Ocultar columna “vacía” de la izquierda
            dgv.RowHeadersVisible = false;

           
            // Ocultar ID si existe
            if (dgv.Columns.Contains("id_alumno"))
                dgv.Columns["id_alumno"].Visible = false;

            // Asegurar encabezado amigable para el estado
            if (dgv.Columns.Contains("estado_texto"))
                dgv.Columns["estado_texto"].HeaderText = "Estado";


            dgv.ClearSelection();
            
            dgv.CurrentCell = null;
        }


        private void dgv_lista_alumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_lista_alumnos.ClearSelection();
            dgv_lista_alumnos.CurrentCell = null;

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

        private void ReporteAdminControl_Load_1(object sender, EventArgs e)
        {

        }
    }
}
