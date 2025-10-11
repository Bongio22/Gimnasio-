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
        public partial class EditarEntrenador : Form
        {
            private readonly int _idEntrenador;

            public EditarEntrenador(int idEntrenador)
            {
                InitializeComponent();
                _idEntrenador = idEntrenador;
                this.Load += EditarEntrenador_Load;
            
        }

            private void EditarEntrenador_Load(object sender, EventArgs e)
            {
                // para hacer visible el dni pero no editable
            textBoxDni.ReadOnly = true;
            textBoxDni.TabStop = false;

            dtpFecha_nac.Format = DateTimePickerFormat.Short;
            dtpFecha_nac.MaxDate = DateTime.Today;
            dtpFecha_nac.MinDate = new DateTime(1900, 1, 1);
            dtpFecha_nac.ShowCheckBox = true;        // si se destilda => NULL


            //  estilo para el combo y sea solo selección
            comboBoxTurno.DropDownStyle = ComboBoxStyle.DropDownList;

                // primero cargo los turnos 
                CargarTurnos();

                // dspues cargo los datos del entrenador y asigno el turno si existe
                CargarDatos();
            }

            private void CargarTurnos()
            {
                string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
                const string sql = "SELECT id_turno, descripcion FROM Turno ORDER BY descripcion;";
                using (var cn = new SqlConnection(cs))
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
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            const string sql = @"
    SELECT 
        e.id_entrenador,
        e.nombre,
        e.dni,
        e.telefono,
        e.domicilio,
        e.cupo,
        e.correo,        
        e.fecha_nac,      
        te.id_turno
    FROM Entrenador e
    LEFT JOIN Turno_Entrenador te ON e.id_entrenador = te.id_entrenador
    WHERE e.id_entrenador = @id;";

            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@id", _idEntrenador);
                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        textBoxNombre.Text = dr["nombre"]?.ToString() ?? string.Empty;
                        textBoxDni.Text = dr["dni"]?.ToString() ?? string.Empty;
                        textBoxTelefono.Text = dr["telefono"]?.ToString() ?? string.Empty;
                        textBoxDomicilio.Text = dr["domicilio"]?.ToString() ?? string.Empty;

                        // NUEVO: correo
                        textBoxCorreo.Text = dr["correo"]?.ToString() ?? string.Empty;

                        // NUEVO: fecha de nacimiento (manejo de NULL)
                        if (dr["fecha_nac"] == DBNull.Value)
                        {
                            dtpFecha_nac.Checked = false;  // queda “sin fecha”
                        }
                        else
                        {
                            dtpFecha_nac.Checked = true;
                            dtpFecha_nac.Value = Convert.ToDateTime(dr["fecha_nac"]);
                        }

                        if (int.TryParse(dr["cupo"]?.ToString(), out int cupo))
                            numCupo.Value = cupo;
                        else
                            numCupo.Value = 0;

                        if (dr["id_turno"] != DBNull.Value && comboBoxTurno.Items.Count > 0)
                            comboBoxTurno.SelectedValue = Convert.ToInt32(dr["id_turno"]);
                        else
                            comboBoxTurno.SelectedIndex = -1;
                    }
                }
            }
        }

        private void BGuardar_Edit_Click(object sender, EventArgs e)
            {
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            { MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxNombre.Focus(); return; }

            if (!long.TryParse(textBoxTelefono.Text, out long telefono))
            { MessageBox.Show("El teléfono es inválido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxTelefono.Focus(); return; }

            if (string.IsNullOrWhiteSpace(textBoxDomicilio.Text))
            { MessageBox.Show("El Domicilio es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxDomicilio.Focus(); return; }

            if (comboBoxTurno.SelectedValue == null)
            { MessageBox.Show("Debes seleccionar un turno.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); comboBoxTurno.Focus(); return; }

            // NUEVO: correo obligatorio (sin validar formato)
            string correo = textBoxCorreo.Text.Trim();
            if (string.IsNullOrWhiteSpace(correo))
            { MessageBox.Show("El correo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxCorreo.Focus(); return; }

            // NUEVO: fecha (NULL si está destildado)
            DateTime? fechaNac = null;
            if (dtpFecha_nac.ShowCheckBox)
            {
                if (dtpFecha_nac.Checked)
                    fechaNac = dtpFecha_nac.Value.Date;
            }
            else
            {
                fechaNac = dtpFecha_nac.Value.Date; // obligatoria si no hay checkbox
            }

            // (Opcional) no futura
            if (fechaNac.HasValue && fechaNac.Value > DateTime.Today)
            { MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpFecha_nac.Focus(); return; }

            // (Opcional) edad mínima
            if (fechaNac.HasValue && fechaNac.Value > DateTime.Today.AddYears(-18))
            { MessageBox.Show("La edad mínima es de 18 años.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); dtpFecha_nac.Focus(); return; }

            // === UPDATE + UPSERT TURNO ===
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            using (var cn = new SqlConnection(cs))
            {
                cn.Open();
                using (var tx = cn.BeginTransaction())
                {
                    try
                    {
                      
                        const string sqlEntr = @"
                    UPDATE Entrenador
                    SET nombre = @nombre,
                        telefono = @telefono,
                        domicilio = @domicilio,
                        cupo = @cupo,
                        correo = @correo,    
                        fecha_nac = @fecha_nac 
                    WHERE id_entrenador = @id;";

                        using (var cmd = new SqlCommand(sqlEntr, cn, tx))
                        {
                            cmd.Parameters.AddWithValue("@nombre", textBoxNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@telefono", telefono);
                            cmd.Parameters.AddWithValue("@domicilio", textBoxDomicilio.Text.Trim());
                            cmd.Parameters.AddWithValue("@cupo", (int)numCupo.Value);
                            cmd.Parameters.AddWithValue("@id", _idEntrenador);

                            cmd.Parameters.Add("@correo", SqlDbType.VarChar, 120).Value = correo;
                            cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value =
                                fechaNac.HasValue ? (object)fechaNac.Value : DBNull.Value;

                            cmd.ExecuteNonQuery();
                        }

                        const string sqlTurnoUpsert = @"
                    IF EXISTS (SELECT 1 FROM Turno_Entrenador WHERE id_entrenador = @id)
                        UPDATE Turno_Entrenador SET id_turno = @id_turno WHERE id_entrenador = @id;
                    ELSE
                        INSERT INTO Turno_Entrenador (id_entrenador, id_turno) VALUES (@id, @id_turno);";

                        using (var cmd2 = new SqlCommand(sqlTurnoUpsert, cn, tx))
                        {
                            cmd2.Parameters.AddWithValue("@id_turno", (int)comboBoxTurno.SelectedValue);
                            cmd2.Parameters.AddWithValue("@id", _idEntrenador);
                            cmd2.ExecuteNonQuery();
                        }

                        tx.Commit();

                        MessageBox.Show("Entrenador actualizado correctamente.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        

        private void BCancelar_Edit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        //NO ELIMINAR ESTE METODO!!
        private void EditarEntrenador_Load_1(object sender, EventArgs e)
        {

        }
    }
    }
