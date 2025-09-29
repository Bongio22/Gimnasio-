namespace Gestor_Gimnasio
{
    partial class EstadoCuotasControl
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
            this.dataGridView_Cuotas = new System.Windows.Forms.DataGridView();
            this.B_BuscarCuotasDni = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Cuotas
            // 
            this.dataGridView_Cuotas.BackgroundColor = System.Drawing.Color.GreenYellow;
            this.dataGridView_Cuotas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Cuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cuotas.Location = new System.Drawing.Point(260, 291);
            this.dataGridView_Cuotas.Name = "dataGridView_Cuotas";
            this.dataGridView_Cuotas.RowHeadersWidth = 51;
            this.dataGridView_Cuotas.RowTemplate.Height = 24;
            this.dataGridView_Cuotas.Size = new System.Drawing.Size(1140, 506);
            this.dataGridView_Cuotas.TabIndex = 7;
            // 
            // B_BuscarCuotasDni
            // 
            this.B_BuscarCuotasDni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_BuscarCuotasDni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BuscarCuotasDni.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_BuscarCuotasDni.Location = new System.Drawing.Point(1293, 241);
            this.B_BuscarCuotasDni.Name = "B_BuscarCuotasDni";
            this.B_BuscarCuotasDni.Size = new System.Drawing.Size(107, 38);
            this.B_BuscarCuotasDni.TabIndex = 11;
            this.B_BuscarCuotasDni.Text = "Buscar";
            this.B_BuscarCuotasDni.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(95, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "ESTADO DE CUOTAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(255, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Cuota correspondiente al mes de";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(578, 249);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(196, 28);
            this.comboBox1.TabIndex = 14;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(917, 249);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(204, 28);
            this.comboBox2.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(813, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Estado";
            // 
            // EstadoCuotasControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.B_BuscarCuotasDni);
            this.Controls.Add(this.dataGridView_Cuotas);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "EstadoCuotasControl";
            this.Size = new System.Drawing.Size(1414, 941);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Cuotas;
        private System.Windows.Forms.Button B_BuscarCuotasDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
    }
}
