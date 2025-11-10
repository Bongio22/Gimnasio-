namespace Gestor_Gimnasio
{
    partial class ListaEntrenadoresControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lista_Entrenadores = new System.Windows.Forms.DataGridView();
            this.BLimpiar = new System.Windows.Forms.Button();
            this.BBuscar = new System.Windows.Forms.Button();
            this.textBoxdni = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lista_Entrenadores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(95, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "LISTA DE ENTRENADORES";
            // 
            // lista_Entrenadores
            // 
            this.lista_Entrenadores.AllowUserToAddRows = false;
            this.lista_Entrenadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.lista_Entrenadores.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.lista_Entrenadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista_Entrenadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.lista_Entrenadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lista_Entrenadores.DefaultCellStyle = dataGridViewCellStyle23;
            this.lista_Entrenadores.EnableHeadersVisualStyles = false;
            this.lista_Entrenadores.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lista_Entrenadores.Location = new System.Drawing.Point(304, 387);
            this.lista_Entrenadores.Name = "lista_Entrenadores";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista_Entrenadores.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.lista_Entrenadores.RowHeadersWidth = 51;
            this.lista_Entrenadores.RowTemplate.Height = 24;
            this.lista_Entrenadores.Size = new System.Drawing.Size(1180, 529);
            this.lista_Entrenadores.TabIndex = 2;
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.Gray;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.Color.White;
            this.BLimpiar.Location = new System.Drawing.Point(1243, 308);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(129, 47);
            this.BLimpiar.TabIndex = 12;
            this.BLimpiar.Text = "Borrar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.Color.White;
            this.BBuscar.Location = new System.Drawing.Point(1100, 308);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(129, 47);
            this.BBuscar.TabIndex = 11;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            // 
            // textBoxdni
            // 
            this.textBoxdni.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdni.Location = new System.Drawing.Point(874, 315);
            this.textBoxdni.Name = "textBoxdni";
            this.textBoxdni.Size = new System.Drawing.Size(186, 31);
            this.textBoxdni.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(511, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ingrese DNI del Entrenador:";
            // 
            // ListaEntrenadoresControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BLimpiar);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.textBoxdni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lista_Entrenadores);
            this.Name = "ListaEntrenadoresControl";
            this.Size = new System.Drawing.Size(1511, 937);
            ((System.ComponentModel.ISupportInitialize)(this.lista_Entrenadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView lista_Entrenadores;
        private System.Windows.Forms.Button BLimpiar;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.TextBox textBoxdni;
        private System.Windows.Forms.Label label2;
    }
}
