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
            this.groupBoxRegistro = new System.Windows.Forms.GroupBox();
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
            this.groupBoxRegistro.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRegistro
            // 
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
            this.groupBoxRegistro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxRegistro.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBoxRegistro.Location = new System.Drawing.Point(104, 92);
            this.groupBoxRegistro.Name = "groupBoxRegistro";
            this.groupBoxRegistro.Size = new System.Drawing.Size(941, 361);
            this.groupBoxRegistro.TabIndex = 0;
            this.groupBoxRegistro.TabStop = false;
            this.groupBoxRegistro.Text = "Datos del Alumno";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(807, 285);
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
            this.btnGuardar.Location = new System.Drawing.Point(680, 285);
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
            this.comboBoxProfesor.Location = new System.Drawing.Point(707, 187);
            this.comboBoxProfesor.Name = "comboBoxProfesor";
            this.comboBoxProfesor.Size = new System.Drawing.Size(200, 28);
            this.comboBoxProfesor.TabIndex = 11;
            // 
            // lProfesor
            // 
            this.lProfesor.AutoSize = true;
            this.lProfesor.Location = new System.Drawing.Point(703, 161);
            this.lProfesor.Name = "lProfesor";
            this.lProfesor.Size = new System.Drawing.Size(77, 23);
            this.lProfesor.TabIndex = 10;
            this.lProfesor.Text = "Profesor";
            // 
            // comboBoxTurno
            // 
            this.comboBoxTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTurno.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxTurno.Location = new System.Drawing.Point(419, 187);
            this.comboBoxTurno.Name = "comboBoxTurno";
            this.comboBoxTurno.Size = new System.Drawing.Size(200, 28);
            this.comboBoxTurno.TabIndex = 9;
            this.comboBoxTurno.SelectedIndexChanged += new System.EventHandler(this.comboBoxTurno_SelectedIndexChanged);
            // 
            // lTurno
            // 
            this.lTurno.AutoSize = true;
            this.lTurno.Location = new System.Drawing.Point(415, 161);
            this.lTurno.Name = "lTurno";
            this.lTurno.Size = new System.Drawing.Size(56, 23);
            this.lTurno.TabIndex = 8;
            this.lTurno.Text = "Turno";
            // 
            // textBoxDomicilio
            // 
            this.textBoxDomicilio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDomicilio.Location = new System.Drawing.Point(40, 187);
            this.textBoxDomicilio.Name = "textBoxDomicilio";
            this.textBoxDomicilio.Size = new System.Drawing.Size(300, 27);
            this.textBoxDomicilio.TabIndex = 7;
            this.textBoxDomicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDomicilio_KeyPress);
            // 
            // lDomicilio
            // 
            this.lDomicilio.AutoSize = true;
            this.lDomicilio.Location = new System.Drawing.Point(40, 161);
            this.lDomicilio.Name = "lDomicilio";
            this.lDomicilio.Size = new System.Drawing.Size(87, 23);
            this.lDomicilio.TabIndex = 6;
            this.lDomicilio.Text = "Domicilio";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxTelefono.Location = new System.Drawing.Point(707, 95);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(200, 27);
            this.textBoxTelefono.TabIndex = 5;
            this.textBoxTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTelefono_KeyPress);
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxDNI.Location = new System.Drawing.Point(419, 95);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(200, 27);
            this.textBoxDNI.TabIndex = 3;
            this.textBoxDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDNI_KeyPress);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBoxNombre.Location = new System.Drawing.Point(40, 95);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(300, 27);
            this.textBoxNombre.TabIndex = 1;
            this.textBoxNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNombre_KeyPress);
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Location = new System.Drawing.Point(703, 69);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(78, 23);
            this.lTelefono.TabIndex = 4;
            this.lTelefono.Text = "Teléfono";
            // 
            // Ldni
            // 
            this.Ldni.AutoSize = true;
            this.Ldni.Location = new System.Drawing.Point(415, 69);
            this.Ldni.Name = "Ldni";
            this.Ldni.Size = new System.Drawing.Size(41, 23);
            this.Ldni.TabIndex = 2;
            this.Ldni.Text = "DNI";
            // 
            // Lnombre
            // 
            this.Lnombre.AutoSize = true;
            this.Lnombre.Location = new System.Drawing.Point(40, 69);
            this.Lnombre.Name = "Lnombre";
            this.Lnombre.Size = new System.Drawing.Size(76, 23);
            this.Lnombre.TabIndex = 0;
            this.Lnombre.Text = "Nombre";
            // 
            // lRegistro
            // 
            this.lRegistro.AutoSize = true;
            this.lRegistro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lRegistro.ForeColor = System.Drawing.Color.DarkGreen;
            this.lRegistro.Location = new System.Drawing.Point(50, 30);
            this.lRegistro.Name = "lRegistro";
            this.lRegistro.Size = new System.Drawing.Size(209, 28);
            this.lRegistro.TabIndex = 1;
            this.lRegistro.Text = "Registro de Alumnos";
            // 
            // ClienteAgregarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lRegistro);
            this.Controls.Add(this.groupBoxRegistro);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "ClienteAgregarControl";
            this.Size = new System.Drawing.Size(1128, 731);
            this.Load += new System.EventHandler(this.ClienteAgregarControl_Load);
            this.groupBoxRegistro.ResumeLayout(false);
            this.groupBoxRegistro.PerformLayout();
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
    }
}