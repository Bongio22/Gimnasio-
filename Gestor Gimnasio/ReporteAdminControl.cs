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

        // Cache y filtro en memoria
        private DataTable _dtAlumnos;
        private readonly BindingSource _bs = new BindingSource();

        public ReporteAdminControl()
        {
            InitializeComponent();

            this.Load += ReporteAdminControl_Load;
            ConfigurarDataGridView(dgv_lista_alumnos);

            // Buscar
            if (BBuscar != null) BBuscar.Click += (s, e) => BuscarEnGridPorDni();
            if (textBoxdni != null) textBoxdni.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    BuscarEnGridPorDni();
                }
            };

            // ✨ LIMPIAR
            if (BLimpiar != null) BLimpiar.Click += (s, e) => LimpiarBusqueda();
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

                    _dtAlumnos = new DataTable();
                    da.Fill(_dtAlumnos);

                    _bs.DataSource = _dtAlumnos;
                    dgv_lista_alumnos.DataSource = _bs;

                    Estilos_Grid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        // =================== BÚSQUEDA POR DNI ===================
        private void BuscarEnGridPorDni()
        {
            if (_dtAlumnos == null || _dtAlumnos.Rows.Count == 0)
                return;

            var q = (textBoxdni == null ? "" : textBoxdni.Text).Trim();

            // Vacío → mostrar todo
            if (string.IsNullOrEmpty(q))
            {
                MostrarTodos();
                return;
            }

            // Solo números
            for (int i = 0; i < q.Length; i++)
            {
                if (!char.IsDigit(q[i]))
                {
                    MessageBox.Show("Ingresá solo números para buscar por DNI.", "Dato inválido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxdni?.Focus();
                    return;
                }
            }

            // 7+ dígitos = exacto; menos = prefijo
            string filtro = (q.Length >= 7)
                ? $"Convert(dni, 'System.String') = '{q}'"
                : $"Convert(dni, 'System.String') LIKE '{q}%'";

            try
            {
                _bs.RemoveFilter();
                _bs.Filter = filtro;

                if (_bs.Count == 0)
                {
                    MessageBox.Show("No se encontraron alumnos con ese DNI.", "Sin resultados",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarTodos();
                    textBoxdni?.SelectAll();
                }
                else
                {
                    dgv_lista_alumnos.ClearSelection();
                    dgv_lista_alumnos.CurrentCell = null;
                }
            }
            catch
            {
                MostrarTodos();
            }
        }

        private void MostrarTodos()
        {
            _bs.RemoveFilter();
            dgv_lista_alumnos.ClearSelection();
            dgv_lista_alumnos.CurrentCell = null;
        }
        // ========================================================

        // 🧹 Limpia textbox, quita filtro y deja foco para nueva búsqueda
        private void LimpiarBusqueda()
        {
            try
            {
                textBoxdni?.Clear();
                _bs.RemoveFilter();

                if (dgv_lista_alumnos.DataSource != _bs)
                    dgv_lista_alumnos.DataSource = _bs;

                dgv_lista_alumnos.ClearSelection();
                dgv_lista_alumnos.CurrentCell = null;

                textBoxdni?.Focus();
            }
            catch
            {
                // evitamos romper la UI por detalles visuales
            }
        }

        private void Estilos_Grid()
        {
            var dgv = dgv_lista_alumnos;

            dgv.RowHeadersVisible = false;

            if (dgv.Columns.Contains("id_alumno"))
                dgv.Columns["id_alumno"].Visible = false;

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

        private void ReporteAdminControl_Load_1(object sender, EventArgs e)
        {
        }
    }
}
