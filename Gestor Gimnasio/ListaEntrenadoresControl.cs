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
        public ListaEntrenadoresControl()
        {
            InitializeComponent();
            
        }
        // metodo público para cargar los entrenadores
        public void CargarEntrenadores()
        {
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                string sql = @"SELECT e.id_entrenador, e.nombre, e.dni, e.telefono, e.domicilio, e.cupo, e.estado,
                           t.descripcion AS Turno
                    FROM Entrenador e
                    LEFT JOIN Turno_Entrenador te ON e.id_entrenador = te.id_entrenador
                    LEFT JOIN Turno t ON te.id_turno = t.id_turno
                    ORDER BY e.nombre;
                ";

                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(cs))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, cn))
                {
                    da.Fill(dt);
                }

                // columna para estado
                //recorre y convierte los estados que eran bool en texto
                if (!dt.Columns.Contains("EstadoTexto"))
                    dt.Columns.Add("EstadoTexto", typeof(string));


                foreach (DataRow row in dt.Rows)
                {
                    bool activo = Convert.ToBoolean(row["estado"]);
                    row["EstadoTexto"] = activo ? "Activo" : "Inactivo";
                }

                // limpia y muestra los datos
                lista_Entrenadores.DataSource = null;
                lista_Entrenadores.Rows.Clear();
                lista_Entrenadores.Columns.Clear();
                lista_Entrenadores.DataSource = dt;

                // encabezados
                lista_Entrenadores.Columns["id_entrenador"].HeaderText = "ID";
                lista_Entrenadores.Columns["nombre"].HeaderText = "NOMBRE";
                lista_Entrenadores.Columns["dni"].HeaderText = "DNI";
                lista_Entrenadores.Columns["telefono"].HeaderText = "TELÉFONO";
                lista_Entrenadores.Columns["domicilio"].HeaderText = "DOMICILIO";
                lista_Entrenadores.Columns["cupo"].HeaderText = "CUPO";
                lista_Entrenadores.Columns["EstadoTexto"].HeaderText = "ESTADO";
                lista_Entrenadores.Columns["Turno"].HeaderText = "TURNO";

                // oculta columna BIT original
                lista_Entrenadores.Columns["estado"].Visible = false;

                // ajusta las columnas automaticamente al contenido
                lista_Entrenadores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // centra el contenido de las celdas
                lista_Entrenadores.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // centra encabezado
                lista_Entrenadores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //evita redimensionar el tamaño de filas y columnas
                lista_Entrenadores.AllowUserToResizeColumns = false;
                lista_Entrenadores.AllowUserToResizeRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar entrenadores: " + ex.Message);
            }
        }


        private void ListaEntrenadores_Load(object sender, EventArgs e)
        {
            CargarEntrenadores();
        }

    }
}
