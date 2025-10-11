using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;     // ConfigurationManager
using System.Data;
using System.Data.SqlClient;    // SqlConnection, SqlCommand
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            txt_contrasena.UseSystemPasswordChar = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private static string HashSHA256(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(bytes.Length * 2);
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString(); // 64 chars hex
            }
        }

        private void Button_Ingresar_Click(object sender, EventArgs e)
        {
            string dniTxt = txt_user.Text.Trim();
            string passTxt = txt_contrasena.Text;

            if (string.IsNullOrWhiteSpace(dniTxt) || string.IsNullOrWhiteSpace(passTxt))
            {
                MessageBox.Show("Debe ingresar DNI y contraseña.");
                return;
            }
            if (!int.TryParse(dniTxt, out int dni))
            {
                MessageBox.Show("DNI inválido.");
                return;
            }

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

                const string sql = @"
SELECT TOP 1 u.id_usuario, u.nombre, u.dni, u.id_rol
FROM dbo.Usuario AS u
WHERE u.dni = @dni
  AND u.contrasena = @hash
  AND u.activo = 1;";

                using (var con = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                    cmd.Parameters.Add("@hash", SqlDbType.VarChar, 64).Value = HashSHA256(passTxt);

                    con.Open();
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            int idUsuario = (int)rd["id_usuario"];
                            int idRol = (int)rd["id_rol"];

                            // Redirección según rol
                            switch (idRol)
                            {
                                case 1:
                                    new DashboardDueño().Show(); break;
                                case 2:
                                    new DashboardSuperAdmin().Show(); break;
                                case 3:
                                    new DashboardAdministrador().Show(); break;
                                default:
                                    MessageBox.Show("Rol no reconocido."); return;
                            }
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("DNI o contraseña incorrectos, o usuario inactivo.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar iniciar sesión: " + ex.Message);
            }
        }


        private void BCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y teclas de control (ej: Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void txt_contrasena_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}