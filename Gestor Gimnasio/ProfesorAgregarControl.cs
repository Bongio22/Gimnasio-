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
        // dispara el ID nuevo para que el dashboard refresque listas si quiere

        public ProfesorAgregarControl()
        {
            InitializeComponent();
            tabla_profesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tabla_profesores.MultiSelect = false;
            tabla_profesores.AllowUserToAddRows = false;
            tabla_profesores.AllowUserToResizeRows = false;
            tabla_profesores.RowHeadersVisible = false;
            ConfigurarDataGridView(tabla_profesores);
        }

        private void ProfesorAgregarControl_Load(object sender, EventArgs e)
        {
            
            this.Dock = DockStyle.Fill;
            
            // DateTimePicker: formato, límites y check para permitir NULL
            dtpFecha_nac.Format = DateTimePickerFormat.Short;
            dtpFecha_nac.MaxDate = DateTime.Today;
            dtpFecha_nac.MinDate = new DateTime(1900, 1, 1);
            dtpFecha_nac.ShowCheckBox = true;   // si se destilda => NULL

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

            CargarEntrenadores();
            tabla_profesores.CellContentClick += tabla_profesores_CellContentClick;
        }

        //cuando se cancela se limpia
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        //limpia los campos con los datos
        private void LimpiarFormulario()
        {
            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxTelefono.Clear();
            textBoxDomicilio.Clear();
            numCupo.Value = 0;
            chkActivo.Checked = true;
            textBoxNombre.Focus();
            textBoxCorreo.Clear();                
            numCupo.Value = 0;
            chkActivo.Checked = true;

            dtpFecha_nac.Checked = false; //  sin fecha por defecto
            textBoxNombre.Focus();
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
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // validaciones
            if (string.IsNullOrWhiteSpace(textBoxNombre.Text))
            { MessageBox.Show("El nombre es obligatorio."); textBoxNombre.Focus(); return; }

            if (!int.TryParse(textBoxDNI.Text, out var dni))
            { MessageBox.Show("DNI inválido."); textBoxDNI.Focus(); return; }

            //  limitá largo del textbox en el diseñador (p.ej. MaxLength = 15)
            if (!long.TryParse(textBoxTelefono.Text.Trim(), out long tel))
            {
                MessageBox.Show("Teléfono inválido.");
                textBoxTelefono.Focus();
                return;
            }

            // (opcional) chequeo de longitud razonable
            var len = textBoxTelefono.Text.Trim().Length;
            if (len < 6 || len > 15)
            {
                MessageBox.Show("El teléfono debe tener entre 6 y 15 dígitos.");
                textBoxTelefono.Focus();
                return;
            }


            if (comboBoxTurno.SelectedValue == null)
            { MessageBox.Show("Debes seleccionar un turno."); return; }

           
            string correo = textBoxCorreo.Text.Trim();
            if (string.IsNullOrWhiteSpace(correo))
            {
                MessageBox.Show("El correo es obligatorio.");
                textBoxCorreo.Focus();
                return;
            }

            // Fecha (NULL si está destildado el checkbox)
            DateTime? fechaNac = null;
            if (dtpFecha_nac.ShowCheckBox)
            {
                if (dtpFecha_nac.Checked)
                    fechaNac = dtpFecha_nac.Value.Date;
            }
            else
            {
                fechaNac = dtpFecha_nac.Value.Date;
            }

        

            var cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            //  Insertar entrenador sin id_turno
           
            const string sqlEntrenador = @"
INSERT INTO dbo.Entrenador (cupo, nombre, estado, telefono, dni, domicilio, correo, fecha_nac)
VALUES (@cupo, @nombre, @estado, @telefono, @dni, @domicilio, @correo, @fecha_nac);
SELECT CAST(SCOPE_IDENTITY() AS int);";


            // vincula con turno
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
                        // insert etrenador
                        int idNuevo;
                        using (var cmd = new SqlCommand(sqlEntrenador, cn, tx))
                        {
                            cmd.Parameters.Add("@cupo", SqlDbType.Int).Value = (int)numCupo.Value;
                            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = textBoxNombre.Text.Trim();
                            cmd.Parameters.Add("@estado", SqlDbType.Bit).Value = chkActivo.Checked ? 1 : 0;
                            cmd.Parameters.Add("@telefono", SqlDbType.BigInt).Value = tel;               
                            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;                    // INT y UNIQUE
                            cmd.Parameters.Add("@domicilio", SqlDbType.VarChar, 50).Value = (object)(textBoxDomicilio.Text?.Trim() ?? string.Empty);
                            cmd.Parameters.Add("@correo", SqlDbType.VarChar, 120).Value = correo;
                            cmd.Parameters.Add("@fecha_nac", SqlDbType.Date).Value = fechaNac.HasValue ? (object)fechaNac.Value : DBNull.Value;

                            idNuevo = (int)cmd.ExecuteScalar();
                        }

                        // insert del vinculo con el turno
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
                        CargarEntrenadores();

                        LimpiarFormulario();
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // clave duplicada dni debe ser unico
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


        // metodo para obtener todos los proesores
        
        private DataTable ObtenerEntrenadores()
        {
            DataTable dt = new DataTable();
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = @"
SELECT 
    e.id_entrenador,
    e.nombre,
    e.dni,
    e.telefono,
    e.domicilio,
    e.cupo,
    e.estado,
    e.correo,                 -- NUEVO
    e.fecha_nac,      -- NUEVO
    t.descripcion AS turno
FROM Entrenador e
INNER JOIN Turno_Entrenador te ON e.id_entrenador = te.id_entrenador
INNER JOIN Turno t ON te.id_turno = t.id_turno";


                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        // cargar entrenadores en data grid view
        private void CargarEntrenadores()
        {
            DataTable entrenadores = ObtenerEntrenadores();

            // Columna calculada de estado (texto)
            if (!entrenadores.Columns.Contains("estadoTexto"))
                entrenadores.Columns.Add("estadoTexto", typeof(string));

            foreach (DataRow row in entrenadores.Rows)
            {
                bool activo = Convert.ToBoolean(row["estado"]);
                row["estadoTexto"] = activo ? "Activo" : "Inactivo";
            }

            tabla_profesores.DataSource = entrenadores;

            // Encabezados
            tabla_profesores.Columns["id_entrenador"].HeaderText = "ID";
            tabla_profesores.Columns["nombre"].HeaderText = "NOMBRE";
            tabla_profesores.Columns["dni"].HeaderText = "DNI";
            tabla_profesores.Columns["telefono"].HeaderText = "TELÉFONO";
            tabla_profesores.Columns["domicilio"].HeaderText = "DOMICILIO";
            tabla_profesores.Columns["turno"].HeaderText = "TURNO";
            tabla_profesores.Columns["cupo"].HeaderText = "CUPO";
            tabla_profesores.Columns["estadoTexto"].HeaderText = "ESTADO";
            tabla_profesores.Columns["correo"].HeaderText = "CORREO";
            tabla_profesores.Columns["fecha_nac"].HeaderText = "FECHA NAC.";

            // Formato fecha
            tabla_profesores.Columns["fecha_nac"].DefaultCellStyle.Format = "dd/MM/yyyy";
            tabla_profesores.Columns["fecha_nac"].DefaultCellStyle.NullValue = "";

            // Ocultos
            tabla_profesores.Columns["estado"].Visible = false;
            tabla_profesores.Columns["id_entrenador"].Visible = false;

            // Quitar botones si ya estaban
            if (tabla_profesores.Columns.Contains("Editar")) tabla_profesores.Columns.Remove("Editar");
            if (tabla_profesores.Columns.Contains("Accion")) tabla_profesores.Columns.Remove("Accion");

            // 
            var btnEditar = new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = false, // lo pinto y escribo yo
                Width = 120
            };
            tabla_profesores.Columns.Add(btnEditar);

            // 
            var btnAccion = new DataGridViewButtonColumn
            {
                Name = "Accion",
                HeaderText = "Acción",
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = false, // lo pinto y escribo yo
                Width = 150
            };
            tabla_profesores.Columns.Add(btnAccion);

            // Estética/medidas
            tabla_profesores.RowTemplate.Height = 40;
            tabla_profesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //  Eventos 
            tabla_profesores.CellFormatting -= tabla_profesores_CellFormatting;
            tabla_profesores.CellFormatting += tabla_profesores_CellFormatting;

            tabla_profesores.CellPainting -= tabla_profesores_CellPainting;
            tabla_profesores.CellPainting += tabla_profesores_CellPainting;

            // Cursor mano en botones 
            tabla_profesores.CellMouseMove += (s, ev) =>
            {
                if (ev.RowIndex >= 0)
                {
                    string n = tabla_profesores.Columns[ev.ColumnIndex].Name;
                    tabla_profesores.Cursor = (n == "Editar" || n == "Accion") ? Cursors.Hand : Cursors.Default;
                }
            };

            // 
            int last = tabla_profesores.Columns.Count - 1;
            if (tabla_profesores.Columns.Contains("Editar"))
                tabla_profesores.Columns["Editar"].DisplayIndex = last--;
            if (tabla_profesores.Columns.Contains("Accion"))
                tabla_profesores.Columns["Accion"].DisplayIndex = last--;
            if (tabla_profesores.Columns.Contains("estadoTexto"))
                tabla_profesores.Columns["estadoTexto"].DisplayIndex = last--;

            tabla_profesores.ClearSelection();
        }


        //metodo para personalizar apariencia de las celdas en el dgv
        private void tabla_profesores_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string col = tabla_profesores.Columns[e.ColumnIndex].Name;

            if (col == "Accion")
            {
                var estado = tabla_profesores.Rows[e.RowIndex].Cells["estadoTexto"].Value?.ToString();
                e.Value = (string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase))
                          ? "Dar de Baja"
                          : "Dar de Alta";
                
            }
            else if (col == "Editar")
            {
                e.Value = "Editar";
              
            }
        }

        private void tabla_profesores_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var grid = (DataGridView)sender;
            string col = grid.Columns[e.ColumnIndex].Name;
            if (col != "Editar" && col != "Accion") return;

            // Pinta el fondo normal de la celda (mantiene alternado, selección, etc.)
            e.PaintBackground(e.CellBounds, true);
            e.Handled = true;

            // Texto y color del botón
            string text;
            Color bg;

            if (col == "Editar")
            {
                text = "Editar";
                bg = Color.FromArgb(33, 150, 243);           // Azul
            }
            else
            {
                var estado = grid.Rows[e.RowIndex].Cells["estadoTexto"].Value?.ToString();
                bool activo = string.Equals(estado, "Activo", StringComparison.OrdinalIgnoreCase);

                text = activo ? "Dar de Baja" : "Dar de Alta";
                bg = activo ? Color.FromArgb(220, 53, 69)    // Rojo
                              : Color.FromArgb(40, 167, 69);   // Verde
            }

            // Rectángulo del "botón" (márgenes internos para no llenar la celda)
            Rectangle rect = new Rectangle(
                e.CellBounds.X + 10,
                e.CellBounds.Y + 6,
                e.CellBounds.Width - 20,
                e.CellBounds.Height - 12
            );

            using (var br = new SolidBrush(bg))
                e.Graphics.FillRectangle(br, rect);

            using (var pen = new Pen(ControlPaint.Dark(bg), 1))
                e.Graphics.DrawRectangle(pen, rect);

            TextRenderer.DrawText(
                e.Graphics,
                text,
                new Font("Segoe UI", 9, FontStyle.Bold),
                rect,
                Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
            );
        }


        // click en botones del dgv
        private void tabla_profesores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // ignorar encabezados

            // boton editar
            var colName = tabla_profesores.Columns[e.ColumnIndex].Name;

            if (colName == "Editar")
            {
                int idEntrenador = Convert.ToInt32(tabla_profesores.Rows[e.RowIndex].Cells["id_entrenador"].Value);

                using (var frm = new EditarEntrenador(idEntrenador))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        // si guardó correctamente, recargo la grilla 
                        CargarEntrenadores();
                    }
                }
            }
      

            // accion de botones de  alta/baja
            if (tabla_profesores.Columns[e.ColumnIndex].Name == "Accion")
            {
                int idEntrenador = Convert.ToInt32(tabla_profesores.Rows[e.RowIndex].Cells["id_entrenador"].Value);
                string estadoActual = tabla_profesores.Rows[e.RowIndex].Cells["estadoTexto"].Value.ToString();

                bool activo = estadoActual == "Activo";

                if (activo)
                {
                    DialogResult result = MessageBox.Show(
                        "¿Seguro que quieres dar de baja este entrenador?",
                        "Confirmar Baja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        CambiarEstadoEntrenador(idEntrenador, false);
                        MessageBox.Show("El entrenador fue dado de baja.");
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show(
                        "¿Seguro que quieres dar de alta este entrenador?",
                        "Confirmar Alta",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        CambiarEstadoEntrenador(idEntrenador, true);
                        MessageBox.Show("El entrenador fue dado de alta.");
                    }
                }

                CargarEntrenadores();
            }
        }

        //botones previamente crewdos en el dgv de cargar los entrenadores y botones() es para configurar la accion
       
        // metodo para actualizar estado de entrenador (activo/inactivo) en la BD
        public void CambiarEstadoEntrenador(int idEntrenador, bool activo)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "UPDATE Entrenador SET estado = @estado WHERE id_entrenador = @id_entrenador";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@estado", activo);
                    cmd.Parameters.AddWithValue("@id_entrenador", idEntrenador);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void textBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo letras
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bloquea el carácter
            }
        }

        private void textBoxDomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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











        //no eliminar porque se rompe el diseñador
        private void groupBoxRegistroProf_Enter(object sender, EventArgs e)
        {

        }
        private void comboBoxTurno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabla_profesores_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

