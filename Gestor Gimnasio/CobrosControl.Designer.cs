using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    partial class CobrosControl
    {
        private IContainer components = null;

        private Label lblTitulo;

        private GroupBox grpBuscar;
        private Label lblDni;
        private TextBox txtDni;
        private Button btnBuscar;

        private GroupBox grpCobro;
        private Label lblAlumno;
        private Label lblAlumnoNombre;
        private Label lblSiguiente;
        private Label lblProximoPeriodo;
        private Label lblMonto;
        private TextBox txtMonto;
        private Button btnPagar;

        private GroupBox grpPendientes;
        private DataGridView dgvPendientes;
        private Label lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();

            this.lblTitulo = new Label();

            this.grpBuscar = new GroupBox();
            this.lblDni = new Label();
            this.txtDni = new TextBox();
            this.btnBuscar = new Button();

            this.grpCobro = new GroupBox();
            this.lblAlumno = new Label();
            this.lblAlumnoNombre = new Label();
            this.lblSiguiente = new Label();
            this.lblProximoPeriodo = new Label();
            this.lblMonto = new Label();
            this.txtMonto = new TextBox();
            this.btnPagar = new Button();

            this.grpPendientes = new GroupBox();
            this.dgvPendientes = new DataGridView();
            this.lblTotal = new Label();

            ((ISupportInitialize)(this.dgvPendientes)).BeginInit();
            this.grpBuscar.SuspendLayout();
            this.grpCobro.SuspendLayout();
            this.grpPendientes.SuspendLayout();
            this.SuspendLayout();

            // ====== Control ======
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 9F);
            this.Name = "CobrosControl";
            this.Size = new Size(1100, 720);

            // ====== Título ======
            this.lblTitulo.Text = "Cobros";
            this.lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitulo.Location = new Point(16, 12);
            this.lblTitulo.AutoSize = true;

            // ====== Buscar ======
            this.grpBuscar.Text = "Buscar alumno";
            this.grpBuscar.Location = new Point(16, 56);
            this.grpBuscar.Size = new Size(1068, 80);
            this.grpBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.lblDni.Text = "DNI";
            this.lblDni.Location = new Point(16, 36);
            this.lblDni.AutoSize = true;

            this.txtDni.Location = new Point(56, 32);
            this.txtDni.Size = new Size(140, 26);

            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Location = new Point(210, 28);
            this.btnBuscar.Size = new Size(100, 32);
            this.btnBuscar.FlatStyle = FlatStyle.Flat;

            this.grpBuscar.Controls.Add(this.lblDni);
            this.grpBuscar.Controls.Add(this.txtDni);
            this.grpBuscar.Controls.Add(this.btnBuscar);

            // ====== Cobro ======
            this.grpCobro.Text = "Cobro";
            this.grpCobro.Location = new Point(16, 144);
            this.grpCobro.Size = new Size(1068, 120);
            this.grpCobro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.lblAlumno.Text = "Alumno";
            this.lblAlumno.Location = new Point(16, 32);
            this.lblAlumno.AutoSize = true;

            this.lblAlumnoNombre.Text = "—";
            this.lblAlumnoNombre.Location = new Point(80, 32);
            this.lblAlumnoNombre.AutoSize = true;
            this.lblAlumnoNombre.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            this.lblSiguiente.Text = "Cobertura actual / próximo vencimiento";
            this.lblSiguiente.Location = new Point(16, 64);
            this.lblSiguiente.AutoSize = true;

            this.lblProximoPeriodo.Text = "—";
            this.lblProximoPeriodo.Location = new Point(280, 64);
            this.lblProximoPeriodo.AutoSize = true;

            this.lblMonto.Text = "Monto $";
            this.lblMonto.Location = new Point(760, 32);
            this.lblMonto.AutoSize = true;
            this.lblMonto.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.txtMonto.Location = new Point(820, 28);
            this.txtMonto.Size = new Size(120, 26);
            this.txtMonto.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.btnPagar.Text = "Pagar";
            this.btnPagar.Location = new Point(952, 27);
            this.btnPagar.Size = new Size(96, 30);
            this.btnPagar.FlatStyle = FlatStyle.Flat;
            this.btnPagar.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.grpCobro.Controls.Add(this.lblAlumno);
            this.grpCobro.Controls.Add(this.lblAlumnoNombre);
            this.grpCobro.Controls.Add(this.lblSiguiente);
            this.grpCobro.Controls.Add(this.lblProximoPeriodo);
            this.grpCobro.Controls.Add(this.lblMonto);
            this.grpCobro.Controls.Add(this.txtMonto);
            this.grpCobro.Controls.Add(this.btnPagar);

            // ====== Estado de cobertura (antes: "Cuotas pendientes") ======
            this.grpPendientes.Text = "Estado de cobertura";
            this.grpPendientes.Location = new Point(16, 272);
            this.grpPendientes.Size = new Size(1068, 400);
            this.grpPendientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            this.dgvPendientes.Location = new Point(16, 28);
            this.dgvPendientes.Size = new Size(1036, 332);
            this.dgvPendientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.RowHeadersVisible = false;
            this.dgvPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Columnas: mostramos estado/cobertura (nombre, dni, vencimiento, estado)
            this.dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre",
                FillWeight = 35
            });
            this.dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "dni",
                FillWeight = 18,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            this.dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVto",
                HeaderText = "Vence / Cubre hasta",
                DataPropertyName = "fecha_vencimiento",
                FillWeight = 22,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy", Alignment = DataGridViewContentAlignment.MiddleCenter }
            });
            this.dgvPendientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "estado_texto",
                FillWeight = 18,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            this.lblTotal.Text = "—";
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new Point(16, 368);
            this.lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.grpPendientes.Controls.Add(this.dgvPendientes);
            this.grpPendientes.Controls.Add(this.lblTotal);

            // ====== Add Controls ======
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.grpBuscar);
            this.Controls.Add(this.grpCobro);
            this.Controls.Add(this.grpPendientes);

            ((ISupportInitialize)(this.dgvPendientes)).EndInit();
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            this.grpCobro.ResumeLayout(false);
            this.grpCobro.PerformLayout();
            this.grpPendientes.ResumeLayout(false);
            this.grpPendientes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
