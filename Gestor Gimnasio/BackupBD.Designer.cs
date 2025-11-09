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
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ruta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Seleccionar Base de Datos";
            // 
            // BGenerarBackUp
            // 
            this.BGenerarBackUp.Location = new System.Drawing.Point(452, 313);
            this.BGenerarBackUp.Name = "BGenerarBackUp";
            this.BGenerarBackUp.Size = new System.Drawing.Size(168, 36);
            this.BGenerarBackUp.TabIndex = 11;
            this.BGenerarBackUp.Text = "Generar BackUp";
            this.BGenerarBackUp.UseVisualStyleBackColor = true;
            // 
            // BConectar
            // 
            this.BConectar.Location = new System.Drawing.Point(718, 169);
            this.BConectar.Name = "BConectar";
            this.BConectar.Size = new System.Drawing.Size(168, 36);
            this.BConectar.TabIndex = 10;
            this.BConectar.Text = "Conectar";
            this.BConectar.UseVisualStyleBackColor = true;
            // 
            // textBox_RutaBackup
            // 
            this.textBox_RutaBackup.Location = new System.Drawing.Point(253, 247);
            this.textBox_RutaBackup.Name = "textBox_RutaBackup";
            this.textBox_RutaBackup.Size = new System.Drawing.Size(633, 22);
            this.textBox_RutaBackup.TabIndex = 9;
            // 
            // comboBox_BDBackup
            // 
            this.comboBox_BDBackup.FormattingEnabled = true;
            this.comboBox_BDBackup.Location = new System.Drawing.Point(414, 176);
            this.comboBox_BDBackup.Name = "comboBox_BDBackup";
            this.comboBox_BDBackup.Size = new System.Drawing.Size(256, 24);
            this.comboBox_BDBackup.TabIndex = 8;
            // 
            // dgvBackups
            // 
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Location = new System.Drawing.Point(156, 377);
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.RowHeadersWidth = 51;
            this.dgvBackups.RowTemplate.Height = 24;
            this.dgvBackups.Size = new System.Drawing.Size(790, 218);
            this.dgvBackups.TabIndex = 7;
            // 
            // BackupBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BGenerarBackUp);
            this.Controls.Add(this.BConectar);
            this.Controls.Add(this.textBox_RutaBackup);
            this.Controls.Add(this.comboBox_BDBackup);
            this.Controls.Add(this.dgvBackups);
            this.Name = "BackupBD";
            this.Size = new System.Drawing.Size(1102, 764);
            this.Load += new System.EventHandler(this.BackupBD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BGenerarBackUp;
        private System.Windows.Forms.Button BConectar;
        private System.Windows.Forms.TextBox textBox_RutaBackup;
        private System.Windows.Forms.ComboBox comboBox_BDBackup;
        private System.Windows.Forms.DataGridView dgvBackups;
    }
}
