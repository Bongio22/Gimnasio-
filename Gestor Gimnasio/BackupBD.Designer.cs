namespace Gestor_Gimnasio
{
    partial class BackupBD
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BGenerarBackUp = new System.Windows.Forms.Button();
            this.BConectar = new System.Windows.Forms.Button();
            this.textBox_RutaBackup = new System.Windows.Forms.TextBox();
            this.comboBox_BDBackup = new System.Windows.Forms.ComboBox();
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(95, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ruta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(95, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccionar Base de Datos";
            // 
            // BGenerarBackUp
            // 
            this.BGenerarBackUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BGenerarBackUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGenerarBackUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGenerarBackUp.ForeColor = System.Drawing.Color.White;
            this.BGenerarBackUp.Location = new System.Drawing.Point(372, 243);
            this.BGenerarBackUp.Name = "BGenerarBackUp";
            this.BGenerarBackUp.Size = new System.Drawing.Size(205, 46);
            this.BGenerarBackUp.TabIndex = 11;
            this.BGenerarBackUp.Text = "Generar BackUp";
            this.BGenerarBackUp.UseVisualStyleBackColor = false;
            // 
            // BConectar
            // 
            this.BConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BConectar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BConectar.ForeColor = System.Drawing.Color.White;
            this.BConectar.Location = new System.Drawing.Point(719, 102);
            this.BConectar.Name = "BConectar";
            this.BConectar.Size = new System.Drawing.Size(133, 44);
            this.BConectar.TabIndex = 10;
            this.BConectar.Text = "Conectar";
            this.BConectar.UseVisualStyleBackColor = false;
            // 
            // textBox_RutaBackup
            // 
            this.textBox_RutaBackup.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_RutaBackup.Location = new System.Drawing.Point(186, 184);
            this.textBox_RutaBackup.Name = "textBox_RutaBackup";
            this.textBox_RutaBackup.Size = new System.Drawing.Size(666, 31);
            this.textBox_RutaBackup.TabIndex = 9;
            // 
            // comboBox_BDBackup
            // 
            this.comboBox_BDBackup.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_BDBackup.FormattingEnabled = true;
            this.comboBox_BDBackup.Location = new System.Drawing.Point(394, 110);
            this.comboBox_BDBackup.Name = "comboBox_BDBackup";
            this.comboBox_BDBackup.Size = new System.Drawing.Size(256, 33);
            this.comboBox_BDBackup.TabIndex = 8;
            // 
            // dgvBackups
            // 
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Location = new System.Drawing.Point(44, 374);
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.RowHeadersWidth = 51;
            this.dgvBackups.RowTemplate.Height = 24;
            this.dgvBackups.Size = new System.Drawing.Size(861, 218);
            this.dgvBackups.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BGenerarBackUp);
            this.groupBox1.Controls.Add(this.BConectar);
            this.groupBox1.Controls.Add(this.textBox_RutaBackup);
            this.groupBox1.Controls.Add(this.comboBox_BDBackup);
            this.groupBox1.Controls.Add(this.dgvBackups);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(301, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(955, 638);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GESTIÓN BACK UP DE BASES DE DATOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 28);
            this.label3.TabIndex = 14;
            this.label3.Text = "HISTORIAL DE BACKUPS";
            // 
            // BackupBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Name = "BackupBD";
            this.Size = new System.Drawing.Size(1339, 789);
            this.Load += new System.EventHandler(this.BackupBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BGenerarBackUp;
        private System.Windows.Forms.Button BConectar;
        private System.Windows.Forms.TextBox textBox_RutaBackup;
        private System.Windows.Forms.ComboBox comboBox_BDBackup;
        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}
