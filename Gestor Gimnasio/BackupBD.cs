using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class BackupBD : UserControl
    {
        private readonly string _csBase;

        private bool IsDesignMode =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode;

        public BackupBD()
        {
            InitializeComponent();
            if (IsDesignMode) return;

            _csBase = ConfigurationManager.ConnectionStrings["BaseDatos"]?.ConnectionString
                      ?? throw new InvalidOperationException("Falta la cadena de conexión 'BaseDatos' en app.config.");

            // Combo bases
            comboBox_BDBackup.DropDownStyle = ComboBoxStyle.DropDownList;

            // Botones
            BConectar.Click += BConectar_Click;
            BGenerarBackUp.Click += BGenerarBackUp_Click;

            // Grid
            ConfigurarGridHistorial(dgvBackups);
            GridStyler.Aplicar(dgvBackups);
            dgvBackups.CellContentClick += DgvBackups_CellContentClick;
            dgvBackups.CellDoubleClick += DgvBackups_CellDoubleClick;

            // Cargar automáticamente al abrir
            this.Load += BackupBD_Load;
        }

        // ==================== LOAD AUTOMÁTICO ====================
        private void BackupBD_Load(object sender, EventArgs e)
        {
            try
            {
                CargarBasesDeDatos();
                if (comboBox_BDBackup.Items.Count > 0)
                {
                    comboBox_BDBackup.SelectedIndex = 0;

                    using (var cn = new SqlConnection(GetMasterConnectionString(_csBase)))
                    {
                        cn.Open();
                        SugerirRutaPorDefectoServidor(cn);
                    }

                    CargarHistorialBackups(comboBox_BDBackup.Text);
                }
            }
            catch { /* ignora errores iniciales */ }

            // Forzar estilo
            GridStyler.ResetDesignerStyles(dgvBackups);
            GridStyler.AplicarFuerte(dgvBackups);
        }

        // ==================== BOTÓN CONECTAR ====================
        private void BConectar_Click(object sender, EventArgs e)
        {
            CargarBasesDeDatos();
            if (comboBox_BDBackup.Items.Count > 0)
            {
                comboBox_BDBackup.SelectedIndex = 0;
                using (var cn = new SqlConnection(GetMasterConnectionString(_csBase)))
                {
                    cn.Open();
                    SugerirRutaPorDefectoServidor(cn);
                }
                CargarHistorialBackups(comboBox_BDBackup.Text);
            }
        }

        // ==================== BOTÓN GENERAR BACKUP ====================
        private void BGenerarBackUp_Click(object sender, EventArgs e)
        {
            if (comboBox_BDBackup.SelectedItem == null)
            {
                MessageBox.Show("Seleccioná una base de datos.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dbName = comboBox_BDBackup.SelectedItem.ToString().Trim();
            var filePath = textBox_RutaBackup.Text.Trim();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                MessageBox.Show("No hay ruta de backup configurada.",
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var cn = new SqlConnection(GetMasterConnectionString(_csBase)))
                using (var cmd = cn.CreateCommand())
                {
                    cn.Open();

                    cmd.CommandText = @"
DECLARE @db sysname = @p_db;
DECLARE @path nvarchar(4000) = @p_path;
DECLARE @sql nvarchar(max) =
N'BACKUP DATABASE ' + QUOTENAME(@db) + N'
  TO DISK = @p
  WITH COPY_ONLY, INIT, FORMAT, SKIP, STATS = 5,
       NAME = ' + QUOTENAME(@db + N' Full Backup (' + CONVERT(varchar(19), GETDATE(), 120) + N')', '''') + N';';
EXEC sp_executesql @sql, N'@p nvarchar(4000)', @p = @path;";
                    cmd.Parameters.AddWithValue("@p_db", dbName);
                    cmd.Parameters.AddWithValue("@p_path", filePath);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Backup generado correctamente:\r\n" + filePath,
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarHistorialBackups(dbName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el backup:\r\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ==================== MÉTODOS AUXILIARES ====================

        private void CargarBasesDeDatos()
        {
            comboBox_BDBackup.Items.Clear();

            using (var cn = new SqlConnection(GetMasterConnectionString(_csBase)))
            using (var cmd = cn.CreateCommand())
            {
                cn.Open();
                cmd.CommandText = @"SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name;";
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        comboBox_BDBackup.Items.Add(rd.GetString(0));
                }
            }
        }

        private void CargarHistorialBackups(string dbName)
        {
            try
            {
                var dt = new DataTable();

                using (var cn = new SqlConnection(GetMasterConnectionString(_csBase)))
                using (var cmd = cn.CreateCommand())
                using (var da = new SqlDataAdapter(cmd))
                {
                    cn.Open();
                    cmd.CommandText = @"
SELECT TOP 200
    bs.database_name AS [Base],
    CASE bs.type WHEN 'D' THEN 'Full' WHEN 'I' THEN 'Diff' WHEN 'L' THEN 'Log' ELSE bs.type END AS [Tipo],
    bs.backup_start_date AS [Inicio],
    bs.backup_finish_date AS [Fin],
    bmf.physical_device_name AS [Ruta]
FROM msdb.dbo.backupset AS bs
LEFT JOIN msdb.dbo.backupmediafamily AS bmf
  ON bs.media_set_id = bmf.media_set_id
WHERE bs.database_name = @db
ORDER BY bs.backup_finish_date DESC;";
                    cmd.Parameters.AddWithValue("@db", dbName);
                    da.Fill(dt);
                }

                dgvBackups.DataSource = dt;
                AjustarColumnasHistorial(dgvBackups);
                GridStyler.ResetDesignerStyles(dgvBackups);
                GridStyler.AplicarFuerte(dgvBackups);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo leer el historial de backups:\r\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SugerirRutaPorDefectoServidor(SqlConnection cn)
        {
            try
            {
                using (var cmd = cn.CreateCommand())
                {
                    cmd.CommandText = @"
DECLARE @dir nvarchar(4000);
EXEC master.dbo.xp_instance_regread
    N'HKEY_LOCAL_MACHINE',
    N'SOFTWARE\Microsoft\MSSQLServer\MSSQLServer',
    N'BackupDirectory',
    @dir OUTPUT;
SELECT @dir;";
                    var ruta = cmd.ExecuteScalar() as string;
                    var db = comboBox_BDBackup.SelectedItem as string ?? "BackupDB";
                    var stamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                    textBox_RutaBackup.Text = Path.Combine(ruta ?? "C:\\", $"{db}_{stamp}.bak");
                }
            }
            catch { }
        }

        private static string GetMasterConnectionString(string cs)
        {
            var sb = new SqlConnectionStringBuilder(cs) { InitialCatalog = "master" };
            return sb.ConnectionString;
        }

        private static void ConfigurarGridHistorial(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AutoGenerateColumns = true;
        }

        private static void AjustarColumnasHistorial(DataGridView dgv)
        {
            if (dgv.Columns.Count == 0) return;
            if (dgv.Columns["Ruta"] != null && !(dgv.Columns["Ruta"] is DataGridViewLinkColumn))
            {
                var idx = dgv.Columns["Ruta"].Index;
                var link = new DataGridViewLinkColumn
                {
                    Name = "colRuta",
                    HeaderText = "Ruta (.bak)",
                    DataPropertyName = "Ruta",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    TrackVisitedState = false
                };
                dgv.Columns.RemoveAt(idx);
                dgv.Columns.Insert(idx, link);
            }

            if (dgv.Columns["Inicio"] != null)
                dgv.Columns["Inicio"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            if (dgv.Columns["Fin"] != null)
                dgv.Columns["Fin"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
        }

        private void DgvBackups_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvBackups.Columns[e.ColumnIndex].Name != "colRuta") return;
            var path = Convert.ToString(dgvBackups.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            AbrirRutaEnExplorer(path);
        }

        private void DgvBackups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var path = Convert.ToString(dgvBackups.Rows[e.RowIndex].Cells["colRuta"].Value);
            AbrirRutaEnExplorer(path);
        }

        private static void AbrirRutaEnExplorer(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return;

            try
            {
                if (File.Exists(path))
                {
                    Process.Start("explorer.exe", "/select,\"" + path + "\"");
                    return;
                }

                var dir = Path.GetDirectoryName(path);
                if (Directory.Exists(dir))
                {
                    Process.Start("explorer.exe", "\"" + dir + "\"");
                    return;
                }

                MessageBox.Show("No se encontró la ruta:\r\n" + path, "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la ruta:\r\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // ==================== GRID STYLER ====================
    internal static class GridStyler
    {
        private static readonly Color verdeEncabezado = ColorTranslator.FromHtml("#014A16");
        private static readonly Color verdeAlterna = ColorTranslator.FromHtml("#EDFFEF");
        private static readonly Color hoverSuave = ColorTranslator.FromHtml("#DCEFE6");

        public static void Aplicar(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.EnableHeadersVisualStyles = false;

            // ======== Fuentes ========
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12f, FontStyle.Bold);

            // ======== Encabezados ========
            dgv.ColumnHeadersDefaultCellStyle.BackColor = verdeEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Evita “celeste” al seleccionar encabezado
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = verdeEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            // ======== Celdas ========
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;

            // Sin color azul de selección en filas
            dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
            dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;

            // Alterna
            dgv.AlternatingRowsDefaultCellStyle.BackColor = verdeAlterna;
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = verdeAlterna;
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;

            // Hover suave (no es selección)
            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = hoverSuave;
            };
            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                        (e.RowIndex % 2 == 0) ? Color.White : verdeAlterna;
            };
        }

        public static void ResetDesignerStyles(DataGridView dgv)
        {
            if (dgv == null) return;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.DefaultCellStyle = new DataGridViewCellStyle();
                col.HeaderCell.Style = new DataGridViewCellStyle();
            }
        }

        public static void AplicarFuerte(DataGridView dgv)
        {
            Aplicar(dgv);
            // refuerza también para filas creadas tras setear DataSource
            dgv.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Regular);
            dgv.Invalidate();
            dgv.Refresh();
        }
    }
}
