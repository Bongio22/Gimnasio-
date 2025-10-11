namespace Gestor_Gimnasio
{
    partial class EditarUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelEditarEntrenador = new System.Windows.Forms.Panel();
            this.groupBoxEditarEntrenador = new System.Windows.Forms.GroupBox();
            this.textBoxDomicilio = new System.Windows.Forms.TextBox();
            this.lDomicilio = new System.Windows.Forms.Label();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.lTelefono = new System.Windows.Forms.Label();
            this.Ldni = new System.Windows.Forms.Label();
            this.Lnombre = new System.Windows.Forms.Label();
            this.BGuardar_Edit = new System.Windows.Forms.Button();
            this.BCancelar_Edit = new System.Windows.Forms.Button();
            this.textBoxContrasena = new System.Windows.Forms.TextBox();
            this.comboBoxTipoRol = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEditarEntrenador.SuspendLayout();
            this.groupBoxEditarEntrenador.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEditarEntrenador
            // 
            this.panelEditarEntrenador.BackColor = System.Drawing.Color.White;
            this.panelEditarEntrenador.Controls.Add(this.groupBoxEditarEntrenador);
            this.panelEditarEntrenador.Location = new System.Drawing.Point(126, 58);
            this.panelEditarEntrenador.Name = "panelEditarEntrenador";
            this.panelEditarEntrenador.Size = new System.Drawing.Size(950, 563);
            this.panelEditarEntrenador.TabIndex = 2;
            // 
            // groupBoxEditarEntrenador
            // 
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxContrasena);
            this.groupBoxEditarEntrenador.Controls.Add(this.comboBoxTipoRol);
            this.groupBoxEditarEntrenador.Controls.Add(this.label5);
            this.groupBoxEditarEntrenador.Controls.Add(this.label4);
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxDomicilio);
            this.groupBoxEditarEntrenador.Controls.Add(this.lDomicilio);
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxTelefono);
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxDNI);
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxNombre);
            this.groupBoxEditarEntrenador.Controls.Add(this.lTelefono);
            this.groupBoxEditarEntrenador.Controls.Add(this.Ldni);
            this.groupBoxEditarEntrenador.Controls.Add(this.Lnombre);
            this.groupBoxEditarEntrenador.Controls.Add(this.BGuardar_Edit);
            this.groupBoxEditarEntrenador.Controls.Add(this.BCancelar_Edit);
            this.groupBoxEditarEntrenador.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEditarEntrenador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBoxEditarEntrenador.Location = new System.Drawing.Point(55, 44);
            this.groupBoxEditarEntrenador.Name = "groupBoxEditarEntrenador";
            this.groupBoxEditarEntrenador.Size = new System.Drawing.Size(831, 468);
            this.groupBoxEditarEntrenador.TabIndex = 0;
            this.groupBoxEditarEntrenador.TabStop = false;
            this.groupBoxEditarEntrenador.Text = "Editar datos del Usuario";
            // 
            // textBoxDomicilio
            // 
            this.textBoxDomicilio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBoxDomicilio.Location = new System.Drawing.Point(34, 228);
            this.textBoxDomicilio.Name = "textBoxDomicilio";
            this.textBoxDomicilio.Size = new System.Drawing.Size(471, 30);
            this.textBoxDomicilio.TabIndex = 38;
            // 
            // lDomicilio
            // 
            this.lDomicilio.AutoSize = true;
            this.lDomicilio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lDomicilio.Location = new System.Drawing.Point(31, 197);
            this.lDomicilio.Name = "lDomicilio";
            this.lDomicilio.Size = new System.Drawing.Size(103, 28);
            this.lDomicilio.TabIndex = 37;
            this.lDomicilio.Text = "Domicilio";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBoxTelefono.Location = new System.Drawing.Point(566, 228);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(211, 30);
            this.textBoxTelefono.TabIndex = 36;
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBoxDNI.Location = new System.Drawing.Point(566, 130);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.ReadOnly = true;
            this.textBoxDNI.Size = new System.Drawing.Size(211, 30);
            this.textBoxDNI.TabIndex = 34;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.textBoxNombre.Location = new System.Drawing.Point(36, 130);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(437, 30);
            this.textBoxNombre.TabIndex = 32;
            // 
            // lTelefono
            // 
            this.lTelefono.AutoSize = true;
            this.lTelefono.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lTelefono.Location = new System.Drawing.Point(561, 197);
            this.lTelefono.Name = "lTelefono";
            this.lTelefono.Size = new System.Drawing.Size(94, 28);
            this.lTelefono.TabIndex = 35;
            this.lTelefono.Text = "Teléfono";
            // 
            // Ldni
            // 
            this.Ldni.AutoSize = true;
            this.Ldni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Ldni.Location = new System.Drawing.Point(511, 128);
            this.Ldni.Name = "Ldni";
            this.Ldni.Size = new System.Drawing.Size(49, 28);
            this.Ldni.TabIndex = 33;
            this.Ldni.Text = "DNI";
            // 
            // Lnombre
            // 
            this.Lnombre.AutoSize = true;
            this.Lnombre.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Lnombre.Location = new System.Drawing.Point(31, 92);
            this.Lnombre.Name = "Lnombre";
            this.Lnombre.Size = new System.Drawing.Size(191, 28);
            this.Lnombre.TabIndex = 31;
            this.Lnombre.Text = "Nombre y Apellido";
            // 
            // BGuardar_Edit
            // 
            this.BGuardar_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BGuardar_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardar_Edit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar_Edit.ForeColor = System.Drawing.Color.White;
            this.BGuardar_Edit.Location = new System.Drawing.Point(521, 405);
            this.BGuardar_Edit.Name = "BGuardar_Edit";
            this.BGuardar_Edit.Size = new System.Drawing.Size(120, 35);
            this.BGuardar_Edit.TabIndex = 0;
            this.BGuardar_Edit.Text = "Guardar";
            this.BGuardar_Edit.UseVisualStyleBackColor = false;
            // 
            // BCancelar_Edit
            // 
            this.BCancelar_Edit.BackColor = System.Drawing.Color.Gray;
            this.BCancelar_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar_Edit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar_Edit.ForeColor = System.Drawing.Color.White;
            this.BCancelar_Edit.Location = new System.Drawing.Point(676, 405);
            this.BCancelar_Edit.Name = "BCancelar_Edit";
            this.BCancelar_Edit.Size = new System.Drawing.Size(120, 35);
            this.BCancelar_Edit.TabIndex = 1;
            this.BCancelar_Edit.Text = "Cancelar";
            this.BCancelar_Edit.UseVisualStyleBackColor = false;
            // 
            // textBoxContrasena
            // 
            this.textBoxContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContrasena.Location = new System.Drawing.Point(422, 330);
            this.textBoxContrasena.Name = "textBoxContrasena";
            this.textBoxContrasena.ReadOnly = true;
            this.textBoxContrasena.Size = new System.Drawing.Size(244, 27);
            this.textBoxContrasena.TabIndex = 42;
            this.textBoxContrasena.UseSystemPasswordChar = true;
            // 
            // comboBoxTipoRol
            // 
            this.comboBoxTipoRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTipoRol.FormattingEnabled = true;
            this.comboBoxTipoRol.Location = new System.Drawing.Point(36, 333);
            this.comboBoxTipoRol.Name = "comboBoxTipoRol";
            this.comboBoxTipoRol.Size = new System.Drawing.Size(216, 28);
            this.comboBoxTipoRol.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(298, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 28);
            this.label5.TabIndex = 40;
            this.label5.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(35, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 28);
            this.label4.TabIndex = 39;
            this.label4.Text = "Rol";
            // 
            // EditarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GreenYellow;
            this.ClientSize = new System.Drawing.Size(1204, 670);
            this.Controls.Add(this.panelEditarEntrenador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarUsuario";
            this.panelEditarEntrenador.ResumeLayout(false);
            this.groupBoxEditarEntrenador.ResumeLayout(false);
            this.groupBoxEditarEntrenador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEditarEntrenador;
        private System.Windows.Forms.GroupBox groupBoxEditarEntrenador;
        private System.Windows.Forms.TextBox textBoxDomicilio;
        private System.Windows.Forms.Label lDomicilio;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label lTelefono;
        private System.Windows.Forms.Label Ldni;
        private System.Windows.Forms.Label Lnombre;
        private System.Windows.Forms.Button BGuardar_Edit;
        private System.Windows.Forms.Button BCancelar_Edit;
        private System.Windows.Forms.TextBox textBoxContrasena;
        private System.Windows.Forms.ComboBox comboBoxTipoRol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}