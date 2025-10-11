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
    public partial class EditarCliente : Form
    {
        private readonly int _idAlumno;
        private string CS => ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
        public EditarCliente(int id_alumno)
        {
            InitializeComponent();
            _idAlumno = id_alumno;

            this.Load += EditarCliente_Load;
            BGuardar_Edit.Click += BGuardar_Edit_Click;
            BCancelar_Edit.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            textBoxDNI.ReadOnly = true;
            textBoxDNI.TabStop = false;

            // Fecha de nacimiento (permite NULL destildando)
            dtpFecha_nac.Format = DateTimePickerFormat.Short;
            dtpFecha_nac.ShowCheckBox = true;
            dtpFecha_nac.MaxDate = DateTime.Today;
            dtpFecha_nac.MinDate = new DateTime(1900, 1, 1);

            comboBoxTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProfesor.DropDownStyle = ComboBoxStyle.DropDownList;

            // evito doble suscripción por si el diseñador ya enganchó el evento
            comboBoxTurno.SelectedIndexChanged -= comboBoxTurno_SelectedIndexChanged;
            comboBoxTurno.SelectedIndexChanged += comboBoxTurno_SelectedIndexChanged;

            comboBoxTurno.DropDownStyle = ComboBoxStyle.DropDownList;

            CargarTurnos();
            CargarDatos();
        }
        private void CargarTurnos()
        {
            const string sql = @"SELECT id_turno, descripcion FROM dbo.Turno ORDER BY descripcion;";
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                var dt = new DataTable();
                da.Fill(dt);
                comboBoxTurno.DataSource = dt;
                comboBoxTurno.DisplayMember = "descripcion";
                comboBoxTurno.ValueMember = "id_turno";
            }
        }

        private void CargarDatos()
        {
            const string sql = @"
SELECT a.id_alumno, a.nombre, a.dni, a.telefono, a.domicilio, a.correo, a.fecha_nac, a.id_turno
FROM dbo.Alumno a
WHERE a.id_alumno = @id;";

            using (var cn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = _idAlumno;
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        textBoxNombre.Text = dr["nombre"]?.ToString() ?? "";
                        textBoxDNI.Text = dr["dni"]?.ToString() ?? "";
                        textBoxTelefono.Text = dr["telefono"]?.ToString() ?? "";
                        textBoxDomicilio.Text = dr["domicilio"]?.ToString() ?? "";
                        textBoxCorreo.Text = dr["correo"]?.ToString() ?? "";

                        if (dr["fecha_nac"] == DBNull.Value)
                            dtpFecha_nac.Checked = false;
                        else
                        {
                            dtpFecha_nac.Checked = true;
                            dtpFecha_nac.Value = Convert.ToDateTime(dr["fecha_nac"]);
                        }

                        if (dr["id_turno"] != DBNull.Value)
                            comboBoxTurno.SelectedValue = Convert.ToInt32(dr["id_turno"]);
                        else
                            comboBoxTurno.SelectedIndex = -1;
                    }
                }
            }
        }

        private void BGuardar_Edit_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text.Trim();
            string domicilio = textBoxDomicilio.Text.Trim();
            string correo = textBoxCorreo.Text.Trim();
            string telTxt = textBoxTelefono.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            { MessageBox.Show("El nombre es obligatorio."); textBoxNombre.Focus(); return; }
            if (string.IsNullOrWhiteSpace(domicilio))
            { MessageBox.Show("El domicilio es obligatorio."); textBoxDomicilio.Focus(); return; }
            if (string.IsNullOrWhiteSpace(correo))
            { MessageBox.Show("El correo es obligatorio."); textBoxCorreo.Focus(); return; }

            if (!Regex.IsMatch(telTxt, @"^\d{7,15}$"))
            { MessageBox.Show("Teléfono inválido (solo dígitos 7–15)."); textBoxTelefono.Focus(); return; }
            long telefono = long.Parse(telTxt); // BIGINT en BD

            if (comboBoxTurno.SelectedValue == null)
            { MessageBox.Show("Seleccione un turno válido."); comboBoxTurno.DroppedDown = true; return; }

            // Fecha de nacimiento (NULL si está destildado)
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
            { MessageBox.Show("La fecha de nacimiento no puede ser futura."); dtpFecha_nac.Focus(); return; }

            int idTurno = Convert.ToInt32(comboBoxTurno.SelectedValue);

            // === UPDATE (NO se toca DNI ni ESTADO) ===
            const string sql = @"
UPDATE dbo.Alumno
SET nombre    = @nombre,
    telefono  = @telefono,
    domicilio = @domicilio,
    correo    = @correo,
    fecha_nac = @fecha_nac,
    id_turno  = @id_turno
WHERE id_alumno = @id;";

            try
            {
                using (var cn = new SqlConnection(CS))
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 50).Value = domicilio;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar, 150).Value = correo;
                    cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value =
    fechaNac.HasValue ? (object)fechaNac.Value : DBNull.Value;
                    cmd.Parameters.Add("@id_turno", SqlDbType.Int).Value = idTurno;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = _idAlumno;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Alumno actualizado correctamente.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar alumno: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTurno.SelectedValue == null) return;
            if (!int.TryParse(comboBoxTurno.SelectedValue.ToString(), out var idTurno)) return;
            CargarProfesoresPorTurno(idTurno);
        }

        private void CargarProfesoresPorTurno(int idTurno, int? idEntrenadorSel = null)
        {
            const string sql = @"
        SELECT e.id_entrenador, e.nombre
        FROM dbo.Turno_Entrenador te
        INNER JOIN dbo.Entrenador e ON e.id_entrenador = te.id_entrenador
        WHERE te.id_turno = @t AND e.estado = 1
        ORDER BY e.nombre;";

            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.AddWithValue("@t", idTurno);
                var dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    comboBoxProfesor.DataSource = null;
                    comboBoxProfesor.Items.Clear();
                    comboBoxProfesor.Items.Add("No hay profesores en este turno");
                    comboBoxProfesor.SelectedIndex = 0;
                    comboBoxProfesor.Enabled = false;
                    return;
                }

                comboBoxProfesor.Enabled = true;
                comboBoxProfesor.DataSource = dt;
                comboBoxProfesor.DisplayMember = "nombre";
                comboBoxProfesor.ValueMember = "id_entrenador";

                if (idEntrenadorSel.HasValue && dt.Select($"id_entrenador = {idEntrenadorSel.Value}").Length > 0)
                    comboBoxProfesor.SelectedValue = idEntrenadorSel.Value;
                else
                    comboBoxProfesor.SelectedIndex = 0;
            }
        }
    }
}
