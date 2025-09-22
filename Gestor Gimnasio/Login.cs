using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;     // ConfigurationManager
using System.Data;
using System.Data.SqlClient;    // SqlConnection, SqlCommand
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            //PARA INGRESAR CON EL BOTON ENTER
            this.AcceptButton = Button_Ingresar;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Button_Ingresar_Click(object sender, EventArgs e)
        {
            string dni = txt_user.Text.Trim();
            string contrasena = txt_contrasena.Text.Trim();

            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debe ingresar DNI y contraseña.");
                return;
            }

            try
            {
                // Obtener la conexión desde App.config (Key: "BaseDatos")
                string conexionString = System.Configuration.ConfigurationManager
                                            .ConnectionStrings["BaseDatos"].ConnectionString;

                using (SqlConnection con = new SqlConnection(conexionString))
                {
                    con.Open();

                    string query = @"SELECT u.id_usuario, u.nombre, u.dni, r.id_rol
                    FROM Usuario u
                    INNER JOIN Rol r ON u.id_rol = r.id_rol
                    WHERE u.dni = @dni AND u.contrasena = @contrasena;";


                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Usar parámetros para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@dni", dni);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idUsuario = Convert.ToInt32(reader["id_usuario"]);
                                string nombre = reader["nombre"].ToString();
                                int idRol = Convert.ToInt32(reader["id_rol"]);  // 👈 acá tomamos el id_rol

                                switch (idRol)
                                {
                                    case 1: // Super Admin
                                        DashboardSuperAdmin superAdmin = new DashboardSuperAdmin();
                                        superAdmin.Show();
                                        this.Hide();
                                        break;

                                    case 2: // Admin
                                        DashboardAdministrador admin = new DashboardAdministrador();
                                        admin.Show();
                                        this.Hide();
                                        break;

                                    case 3: // Dueño
                                        DashboardDueño dueno = new DashboardDueño();
                                        dueno.Show();
                                        this.Hide();
                                        break;

                                    default:
                                        MessageBox.Show("Rol no reconocido en la base de datos.");
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("DNI o contraseña incorrectos.");
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo básico de errores: para debugging y producción lo ideal es loggear.
                MessageBox.Show("Ocurrió un error al intentar iniciar sesión: " + ex.Message);
            }


        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}