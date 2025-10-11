using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;   // ConfigurationManager
using System.Data.SqlClient;  // SqlConnection, SqlCommand, SqlDataAdapter

namespace Gestor_Gimnasio
{
    public partial class ClienteAgregarControl : UserControl
    {
        public ClienteAgregarControl()
        {
            InitializeComponent();
            Agregar_ListaClientes();
            CargarListaClientes();
            comboBoxTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProfesor.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ClienteAgregarControl_Load(object sender, EventArgs e)
        {
 
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            // consulta para obtener los turnos disponibles
            const string sqlTurnos = @"SELECT id_turno, descripcion FROM dbo.Turno ORDER BY descripcion;";

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var da = new SqlDataAdapter(sqlTurnos, cn))
                {
                    var tablaTurnos = new DataTable();
                    da.Fill(tablaTurnos);

                    if (tablaTurnos.Rows.Count > 0)
                    {
                        comboBoxTurno.Enabled = true;
                        comboBoxTurno.DataSource = tablaTurnos;
                        comboBoxTurno.DisplayMember = "descripcion";  // lo que se ve 
                        comboBoxTurno.ValueMember = "id_turno";       // el ID real
                        comboBoxTurno.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxTurno.DataSource = null;
                        comboBoxTurno.Items.Clear();
                        comboBoxTurno.Items.Add("No existen turnos");
                        comboBoxTurno.SelectedIndex = 0;
                        comboBoxTurno.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // en caso de error, deshabilitar controles
                comboBoxTurno.DataSource = null;
                comboBoxTurno.Items.Clear();
                comboBoxTurno.Items.Add("Error al cargar turnos");
                comboBoxTurno.SelectedIndex = 0;
                comboBoxTurno.Enabled = false;
            }

            // deshabilitamos profesores hasta que se elija un turno
            comboBoxProfesor.DataSource = null;
            comboBoxProfesor.Items.Clear();
            comboBoxProfesor.Items.Add("Seleccioná un turno primero");
            comboBoxProfesor.SelectedIndex = 0;
            comboBoxProfesor.Enabled = false;

            // fechas
            dtpFechaAlta.Value = DateTime.Today;

            // Configurar dtp de nacimiento (asegurate que el control exista con ese nombre)
            dtpFecha_nac.Format = DateTimePickerFormat.Short;
            dtpFecha_nac.MaxDate = DateTime.Today;
            dtpFecha_nac.MinDate = new DateTime(1900, 1, 1);
            dtpFecha_nac.ShowCheckBox = true;   // si se destilda => NULL

            // evento del Turno (por si el diseñador no lo enganchó)
            comboBoxTurno.SelectedIndexChanged -= comboBoxTurno_SelectedIndexChanged;
            comboBoxTurno.SelectedIndexChanged += comboBoxTurno_SelectedIndexChanged;

            // que NO quede turno “forzado”
            comboBoxTurno.SelectedIndex = -1;
            comboBoxTurno.Text = "Seleccioná un turno";

           
        }

        //el disable de los entrenadores correspomdientes al turno elegido
        private void comboBoxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!comboBoxTurno.Enabled || comboBoxTurno.SelectedValue == null) return;
            if (!(comboBoxTurno.SelectedValue is int) && !int.TryParse(comboBoxTurno.SelectedValue.ToString(), out _)) return;

            int idTurno = Convert.ToInt32(comboBoxTurno.SelectedValue);
            CargarProfesoresPorTurno(idTurno);
        }

        private void CargarProfesoresPorTurno(int idTurno)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            const string sqlProfes = @"
        SELECT DISTINCT e.id_entrenador, e.nombre
        FROM dbo.Turno_Entrenador te
        INNER JOIN dbo.Entrenador e ON e.id_entrenador = te.id_entrenador
        WHERE te.id_turno = @id_turno AND e.estado = 1
        ORDER BY e.nombre;";

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var da = new SqlDataAdapter(sqlProfes, cn))
                {
                    da.SelectCommand.Parameters.Add("@id_turno", SqlDbType.Int).Value = idTurno;

                    var tablaProfesores = new DataTable();
                    da.Fill(tablaProfesores);

                    if (tablaProfesores.Rows.Count > 0)
                    {
                        comboBoxProfesor.Enabled = true;
                        comboBoxProfesor.DataSource = tablaProfesores;
                        comboBoxProfesor.DisplayMember = "nombre";
                        comboBoxProfesor.ValueMember = "id_entrenador";
                        comboBoxProfesor.SelectedIndex = -1;
                        comboBoxProfesor.Text = "Seleccioná un profesor";
                    }
                    else
                    {
                        comboBoxProfesor.DataSource = null;
                        comboBoxProfesor.Items.Clear();
                        comboBoxProfesor.Items.Add("No hay profesores en este turno");
                        comboBoxProfesor.SelectedIndex = 0;
                        comboBoxProfesor.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar profesores: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                comboBoxProfesor.DataSource = null;
                comboBoxProfesor.Items.Clear();
                comboBoxProfesor.Items.Add("Error al cargar profesores");
                comboBoxProfesor.SelectedIndex = 0;
                comboBoxProfesor.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // === VALIDACIONES ===
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            { MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxNombre.Focus(); return; }

            if (string.IsNullOrWhiteSpace(textBoxDNI.Text))
            { MessageBox.Show("El DNI es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxDNI.Focus(); return; }

            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            { MessageBox.Show("El teléfono es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxTelefono.Focus(); return; }

            if (string.IsNullOrWhiteSpace(textBoxDomicilio.Text))
            { MessageBox.Show("El domicilio es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxDomicilio.Focus(); return; }

            if (comboBoxTurno.SelectedValue == null)
            { MessageBox.Show("Debes seleccionar un turno válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); comboBoxTurno.Focus(); return; }

            if (!comboBoxProfesor.Enabled || comboBoxProfesor.SelectedValue == null)
            { MessageBox.Show("Debes seleccionar un profesor válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); comboBoxProfesor.Focus(); return; }

            // numéricos
            if (!int.TryParse(textBoxDNI.Text.Trim(), out var dni) || dni <= 0)
            { MessageBox.Show("El DNI debe ser un número válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxDNI.Focus(); return; }

            if (!long.TryParse(textBoxTelefono.Text.Trim(), out long telefono) || telefono <= 0)
            { MessageBox.Show("El teléfono debe ser un número válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxTelefono.Focus(); return; }

            // correo obligatorio (sin validar formato)
            string correo = textBoxCorreo.Text.Trim();
            if (string.IsNullOrWhiteSpace(correo))
            { MessageBox.Show("El correo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxCorreo.Focus(); return; }

            // fechas
            DateTime fechaAlta = dtpFechaAlta.Value.Date;

            // fecha de nacimiento (NULL si checkbox destildado)
            DateTime? fechaNac = null;
            if (dtpFecha_nac.ShowCheckBox)
            {
                if (dtpFecha_nac.Checked) fechaNac = dtpFecha_nac.Value.Date;
            }
            else
            {
                fechaNac = dtpFecha_nac.Value.Date;
            }
            if (fechaNac.HasValue && fechaNac.Value > DateTime.Today)
            { MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpFecha_nac.Focus(); return; }

            // datos finales
            string nombre = textBoxNombre.Text.Trim();
            string domicilio = textBoxDomicilio.Text.Trim();
            int idTurno = Convert.ToInt32(comboBoxTurno.SelectedValue);
            int idProfesor = Convert.ToInt32(comboBoxProfesor.SelectedValue); // por si lo usás más adelante

            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            const string sqlInsAlumno = @"
INSERT INTO dbo.Alumno
    (estado, dni, nombre, telefono, domicilio, correo, fecha_nac, id_turno, fecha_alta)
VALUES
    (@estado, @dni, @nombre, @telefono, @domicilio, @correo, @fecha_nac, @id_turno, @fecha_alta);
SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sqlInsAlumno, cn))
                {
                    cn.Open();

                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = 1;
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;          // BIGINT
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 50).Value = domicilio;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar, 150).Value = correo;        // NUEVO
                    cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value =                     // NUEVO
                        fechaNac.HasValue ? (object)fechaNac.Value : DBNull.Value;
                    cmd.Parameters.Add("@id_turno", SqlDbType.Int).Value = idTurno;
                    cmd.Parameters.Add("@fecha_alta", SqlDbType.Date).Value = fechaAlta;         // NUEVO

                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null && int.TryParse(resultado.ToString(), out int idAlumno))
                    {
                        MessageBox.Show(
                            $"¡Alumno guardado!\n\nID: {idAlumno}\nNombre: {nombre}\nTurno: {comboBoxTurno.Text}\nProfesor: {comboBoxProfesor.Text}\nFecha alta: {fechaAlta:dd/MM/yyyy}",
                            "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el ID del alumno creado.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Ya existe un alumno registrado con el DNI ingresado.",
                    "DNI Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDNI.Focus();
                textBoxDNI.SelectAll();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos al guardar el alumno:\n\nCódigo: {ex.Number}\nMensaje: {ex.Message}",
                    "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado al guardar el alumno:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarListaClientes();
        }



        private void Agregar_ListaClientes()
        {
            var dgv = dataGridView_ListaClientes;

            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.ReadOnly = true; // los botones igual funcionan
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // id oculto
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "id_alumno",
                Visible = false
            });
            // guardar bit real para usarlo en los botones
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstadoBit",
                HeaderText = "estado_bit",
                DataPropertyName = "estado",
                Visible = false
            });

            // visibles
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "dni",
                Width = 110
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTelefono",
                HeaderText = "Teléfono",
                DataPropertyName = "telefono",
                Width = 110
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDomicilio",
                HeaderText = "Domicilio",
                DataPropertyName = "domicilio"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTurno",
                HeaderText = "Turno",
                DataPropertyName = "turno"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstadoTxt",
                HeaderText = "Estado",
                DataPropertyName = "EstadoTexto",
                Width = 90
            });

            // acciones
            var colEditar = new DataGridViewButtonColumn
            {
                Name = "colEditar",
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };
            dgv.Columns.Add(colEditar);

            // 
            var colToggle = new DataGridViewButtonColumn
            {
                Name = "colToggle",
                HeaderText = "Acción",
                UseColumnTextForButtonValue = false // lo seteo en DataBindingComplete
            };
            dgv.Columns.Add(colToggle);

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCorreo",
                HeaderText = "Correo",
                DataPropertyName = "correo"
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaNac",
                HeaderText = "Fecha Nac.",
                DataPropertyName = "fecha_nac",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy", NullValue = "" }
            });

            // Eventos
            dgv.DataBindingComplete -= dataGridView_ListaClientes_DataBindingComplete;
            dgv.DataBindingComplete += dataGridView_ListaClientes_DataBindingComplete;

            dgv.CellContentClick -= dataGridView_ListaClientes_CellContentClick;
            dgv.CellContentClick += dataGridView_ListaClientes_CellContentClick;
        }

        public void CargarListaClientes()
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            const string sql = @"
SELECT
    a.id_alumno,
    a.nombre,
    a.dni,
    a.telefono,
    a.domicilio,
    a.correo,          
    a.fecha_nac,      
    a.estado,
    t.descripcion AS turno
FROM dbo.Alumno a
LEFT JOIN dbo.Turno t ON t.id_turno = a.id_turno
ORDER BY a.nombre;";


            var dt = new DataTable();
            try
            {
                using (var cn = new SqlConnection(cs))
                using (var da = new SqlDataAdapter(sql, cn))
                {
                    da.Fill(dt);
                }

                // col EstadoTexto (Activo/Inactivo)
                if (!dt.Columns.Contains("EstadoTexto"))
                    dt.Columns.Add("EstadoTexto", typeof(string));

                foreach (DataRow r in dt.Rows)
                {
                    bool activo = r["estado"] != DBNull.Value && Convert.ToBoolean(r["estado"]);
                    r["EstadoTexto"] = activo ? "Activo" : "Inactivo";
                }

                dataGridView_ListaClientes.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CambiarEstadoAlumno(int idAlumno, bool activar)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            const string sql = "UPDATE dbo.Alumno SET estado = @estado WHERE id_alumno = @id;";

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = activar ? 1 : 0;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cambiar el estado del alumno: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // ajustar el texto del botón según el estado (por cada fila)
        private void dataGridView_ListaClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = dataGridView_ListaClientes;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                bool activo = false;
                if (row.Cells["colEstadoBit"].Value != null && row.Cells["colEstadoBit"].Value != DBNull.Value)
                    activo = Convert.ToBoolean(row.Cells["colEstadoBit"].Value);

                var cell = (DataGridViewButtonCell)row.Cells["colToggle"];
                cell.Value = activo ? "Dar de baja" : "Dar de alta";
                cell.Style.BackColor = activo ? Color.Red : Color.Green;
                cell.Style.ForeColor = Color.White;
                cell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }

        // 
        private void dataGridView_ListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = dataGridView_ListaClientes;

            // Botón Editar (lo tuyo)
            if (dgv.Columns[e.ColumnIndex].Name == "colEditar")
            {
                int idAlumno = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["colId"].Value);

                using (var frm = new EditarCliente(idAlumno))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarListaClientes();         // refresca la grilla
                        dgv.ClearSelection();          // opcional
                        dgv.CurrentCell = null;
                    }
                }
                return;
            }


            // Botón Alta/Baja
            if (dgv.Columns[e.ColumnIndex].Name == "colToggle")
            {
                int idAlumno = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["colId"].Value);

                bool activo = false;
                if (dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value != null &&
                    dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value != DBNull.Value)
                {
                    activo = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value);
                }

                string msg = activo ? "¿Seguro que deseas dar de baja a este alumno?"
                                    : "¿Seguro que deseas dar de alta a este alumno?";

                var r = MessageBox.Show(msg, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    // Toggle: si está activo lo bajo, si está inactivo lo doy de alta
                    CambiarEstadoAlumno(idAlumno, !activo);

                    // recargar la grilla para ver el nuevo estado y botón actualizado
                    CargarListaClientes();

                    // opcional: sin selección visible
                    dataGridView_ListaClientes.ClearSelection();
                    dataGridView_ListaClientes.CurrentCell = null;
                }
            }
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //  cancelación si hay datos en el formulario
            if (TieneInformacion())
            {
                var resultado = MessageBox.Show("¿Está seguro que desea cancelar?\n\nSe perderán todos los datos ingresados.",
                    "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    LimpiarFormulario();
                }
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void LimpiarFormulario()
        {
            //limpia los cmapos
            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxTelefono.Clear();
            textBoxDomicilio.Clear();

            // reset los combo box a su estado inicial si tienen elementos
            if (comboBoxTurno.Enabled && comboBoxTurno.Items.Count > 0)
            {
                comboBoxTurno.SelectedIndex = 0;
            }

            // enfoca el primer campo para facilitar el siguiente ingreso
            textBoxNombre.Focus();
        }

        private bool TieneInformacion()
        {
            return !string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                   !string.IsNullOrWhiteSpace(textBoxDNI.Text) ||
                   !string.IsNullOrWhiteSpace(textBoxTelefono.Text) ||
                   !string.IsNullOrWhiteSpace(textBoxDomicilio.Text);
        }




        //Permitir solo letras y/o numeros, espacios y backspace
        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir solo números y teclas de control (ej: Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            // permitir solo números y teclas de control (ej: Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void textBoxDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}