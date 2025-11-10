using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class ListaEntrenadoresControl : UserControl
    {
        // Cache de datos y binding para filtrar sin reconsultar SQL
        private DataTable _dtEntrenadores;
        private readonly BindingSource _bs = new BindingSource();

        public ListaEntrenadoresControl()
        {
            InitializeComponent();
            ConfigurarDataGridView(lista_Entrenadores);

            // Cargar al iniciar
            this.Load += ListaEntrenadores_Load;

            // Buscar por botón
            if (BBuscar != null) BBuscar.Click += (s, e) => BuscarPorDni();

            // Enter en el textbox también busca
            if (textBoxdni != null)
            {
                textBoxdni.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        e.SuppressKeyPress = true;
                        BuscarPorDni();
                    }
                };
            }

            // Limpiar filtro y restaurar lista completa
            if (BLimpiar != null) BLimpiar.Click += (s, e) => LimpiarBusqueda();
        }

        private void ListaEntrenadores_Load(object sender, EventArgs e)
        {
            CargarEntrenadores(); // llena _dtEntrenadores
            // Enlazar solo una vez
            _bs.DataSource = _dtEntrenadores;
            lista_Entrenadores.DataSource = _bs;
            AplicarEncabezados();
        }

        // ====== MÉTODO PÚBLICO ORIGINAL (con pequeñas mejoras para cachear) ======
        public void CargarEntrenadores()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                string sql = @"
                    SELECT e.id_entrenador, e.nombre, e.dni, e.telefono, e.domicilio, e.cupo, e.estado,
                           t.descripcion AS Turno
                    FROM Entrenador e
                    LEFT JOIN Turno_Entrenador te ON e.id_entrenador = te.id_entrenador
                    LEFT JOIN Turno t ON te.id_turno = t.id_turno
                    ORDER BY e.nombre;
                ";

                var dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(cs))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    da.Fill(dt);
                }

                // Columna de texto para estado si no existe
                if (!dt.Columns.Contains("EstadoTexto"))
                    dt.Columns.Add("EstadoTexto", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool activo = Convert.ToBoolean(row["estado"]);
                    row["EstadoTexto"] = activo ? "Activo" : "Inactivo";
                }

                // Guardamos en cache
                _dtEntrenadores = dt;

                // Si ya está enlazado, sólo actualizamos el DataSource del BindingSource
                if (lista_Entrenadores.DataSource is BindingSource)
                {
                    _bs.DataSource = _dtEntrenadores;
                }
                else
                {
                    lista_Entrenadores.DataSource = null;
                    lista_Entrenadores.Rows.Clear();
                    lista_Entrenadores.Columns.Clear();
                    lista_Entrenadores.DataSource = _dtEntrenadores;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar entrenadores: " + ex.Message);
            }
        }

        // Aplica encabezados/visibilidades (separado para reusar)
        private void AplicarEncabezados()
        {
            if (lista_Entrenadores.Columns.Contains("id_entrenador"))
                lista_Entrenadores.Columns["id_entrenador"].HeaderText = "ID";
            if (lista_Entrenadores.Columns.Contains("nombre"))
                lista_Entrenadores.Columns["nombre"].HeaderText = "NOMBRE";
            if (lista_Entrenadores.Columns.Contains("dni"))
                lista_Entrenadores.Columns["dni"].HeaderText = "DNI";
            if (lista_Entrenadores.Columns.Contains("telefono"))
                lista_Entrenadores.Columns["telefono"].HeaderText = "TELÉFONO";
            if (lista_Entrenadores.Columns.Contains("domicilio"))
                lista_Entrenadores.Columns["domicilio"].HeaderText = "DOMICILIO";
            if (lista_Entrenadores.Columns.Contains("cupo"))
                lista_Entrenadores.Columns["cupo"].HeaderText = "CUPO";
            if (lista_Entrenadores.Columns.Contains("EstadoTexto"))
                lista_Entrenadores.Columns["EstadoTexto"].HeaderText = "ESTADO";
            if (lista_Entrenadores.Columns.Contains("Turno"))
                lista_Entrenadores.Columns["Turno"].HeaderText = "TURNO";

            if (lista_Entrenadores.Columns.Contains("estado"))
                lista_Entrenadores.Columns["estado"].Visible = false;

            // sin selección inicial
            lista_Entrenadores.ClearSelection();
        }

        // ----------- FILTRO POR DNI -----------
        private void BuscarPorDni()
        {
            string dniTxt = (textBoxdni?.Text ?? "").Trim();

            if (string.IsNullOrEmpty(dniTxt))
            {
                MessageBox.Show("Ingresá un DNI para buscar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validación numérica simple
            foreach (char c in dniTxt)
            {
                if (!char.IsDigit(c))
                {
                    MessageBox.Show("El DNI debe ser numérico.", "Dato inválido",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxdni.Focus();
                    return;
                }
            }

            // Filtro exacto por columna 'dni' (numérica) -> Convert a string
            _bs.RemoveFilter();
            _bs.Filter = $"Convert(dni, 'System.String') = '{dniTxt}'";

            if (_bs.Count == 0)
            {
                MessageBox.Show("No se encontró un entrenador con ese DNI.", "Sin coincidencias",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Quita selección visual inicial
                lista_Entrenadores.ClearSelection();
                if (lista_Entrenadores.Rows.Count > 0)
                {
                    lista_Entrenadores.CurrentCell = null;
                }
            }
        }

        // ----------- LIMPIAR Y RESTAURAR LISTA -----------
        private void LimpiarBusqueda()
        {
            _bs.RemoveFilter();
            textBoxdni?.Clear();

            // Limpia selección visual
            if (lista_Entrenadores.Rows.Count > 0)
            {
                lista_Entrenadores.ClearSelection();
                lista_Entrenadores.CurrentCell = null;
            }

            textBoxdni?.Focus();
        }

        // =================== TU ESTILO DE GRID (SIN CAMBIOS) ===================
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

            // --- Hover suave ---
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

            // --- Doble buffer ---
            try
            {
                typeof(DataGridView)
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(dgv, true, null);
            }
            catch { }
        }
    }
}
