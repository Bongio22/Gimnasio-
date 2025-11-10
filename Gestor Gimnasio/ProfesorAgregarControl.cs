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

        // ========= NUEVO: cache + binding para filtro =========
        private DataTable _dtEntrenadores;
        private readonly BindingSource _bs = new BindingSource();

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

            // ========= NUEVO: eventos de búsqueda =========
            if (B_BuscarEntrenador != null)
                B_BuscarEntrenador.Click += (s, ev) => BuscarEntrenador();

            if (BLimpiar != null)
                BLimpiar.Click += (s, ev) => LimpiarBusqueda();

            if (textBox_DniEntrenadores != null)
                textBox_DniEntrenadores.KeyDown += (s, ev) =>
                {
                    if (ev.KeyCode == Keys.Enter)
                    {
                        ev.SuppressKeyPress = true;
                        BuscarEntrenador();
                    }
                    else if (ev.KeyCode == Keys.Escape)
                    {
                        LimpiarBusqueda();
                    }
                };
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
                        // insert entrenador
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

        // ======== NUEVO: helpers de Baja + Migración ========

        private int ContarAlumnosAsignados(int idEntrenador)
        {
            // Asumiendo FK: Alumno.id_entrenador -> Entrenador.id_entrenador
            // (si usás otra tabla, ajustá el FROM)
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            const string sql = @"SELECT COUNT(*) FROM dbo.Alumno WHERE id_entrenador = @id;";
            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEntrenador;
                cn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        private DataTable ObtenerEntrenadoresActivosParaMigrar(int excluirId, int? idTurnoPreferido)
        {
            // Trae entrenadores activos distintos al actual; si se desea, prioriza por mismo turno
            // Ajusta el JOIN si tu modelo de turnos lo requiere (ya usás Turno_Entrenador).
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            var sql = new StringBuilder(@"
SELECT e.id_entrenador,
       e.nombre,
       e.dni,
       t.descripcion AS turno,
       te.id_turno
FROM dbo.Entrenador e
LEFT JOIN dbo.Turno_Entrenador te ON te.id_entrenador = e.id_entrenador
LEFT JOIN dbo.Turno t ON t.id_turno = te.id_turno
WHERE e.estado = 1 AND e.id_entrenador <> @excluir");

            if (idTurnoPreferido.HasValue)
            {
                sql.Append(" ORDER BY CASE WHEN te.id_turno = @turno THEN 0 ELSE 1 END, e.nombre");
            }
            else
            {
                sql.Append(" ORDER BY e.nombre");
            }

            using (var cn = new SqlConnection(cs))
            using (var da = new SqlDataAdapter(sql.ToString(), cn))
            {
                da.SelectCommand.Parameters.Add("@excluir", SqlDbType.Int).Value = excluirId;
                if (idTurnoPreferido.HasValue)
                    da.SelectCommand.Parameters.Add("@turno", SqlDbType.Int).Value = idTurnoPreferido.Value;

                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private int? ObtenerTurnoPrincipalDeEntrenador(int idEntrenador)
        {
            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;
            const string sql = @"
SELECT TOP 1 te.id_turno
FROM dbo.Turno_Entrenador te
WHERE te.id_entrenador = @id
ORDER BY te.id_turno;";

            using (var cn = new SqlConnection(cs))
            using (var cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idEntrenador;
                cn.Open();
                object o = cmd.ExecuteScalar();
                if (o == null || o == DBNull.Value) return null;
                return Convert.ToInt32(o);
            }
        }

        private DialogResult MostrarDialogoMigracion(DataTable opciones, out int idEntrenadorDestino)
        {
            idEntrenadorDestino = 0;

            Color header = ColorTranslator.FromHtml("#014A16");
            Color border = ColorTranslator.FromHtml("#C8D3C4");
            Color success = ColorTranslator.FromHtml("#7BAE7F");
            Color grayBtn = Color.FromArgb(120, 120, 120);

            using (var f = new Form())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ClientSize = new Size(620, 220);
                f.BackColor = Color.White;
                f.Text = "Migrar alumnos a otro entrenador";

                // --- Encabezado verde oscuro ---
                var headerPanel = new Panel { BackColor = header, Dock = DockStyle.Top, Height = 50 };
                var lblTitle = new Label
                {
                    Text = "Seleccioná el entrenador destino",
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                    AutoSize = false,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(16, 0, 16, 0)
                };
                headerPanel.Controls.Add(lblTitle);
                f.Controls.Add(headerPanel);

                // --- Texto descriptivo ---
                var lbl = new Label
                {
                    Text = "El entrenador tiene alumnos asignados.\nElegí a qué entrenador activo migrarlos:",
                    Font = new Font("Segoe UI", 10.5f, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = false,
                    Location = new Point(24, 70),
                    Size = new Size(572, 40)
                };
                f.Controls.Add(lbl);

                // --- ComboBox de entrenadores ---
                var cb = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Location = new Point(24, 118),
                    Size = new Size(572, 28),
                    DisplayMember = "nombre",
                    ValueMember = "id_entrenador",
                    DataSource = opciones
                };
                f.Controls.Add(cb);

                // --- Línea inferior separadora ---
                var line = new Panel { BackColor = border, Height = 1, Dock = DockStyle.Bottom };
                f.Controls.Add(line);

                // --- Botón helper estilizado ---
                Button CrearBoton(string texto, Color colorFondo, DialogResult dr)
                {
                    var b = new Button
                    {
                        Text = texto,
                        DialogResult = dr,
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = Color.White,
                        BackColor = colorFondo,
                        Height = 36,
                        Width = 180,
                        Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                        Cursor = Cursors.Hand
                    };
                    b.FlatAppearance.BorderSize = 0;
                    b.MouseEnter += (s, e) => b.BackColor = ControlPaint.Light(colorFondo);
                    b.MouseLeave += (s, e) => b.BackColor = colorFondo;
                    return b;
                }

                // --- Botones ---
                var btnCancelar = CrearBoton("Cancelar", grayBtn, DialogResult.Cancel);
                var btnAceptar = CrearBoton("Transferir y dar de baja", Color.DarkGreen, DialogResult.OK);

                btnCancelar.Location = new Point(f.ClientSize.Width - 24 - 180 - 12 - 180, 168);
                btnAceptar.Location = new Point(f.ClientSize.Width - 24 - 180, 168);

                f.Controls.Add(btnCancelar);
                f.Controls.Add(btnAceptar);

                f.AcceptButton = btnAceptar;
                f.CancelButton = btnCancelar;

                // --- Mostrar diálogo ---
                var result = f.ShowDialog(this);
                if (result == DialogResult.OK && cb.SelectedValue != null)
                    idEntrenadorDestino = Convert.ToInt32(cb.SelectedValue);

                return result;
            }
        }


        private void MigrarAlumnos(int idDesde, int idHacia, SqlConnection cn, SqlTransaction tx)
        {
            // Ajustá el nombre de la FK si en tu modelo es distinto
            const string sql = @"UPDATE dbo.Alumno SET id_entrenador = @to WHERE id_entrenador = @from;";
            using (var cmd = new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.Add("@to", SqlDbType.Int).Value = idHacia;
                cmd.Parameters.Add("@from", SqlDbType.Int).Value = idDesde;
                cmd.ExecuteNonQuery();
            }
        }

        private void DarDeBajaConMigracion(int idEntrenador)
        {
            // === helper de UI local (estilo consistente) ===
            void Info(string titulo, string mensaje, bool ok = true)
            {
                Color header = ColorTranslator.FromHtml("#014A16");
                Color border = ColorTranslator.FromHtml("#C8D3C4");
                Color primary = ok ? ColorTranslator.FromHtml("#7BAE7F") : Color.FromArgb(220, 53, 69);

                using (var f = new Form())
                {
                    f.StartPosition = FormStartPosition.CenterParent;
                    f.FormBorderStyle = FormBorderStyle.FixedDialog;
                    f.MaximizeBox = false;
                    f.MinimizeBox = false;
                    f.ClientSize = new Size(520, 180);
                    f.BackColor = Color.White;
                    f.Text = titulo;

                    var headerPanel = new Panel { BackColor = header, Dock = DockStyle.Top, Height = 50 };
                    var lblTitle = new Label
                    {
                        Text = titulo,
                        ForeColor = Color.White,
                        Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                        AutoSize = false,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Padding = new Padding(16, 0, 16, 0)
                    };
                    headerPanel.Controls.Add(lblTitle);
                    f.Controls.Add(headerPanel);

                    var lblMsg = new Label
                    {
                        Text = mensaje,
                        Font = new Font("Segoe UI", 10.5f, FontStyle.Regular),
                        ForeColor = Color.Black,
                        AutoSize = false,
                        Location = new Point(20, 70),
                        Size = new Size(480, 56)
                    };
                    f.Controls.Add(lblMsg);

                    var line = new Panel { BackColor = border, Height = 1, Dock = DockStyle.Bottom };
                    f.Controls.Add(line);

                    var btnOk = new Button
                    {
                        Text = "Aceptar",
                        DialogResult = DialogResult.OK,
                        FlatStyle = FlatStyle.Flat,
                        ForeColor = Color.White,
                        BackColor = primary,
                        Height = 34,
                        Width = 120,
                        Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                        Location = new Point(f.ClientSize.Width - 24 - 120, 130)
                    };
                    btnOk.FlatAppearance.BorderSize = 0;
                    btnOk.MouseEnter += (s, ev) => btnOk.BackColor = ControlPaint.Light(primary);
                    btnOk.MouseLeave += (s, ev) => btnOk.BackColor = primary;

                    f.Controls.Add(btnOk);
                    f.AcceptButton = btnOk;

                    f.ShowDialog(this);
                }
            }
            // === fin helper UI ===

            string cs = ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

            // 1) ¿Tiene alumnos el entrenador que se va a dar de baja?
            int cantidad = ContarAlumnosAsignados(idEntrenador);

            if (cantidad <= 0)
            {
                // No tiene alumnos: baja directa
                CambiarEstadoEntrenador(idEntrenador, false);
                Info("Listo", "Entrenador dado de baja.", true);
                return;
            }

            // 2) Buscar candidatos de destino (opcionalmente priorizando mismo turno)
            int? turnoPreferido = ObtenerTurnoPrincipalDeEntrenador(idEntrenador);
            DataTable candidatos = ObtenerEntrenadoresActivosParaMigrar(idEntrenador, turnoPreferido);

            if (candidatos.Rows.Count == 0)
            {
                Info("No hay destino",
                    "No existe otro entrenador activo para migrar los alumnos. Creá/activá otro entrenador e intentá nuevamente.",
                    false);
                return;
            }

            // 3) Elegir destino (usa el método de clase MostrarDialogoMigracion)
            int idDestino;
            if (MostrarDialogoMigracion(candidatos, out idDestino) != DialogResult.OK || idDestino <= 0)
                return; // cancelado por el usuario

            if (idDestino == idEntrenador)
            {
                Info("Selección inválida", "No podés migrar los alumnos al mismo entrenador.", false);
                return;
            }

            // 3.1 (pre-chequeo rápido) Validar cupo antes de abrir transacción
            //    Nota: El chequeo definitivo se hace adentro de la transacción con locks.
            int cupoMax = 0, actuales = 0;
            using (var cnPre = new SqlConnection(cs))
            using (var cmdPre = new SqlCommand(@"
        SELECT e.cupo,
               COUNT(a.id_alumno) AS actuales
        FROM dbo.Entrenador e
        LEFT JOIN dbo.Alumno a ON a.id_entrenador = e.id_entrenador
        WHERE e.id_entrenador = @id
        GROUP BY e.cupo;", cnPre))
            {
                cmdPre.Parameters.Add("@id", SqlDbType.Int).Value = idDestino;
                cnPre.Open();
                using (var r = cmdPre.ExecuteReader())
                {
                    if (r.Read())
                    {
                        cupoMax = r.IsDBNull(0) ? 0 : r.GetInt32(0);
                        actuales = r.IsDBNull(1) ? 0 : r.GetInt32(1);
                    }
                }
            }

            if (actuales + cantidad > cupoMax)
            {
                Info("Cupo excedido",
                    $"El entrenador destino tiene {actuales} alumnos y un cupo máximo de {cupoMax}.\n" +
                    $"No es posible migrar {cantidad} alumnos adicionales.", false);
                return;
            }

            // 4) Migración + baja dentro de transacción (con locks para evitar condiciones de carrera)
            using (var cn = new SqlConnection(cs))
            {
                cn.Open();
                using (var tx = cn.BeginTransaction())
                {
                    try
                    {
                        // 4.1 Revalidar cupo con locks de actualización
                        int cupoTx = 0, actualesTx = 0;
                        using (var cmdChk = new SqlCommand(@"
                    SELECT e.cupo,
                           COUNT(a.id_alumno) AS actuales
                    FROM dbo.Entrenador e WITH (UPDLOCK, HOLDLOCK)
                    LEFT JOIN dbo.Alumno a WITH (UPDLOCK, HOLDLOCK)
                        ON a.id_entrenador = e.id_entrenador
                    WHERE e.id_entrenador = @id
                    GROUP BY e.cupo;", cn, tx))
                        {
                            cmdChk.Parameters.Add("@id", SqlDbType.Int).Value = idDestino;
                            using (var r = cmdChk.ExecuteReader())
                            {
                                if (r.Read())
                                {
                                    cupoTx = r.IsDBNull(0) ? 0 : r.GetInt32(0);
                                    actualesTx = r.IsDBNull(1) ? 0 : r.GetInt32(1);
                                }
                                else
                                {
                                    throw new InvalidOperationException("No se pudo leer el cupo del entrenador destino.");
                                }
                            }
                        }

                        if (actualesTx + cantidad > cupoTx)
                            throw new InvalidOperationException(
                                $"Cupo excedido en destino: actuales={actualesTx}, a migrar={cantidad}, cupo={cupoTx}.");

                        // 4.2 Migrar alumnos (todos los del entrenador dado de baja)
                        using (var cmdMig = new SqlCommand(@"
                    UPDATE dbo.Alumno
                    SET id_entrenador = @destino
                    WHERE id_entrenador = @origen;", cn, tx))
                        {
                            cmdMig.Parameters.Add("@destino", SqlDbType.Int).Value = idDestino;
                            cmdMig.Parameters.Add("@origen", SqlDbType.Int).Value = idEntrenador;
                            cmdMig.ExecuteNonQuery();
                        }

                        // 4.3 Dar de baja al entrenador original
                        using (var cmdBaja = new SqlCommand(@"
                    UPDATE dbo.Entrenador
                    SET estado = 0
                    WHERE id_entrenador = @id;", cn, tx))
                        {
                            cmdBaja.Parameters.Add("@id", SqlDbType.Int).Value = idEntrenador;
                            cmdBaja.ExecuteNonQuery();
                        }

                        tx.Commit();

                        Info("Operación exitosa",
                            $"Se migraron {cantidad} alumno(s) al entrenador seleccionado y se dio de baja al entrenador.",
                            true);
                    }
                    catch (InvalidOperationException ioex)
                    {
                        tx.Rollback();
                        Info("Cupo excedido", ioex.Message, false);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        Info("Error", "Error en la migración/baja: " + ex.Message, false);
                    }
                }
            }
        }


        // ======== Código existente (listado / UI / búsqueda) ========

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
    COUNT(a.id_alumno) AS alumnos_asignados,  -- 👈 NUEVO
    e.estado,
    e.correo,
    e.fecha_nac,
    t.descripcion AS turno
FROM Entrenador e
INNER JOIN Turno_Entrenador te ON e.id_entrenador = te.id_entrenador
INNER JOIN Turno t ON te.id_turno = t.id_turno
LEFT JOIN Alumno a ON a.id_entrenador = e.id_entrenador  -- 👈 para contar alumnos
GROUP BY e.id_entrenador, e.nombre, e.dni, e.telefono, e.domicilio, e.cupo,
         e.estado, e.correo, e.fecha_nac, t.descripcion;";
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
            _dtEntrenadores = ObtenerEntrenadores();     // trae también alumnos_asignados
            _dtEntrenadores.CaseSensitive = false;

            // Columna calculada ESTADO texto
            if (!_dtEntrenadores.Columns.Contains("estadoTexto"))
                _dtEntrenadores.Columns.Add("estadoTexto", typeof(string));

            foreach (DataRow row in _dtEntrenadores.Rows)
            {
                bool activo = Convert.ToBoolean(row["estado"]);
                row["estadoTexto"] = activo ? "Activo" : "Inactivo";
            }

            // 🔐 Aseguramos autogeneración de columnas
            tabla_profesores.AutoGenerateColumns = true;

            // Enlazar
            _bs.DataSource = _dtEntrenadores;
            tabla_profesores.DataSource = _bs;

            // Helper para buscar columnas por DataPropertyName o Name
            DataGridViewColumn FindCol(string propOrName)
            {
                // intenta por DataPropertyName
                var col = tabla_profesores.Columns.Cast<DataGridViewColumn>()
                             .FirstOrDefault(c => string.Equals(c.DataPropertyName, propOrName, StringComparison.OrdinalIgnoreCase));
                if (col != null) return col;

                // intenta por Name
                return tabla_profesores.Columns.Cast<DataGridViewColumn>()
                             .FirstOrDefault(c => string.Equals(c.Name, propOrName, StringComparison.OrdinalIgnoreCase));
            }

            void SetHeader(string prop, string header)
            {
                var c = FindCol(prop);
                if (c != null) c.HeaderText = header;
            }

            void SetFormat(string prop, string format)
            {
                var c = FindCol(prop);
                if (c != null) c.DefaultCellStyle.Format = format;
            }

            void SetVisible(string prop, bool visible)
            {
                var c = FindCol(prop);
                if (c != null) c.Visible = visible;
            }

            // 🏷 Encabezados seguros (solo si existen)
            SetHeader("id_entrenador", "ID");
            SetHeader("nombre", "NOMBRE");
            SetHeader("dni", "DNI");
            SetHeader("telefono", "TELÉFONO");
            SetHeader("domicilio", "DOMICILIO");
            SetHeader("turno", "TURNO");
            SetHeader("cupo", "CUPO");
            SetHeader("alumnos_asignados", "ALUMNOS");   // NUEVO
            SetHeader("estadoTexto", "ESTADO");
            SetHeader("correo", "CORREO");
            SetHeader("fecha_nac", "FECHA NAC.");

            // Formato fecha
            SetFormat("fecha_nac", "dd/MM/yyyy");

            // Ocultos
            SetVisible("estado", false);
            SetVisible("id_entrenador", false); // si querés ocultarlo; o dejalo visible y quitá esta línea

            // Quitar botones si ya estaban
            if (tabla_profesores.Columns.Contains("Editar")) tabla_profesores.Columns.Remove("Editar");
            if (tabla_profesores.Columns.Contains("Accion")) tabla_profesores.Columns.Remove("Accion");

            // Botón Editar
            var btnEditar = new DataGridViewButtonColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = false,
                Width = 120
            };
            tabla_profesores.Columns.Add(btnEditar);

            // Botón Acción (Alta/Baja)
            var btnAccion = new DataGridViewButtonColumn
            {
                Name = "Accion",
                HeaderText = "Acción",
                FlatStyle = FlatStyle.Flat,
                UseColumnTextForButtonValue = false,
                Width = 150
            };
            tabla_profesores.Columns.Add(btnAccion);

            // Estética/medidas
            tabla_profesores.RowTemplate.Height = 40;
            tabla_profesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Reasignar eventos para que no se dupliquen
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

            // Orden de columnas (si existen)
            int last = tabla_profesores.Columns.Count - 1;
            if (tabla_profesores.Columns.Contains("Editar"))
                tabla_profesores.Columns["Editar"].DisplayIndex = last--;
            if (tabla_profesores.Columns.Contains("Accion"))
                tabla_profesores.Columns["Accion"].DisplayIndex = last--;
            var cEstado = FindCol("estadoTexto");
            if (cEstado != null) cEstado.DisplayIndex = last--;

            tabla_profesores.ClearSelection();
        }


        // ========= NUEVO: búsqueda por DNI/Nombre =========
        private void BuscarEntrenador()
        {
            if (_dtEntrenadores == null || _dtEntrenadores.Rows.Count == 0)
                return;

            string term = textBox_DniEntrenadores?.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(term))
            {
                _bs.RemoveFilter();
                tabla_profesores.ClearSelection();
                return;
            }

            // Escapar comillas para RowFilter
            string esc(string s) => s.Replace("'", "''");

            // Si es numérico -> filtra por prefijo de DNI; si no, por nombre contiene
            if (int.TryParse(term, out _))
            {
                _bs.Filter = $"Convert(dni, 'System.String') LIKE '{esc(term)}%'";
            }
            else
            {
                _bs.Filter = $"nombre LIKE '%{esc(term)}%'";
            }

            tabla_profesores.ClearSelection();
        }

        // ========= NUEVO: botón BLimpiar =========
        private void LimpiarBusqueda()
        {
            if (textBox_DniEntrenadores != null)
                textBox_DniEntrenadores.Clear();

            _bs.RemoveFilter();
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

            var colName = tabla_profesores.Columns[e.ColumnIndex].Name;

            // boton editar
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
                return;
            }

            // accion de alta/baja
            if (colName == "Accion")
            {
                int idEntrenador = Convert.ToInt32(tabla_profesores.Rows[e.RowIndex].Cells["id_entrenador"].Value);
                string estadoActual = tabla_profesores.Rows[e.RowIndex].Cells["estadoTexto"].Value.ToString();
                bool activo = estadoActual == "Activo";

                if (activo)
                {
                    // BAJA con validación/migración
                    DialogResult result = MessageBox.Show(
                        "¿Seguro que quieres dar de baja este entrenador?\n\n" +
                        "Si tiene alumnos asignados, deberás transferirlos a otro entrenador.",
                        "Confirmar Baja",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        DarDeBajaConMigracion(idEntrenador);
                        CargarEntrenadores();
                    }
                }
                else
                {
                    // ALTA simple reutilizando tu método existente
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
                        CargarEntrenadores();
                    }
                }
            }
        }

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
