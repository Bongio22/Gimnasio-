namespace Gestor_Gimnasio
{
    partial class ReporteAdminControl
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
            this.dgv_lista_alumnos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxdni = new System.Windows.Forms.TextBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_alumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_lista_alumnos
            // 
            this.dgv_lista_alumnos.AllowUserToAddRows = false;
            this.dgv_lista_alumnos.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgv_lista_alumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lista_alumnos.Location = new System.Drawing.Point(192, 219);
            this.dgv_lista_alumnos.MultiSelect = false;
            this.dgv_lista_alumnos.Name = "dgv_lista_alumnos";
            this.dgv_lista_alumnos.ReadOnly = true;
            this.dgv_lista_alumnos.RowHeadersVisible = false;
            this.dgv_lista_alumnos.RowHeadersWidth = 51;
            this.dgv_lista_alumnos.RowTemplate.Height = 24;
            this.dgv_lista_alumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_lista_alumnos.Size = new System.Drawing.Size(1310, 685);
            this.dgv_lista_alumnos.TabIndex = 0;
            this.dgv_lista_alumnos.TabStop = false;
            this.dgv_lista_alumnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_lista_alumnos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(939, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI del Alumno:";
            // 
            // textBoxdni
            // 
            this.textBoxdni.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdni.Location = new System.Drawing.Point(944, 156);
            this.textBoxdni.Name = "textBoxdni";
            this.textBoxdni.Size = new System.Drawing.Size(224, 34);
            this.textBoxdni.TabIndex = 2;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.Color.White;
            this.BBuscar.Location = new System.Drawing.Point(1210, 153);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(135, 41);
            this.BBuscar.TabIndex = 3;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(186, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 38);
            this.label2.TabIndex = 4;
            this.label2.Text = "REGISTRO DE MIS ALTAS";
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.Gray;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.Color.White;
            this.BLimpiar.Location = new System.Drawing.Point(1367, 153);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(135, 41);
            this.BLimpiar.TabIndex = 5;
            this.BLimpiar.Text = "Borrar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            // 
            // ReporteAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BLimpiar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.textBoxdni);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_lista_alumnos);
            this.Name = "ReporteAdminControl";
            this.Size = new System.Drawing.Size(1600, 1087);
            this.Load += new System.EventHandler(this.ReporteAdminControl_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_alumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_lista_alumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxdni;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BLimpiar;
    }
}
