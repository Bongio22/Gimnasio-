using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        // ==== NUEVO: cache y binding para filtrar en memoria ====
        private DataTable _dtClientes;                    // cache de clientes
        private readonly BindingSource _bsClientes = new BindingSource(); // binding del grid

        public ClienteAgregarControl()
        {
            InitializeComponent();
            Agregar_ListaClientes();
            CargarListaClientes();
            comboBoxTurno.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProfesor.DropDownStyle = ComboBoxStyle.DropDownList;
            ConfigurarDataGridView(dataGridView_ListaClientes);

            // ==== NUEVO: enganchar búsqueda y limpiar (si existen en el diseñador) ====
            WireSearchUI();
        }

        private void ClienteAgregarControl_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

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
                        comboBoxTurno.DisplayMember = "descripcion";
                        comboBoxTurno.ValueMember = "id_turno";
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

                comboBoxTurno.DataSource = null;
                comboBoxTurno.Items.Clear();
                comboBoxTurno.Items.Add("Error al cargar turnos");
                comboBoxTurno.SelectedIndex = 0;
                comboBoxTurno.Enabled = false;
            }

            comboBoxProfesor.DataSource = null;
            comboBoxProfesor.Items.Clear();
            comboBoxProfesor.Items.Add("Seleccioná un turno primero");
            comboBoxProfesor.SelectedIndex = 0;
            comboBoxProfesor.Enabled = false;

            dtpFechaAlta.Value = DateTime.Today;

            dtpFecha_nac.Format = DateTimePickerFormat.Short;
            dtpFecha_nac.MaxDate = DateTime.Today;
            dtpFecha_nac.MinDate = new DateTime(1900, 1, 1);
            dtpFecha_nac.ShowCheckBox = true;

            comboBoxTurno.SelectedIndexChanged -= comboBoxTurno_SelectedIndexChanged;
            comboBoxTurno.SelectedIndexChanged += comboBoxTurno_SelectedIndexChanged;

            comboBoxTurno.SelectedIndex = -1;
            comboBoxTurno.Text = "Seleccioná un turno";
        }

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

            int dni;
            if (!int.TryParse(textBoxDNI.Text.Trim(), out dni) || dni <= 0)
            { MessageBox.Show("El DNI debe ser numérico y mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxDNI.Focus(); return; }

            long telefono;
            if (!long.TryParse(textBoxTelefono.Text.Trim(), out telefono) || telefono <= 0)
            { MessageBox.Show("El teléfono debe ser numérico y mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxTelefono.Focus(); return; }

            string correo = textBoxCorreo.Text.Trim();
            if (string.IsNullOrWhiteSpace(correo))
            { MessageBox.Show("El correo es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBoxCorreo.Focus(); return; }

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

            string nombre = textBoxNombre.Text.Trim();
            string domicilio = textBoxDomicilio.Text.Trim();
            int idTurno = Convert.ToInt32(comboBoxTurno.SelectedValue);
            int idProfesor = Convert.ToInt32(comboBoxProfesor.SelectedValue);

            // chequear cupo (si lo manejás en otro lado, esto es defensivo)
            var cupoInfo = ObtenerCupoYOcupadosEntrenador(idProfesor);
            if (cupoInfo.cupo > 0 && cupoInfo.ocupados >= cupoInfo.cupo)
            {
                MessageBox.Show(string.Format("El entrenador seleccionado alcanzó su cupo ({0}/{1}).", cupoInfo.ocupados, cupoInfo.cupo),
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

                    using (var ctx = cn.CreateCommand())
                    {
                        ctx.CommandText = "EXEC sys.sp_set_session_context @key=N'current_user_id', @value=@id;";
                        ctx.Parameters.Add("@id", SqlDbType.Int).Value = UserSession.IdUsuario;
                        ctx.ExecuteNonQuery();
                    }

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@admin_id", SqlDbType.Int).Value = UserSession.IdUsuario;
                    cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = 1;
                    cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
                    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
                    cmd.Parameters.Add("@telefono", SqlDbType.BigInt).Value = telefono;
                    cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 50).Value = domicilio;
                    cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = fechaNac.HasValue ? (object)fechaNac.Value : DBNull.Value;
                    cmd.Parameters.Add("@correo", SqlDbType.VarChar, 150).Value = correo;
                    cmd.Parameters.Add("@id_turno", SqlDbType.Int).Value = idTurno;
                    cmd.Parameters.Add("@id_entrenador", SqlDbType.Int).Value = idProfesor;
                    cmd.Parameters.Add("@monto_mensual", SqlDbType.Decimal).Value = DBNull.Value;
                    cmd.Parameters.Add("@fecha_alta", SqlDbType.Date).Value = fechaAlta;
                    cmd.Parameters.Add("@activo_desde", SqlDbType.Date).Value = fechaAlta;

                    var result = cmd.ExecuteScalar();
                    int idAlumno;
                    if (result != null && int.TryParse(result.ToString(), out idAlumno))
                    {
                        MessageBox.Show(
                            string.Format("¡Cliente guardado!\n\nID: {0}\nNombre: {1}\nTurno: {2}\nProfesor: {3}",
                                idAlumno, nombre, comboBoxTurno.Text, comboBoxProfesor.Text),
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
                MessageBox.Show(string.Format("Error SQL al guardar el cliente.\n\nCódigo: {0}\nMensaje: {1}", ex.Number, ex.Message),
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

            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "id_alumno",
                Visible = false
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstadoBit",
                HeaderText = "estado_bit",
                DataPropertyName = "estado",
                Visible = false
            });

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

            var colEditar = new DataGridViewButtonColumn
            {
                Name = "colEditar",
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                FlatStyle = FlatStyle.Flat
            };
            dgv.Columns.Add(colEditar);

            var colToggle = new DataGridViewButtonColumn
            {
                Name = "colToggle",
                HeaderText = "Acción",
                UseColumnTextForButtonValue = false,
                FlatStyle = FlatStyle.Flat
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

            dgv.DataBindingComplete -= dataGridView_ListaClientes_DataBindingComplete;
            dgv.DataBindingComplete += dataGridView_ListaClientes_DataBindingComplete;

            dgv.CellContentClick -= dataGridView_ListaClientes_CellContentClick;
            dgv.CellContentClick += dataGridView_ListaClientes_CellContentClick;

            dgv.CellPainting -= dataGridView_ListaClientes_CellPainting;
            dgv.CellPainting += dataGridView_ListaClientes_CellPainting;

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

                if (!dt.Columns.Contains("EstadoTexto"))
                    dt.Columns.Add("EstadoTexto", typeof(string));

                foreach (DataRow r in dt.Rows)
                {
                    bool activo = r["estado"] != DBNull.Value && Convert.ToBoolean(r["estado"]);
                    r["EstadoTexto"] = activo ? "Activo" : "Inactivo";
                }

                // ==== NUEVO: cache y binding para filtrar sin re-consultar SQL ====
                _dtClientes = dt;
                _bsClientes.DataSource = _dtClientes;
                dataGridView_ListaClientes.DataSource = _bsClientes;
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

            var sets = new List<string>();
            if (ColumnaExiste("dbo.Alumno", "estado")) sets.Add("estado = @b");
            if (ColumnaExiste("dbo.Alumno", "activo")) sets.Add("activo = @b");

            if (ColumnaExiste("dbo.Alumno", "fecha_baja"))
                sets.Add(activar ? "fecha_baja = NULL" : "fecha_baja = CAST(GETDATE() AS date)");

            if (ColumnaExiste("dbo.Alumno", "activo_desde"))
                sets.Add(activar ? "activo_desde = CAST(GETDATE() AS date)" : "activo_desde = activo_desde");

            if (sets.Count == 0)
            {
                MessageBox.Show("No encontré columnas de estado en dbo.Alumno.", "Esquema incompatible",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = "UPDATE dbo.Alumno SET " + string.Join(", ", sets) + " WHERE id_alumno = @id;";

            try
            {
                using (var cn = new SqlConnection(cs))
                using (var cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = idAlumno;
                    cmd.Parameters.Add("@b", SqlDbType.Bit).Value = activar ? 1 : 0;
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

        private void dataGridView_ListaClientes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = dataGridView_ListaClientes;

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

            int last = dgv.Columns.Count - 1;

            if (dgv.Columns.Contains("colEditar"))
                dgv.Columns["colEditar"].DisplayIndex = last--;

            if (dgv.Columns.Contains("colEstadoTxt"))
                dgv.Columns["colEstadoTxt"].DisplayIndex = last--;

            if (dgv.Columns.Contains("colToggle"))
                dgv.Columns["colToggle"].DisplayIndex = last;

            dgv.ClearSelection();
        }

        private void dataGridView_ListaClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dgv = dataGridView_ListaClientes;

            if (dgv.Columns[e.ColumnIndex].Name == "colEditar")
            {
                int idAlumno = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["colId"].Value);

                using (var frm = new EditarCliente(idAlumno))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarListaClientes();
                        dgv.ClearSelection();
                        dgv.CurrentCell = null;
                    }
                }
                return;
            }

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
                    CambiarEstadoAlumno(idAlumno, !activo);
                    CargarListaClientes();
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

            e.PaintBackground(e.CellBounds, true);
            e.Handled = true;

            string text;
            Color bg;

            if (colName == "colEditar")
            {
                text = "Editar";
                bg = Color.FromArgb(33, 150, 243);
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
                bg = activo ? Color.FromArgb(220, 53, 69) : Color.FromArgb(40, 167, 69);
            }

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
            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxTelefono.Clear();
            textBoxDomicilio.Clear();

            if (comboBoxTurno.Enabled && comboBoxTurno.Items.Count > 0)
            {
                comboBoxTurno.SelectedIndex = 0;
            }

            textBoxNombre.Focus();
        }

        private bool TieneInformacion()
        {
            return !string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                   !string.IsNullOrWhiteSpace(textBoxDNI.Text) ||
                   !string.IsNullOrWhiteSpace(textBoxTelefono.Text) ||
                   !string.IsNullOrWhiteSpace(textBoxDomicilio.Text);
        }

        private void comboBoxProfesor_DrawItem(object sender, DrawItemEventArgs e)
        {
            var combo = (ComboBox)sender;
            e.DrawBackground();
            if (e.Index < 0) { e.DrawFocusRectangle(); return; }

            var drv = combo.Items[e.Index] as DataRowView;
            string text = drv != null && drv.Row.Table.Columns.Contains("label")
                          ? Convert.ToString(drv["label"])
                          : combo.Items[e.Index].ToString();

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
                MessageBox.Show(string.Format("{0} no tiene cupo disponible ({1}/{2}).", nombre, ocupados, cupo), "Sin cupo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                combo.SelectedIndex = -1;
                combo.Text = "Seleccioná un profesor";
                combo.DroppedDown = true;
            }
        }

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

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitido todo (lo validás por UI si querés)
        }

        private void ConfigurarDataGridView(DataGridView dgv)
        {
            Color verdeEncabezado = ColorTranslator.FromHtml("#014A16");
            Color verdeSeleccion = ColorTranslator.FromHtml("#7BAE7F");
            Color verdeAlterna = ColorTranslator.FromHtml("#EDFFEF");
            Color grisBorde = ColorTranslator.FromHtml("#C8D3C4");
            Color hoverSuave = ColorTranslator.FromHtml("#DCEFE6");

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

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = grisBorde;

            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = verdeEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 36;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = verdeSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = verdeAlterna;

            dgv.ClearSelection();
            dgv.DataBindingComplete += (s, e) => ((DataGridView)s).ClearSelection();

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

            try
            {
                typeof(DataGridView)
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(dgv, true, null);
            }
            catch { }
        }

        // ===== util local =====
        private bool ColumnaExiste(string tabla, string columna)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            const string q = @"SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID(@t) AND name = @c;";
            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(q, cn))
            {
                cmd.Parameters.Add("@t", SqlDbType.NVarChar, 256).Value = tabla;
                cmd.Parameters.Add("@c", SqlDbType.NVarChar, 128).Value = columna;
                cn.Open();
                object r = cmd.ExecuteScalar();
                return r != null;
            }
        }

        // =======================
        // ==== NUEVO: FILTRO ====
        // =======================

        // Conecta eventos de buscar/limpiar/Enter si los controles existen
        private void WireSearchUI()
        {
            // Enter en el textbox dispara buscar
            if (textBox_DniClientes != null)
            {
                textBox_DniClientes.KeyDown -= textBox_DniClientes_KeyDown;
                textBox_DniClientes.KeyDown += textBox_DniClientes_KeyDown;
            }

            // Botón Buscar
            if (B_BuscarCliente != null)
            {
                B_BuscarCliente.Click -= B_BuscarCliente_Click;
                B_BuscarCliente.Click += B_BuscarCliente_Click;
            }

            // Botón Limpiar
            if (BLimpiar != null)
            {
                BLimpiar.Click -= BLimpiar_Click;
                BLimpiar.Click += BLimpiar_Click;
            }
        }

        // Escapa caracteres especiales para RowFilter (', [, ], %)
        private static string EscapeRowFilter(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            // Duplicar comillas simples y encerrar corchetes
            var sb = new StringBuilder(value.Length);
            foreach (char c in value)
            {
                if (c == '\'') sb.Append("''");
                else if (c == '[') sb.Append("[[]");
                else if (c == ']') sb.Append("[]]");
                else if (c == '%') sb.Append("[%]");
                else if (c == '*') sb.Append("[*]");
                else sb.Append(c);
            }
            return sb.ToString();
        }

        // Aplica filtro por DNI o Nombre (contiene)
        private void BuscarClientesPorTexto()
        {
            if (_bsClientes.DataSource == null)
            {
                // por las dudas recargamos si aún no hay data
                CargarListaClientes();
            }

            string termino = (textBox_DniClientes != null ? textBox_DniClientes.Text.Trim() : string.Empty);

            if (string.IsNullOrEmpty(termino))
            {
                _bsClientes.RemoveFilter();
                dataGridView_ListaClientes.ClearSelection();
                return;
            }

            string t = EscapeRowFilter(termino);

            // Si el término es numérico, también filtramos por DNI "contiene"
            bool esNumero = termino.All(char.IsDigit);

            // Importante: RowFilter usa nombres de columnas del DataTable (_dtClientes)
            // DNI es int, por eso usamos CONVERT(..., 'System.String') para buscar parcial
            string filtro = esNumero
                ? string.Format("CONVERT(dni, 'System.String') LIKE '%{0}%' OR nombre LIKE '%{0}%'", t)
                : string.Format("nombre LIKE '%{0}%'", t);

            _bsClientes.Filter = filtro;
            dataGridView_ListaClientes.ClearSelection();
        }

        private void LimpiarFiltroClientes()
        {
            if (textBox_DniClientes != null)
                textBox_DniClientes.Clear();

            if (_bsClientes != null)
                _bsClientes.RemoveFilter();

            dataGridView_ListaClientes.ClearSelection();
            dataGridView_ListaClientes.CurrentCell = null;
        }

        // ==== Handlers nuevos ====
        private void textBox_DniClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                BuscarClientesPorTexto();
            }
        }

        private void B_BuscarCliente_Click(object sender, EventArgs e)
        {
            BuscarClientesPorTexto();
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFiltroClientes();
        }
    }
}
