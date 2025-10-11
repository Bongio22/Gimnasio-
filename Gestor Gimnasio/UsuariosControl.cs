using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
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
            dataGridView_Usuarios.CellFormatting += dataGridView_Usuarios_CellFormatting;
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

            // ocultas
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId", DataPropertyName = "id_usuario", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIdRol", DataPropertyName = "id_rol", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colContrasena", DataPropertyName = "contrasena", Visible = false });

            // NUEVO: guardo el bit para lógica (oculto) y el texto visible
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEstadoBit", DataPropertyName = "activo", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEstadoTxt", HeaderText = "Estado", DataPropertyName = "EstadoTexto", Width = 90 });

            // visibles
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDni", HeaderText = "DNI", DataPropertyName = "dni" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTelefono", HeaderText = "Teléfono", DataPropertyName = "telefono" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colRol", HeaderText = "Rol", DataPropertyName = "tipo_rol" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDom", HeaderText = "Domicilio", DataPropertyName = "domicilio" });

            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colEditar",
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat,
                Width = 90
            });

            // IMPORTANTE: UseColumnTextForButtonValue = false para poder cambiar el texto por fila
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colAccion",
                HeaderText = "Acción",
                UseColumnTextForButtonValue = false,
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
    ISNULL(u.activo, 1) AS activo,
    r.tipo_rol,
    u.domicilio
FROM dbo.Usuario AS u
LEFT JOIN dbo.Rol AS r ON r.id_rol = u.id_rol
ORDER BY u.nombre;";

            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                var dt = new DataTable();
                da.Fill(dt);

                // NUEVO: mapeo a "Activo" / "Inactivo"
                if (!dt.Columns.Contains("EstadoTexto"))
                    dt.Columns.Add("EstadoTexto", typeof(string));
                foreach (DataRow r in dt.Rows)
                {
                    bool activo = r["activo"] != DBNull.Value && Convert.ToBoolean(r["activo"]);
                    r["EstadoTexto"] = activo ? "Activo" : "Inactivo";
                }

                dataGridView_Usuarios.DataSource = dt;
                dataGridView_Usuarios.Refresh();
            }
        }


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
                return;
            }

            if (col == "colAccion")
            {
                bool activo = false;
                var v = dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value;
                if (v != null && v != DBNull.Value) activo = Convert.ToBoolean(v);

                e.Value = activo ? "Dar de baja" : "Dar de alta";
                e.CellStyle.BackColor = activo ? Color.Red : Color.Green;
                e.CellStyle.ForeColor = Color.White;
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }



        private void dataGridView_Usuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = dataGridView_Usuarios;
            string colName = dgv.Columns[e.ColumnIndex].Name;

            if (colName == "colEditar")
            {
                // 1) Tomar el ID desde la columna oculta "colId"
                object idObj = dgv.Rows[e.RowIndex].Cells["colId"].Value;

                // fallback por si algo raro pasa con el binding
                if (idObj == null || idObj == DBNull.Value)
                {
                    if (dgv.Rows[e.RowIndex].DataBoundItem is DataRowView drv &&
                        drv.Row.Table.Columns.Contains("id_usuario"))
                    {
                        idObj = drv.Row["id_usuario"];
                    }
                }

                if (idObj == null || idObj == DBNull.Value)
                {
                    MessageBox.Show("No se pudo obtener el ID del usuario.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idUsuario = Convert.ToInt32(idObj);

                // 2) Abrir el formulario de edición
                using (var frm = new EditarUsuario(idUsuario))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // 3) Refrescar la grilla después de guardar
                        CargarUsuarios();
                        dgv.ClearSelection();
                        dgv.CurrentCell = null;
                    }
                }
                return;
            }

            if (colName == "colAccion")
            {
                int id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["colId"].Value);
                bool activo = false;
                var v = dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value;
                if (v != null && v != DBNull.Value) activo = Convert.ToBoolean(v);

                string msg = activo ? "¿Seguro que deseas dar de baja este usuario?"
                                    : "¿Seguro que deseas dar de alta este usuario?";

                if (MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CambiarEstadoUsuario(id, !activo);
                    CargarUsuarios();
                    dgv.ClearSelection();
                    dgv.CurrentCell = null;
                }
            }
        }


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
            // Validaciones básicas
          
            string nombre = textBoxNombre.Text.Trim();
            string domicilio = textBoxDomicilio.Text.Trim();
            string pass = (textBoxContrasena.Text ?? string.Empty).Trim();
            string dniTxt = textBoxDni.Text.Trim();
            string telTxt = textBoxTelefono.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(nombre))
            { MessageBox.Show("El nombre es obligatorio."); textBoxNombre.Focus(); return; }
            if (nombre.Length > 50)
            { MessageBox.Show("El nombre no puede superar 50 caracteres."); textBoxNombre.Focus(); return; }

            //  fni (7 u 8 dígitos)
            if (!System.Text.RegularExpressions.Regex.IsMatch(dniTxt, @"^\d{7,8}$"))
            { MessageBox.Show("DNI inválido (debe tener 7 u 8 dígitos)."); textBoxDni.Focus(); return; }
            int dni = int.Parse(dniTxt);

            // teléfono (7 a 15 dígitos)
            if (!System.Text.RegularExpressions.Regex.IsMatch(telTxt, @"^\d{7,15}$"))
            { MessageBox.Show("Teléfono inválido (solo dígitos, 7–15)."); textBoxTelefono.Focus(); return; }
            long telefono = long.Parse(telTxt);

            if (comboBoxTipoRol.SelectedIndex < 0 || comboBoxTipoRol.SelectedValue == null)
            { MessageBox.Show("Seleccione un rol válido."); comboBoxTipoRol.DroppedDown = true; return; }

            if (string.IsNullOrWhiteSpace(pass) || pass.Length < 6)
            { MessageBox.Show("La contraseña es obligatoria."); textBoxContrasena.Focus(); return; }

            if (string.IsNullOrWhiteSpace(domicilio))
            { MessageBox.Show("El domicilio es obligatorio."); textBoxDomicilio.Focus(); return; }
            if (domicilio.Length > 100)
            { MessageBox.Show("El domicilio no puede superar 100 caracteres."); textBoxDomicilio.Focus(); return; }

            // Si llegaste hasta acá, los datos son válidos; sigue con el INSERT…

            // insert
            const string sql = @"
INSERT INTO dbo.Usuario(nombre, telefono, dni, id_rol, contrasena, domicilio)
VALUES(@nombre, @telefono, @dni, @id_rol, @hash, @domicilio); ";


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
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 100).Value = domicilio;

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
        private void CambiarEstadoUsuario(int idUsuario, bool activar)
        {
            const string sql = "UPDATE dbo.Usuario SET activo = @activo WHERE id_usuario = @id;";
            try
            {
                using (var cn = new SqlConnection(CS))
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@activo", SqlDbType.Bit).Value = activar ? 1 : 0;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado del usuario: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }

}

