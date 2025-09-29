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
            comboBoxProfesor.Items.Add("Seleccione un turno primero");
            comboBoxProfesor.SelectedIndex = 0;
            comboBoxProfesor.Enabled = false;
            dtpFechaAlta.Value = DateTime.Today;
        }

        //el disable de los entrenadores correspomdientes al turno elegido
        private void comboBoxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            // verificar si hay un valor seleccionado válido
            if (comboBoxTurno.SelectedValue == null || !comboBoxTurno.Enabled)
                return;

            // verificar que el valor sea numérico (no sea el texto de error)
            if (!int.TryParse(comboBoxTurno.SelectedValue.ToString(), out int idTurno))
                return;

            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            // consulta  para obtener los entrenadores que hay disponibles ese turno seleccionado
            const string sqlProfesores = @"SELECT e.id_entrenador, e.nombre FROM dbo.Turno_Entrenador te
            JOIN dbo.Entrenador e ON e.id_entrenador = te.id_entrenador WHERE te.id_turno = @id_turno
AND e.estado = 1 ORDER BY e.nombre;";

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var da = new SqlDataAdapter(sqlProfesores, cn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id_turno", idTurno);

                    var tablaProfesores = new DataTable();
                    da.Fill(tablaProfesores);

                    if (tablaProfesores.Rows.Count > 0)
                    {
                        comboBoxProfesor.Enabled = true;
                        comboBoxProfesor.DataSource = tablaProfesores;
                        comboBoxProfesor.DisplayMember = "nombre";        // lo que se ve
                        comboBoxProfesor.ValueMember = "id_entrenador";   // el id real
                        comboBoxProfesor.SelectedIndex = 0;
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

                // deshabilitar el combo de profesores si hay errores
                comboBoxProfesor.DataSource = null;
                comboBoxProfesor.Items.Clear();
                comboBoxProfesor.Items.Add("Error al cargar profesores");
                comboBoxProfesor.SelectedIndex = 0;
                comboBoxProfesor.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // validaciones de campos 
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDNI.Text))
            {
                MessageBox.Show("El DNI es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDNI.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTelefono.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTelefono.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDomicilio.Text))
            {
                MessageBox.Show("El domicilio es obligatorio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDomicilio.Focus();
                return;
            }

            // validacion de selección de turno y profesor
            if (!comboBoxTurno.Enabled || comboBoxTurno.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar un turno válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!comboBoxProfesor.Enabled || comboBoxProfesor.SelectedValue == null)
            {
                MessageBox.Show("Debes seleccionar un profesor válido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validaciones de formato num
            if (!int.TryParse(textBoxDNI.Text.Trim(), out var dni) || dni <= 0)
            {
                MessageBox.Show("El DNI debe ser un número válido mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDNI.Focus();
                return;
            }

            if (!int.TryParse(textBoxTelefono.Text.Trim(), out var telefono) || telefono <= 0)
            {
                MessageBox.Show("El teléfono debe ser un número válido mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTelefono.Focus();
                return;
            }

            // tomar fecha de alta desde el picker
            DateTime fechaAlta = dtpFechaAlta.Value.Date;

            // datos
            string nombre = textBoxNombre.Text.Trim();
            string domicilio = textBoxDomicilio.Text.Trim();
            int idTurno = int.Parse(comboBoxTurno.SelectedValue.ToString());
            int idProfesor = int.Parse(comboBoxProfesor.SelectedValue.ToString()); // si más adelante lo guardás

            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            const string sqlInsAlumno = @"
        INSERT INTO dbo.Alumno (estado, dni, nombre, telefono, domicilio, id_turno, fecha_alta)
        VALUES (@estado, @dni, @nombre, @telefono, @domicilio, @id_turno, @fecha_alta);
        SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sqlInsAlumno, cn))
                {
                    cn.Open();

                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = 1;
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = int.Parse(textBoxDNI.Text.Trim());
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = int.Parse(textBoxTelefono.Text.Trim());
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 50).Value = domicilio;
                    cmd.Parameters.Add("@id_turno", SqlDbType.Int).Value = idTurno;

                    fechaAlta = dtpFechaAlta.Value.Date;
                    cmd.Parameters.Add("@fecha_alta", SqlDbType.Date).Value = fechaAlta;


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
                MessageBox.Show($"Ya existe un alumno registrado con el DNI ingresado.",
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
            a.estado,              -- BIT (1 activo / 0 inactivo)
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

                row.Cells["colToggle"].Value = activo ? "Dar de baja" : "Dar de alta";
            }
        }

        // 
        private void dataGridView_ListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = dataGridView_ListaClientes;

            // btn editar
            if (dgv.Columns[e.ColumnIndex].Name == "colEditar")
            {
                int idAlumno = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["colId"].Value);
                string nombre = dgv.Rows[e.RowIndex].Cells["colNombre"].Value?.ToString() ?? "";
                //sql funcional
                MessageBox.Show($"Editar alumno: {nombre} (ID {idAlumno})");
            }

            
            if (dgv.Columns[e.ColumnIndex].Name == "colToggle")
            {
                int idAlumno = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["colId"].Value);
                bool activo = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value);
                string accion = activo ? "dar de baja" : "dar de alta";
              //sql funcional
                MessageBox.Show($"(Demo) Vas a {accion} al alumno ID {idAlumno}");
               
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