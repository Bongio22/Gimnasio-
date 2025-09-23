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
                        comboBoxProfesor.ValueMember = "id_entrenador";   // el ID real
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

            // obtener datos del formulario
            string nombre = textBoxNombre.Text.Trim();
            string domicilio = textBoxDomicilio.Text.Trim();

            if (!int.TryParse(comboBoxTurno.SelectedValue.ToString(), out int idTurno))
            {
                MessageBox.Show("Error en la selección del turno.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(comboBoxProfesor.SelectedValue.ToString(), out int idProfesor))
            {
                MessageBox.Show("Error en la selección del profesor.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            // insertar alumno usando turno y profesor seleccionados
            const string sqlInsAlumno = @"INSERT INTO dbo.Alumno (estado, dni, nombre, telefono, domicilio, id_turno)
    VALUES (@estado, @dni, @nombre, @telefono, @domicilio, @id_turno);
    SELECT CAST(SCOPE_IDENTITY() AS int);";

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sqlInsAlumno, cn))
                {
                    cn.Open();

                    // parametros para evitar errores
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = 1;
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = telefono;
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 50).Value = domicilio;
                    cmd.Parameters.Add("@id_turno", SqlDbType.Int).Value = idTurno;

                    var resultado = cmd.ExecuteScalar();
                    if (resultado != null && int.TryParse(resultado.ToString(), out int idAlumno))
                    {
                        MessageBox.Show($"¡Alumno guardado exitosamente!\n\nID: {idAlumno}\nNombre: {nombre}\nTurno: {comboBoxTurno.Text}\nProfesor: {comboBoxProfesor.Text}",
                            "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       
                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("Error: No se pudo obtener el ID del alumno creado.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // restricción UNIQUE para dni
            {
                MessageBox.Show($"Ya existe un alumno registrado con el DNI: {dni}\n\nPor favor, verifique el DNI e intente nuevamente.",
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
            // Permitir solo números y teclas de control (ej: Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Permitir solo números y teclas de control (ej: Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void textBoxDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}