namespace Gestor_Gimnasio
{
    partial class ListaClientesControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lista_Clientes = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxdni = new System.Windows.Forms.TextBox();
            this.BBuscar = new System.Windows.Forms.Button();
            this.BLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lista_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(95, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "LISTADO DE CLIENTES";
            // 
            // lista_Clientes
            // 
            this.lista_Clientes.AllowUserToAddRows = false;
            this.lista_Clientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.lista_Clientes.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.lista_Clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista_Clientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.lista_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.lista_Clientes.DefaultCellStyle = dataGridViewCellStyle8;
            this.lista_Clientes.EnableHeadersVisualStyles = false;
            this.lista_Clientes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lista_Clientes.Location = new System.Drawing.Point(304, 387);
            this.lista_Clientes.Name = "lista_Clientes";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.lista_Clientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.lista_Clientes.RowHeadersWidth = 51;
            this.lista_Clientes.RowTemplate.Height = 24;
            this.lista_Clientes.Size = new System.Drawing.Size(1180, 529);
            this.lista_Clientes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(516, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ingrese DNI del Cliente:";
            // 
            // textBoxdni
            // 
            this.textBoxdni.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxdni.Location = new System.Drawing.Point(809, 318);
            this.textBoxdni.Name = "textBoxdni";
            this.textBoxdni.Size = new System.Drawing.Size(186, 31);
            this.textBoxdni.TabIndex = 6;
            // 
            // BBuscar
            // 
            this.BBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBuscar.ForeColor = System.Drawing.Color.White;
            this.BBuscar.Location = new System.Drawing.Point(1035, 311);
            this.BBuscar.Name = "BBuscar";
            this.BBuscar.Size = new System.Drawing.Size(129, 47);
            this.BBuscar.TabIndex = 7;
            this.BBuscar.Text = "Buscar";
            this.BBuscar.UseVisualStyleBackColor = false;
            // 
            // BLimpiar
            // 
            this.BLimpiar.BackColor = System.Drawing.Color.Gray;
            this.BLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BLimpiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BLimpiar.ForeColor = System.Drawing.Color.White;
            this.BLimpiar.Location = new System.Drawing.Point(1178, 311);
            this.BLimpiar.Name = "BLimpiar";
            this.BLimpiar.Size = new System.Drawing.Size(129, 47);
            this.BLimpiar.TabIndex = 8;
            this.BLimpiar.Text = "Borrar";
            this.BLimpiar.UseVisualStyleBackColor = false;
            // 
            // ListaClientesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.BLimpiar);
            this.Controls.Add(this.BBuscar);
            this.Controls.Add(this.textBoxdni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lista_Clientes);
            this.Name = "ListaClientesControl";
            this.Size = new System.Drawing.Size(1511, 937);
            ((System.ComponentModel.ISupportInitialize)(this.lista_Clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView lista_Clientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxdni;
        private System.Windows.Forms.Button BBuscar;
        private System.Windows.Forms.Button BLimpiar;
    }
}
