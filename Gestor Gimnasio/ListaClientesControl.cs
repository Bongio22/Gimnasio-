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

                // Ajustes visuales (mismos que usaste)
                lista_Clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                lista_Clientes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                lista_Clientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                lista_Clientes.AllowUserToResizeColumns = false;
                lista_Clientes.AllowUserToResizeRows = false;
                lista_Clientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                lista_Clientes.MultiSelect = false;
                lista_Clientes.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }
    }
}
