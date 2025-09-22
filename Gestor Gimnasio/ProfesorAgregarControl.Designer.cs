using System.Windows.Forms;
using System.Drawing;

namespace Gestor_Gimnasio
{
    partial class ProfesorAgregarControl
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox groupBoxRegistroProf;
        private Label lTitulo;
        private Label lNombre;
        private Label lDni;
        private Label lTelefono;
        private Label lDomicilio;
        private Label lCupo;
        private TextBox textBoxNombre;
        private TextBox textBoxDNI;
        private TextBox textBoxTelefono;
        private TextBox textBoxDomicilio;
        private NumericUpDown numCupo;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnCancelar;
        private System.Windows.Forms.Label lTurno;
        private System.Windows.Forms.ComboBox comboBoxTurno;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lTitulo = new System.Windows.Forms.Label();
            this.groupBoxRegistroProf = new System.Windows.Forms.GroupBox();
            this.lTurno = new System.Windows.Forms.Label();
            this.comboBoxTurno = new System.Windows.Forms.ComboBox();
            this.lNombre = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.lDni = new System.Windows.Forms.Label();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.lTelefono = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.lDomicilio = new System.Windows.Forms.Label();
            this.textBoxDomicilio = new System.Windows.Forms.TextBox();
            this.lCupo = new System.Windows.Forms.Label();
            this.numCupo = new System.Windows.Forms.NumericUpDown();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabla_profesores = new System.Windows.Forms.DataGridView();
            this.groupBoxRegistroProf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCupo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_profesores)).BeginInit();
            this.SuspendLayout();
            // 
            // lTitulo
            // 
            this.lTitulo.AutoSize = true;
            this.lTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lTitulo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lTitulo.Location = new System.Drawing.Point(95, 54);
            this.lTitulo.Name = "lTitulo";
            this.lTitulo.Size = new System.Drawing.Size(226, 28);
            this.lTitulo.TabIndex = 0;
            this.lTitulo.Text = "Registro de Profesores";
            // 
            // groupBoxRegistroProf
            // 
            this.groupBoxRegistroProf.Controls.Add(this.lTurno);
            this.groupBoxRegistroProf.Controls.Add(this.comboBoxTurno);
            this.groupBoxRegistroProf.Controls.Add(this.lNombre);
            this.groupBoxRegistroProf.Controls.Add(this.textBoxNombre);
            this.groupBoxRegistroProf.Controls.Add(this.lDni);
            this.groupBoxRegistroProf.Controls.Add(this.textBoxDNI);
            this.groupBoxRegistroProf.Controls.Add(this.lTelefono);
            this.groupBoxRegistroProf.Controls.Add(this.textBoxTelefono);
            this.groupBoxRegistroProf.Controls.Add(this.lDomicilio);
            this.groupBoxRegistroProf.Controls.Add(this.textBoxDomicilio);
            this.groupBoxRegistroProf.Controls.Add(this.lCupo);
            this.groupBoxRegistroProf.Controls.Add(this.numCupo);
            this.groupBoxRegistroProf.Controls.Add(this.chkActivo);
            this.groupBoxRegistroProf.Controls.Add(this.btnGuardar);
            this.groupBoxRegistroProf.Controls.Add(this.btnCancelar);
            this.groupBoxRegistroProf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxRegistroProf.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBoxRegistroProf.Location = new System.Drawing.Point(166, 115);
            this.groupBoxRegistroProf.Name = "groupBoxRegistroProf";
            this.groupBoxRegistroProf.Size = new System.Drawing.Size(941, 361);
            this.groupBoxRegistroProf.TabIndex = 1;
            this.groupBoxRegistroProf.TabStop = false;
            this.groupBoxRegistroProf.Text = "Datos del Profesor";
            // 
            // lTurno
            // 
            this.lTurno.AutoSize = true;
            this.lTurno.Location = new System.Drawing.Point(386, 144);
            this.lTurno.Name = "lTurno";
            this.lTurno.Size = new System.Drawing.Size(56, 23);
            this.lTurno.TabIndex = 10;
            this.lTurno.Text = "Turno";
            // 
            // comboBoxTurno
            // 
            this.comboBoxTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTurno.FormattingEnabled = true;
            this.comboBoxTurno.Location = new System.Drawing.Point(390, 170);
            this.comboBoxTurno.Name = "comboBoxTurno";
            this.comboBoxTurno.Size = new System.Drawing.Size(200, 31);
            this.comboBoxTurno.TabIndex = 11;
            this.comboBoxTurno.SelectedIndexChanged += new System.EventHandler(this.comboBoxTurno_SelectedIndexChanged);
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Location = new System.Drawing.Point(42, 55);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(163, 23);
            this.lNombre.TabIndex = 12;
            this.lNombre.Text = "Nombre y Apellido";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(46, 81);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(300, 30);
            this.textBoxNombre.TabIndex = 13;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBoxNombre_TextChanged);
            // 
            // lDni
            // 
            this.lDni.AutoSize = true;
            this.lDni.Location = new System.Drawing.Point(386, 55);
            this.lDni.Name = "lDni";
            this.lDni.Size = new System.Drawing.Size(41, 23);
            this.lDni.TabIndex = 14;
            this.lDni.Text = "DNI";
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(390, 81);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(233, 30);
            this.textBoxDNI.TabIndex = 15;
            this.textBoxDNI.TextChanged += new System.EventHandler(this.textBoxDNI_TextChanged);
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Location = new System.Drawing.Point(657, 55);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(78, 23);
            this.lTelefono.TabIndex = 16;
            this.lTelefono.Text = "Teléfono";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(661, 81);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(233, 30);
            this.textBoxTelefono.TabIndex = 17;
            // 
            // lDomicilio
            // 
            this.lDomicilio.AutoSize = true;
            this.lDomicilio.Location = new System.Drawing.Point(42, 144);
            this.lDomicilio.Name = "lDomicilio";
            this.lDomicilio.Size = new System.Drawing.Size(87, 23);
            this.lDomicilio.TabIndex = 18;
            this.lDomicilio.Text = "Domicilio";
            // 
            // textBoxDomicilio
            // 
            this.textBoxDomicilio.Location = new System.Drawing.Point(46, 170);
            this.textBoxDomicilio.Name = "textBoxDomicilio";
            this.textBoxDomicilio.Size = new System.Drawing.Size(300, 30);
            this.textBoxDomicilio.TabIndex = 19;
            // 
            // lCupo
            // 
            this.lCupo.AutoSize = true;
            this.lCupo.Location = new System.Drawing.Point(42, 256);
            this.lCupo.Name = "lCupo";
            this.lCupo.Size = new System.Drawing.Size(52, 23);
            this.lCupo.TabIndex = 20;
            this.lCupo.Text = "Cupo";
            // 
            // numCupo
            // 
            this.numCupo.Location = new System.Drawing.Point(120, 254);
            this.numCupo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCupo.Name = "numCupo";
            this.numCupo.Size = new System.Drawing.Size(120, 30);
            this.numCupo.TabIndex = 21;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Checked = true;
            this.chkActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActivo.Location = new System.Drawing.Point(274, 257);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(83, 27);
            this.chkActivo.TabIndex = 22;
            this.chkActivo.Text = "Activo";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(599, 290);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(774, 290);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 35);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabla_profesores
            // 
            this.tabla_profesores.AllowUserToAddRows = false;
            this.tabla_profesores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabla_profesores.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tabla_profesores.BackgroundColor = System.Drawing.Color.GreenYellow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabla_profesores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tabla_profesores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.GreenYellow;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tabla_profesores.DefaultCellStyle = dataGridViewCellStyle2;
            this.tabla_profesores.GridColor = System.Drawing.Color.GreenYellow;
            this.tabla_profesores.Location = new System.Drawing.Point(183, 506);
            this.tabla_profesores.Name = "tabla_profesores";
            this.tabla_profesores.RowHeadersWidth = 51;
            this.tabla_profesores.RowTemplate.Height = 24;
            this.tabla_profesores.Size = new System.Drawing.Size(907, 264);
            this.tabla_profesores.TabIndex = 2;
            this.tabla_profesores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tabla_profesores_CellContentClick_1);
            // 
            // ProfesorAgregarControl
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tabla_profesores);
            this.Controls.Add(this.lTitulo);
            this.Controls.Add(this.groupBoxRegistroProf);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ProfesorAgregarControl";
            this.Size = new System.Drawing.Size(1191, 800);
            this.Load += new System.EventHandler(this.ProfesorAgregarControl_Load);
            this.groupBoxRegistroProf.ResumeLayout(false);
            this.groupBoxRegistroProf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCupo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabla_profesores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridView tabla_profesores;
    }
}
