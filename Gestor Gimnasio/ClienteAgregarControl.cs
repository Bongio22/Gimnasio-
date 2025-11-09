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
            ConfigurarDataGridView(dataGridView_ListaClientes); 
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
            int idProfesor = Convert.ToInt32(comboBoxProfesor.SelectedValue);

            // === CHEQUEO DE CUPO (por si cambió algo antes de Guardar) ===
            var (cupo, ocupados) = ObtenerCupoYOcupadosEntrenador(idProfesor);
            if (cupo > 0 && ocupados >= cupo)
            {
                MessageBox.Show($"El entrenador seleccionado alcanzó su cupo ({ocupados}/{cupo}).",
                    "Cupo completo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxProfesor.Focus();
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var cmd = new SqlCommand("dbo.sp_Alumno_Crear", cn))
                {
                    cn.Open();

                    // (opcional) contexto de sesión para tu trigger de creado_por
                    using (var ctx = cn.CreateCommand())
                    {
                        ctx.CommandText = "EXEC sys.sp_set_session_context @key=N'current_user_id', @value=@id;";
                        ctx.Parameters.Add("@id", SqlDbType.Int).Value = UserSession.IdUsuario;   // admin logueado
                        ctx.ExecuteNonQuery();
                    }

                    cmd.CommandType = CommandType.StoredProcedure;

                    // === PARÁMETROS DEL SP (incluye @id_entrenador) ===
                    cmd.Parameters.Add("@admin_id", SqlDbType.Int).Value = UserSession.IdUsuario;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = 1;
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 50).Value = domicilio;
                    cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = fechaNac.HasValue ? (object)fechaNac.Value : DBNull.Value;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar, 150).Value = correo;
                    cmd.Parameters.Add("@id_turno", SqlDbType.Int).Value = idTurno;
                    cmd.Parameters.Add("@id_entrenador", SqlDbType.Int).Value = idProfesor; // <<--- AQUÍ PASÁS EL ENTRENADOR
                    cmd.Parameters.Add("@monto_mensual", SqlDbType.Decimal).Value = DBNull.Value;

                    var result = cmd.ExecuteScalar();
                    if (result != null && int.TryParse(result.ToString(), out int idAlumno))
                    {
                        MessageBox.Show(
                            $"¡Cliente guardado!\n\nID: {idAlumno}\nNombre: {nombre}\nTurno: {comboBoxTurno.Text}\nProfesor: {comboBoxProfesor.Text}",
                            "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimpiarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo obtener el ID del cliente creado.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                MessageBox.Show("Ya existe un cliente/alumno con ese DNI.",
                    "DNI duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDNI.Focus();
                textBoxDNI.SelectAll();
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error SQL al guardar el cliente.\n\nCódigo: {ex.Number}\nMensaje: {ex.Message}",
                    "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cliente: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CargarListaClientes();
        }



        private void Agregar_ListaClientes()
        {
            var dgv = dataGridView_ListaClientes;


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
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat            // <- importante
            };
            dgv.Columns.Add(colEditar);

            var colToggle = new DataGridViewButtonColumn
            {
                Name = "colToggle",
                HeaderText = "Acción",
                UseColumnTextForButtonValue = false,  // lo seteo o dibujo luego
                FlatStyle = FlatStyle.Flat            // <- importante
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

            dgv.CellPainting -= dataGridView_ListaClientes_CellPainting;
            dgv.CellPainting += dataGridView_ListaClientes_CellPainting;

            // (opcional) manito sobre botones
            dgv.CellMouseMove += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                {
                    string n = dgv.Columns[ev.ColumnIndex].Name;
                    dgv.Cursor = (n == "colEditar" || n == "colToggle") ? Cursors.Hand : Cursors.Default;
                }
            };

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

            // Actualiza el texto del botón de acción si existiera (defensivo)
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                if (dgv.Columns.Contains("colToggle"))
                {
                    bool activo = false;
                    var c = row.Cells["colEstadoBit"];
                    if (c?.Value != null && c.Value != DBNull.Value) activo = Convert.ToBoolean(c.Value);

                    var btnCell = (DataGridViewButtonCell)row.Cells["colToggle"];
                    btnCell.Value = activo ? "Dar de baja" : "Dar de alta";
                }
            }

            // --- Orden final de columnas ---
            int last = dgv.Columns.Count - 1;

            // 1) Último = Editar
            if (dgv.Columns.Contains("colEditar"))
                dgv.Columns["colEditar"].DisplayIndex = last--;

            // 2) Penúltimo = Estado (texto)
            if (dgv.Columns.Contains("colEstadoTxt"))
                dgv.Columns["colEstadoTxt"].DisplayIndex = last--;

            // 3) (Opcional) Antepenúltimo = Acción (Dar de alta/baja), si existe
            if (dgv.Columns.Contains("colToggle"))
                dgv.Columns["colToggle"].DisplayIndex = last;

            // Sin selección inicial
            dgv.ClearSelection();
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

        private void dataGridView_ListaClientes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dgv = (DataGridView)sender;
            string colName = dgv.Columns[e.ColumnIndex].Name;
            if (colName != "colEditar" && colName != "colToggle") return;

            // Limpia el fondo de la celda (sin color)
            e.PaintBackground(e.CellBounds, true);
            e.Handled = true;

            // Texto y color del "botón"
            string text;
            Color bg;

            if (colName == "colEditar")
            {
                text = "Editar";
                bg = Color.FromArgb(33, 150, 243);    // Azul Material
            }
            else
            {
                bool activo = false;
                if (dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value != null &&
                    dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value != DBNull.Value)
                {
                    activo = Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells["colEstadoBit"].Value);
                }

                text = activo ? "Dar de baja" : "Dar de alta";
                bg = activo ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69); // Rojo / Verde
            }

            // Rectángulo del botón (márgenes internos)
            var rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 6,
                                     e.CellBounds.Width - 16, e.CellBounds.Height - 12);

            using (var br = new SolidBrush(bg))
                e.Graphics.FillRectangle(br, rect);

            using (var pen = new Pen(ControlPaint.Dark(bg), 1))
                e.Graphics.DrawRectangle(pen, rect);

            TextRenderer.DrawText(e.Graphics, text, new Font("Segoe UI", 9, FontStyle.Bold),
                                  rect, Color.White,
                                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
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


        // DIBUJA los profesores SIN CUPO en gris + itálica
        private void comboBoxProfesor_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = (ComboBox)sender;
            e.DrawBackground();
            if (e.Index < 0) { e.DrawFocusRectangle(); return; }

            var drv = combo.Items[e.Index] as DataRowView;
            string text = drv?["label"]?.ToString() ?? combo.Items[e.Index].ToString();

            bool inaccesible = drv != null
                               && drv.Row.Table.Columns.Contains("inaccesible")
                               && Convert.ToBoolean(drv["inaccesible"]);

            Color fore = inaccesible
                ? SystemColors.GrayText
                : ((e.State & DrawItemState.Selected) == DrawItemState.Selected
                    ? SystemColors.HighlightText
                    : SystemColors.WindowText);

            using (var foreBr = new SolidBrush(fore))
            {
                var font = inaccesible ? new Font(e.Font, FontStyle.Italic) : e.Font;
                TextRenderer.DrawText(e.Graphics, text, font, e.Bounds, fore,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
            e.DrawFocusRectangle();
        }

        // BLOQUEA selección de profesores SIN CUPO y avisa
        private void comboBoxProfesor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var combo = (ComboBox)sender;
            if (combo.SelectedIndex < 0) return;

            var drv = combo.SelectedItem as DataRowView;
            if (drv == null) return;

            bool inaccesible = drv.Row.Table.Columns.Contains("inaccesible")
                               && Convert.ToBoolean(drv["inaccesible"]);
            if (inaccesible)
            {
                string nombre = Convert.ToString(drv["nombre"]);
                int cupo = drv["cupo"] == DBNull.Value ? 0 : Convert.ToInt32(drv["cupo"]);
                int ocupados = drv["ocupados"] == DBNull.Value ? 0 : Convert.ToInt32(drv["ocupados"]);
                MessageBox.Show($"{nombre} no tiene cupo disponible ({ocupados}/{cupo}).", "Sin cupo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                combo.SelectedIndex = -1;
                combo.Text = "Seleccioná un profesor";
                combo.DroppedDown = true; // reabre para elegir otro
            }
        }

        // Helper para contar cupo/ocupados de un entrenador
        private (int cupo, int ocupados) ObtenerCupoYOcupadosEntrenador(int idEntrenador)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            const string sql = @"
SELECT e.cupo,
       ocupados = COUNT(CASE WHEN a.estado = 1 THEN 1 END)
FROM dbo.Entrenador e
LEFT JOIN dbo.Alumno a ON a.id_entrenador = e.id_entrenador
WHERE e.id_entrenador = @id
GROUP BY e.cupo;";

            int cupo = 0, ocup = 0;
            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEntrenador;
                cn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        cupo = rd["cupo"] == DBNull.Value ? 0 : Convert.ToInt32(rd["cupo"]);
                        ocup = rd["ocupados"] == DBNull.Value ? 0 : Convert.ToInt32(rd["ocupados"]);
                    }
                }
            }
            return (cupo, ocup);
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

        private void ConfigurarDataGridView(DataGridView dgv)
        {

            Color verdeEncabezado = ColorTranslator.FromHtml("#014A16"); // verde bosque apagado
            Color verdeSeleccion = ColorTranslator.FromHtml("#7BAE7F"); // verde medio selección
            Color verdeAlterna = ColorTranslator.FromHtml("#EDFFEF"); // verde muy claro alternado
            Color grisBorde = ColorTranslator.FromHtml("#C8D3C4"); // gris verdoso claro
            Color hoverSuave = ColorTranslator.FromHtml("#DCEFE6"); // verde pastel para hover

            // --- Comportamiento ---
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.EnableHeadersVisualStyles = false;

            // --- Autoajuste ---
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // --- Estética general ---
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = grisBorde;

            // Encabezado
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = verdeEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 36;

            // Celdas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = verdeSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);

            // Filas alternadas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = verdeAlterna;

            // --- Sin selección inicial ---
            dgv.ClearSelection();
            dgv.DataBindingComplete += (s, e) => ((DataGridView)s).ClearSelection();

            // --- Hover suave (efecto al pasar el mouse) ---
            Color originalBackColor = dgv.DefaultCellStyle.BackColor;
            Color originalAltColor = dgv.AlternatingRowsDefaultCellStyle.BackColor;
            int lastRow = -1;

            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex != lastRow)
                {
                    var fila = dgv.Rows[e.RowIndex];
                    fila.DefaultCellStyle.BackColor = hoverSuave;
                    lastRow = e.RowIndex;
                }
            };

            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var fila = dgv.Rows[e.RowIndex];
                    fila.DefaultCellStyle.BackColor = (e.RowIndex % 2 == 0) ? originalBackColor : originalAltColor;
                }
            };

            // --- Doble buffer (scroll suave) ---
            try
            {
                typeof(DataGridView)
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(dgv, true, null);
            }
            catch { }
        }
    }
}