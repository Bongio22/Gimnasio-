using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;     // ConfigurationManager
using System.Data.SqlClient;    // SqlConnection, SqlCommand

namespace Gestor_Gimnasio
{
    public partial class ProfesorAgregarControl : UserControl
    {
        public event EventHandler<int> ProfesorCreado; 
        // Dispara el ID nuevo para que el dashboard refresque listas si quiere

        public ProfesorAgregarControl()
        {
            InitializeComponent();
        }

        private void ProfesorAgregarControl_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            const string sql = "SELECT id_turno, descripcion FROM dbo.Turno ORDER BY descripcion;";

            using (var cn = new SqlConnection(cs))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                var t = new DataTable();
                da.Fill(t);
                comboBoxTurno.DataSource = t;
                comboBoxTurno.DisplayMember = "descripcion";
                comboBoxTurno.ValueMember = "id_turno";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxTelefono.Clear();
            textBoxDomicilio.Clear();
            numCupo.Value = 0;
            chkActivo.Checked = true;
            textBoxNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- Validaciones básicas ---
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            { MessageBox.Show("El nombre es obligatorio."); textBoxNombre.Focus(); return; }

            if (!int.TryParse(textBoxDNI.Text, out var dni))
            { MessageBox.Show("DNI inválido."); textBoxDNI.Focus(); return; }

            if (!int.TryParse(textBoxTelefono.Text, out var tel))
            { MessageBox.Show("Teléfono inválido."); textBoxTelefono.Focus(); return; }

            if (comboBoxTurno.SelectedValue == null)
            { MessageBox.Show("Debes seleccionar un turno."); return; }

            var cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            // 1) Insertar entrenador (SIN id_turno)
            const string sqlEntrenador = @"
        INSERT INTO dbo.Entrenador (cupo, nombre, estado, telefono, dni, domicilio)
        VALUES (@cupo, @nombre, @estado, @telefono, @dni, @domicilio);
        SELECT CAST(SCOPE_IDENTITY() AS int);";

            // 2) Vincular con turno en tabla N:N
            const string sqlVinculo = @"
        INSERT INTO dbo.Turno_Entrenador (id_entrenador, id_turno)
        VALUES (@id_entrenador, @id_turno);";

            try
            {
                using (var cn = new SqlConnection(cs))
                {
                    cn.Open();
                    using (var tx = cn.BeginTransaction())
                    {
                        // Insert Entrenador
                        int idNuevo;
                        using (var cmd = new SqlCommand(sqlEntrenador, cn, tx))
                        {
                            cmd.Parameters.Add("@cupo", SqlDbType.Int).Value = (int)numCupo.Value;
                            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = textBoxNombre.Text.Trim();
                            cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = chkActivo.Checked ? 1 : 0;
                            cmd.Parameters.Add("@telefono", SqlDbType.Int).Value = tel;               // INT en tu esquema
                            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;                    // INT y UNIQUE
                            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 50).Value =
                                (object)(textBoxDomicilio.Text?.Trim() ?? string.Empty);

                            idNuevo = (int)cmd.ExecuteScalar();
                        }

                        // Insert vínculo N:N
                        using (var cmd2 = new SqlCommand(sqlVinculo, cn, tx))
                        {
                            cmd2.Parameters.Add("@id_entrenador", SqlDbType.Int).Value = idNuevo;
                            cmd2.Parameters.Add("@id_turno", SqlDbType.Int).Value = (int)comboBoxTurno.SelectedValue;
                            cmd2.ExecuteNonQuery();
                        }

                        tx.Commit();

                        MessageBox.Show($"Profesor guardado con éxito. ID: {idNuevo}",
                            "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ProfesorCreado?.Invoke(this, idNuevo);
                        LimpiarFormulario();
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // clave duplicada (DNI único)
            {
                MessageBox.Show("Ya existe un profesor con ese DNI.", "Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar profesor: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
