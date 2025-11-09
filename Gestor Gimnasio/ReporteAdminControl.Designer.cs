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
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_alumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_lista_alumnos
            // 
            this.dgv_lista_alumnos.AllowUserToAddRows = false;
            this.dgv_lista_alumnos.BackgroundColor = System.Drawing.Color.LightBlue;
            this.dgv_lista_alumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_lista_alumnos.Location = new System.Drawing.Point(192, 131);
            this.dgv_lista_alumnos.MultiSelect = false;
            this.dgv_lista_alumnos.Name = "dgv_lista_alumnos";
            this.dgv_lista_alumnos.ReadOnly = true;
            this.dgv_lista_alumnos.RowHeadersVisible = false;
            this.dgv_lista_alumnos.RowHeadersWidth = 51;
            this.dgv_lista_alumnos.RowTemplate.Height = 24;
            this.dgv_lista_alumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_lista_alumnos.Size = new System.Drawing.Size(1310, 773);
            this.dgv_lista_alumnos.TabIndex = 0;
            this.dgv_lista_alumnos.TabStop = false;
            this.dgv_lista_alumnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_lista_alumnos_CellContentClick);
            // 
            // ReporteAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgv_lista_alumnos);
            this.Name = "ReporteAdminControl";
            this.Size = new System.Drawing.Size(1600, 1087);
            this.Load += new System.EventHandler(this.ReporteAdminControl_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_lista_alumnos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_lista_alumnos;
    }
}
