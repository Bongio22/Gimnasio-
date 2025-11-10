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
    public partial class ListaClientesControl : UserControl
    {
        // Cache + binding para filtrar en memoria
        private DataTable _dtClientes;
        private readonly BindingSource _bs = new BindingSource();

        public ListaClientesControl()
        {
            InitializeComponent();
            ConfigurarDataGridView(lista_Clientes);

            // Cargar al iniciar
            this.Load += (s, e) =>
            {
                CargarClientes();
                // Enlazo sólo una vez
                _bs.DataSource = _dtClientes;
                lista_Clientes.DataSource = _bs;
                AplicarEncabezados();
            };

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

        public void CargarClientes()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                string sql = @"
                    SELECT 
                        a.id_alumno,
                        a.nombre,
                        a.dni,
                        a.telefono,
                        a.domicilio,
                        a.estado,          -- BIT
                        a.id_turno,        -- FK (puede ocultarse)
                        t.descripcion AS Turno
                    FROM Alumno a
                    LEFT JOIN Turno t ON a.id_turno = t.id_turno
                    ORDER BY a.nombre;
                ";

                var dt = new DataTable();
                using (var cn = new SqlConnection(cs))
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.Fill(dt);
                }

                // Columna Estado en texto
                if (!dt.Columns.Contains("EstadoTexto"))
                    dt.Columns.Add("EstadoTexto", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool activo = row["estado"] != DBNull.Value && Convert.ToBoolean(row["estado"]);
                    row["EstadoTexto"] = activo ? "Activo" : "Inactivo";
                }

                // Guardamos en cache
                _dtClientes = dt;

                // Si ya estaba enlazado, solo refrescamos el BindingSource
                if (lista_Clientes.DataSource is BindingSource)
                    _bs.DataSource = _dtClientes;
                else
                {
                    lista_Clientes.DataSource = null;
                    lista_Clientes.Rows.Clear();
                    lista_Clientes.Columns.Clear();
                    lista_Clientes.DataSource = _dtClientes;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        // Encabezados/visibilidades separados para reusar
        private void AplicarEncabezados()
        {
            if (lista_Clientes.Columns.Contains("id_alumno"))
                lista_Clientes.Columns["id_alumno"].HeaderText = "ID";
            if (lista_Clientes.Columns.Contains("nombre"))
                lista_Clientes.Columns["nombre"].HeaderText = "NOMBRE";
            if (lista_Clientes.Columns.Contains("dni"))
                lista_Clientes.Columns["dni"].HeaderText = "DNI";
            if (lista_Clientes.Columns.Contains("telefono"))
                lista_Clientes.Columns["telefono"].HeaderText = "TELÉFONO";
            if (lista_Clientes.Columns.Contains("domicilio"))
                lista_Clientes.Columns["domicilio"].HeaderText = "DOMICILIO";
            if (lista_Clientes.Columns.Contains("EstadoTexto"))
                lista_Clientes.Columns["EstadoTexto"].HeaderText = "ESTADO";
            if (lista_Clientes.Columns.Contains("Turno"))
                lista_Clientes.Columns["Turno"].HeaderText = "TURNO";

            if (lista_Clientes.Columns.Contains("estado"))
                lista_Clientes.Columns["estado"].Visible = false;
            if (lista_Clientes.Columns.Contains("id_turno"))
                lista_Clientes.Columns["id_turno"].Visible = false;

            lista_Clientes.ClearSelection();
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

            // Filtro exacto por 'dni' (numérica -> Convert a string)
            _bs.RemoveFilter();
            _bs.Filter = $"Convert(dni, 'System.String') = '{dniTxt}'";

            if (_bs.Count == 0)
            {
                MessageBox.Show("No se encontró un cliente con ese DNI.", "Sin coincidencias",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lista_Clientes.ClearSelection();
                lista_Clientes.CurrentCell = null;
            }
        }

        // ----------- LIMPIAR Y RESTAURAR LISTA -----------
        private void LimpiarBusqueda()
        {
            _bs.RemoveFilter();
            textBoxdni?.Clear();

            if (lista_Clientes.Rows.Count > 0)
            {
                lista_Clientes.ClearSelection();
                lista_Clientes.CurrentCell = null;
            }

            textBoxdni?.Focus();
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
    }
}
