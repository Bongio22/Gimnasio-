using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class UsuariosControl : UserControl
    {
        public UsuariosControl()
        {
            InitializeComponent();
            // mascar la contraseña
            textBoxContrasena.UseSystemPasswordChar = true;

            // combos solo selección
            comboBoxTipoRol.DropDownStyle = ComboBoxStyle.DropDownList;

            ListaUsuarios();
            CargarRoles();
            CargarUsuarios();

            dataGridView_Usuarios.CellFormatting += dataGridView_Usuarios_CellFormatting;
            dataGridView_Usuarios.CellContentClick += dataGridView_Usuarios_CellContentClick;
        }

        //
        private void ListaUsuarios()
        {
            var dgv = dataGridView_Usuarios;
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowTemplate.Height = 40;

            // internas ocultas
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "id_usuario", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIdRol", DataPropertyName = "id_rol", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colContrasena", DataPropertyName = "contrasena", Visible = false });

            // visibles
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDni", HeaderText = "DNI", DataPropertyName = "dni" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTelefono", HeaderText = "Teléfono", DataPropertyName = "telefono" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRol", HeaderText = "Rol", DataPropertyName = "tipo_rol" });

            // botones visibles SIN lógica
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colEditar",
                HeaderText = "",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 90
            });
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colAccion",
                HeaderText = "",
                Text = "Dar de baja",
                UseColumnTextForButtonValue = true, // siempre muestra “Dar de baja”
                FlatStyle = FlatStyle.Flat,
                Width = 110
            });
        }

        private void LimpiarFormulario()
        {
            textBoxNombre.Clear();
            textBoxDni.Clear();
            textBoxTelefono.Clear();
            textBoxContrasena.Clear();
            if (comboBoxTipoRol.Items.Count > 0) comboBoxTipoRol.SelectedIndex = 0;
            textBoxNombre.Focus();
        }

        // 
        private string CS => ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

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


        private void CargarUsuarios()
        {
            const string sql = @"
    SELECT 
        u.id_usuario,
        u.nombre,
        u.telefono,
        u.dni,
        u.id_rol,
        r.tipo_rol,
        u.contrasena
    FROM dbo.Usuario u
    LEFT JOIN dbo.Rol r ON r.id_rol = u.id_rol
    ORDER BY u.nombre;";

            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                dataGridView_Usuarios.DataSource = dt;
                dataGridView_Usuarios.Refresh();
            }
        }


        // 


        // 
        private void dataGridView_Usuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = dataGridView_Usuarios;
            string col = dgv.Columns[e.ColumnIndex].Name;

            if (col == "colEditar")
            {
                e.CellStyle.BackColor = Color.RoyalBlue;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
            else if (col == "colAccion")
            {
                e.CellStyle.BackColor = Color.Red;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }


        private void dataGridView_Usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = dataGridView_Usuarios;
            string col = dgv.Columns[e.ColumnIndex].Name;

            if (col == "colEditar" || col == "colAccion")
            {
                // SOLO VISUAL
                return;
            }
        }



        private void CambiarEstadoUsuario(int idUsuario, bool activo)
        {
            const string sql = @"UPDATE dbo.Usuario 
                         SET activo = @activo 
                         WHERE id_usuario = @id;";

            using (var cn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cn.Open();
                cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = activo;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                cmd.ExecuteNonQuery();
            }
        }


        // 
        private static string HashSHA256(string input)
        {
            using (var sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(bytes.Length * 2);
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString(); // 64 chars hex
            }
        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            // --- Validaciones básicas ---
            string nombre = textBoxNombre.Text.Trim();
            string pass = textBoxContrasena.Text; // ya está enmascarada por UI
            if (string.IsNullOrWhiteSpace(nombre))
            { MessageBox.Show("El nombre es obligatorio."); textBoxNombre.Focus(); return; }

            if (!int.TryParse(textBoxDni.Text.Trim(), out var dni) || dni <= 0)
            { MessageBox.Show("DNI inválido."); textBoxDni.Focus(); return; }

            if (!long.TryParse(textBoxTelefono.Text.Trim(), out var telefono) || telefono <= 0)
            { MessageBox.Show("Teléfono inválido."); textBoxTelefono.Focus(); return; }

            if (comboBoxTipoRol.SelectedValue == null || comboBoxTipoRol.SelectedValue == DBNull.Value)
            { MessageBox.Show("Seleccione un rol válido."); comboBoxTipoRol.DroppedDown = true; return; }

            if (string.IsNullOrWhiteSpace(pass))
            { MessageBox.Show("La contraseña es obligatoria."); textBoxContrasena.Focus(); return; }

            // --- Insert ---
            const string sql = @"
  INSERT INTO dbo.Usuario (nombre, telefono, dni, id_rol, contrasena, activo)
  VALUES (@nombre, @telefono, @dni, @id_rol, @hash, 1);";

            try
            {
                using (var cn = new SqlConnection(CS))
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cn.Open();

                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;
                    cmd.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                    cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = (int)comboBoxTipoRol.SelectedValue;
                    cmd.Parameters.Add("@hash", SqlDbType.VarChar, 64).Value = HashSHA256(pass);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Usuario creado correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
                CargarUsuarios(); // refresca la grilla
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // índice único (DNI)
            {
                MessageBox.Show("Ya existe un usuario con ese DNI.", "Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDni.Focus();
                textBoxDni.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear usuario: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

}

