using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class ReporteCobros: Form
    {
        private string CS => ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public ReporteCobros()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarAdministradores();

            B_Buscar.Click -= B_Buscar_Click;
            B_Buscar.Click += B_Buscar_Click;
        }

        // ===================== COMBOBOX =====================
        private void CargarAdministradores()
        {
            cb_nombre_admin.DataSource = null;
            cb_nombre_admin.Items.Clear();
            cb_nombre_admin.DropDownStyle = ComboBoxStyle.DropDownList;

            const string sql = @"
SELECT u.id_usuario, u.nombre
FROM dbo.Usuario u
JOIN dbo.Rol r ON r.id_rol = u.id_rol
WHERE u.activo = 1 AND r.tipo_rol = 'Administrador'
ORDER BY u.nombre;";

            var dt = new DataTable();
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.Fill(dt);
            }

            if (dt.Rows.Count == 0)
            {
                cb_nombre_admin.Items.Add("— No hay administradores activos —");
                cb_nombre_admin.SelectedIndex = 0;
                cb_nombre_admin.Enabled = false;
                return;
            }

            cb_nombre_admin.DisplayMember = "nombre";
            cb_nombre_admin.ValueMember = "id_usuario";
            cb_nombre_admin.DataSource = dt;
            cb_nombre_admin.SelectedIndex = 0;
        }

        // ===================== GRID =====================
        private void ConfigurarGrid()
        {
            var dgv = dataGridView_Clientes;
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIdAlumno", HeaderText = "ID Alumno", DataPropertyName = "id_alumno", Visible = false });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre" });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDni", HeaderText = "DNI", DataPropertyName = "dni", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colTurno", HeaderText = "Turno", DataPropertyName = "turno", Width = 120 });

            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colAnio", HeaderText = "Año", DataPropertyName = "anio", Width = 60 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { Name = "colMes", HeaderText = "Mes", DataPropertyName = "mes", Width = 60 });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaPago",
                HeaderText = "Fecha de pago",
                DataPropertyName = "fecha_pago",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 110
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMonto",
                HeaderText = "Monto",
                DataPropertyName = "monto",
                DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 100
            });
        }

        // ===================== BOTÓN BUSCAR =====================
        private void B_Buscar_Click(object sender, EventArgs e)
        {
            if (cb_nombre_admin.SelectedValue == null || !cb_nombre_admin.Enabled)
            {
                MessageBox.Show("Seleccioná un administrador válido.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idAdmin = Convert.ToInt32(cb_nombre_admin.SelectedValue);
            var tabla = ObtenerClientesCobradosPorAdministrador(idAdmin);

            dataGridView_Clientes.DataSource = tabla;

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros de cobros para este administrador.", "Sin resultados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ===================== CONSULTA PRINCIPAL =====================
        private DataTable ObtenerClientesCobradosPorAdministrador(int idAdmin)
        {
            const string sql = @"
SELECT 
    a.id_alumno,
    a.nombre,
    a.dni,
    t.descripcion AS turno,
    c.anio,
    c.mes,
    p.fecha_pago,
    p.monto
FROM dbo.Pago p
JOIN dbo.Cuota c ON c.id_cuota = p.id_cuota
JOIN dbo.Alumno a ON a.id_alumno = c.id_alumno
JOIN dbo.Turno t ON t.id_turno = a.id_turno
WHERE p.id_admin = @id_admin
ORDER BY p.fecha_pago DESC, a.nombre;";

            var dt = new DataTable();
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@id_admin", SqlDbType.Int).Value = idAdmin;
                da.Fill(dt);
            }
            return dt;
        }
    }
}
