using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class EditarUsuario : Form
    {
        private readonly int _idUsuario;
        private string CS => ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public EditarUsuario(int idUsuario)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            this.Load += EditarUsuario_Load;
            BGuardar_Edit.Click += btnGuardar_Click;
            BCancelar_Edit.Click += btnCancelar_Click;
        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {
            // Controles no editables
            textBoxDNI.ReadOnly = true;
            textBoxDNI.TabStop = false;

            textBoxContrasena.ReadOnly = true;
            textBoxContrasena.UseSystemPasswordChar = true;
            textBoxContrasena.TabStop = false;

            comboBoxTipoRol.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarRoles();
            CargarDatos();
        }

        private void CargarRoles()
        {
            const string sql = @"SELECT id_rol, tipo_rol FROM dbo.Rol ORDER BY tipo_rol;";
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                comboBoxTipoRol.DataSource = dt;
                comboBoxTipoRol.DisplayMember = "tipo_rol";
                comboBoxTipoRol.ValueMember = "id_rol";
            }
        }

        private void CargarDatos()
        {
            const string sql = @"
SELECT u.id_usuario, u.nombre, u.telefono, u.dni, u.id_rol, u.domicilio, u.contrasena
FROM dbo.Usuario u
WHERE u.id_usuario = @id;";

            using (var cn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = _idUsuario;
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        textBoxNombre.Text = dr["nombre"]?.ToString() ?? "";
                        textBoxDNI.Text = dr["dni"]?.ToString() ?? "";
                        textBoxTelefono.Text = dr["telefono"]?.ToString() ?? "";
                        textBoxDomicilio.Text = dr["domicilio"]?.ToString() ?? "";
                        textBoxContrasena.Text = dr["contrasena"]?.ToString() ?? ""; // solo mostrar enmascarado

                        if (dr["id_rol"] != DBNull.Value)
                            comboBoxTipoRol.SelectedValue = Convert.ToInt32(dr["id_rol"]);
                        else
                            comboBoxTipoRol.SelectedIndex = -1;
                    }
                }
            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // === VALIDACIONES ===
            string nombre = textBoxNombre.Text.Trim();
            string domicilio = textBoxDomicilio.Text.Trim();
            string dniTxt = textBoxDNI.Text.Trim();
            string telTxt = textBoxTelefono.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            { MessageBox.Show("El nombre es obligatorio."); textBoxNombre.Focus(); return; }
            if (nombre.Length > 50)
            { MessageBox.Show("El nombre no puede superar 50 caracteres."); textBoxNombre.Focus(); return; }

            // DNI: se muestra pero NO se edita, igual validamos que sea numérico
            if (!Regex.IsMatch(dniTxt, @"^\d{7,8}$"))
            { MessageBox.Show("DNI inválido (7 u 8 dígitos)."); return; }

            // Teléfono: 7 a 15 dígitos (BIGINT)
            if (!Regex.IsMatch(telTxt, @"^\d{7,15}$"))
            { MessageBox.Show("Teléfono inválido (solo dígitos, 7–15)."); textBoxTelefono.Focus(); return; }
            long telefono = long.Parse(telTxt);

            if (comboBoxTipoRol.SelectedIndex < 0 || comboBoxTipoRol.SelectedValue == null)
            { MessageBox.Show("Seleccione un rol válido."); comboBoxTipoRol.DroppedDown = true; return; }

            if (string.IsNullOrWhiteSpace(domicilio))
            { MessageBox.Show("El domicilio es obligatorio."); textBoxDomicilio.Focus(); return; }
            if (domicilio.Length > 100)
            { MessageBox.Show("El domicilio no puede superar 100 caracteres."); textBoxDomicilio.Focus(); return; }

           
            

            const string sql = @"
UPDATE dbo.Usuario
SET nombre    = @nombre,
    telefono  = @telefono,
    id_rol    = @id_rol,
    domicilio = @domicilio
WHERE id_usuario = @id;";   // <-- SIN activo

            try
            {
                using (var cn = new SqlConnection(CS))
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = textBoxNombre.Text.Trim();
                    cmd.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
                    cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = (int)comboBoxTipoRol.SelectedValue;
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 100).Value = textBoxDomicilio.Text.Trim();
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = _idUsuario;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario actualizado correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    

    }
}
