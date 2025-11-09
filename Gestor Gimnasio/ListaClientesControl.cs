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
        public ListaClientesControl()
        {
            InitializeComponent();
            ConfigurarDataGridView(lista_Clientes);
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
            LEFT JOIN Turno t      ON a.id_turno = t.id_turno
            ORDER BY a.nombre;
        ";

                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(cs))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    da.Fill(dt);
                }

                // Agrego columna de estado en texto (Activo/Inactivo)
                if (!dt.Columns.Contains("EstadoTexto"))
                    dt.Columns.Add("EstadoTexto", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    bool activo = row["estado"] != DBNull.Value && Convert.ToBoolean(row["estado"]);
                    row["EstadoTexto"] = activo ? "Activo" : "Inactivo";
                }

                // Bind al grid
                lista_Clientes.DataSource = null;
                lista_Clientes.Rows.Clear();
                lista_Clientes.Columns.Clear();
                lista_Clientes.DataSource = dt;

                // Encabezados
                lista_Clientes.Columns["id_alumno"].HeaderText = "ID";
                lista_Clientes.Columns["nombre"].HeaderText = "NOMBRE";
                lista_Clientes.Columns["dni"].HeaderText = "DNI";
                lista_Clientes.Columns["telefono"].HeaderText = "TELÉFONO";
                lista_Clientes.Columns["domicilio"].HeaderText = "DOMICILIO";
                lista_Clientes.Columns["EstadoTexto"].HeaderText = "ESTADO";
                lista_Clientes.Columns["Turno"].HeaderText = "TURNO";

                // Oculto columnas internas
                if (lista_Clientes.Columns.Contains("estado"))
                    lista_Clientes.Columns["estado"].Visible = false;
                if (lista_Clientes.Columns.Contains("id_turno"))
                    lista_Clientes.Columns["id_turno"].Visible = false;

         
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }


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
