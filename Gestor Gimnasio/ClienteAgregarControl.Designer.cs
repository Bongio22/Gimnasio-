namespace Gestor_Gimnasio
{
    partial class ClienteAgregarControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxRegistro = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha_nac = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaAlta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCorreo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.comboBoxProfesor = new System.Windows.Forms.ComboBox();
            this.lProfesor = new System.Windows.Forms.Label();
            this.comboBoxTurno = new System.Windows.Forms.ComboBox();
            this.lTurno = new System.Windows.Forms.Label();
            this.textBoxDomicilio = new System.Windows.Forms.TextBox();
            this.lDomicilio = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.lTelefono = new System.Windows.Forms.Label();
            this.Ldni = new System.Windows.Forms.Label();
            this.Lnombre = new System.Windows.Forms.Label();
            this.lRegistro = new System.Windows.Forms.Label();
            this.dataGridView_ListaClientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_DniClientes = new System.Windows.Forms.TextBox();
            this.B_BuscarCliente = new System.Windows.Forms.Button();
            this.groupBoxRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxRegistro
            // 
            this.groupBoxRegistro.Controls.Add(this.label5);
            this.groupBoxRegistro.Controls.Add(this.dtpFecha_nac);
            this.groupBoxRegistro.Controls.Add(this.label4);
            this.groupBoxRegistro.Controls.Add(this.dtpFechaAlta);
            this.groupBoxRegistro.Controls.Add(this.label3);
            this.groupBoxRegistro.Controls.Add(this.textBoxCorreo);
            this.groupBoxRegistro.Controls.Add(this.btnCancelar);
            this.groupBoxRegistro.Controls.Add(this.btnGuardar);
            this.groupBoxRegistro.Controls.Add(this.comboBoxProfesor);
            this.groupBoxRegistro.Controls.Add(this.lProfesor);
            this.groupBoxRegistro.Controls.Add(this.comboBoxTurno);
            this.groupBoxRegistro.Controls.Add(this.lTurno);
            this.groupBoxRegistro.Controls.Add(this.textBoxDomicilio);
            this.groupBoxRegistro.Controls.Add(this.lDomicilio);
            this.groupBoxRegistro.Controls.Add(this.textBoxTelefono);
            this.groupBoxRegistro.Controls.Add(this.textBoxDNI);
            this.groupBoxRegistro.Controls.Add(this.textBoxNombre);
            this.groupBoxRegistro.Controls.Add(this.lTelefono);
            this.groupBoxRegistro.Controls.Add(this.Ldni);
            this.groupBoxRegistro.Controls.Add(this.Lnombre);
            this.groupBoxRegistro.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRegistro.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBoxRegistro.Location = new System.Drawing.Point(100, 119);
            this.groupBoxRegistro.Name = "groupBoxRegistro";
            this.groupBoxRegistro.Size = new System.Drawing.Size(967, 387);
            this.groupBoxRegistro.TabIndex = 0;
            this.groupBoxRegistro.TabStop = false;
            this.groupBoxRegistro.Text = "Datos del Cliente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(716, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Fecha de nacimiento";
            // 
            // dtpFecha_nac
            // 
            this.dtpFecha_nac.Location = new System.Drawing.Point(720, 73);
            this.dtpFecha_nac.Name = "dtpFecha_nac";
            this.dtpFecha_nac.Size = new System.Drawing.Size(202, 30);
            this.dtpFecha_nac.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(375, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 23);
            this.label4.TabIndex = 27;
            this.label4.Text = "Correo";
            // 
            // dtpFechaAlta
            // 
            this.dtpFechaAlta.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dtpFechaAlta.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dtpFechaAlta.CalendarTitleForeColor = System.Drawing.Color.GreenYellow;
            this.dtpFechaAlta.Location = new System.Drawing.Point(550, 271);
            this.dtpFechaAlta.Name = "dtpFechaAlta";
            this.dtpFechaAlta.Size = new System.Drawing.Size(200, 30);
            this.dtpFechaAlta.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(546, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Fecha de alta";
            // 
            // textBoxCorreo
            // 
            this.textBoxCorreo.Location = new System.Drawing.Point(379, 174);
            this.textBoxCorreo.Name = "textBoxCorreo";
            this.textBoxCorreo.Size = new System.Drawing.Size(312, 30);
            this.textBoxCorreo.TabIndex = 28;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(822, 328);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 35);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkGreen;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(695, 328);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 35);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // comboBoxProfesor
            // 
            this.comboBoxProfesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProfesor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxProfesor.Location = new System.Drawing.Point(287, 271);
            this.comboBoxProfesor.Name = "comboBoxProfesor";
            this.comboBoxProfesor.Size = new System.Drawing.Size(226, 28);
            this.comboBoxProfesor.TabIndex = 11;
            // 
            // lProfesor
            // 
            this.lProfesor.AutoSize = true;
            this.lProfesor.Location = new System.Drawing.Point(283, 245);
            this.lProfesor.Name = "lProfesor";
            this.lProfesor.Size = new System.Drawing.Size(77, 23);
            this.lProfesor.TabIndex = 10;
            this.lProfesor.Text = "Profesor";
            // 
            // comboBoxTurno
            // 
            this.comboBoxTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTurno.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxTurno.Location = new System.Drawing.Point(40, 271);
            this.comboBoxTurno.Name = "comboBoxTurno";
            this.comboBoxTurno.Size = new System.Drawing.Size(200, 28);
            this.comboBoxTurno.TabIndex = 9;
            this.comboBoxTurno.SelectedIndexChanged += new System.EventHandler(this.comboBoxTurno_SelectedIndexChanged);
            // 
            // lTurno
            // 
            this.lTurno.AutoSize = true;
            this.lTurno.Location = new System.Drawing.Point(36, 245);
            this.lTurno.Name = "lTurno";
            this.lTurno.Size = new System.Drawing.Size(56, 23);
            this.lTurno.TabIndex = 8;
            this.lTurno.Text = "Turno";
            // 
            // textBoxDomicilio
            // 
            this.textBoxDomicilio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDomicilio.Location = new System.Drawing.Point(40, 177);
            this.textBoxDomicilio.Name = "textBoxDomicilio";
            this.textBoxDomicilio.Size = new System.Drawing.Size(308, 27);
            this.textBoxDomicilio.TabIndex = 7;
            this.textBoxDomicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDomicilio_KeyPress);
            // 
            // lDomicilio
            // 
            this.lDomicilio.AutoSize = true;
            this.lDomicilio.Location = new System.Drawing.Point(40, 151);
            this.lDomicilio.Name = "lDomicilio";
            this.lDomicilio.Size = new System.Drawing.Size(87, 23);
            this.lDomicilio.TabIndex = 6;
            this.lDomicilio.Text = "Domicilio";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxTelefono.Location = new System.Drawing.Point(720, 177);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(200, 27);
            this.textBoxTelefono.TabIndex = 5;
            this.textBoxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTelefono_KeyPress);
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDNI.Location = new System.Drawing.Point(450, 78);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(211, 27);
            this.textBoxDNI.TabIndex = 3;
            this.textBoxDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDNI_KeyPress);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxNombre.Location = new System.Drawing.Point(40, 78);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(364, 27);
            this.textBoxNombre.TabIndex = 1;
            this.textBoxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombre_KeyPress);
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Location = new System.Drawing.Point(716, 151);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(78, 23);
            this.lTelefono.TabIndex = 4;
            this.lTelefono.Text = "Teléfono";
            // 
            // Ldni
            // 
            this.Ldni.AutoSize = true;
            this.Ldni.Location = new System.Drawing.Point(446, 52);
            this.Ldni.Name = "Ldni";
            this.Ldni.Size = new System.Drawing.Size(41, 23);
            this.Ldni.TabIndex = 2;
            this.Ldni.Text = "DNI";
            // 
            // Lnombre
            // 
            this.Lnombre.AutoSize = true;
            this.Lnombre.Location = new System.Drawing.Point(40, 52);
            this.Lnombre.Name = "Lnombre";
            this.Lnombre.Size = new System.Drawing.Size(163, 23);
            this.Lnombre.TabIndex = 0;
            this.Lnombre.Text = "Nombre y Apellido";
            // 
            // lRegistro
            // 
            this.lRegistro.AutoSize = true;
            this.lRegistro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lRegistro.ForeColor = System.Drawing.Color.DarkGreen;
            this.lRegistro.Location = new System.Drawing.Point(95, 57);
            this.lRegistro.Name = "lRegistro";
            this.lRegistro.Size = new System.Drawing.Size(234, 28);
            this.lRegistro.TabIndex = 1;
            this.lRegistro.Text = "REGISTRO DE CLIENTES";
            // 
            // dataGridView_ListaClientes
            // 
            this.dataGridView_ListaClientes.BackgroundColor = System.Drawing.Color.GreenYellow;
            this.dataGridView_ListaClientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ListaClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ListaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_ListaClientes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ListaClientes.Location = new System.Drawing.Point(149, 561);
            this.dataGridView_ListaClientes.Name = "dataGridView_ListaClientes";
            this.dataGridView_ListaClientes.RowHeadersWidth = 51;
            this.dataGridView_ListaClientes.RowTemplate.Height = 24;
            this.dataGridView_ListaClientes.Size = new System.Drawing.Size(941, 365);
            this.dataGridView_ListaClientes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(95, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "LISTA DE CLIENTES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(661, 523);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ingresar DNI";
            // 
            // textBox_DniClientes
            // 
            this.textBox_DniClientes.Location = new System.Drawing.Point(787, 520);
            this.textBox_DniClientes.Name = "textBox_DniClientes";
            this.textBox_DniClientes.Size = new System.Drawing.Size(201, 30);
            this.textBox_DniClientes.TabIndex = 5;
            // 
            // B_BuscarCliente
            // 
            this.B_BuscarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_BuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BuscarCliente.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_BuscarCliente.ForeColor = System.Drawing.Color.White;
            this.B_BuscarCliente.Location = new System.Drawing.Point(994, 518);
            this.B_BuscarCliente.Name = "B_BuscarCliente";
            this.B_BuscarCliente.Size = new System.Drawing.Size(96, 32);
            this.B_BuscarCliente.TabIndex = 6;
            this.B_BuscarCliente.Text = "Buscar";
            this.B_BuscarCliente.UseVisualStyleBackColor = false;
            // 
            // ClienteAgregarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.B_BuscarCliente);
            this.Controls.Add(this.textBox_DniClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_ListaClientes);
            this.Controls.Add(this.lRegistro);
            this.Controls.Add(this.groupBoxRegistro);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ClienteAgregarControl";
            this.Size = new System.Drawing.Size(1191, 941);
            this.Load += new System.EventHandler(this.ClienteAgregarControl_Load);
            this.groupBoxRegistro.ResumeLayout(false);
            this.groupBoxRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRegistro;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox comboBoxProfesor;
        private System.Windows.Forms.Label lProfesor;
        private System.Windows.Forms.ComboBox comboBoxTurno;
        private System.Windows.Forms.Label lTurno;
        private System.Windows.Forms.TextBox textBoxDomicilio;
        private System.Windows.Forms.Label lDomicilio;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label lTelefono;
        private System.Windows.Forms.Label Ldni;
        private System.Windows.Forms.Label Lnombre;
        private System.Windows.Forms.Label lRegistro;
        private System.Windows.Forms.DataGridView dataGridView_ListaClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_DniClientes;
        private System.Windows.Forms.Button B_BuscarCliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaAlta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCorreo;
        private System.Windows.Forms.DateTimePicker dtpFecha_nac;
        private System.Windows.Forms.Label label5;
    }
}