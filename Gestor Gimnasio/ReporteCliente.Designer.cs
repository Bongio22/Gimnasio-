namespace Gestor_Gimnasio
{
    partial class ReporteCliente
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
            this.cb_turno = new System.Windows.Forms.ComboBox();
            this.cb_cuotas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.B_Buscar = new System.Windows.Forms.Button();
            this.dataGridView_Clientes = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_turno
            // 
            this.cb_turno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_turno.FormattingEnabled = true;
            this.cb_turno.Location = new System.Drawing.Point(161, 16);
            this.cb_turno.Name = "cb_turno";
            this.cb_turno.Size = new System.Drawing.Size(224, 28);
            this.cb_turno.TabIndex = 7;
            // 
            // cb_cuotas
            // 
            this.cb_cuotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cuotas.FormattingEnabled = true;
            this.cb_cuotas.Location = new System.Drawing.Point(502, 17);
            this.cb_cuotas.Name = "cb_cuotas";
            this.cb_cuotas.Size = new System.Drawing.Size(224, 28);
            this.cb_cuotas.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Clientes turno";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(426, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cuotas";
            // 
            // B_Buscar
            // 
            this.B_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Buscar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Buscar.ForeColor = System.Drawing.Color.White;
            this.B_Buscar.Location = new System.Drawing.Point(758, 10);
            this.B_Buscar.Name = "B_Buscar";
            this.B_Buscar.Size = new System.Drawing.Size(122, 38);
            this.B_Buscar.TabIndex = 11;
            this.B_Buscar.Text = "Buscar";
            this.B_Buscar.UseVisualStyleBackColor = false;
            // 
            // dataGridView_Clientes
            // 
            this.dataGridView_Clientes.BackgroundColor = System.Drawing.Color.GreenYellow;
            this.dataGridView_Clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Clientes.Location = new System.Drawing.Point(12, 80);
            this.dataGridView_Clientes.Name = "dataGridView_Clientes";
            this.dataGridView_Clientes.RowHeadersWidth = 51;
            this.dataGridView_Clientes.RowTemplate.Height = 24;
            this.dataGridView_Clientes.Size = new System.Drawing.Size(868, 389);
            this.dataGridView_Clientes.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(33, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "CLIENTES: ESTADO DE CUOTAS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 602);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView_Clientes);
            this.panel2.Controls.Add(this.B_Buscar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cb_cuotas);
            this.panel2.Controls.Add(this.cb_turno);
            this.panel2.Location = new System.Drawing.Point(26, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(895, 487);
            this.panel2.TabIndex = 14;
            // 
            // ReporteCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 602);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteCliente";
            this.Text = "ReporteCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_turno;
        private System.Windows.Forms.ComboBox cb_cuotas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_Buscar;
        private System.Windows.Forms.DataGridView dataGridView_Clientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}