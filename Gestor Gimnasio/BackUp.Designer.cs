namespace Gestor_Gimnasio
{
    partial class BackUp
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
            this.textBox_RutaBackup = new System.Windows.Forms.TextBox();
            this.comboBox_BDBackup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Conectar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.B_Backup = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_RutaBackup
            // 
            this.textBox_RutaBackup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_RutaBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_RutaBackup.Location = new System.Drawing.Point(145, 127);
            this.textBox_RutaBackup.Name = "textBox_RutaBackup";
            this.textBox_RutaBackup.Size = new System.Drawing.Size(594, 28);
            this.textBox_RutaBackup.TabIndex = 0;
            // 
            // comboBox_BDBackup
            // 
            this.comboBox_BDBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BDBackup.FormattingEnabled = true;
            this.comboBox_BDBackup.Location = new System.Drawing.Point(342, 67);
            this.comboBox_BDBackup.Name = "comboBox_BDBackup";
            this.comboBox_BDBackup.Size = new System.Drawing.Size(255, 30);
            this.comboBox_BDBackup.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(69, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccionar la base de datos";
            // 
            // B_Conectar
            // 
            this.B_Conectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Conectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Conectar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Conectar.ForeColor = System.Drawing.Color.White;
            this.B_Conectar.Location = new System.Drawing.Point(624, 61);
            this.B_Conectar.Name = "B_Conectar";
            this.B_Conectar.Size = new System.Drawing.Size(115, 39);
            this.B_Conectar.TabIndex = 9;
            this.B_Conectar.Text = "Conectar";
            this.B_Conectar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(69, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Ruta";
            // 
            // B_Backup
            // 
            this.B_Backup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Backup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Backup.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Backup.ForeColor = System.Drawing.Color.White;
            this.B_Backup.Location = new System.Drawing.Point(388, 329);
            this.B_Backup.Name = "B_Backup";
            this.B_Backup.Size = new System.Drawing.Size(176, 40);
            this.B_Backup.TabIndex = 11;
            this.B_Backup.Text = "Generar BackUp";
            this.B_Backup.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(53, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(365, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "GESTION DE BACKUP DE BASE DE DATOS";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GreenYellow;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.B_Conectar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox_BDBackup);
            this.panel1.Controls.Add(this.textBox_RutaBackup);
            this.panel1.Location = new System.Drawing.Point(58, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 213);
            this.panel1.TabIndex = 13;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Controls.Add(this.B_Backup);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(377, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 388);
            this.panel2.TabIndex = 14;
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Name = "BackUp";
            this.Size = new System.Drawing.Size(1329, 566);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_RutaBackup;
        private System.Windows.Forms.ComboBox comboBox_BDBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Conectar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_Backup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
