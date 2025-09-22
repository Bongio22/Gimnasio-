namespace Gestor_Gimnasio
{
    partial class EditarEntrenador
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelEditarEntrenador = new System.Windows.Forms.Panel();
            this.groupBoxEditarEntrenador = new System.Windows.Forms.GroupBox();
            this.numCupo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDomicilio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTurno = new System.Windows.Forms.ComboBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxDni = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.BGuardar_Edit = new System.Windows.Forms.Button();
            this.BCancelar_Edit = new System.Windows.Forms.Button();
            this.panelEditarEntrenador.SuspendLayout();
            this.groupBoxEditarEntrenador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCupo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEditarEntrenador
            // 
            this.panelEditarEntrenador.BackColor = System.Drawing.Color.White;
            this.panelEditarEntrenador.Controls.Add(this.groupBoxEditarEntrenador);
            this.panelEditarEntrenador.Controls.Add(this.BGuardar_Edit);
            this.panelEditarEntrenador.Controls.Add(this.BCancelar_Edit);
            this.panelEditarEntrenador.Location = new System.Drawing.Point(94, 76);
            this.panelEditarEntrenador.Name = "panelEditarEntrenador";
            this.panelEditarEntrenador.Size = new System.Drawing.Size(974, 535);
            this.panelEditarEntrenador.TabIndex = 0;
            // 
            // groupBoxEditarEntrenador
            // 
            this.groupBoxEditarEntrenador.Controls.Add(this.numCupo);
            this.groupBoxEditarEntrenador.Controls.Add(this.label6);
            this.groupBoxEditarEntrenador.Controls.Add(this.label5);
            this.groupBoxEditarEntrenador.Controls.Add(this.label4);
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxDomicilio);
            this.groupBoxEditarEntrenador.Controls.Add(this.label3);
            this.groupBoxEditarEntrenador.Controls.Add(this.label2);
            this.groupBoxEditarEntrenador.Controls.Add(this.label1);
            this.groupBoxEditarEntrenador.Controls.Add(this.comboBoxTurno);
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxTelefono);
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxDni);
            this.groupBoxEditarEntrenador.Controls.Add(this.textBoxNombre);
            this.groupBoxEditarEntrenador.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEditarEntrenador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBoxEditarEntrenador.Location = new System.Drawing.Point(34, 38);
            this.groupBoxEditarEntrenador.Name = "groupBoxEditarEntrenador";
            this.groupBoxEditarEntrenador.Size = new System.Drawing.Size(906, 367);
            this.groupBoxEditarEntrenador.TabIndex = 0;
            this.groupBoxEditarEntrenador.TabStop = false;
            this.groupBoxEditarEntrenador.Text = "Editar datos del Entrenador";
            // 
            // numCupo
            // 
            this.numCupo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCupo.Location = new System.Drawing.Point(804, 248);
            this.numCupo.Name = "numCupo";
            this.numCupo.Size = new System.Drawing.Size(61, 30);
            this.numCupo.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(738, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Cupo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(457, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Turno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Domicilio";
            // 
            // textBoxDomicilio
            // 
            this.textBoxDomicilio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDomicilio.Location = new System.Drawing.Point(26, 248);
            this.textBoxDomicilio.Name = "textBoxDomicilio";
            this.textBoxDomicilio.Size = new System.Drawing.Size(403, 30);
            this.textBoxDomicilio.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(653, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "Telefono";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(457, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 28);
            this.label2.TabIndex = 7;
            this.label2.Text = "DNI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre y Apellido";
            // 
            // comboBoxTurno
            // 
            this.comboBoxTurno.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxTurno.FormattingEnabled = true;
            this.comboBoxTurno.Location = new System.Drawing.Point(462, 248);
            this.comboBoxTurno.Name = "comboBoxTurno";
            this.comboBoxTurno.Size = new System.Drawing.Size(215, 31);
            this.comboBoxTurno.TabIndex = 5;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTelefono.Location = new System.Drawing.Point(658, 135);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(207, 30);
            this.textBoxTelefono.TabIndex = 4;
            // 
            // textBoxDni
            // 
            this.textBoxDni.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDni.Location = new System.Drawing.Point(462, 135);
            this.textBoxDni.Name = "textBoxDni";
            this.textBoxDni.Size = new System.Drawing.Size(179, 30);
            this.textBoxDni.TabIndex = 3;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNombre.Location = new System.Drawing.Point(26, 135);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(403, 30);
            this.textBoxNombre.TabIndex = 0;
            // 
            // BGuardar_Edit
            // 
            this.BGuardar_Edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BGuardar_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardar_Edit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardar_Edit.ForeColor = System.Drawing.Color.White;
            this.BGuardar_Edit.Location = new System.Drawing.Point(665, 454);
            this.BGuardar_Edit.Name = "BGuardar_Edit";
            this.BGuardar_Edit.Size = new System.Drawing.Size(120, 35);
            this.BGuardar_Edit.TabIndex = 0;
            this.BGuardar_Edit.Text = "Guardar";
            this.BGuardar_Edit.UseVisualStyleBackColor = false;
            this.BGuardar_Edit.Click += new System.EventHandler(this.BGuardar_Edit_Click);
            // 
            // BCancelar_Edit
            // 
            this.BCancelar_Edit.BackColor = System.Drawing.Color.Gray;
            this.BCancelar_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCancelar_Edit.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCancelar_Edit.ForeColor = System.Drawing.Color.White;
            this.BCancelar_Edit.Location = new System.Drawing.Point(820, 454);
            this.BCancelar_Edit.Name = "BCancelar_Edit";
            this.BCancelar_Edit.Size = new System.Drawing.Size(120, 35);
            this.BCancelar_Edit.TabIndex = 1;
            this.BCancelar_Edit.Text = "Cancelar";
            this.BCancelar_Edit.UseVisualStyleBackColor = false;
            this.BCancelar_Edit.Click += new System.EventHandler(this.BCancelar_Edit_Click);
            // 
            // EditarEntrenador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1162, 677);
            this.Controls.Add(this.panelEditarEntrenador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditarEntrenador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarEntrenador";
            this.Load += new System.EventHandler(this.EditarEntrenador_Load_1);
            this.panelEditarEntrenador.ResumeLayout(false);
            this.groupBoxEditarEntrenador.ResumeLayout(false);
            this.groupBoxEditarEntrenador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCupo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelEditarEntrenador;
        private System.Windows.Forms.Button BGuardar_Edit;
        private System.Windows.Forms.GroupBox groupBoxEditarEntrenador;
        private System.Windows.Forms.Button BCancelar_Edit;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxDni;
        private System.Windows.Forms.TextBox textBoxDomicilio;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.ComboBox comboBoxTurno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCupo;
        private System.Windows.Forms.Label label6;
    }
}