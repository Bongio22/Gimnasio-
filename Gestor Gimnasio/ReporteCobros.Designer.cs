namespace Gestor_Gimnasio
{
    partial class ReporteCobros
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_Clientes = new System.Windows.Forms.DataGridView();
            this.B_Buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_nombre_admin = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clientes)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView_Clientes);
            this.panel2.Controls.Add(this.B_Buscar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cb_nombre_admin);
            this.panel2.Location = new System.Drawing.Point(83, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 496);
            this.panel2.TabIndex = 9;
            // 
            // dataGridView_Clientes
            // 
            this.dataGridView_Clientes.BackgroundColor = System.Drawing.Color.GreenYellow;
            this.dataGridView_Clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Clientes.Location = new System.Drawing.Point(21, 62);
            this.dataGridView_Clientes.Name = "dataGridView_Clientes";
            this.dataGridView_Clientes.RowHeadersWidth = 51;
            this.dataGridView_Clientes.RowTemplate.Height = 24;
            this.dataGridView_Clientes.Size = new System.Drawing.Size(861, 414);
            this.dataGridView_Clientes.TabIndex = 5;
            // 
            // B_Buscar
            // 
            this.B_Buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Buscar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Buscar.ForeColor = System.Drawing.Color.White;
            this.B_Buscar.Location = new System.Drawing.Point(760, 8);
            this.B_Buscar.Name = "B_Buscar";
            this.B_Buscar.Size = new System.Drawing.Size(122, 38);
            this.B_Buscar.TabIndex = 4;
            this.B_Buscar.Text = "Buscar";
            this.B_Buscar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(305, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cobro realizado por";
            // 
            // cb_nombre_admin
            // 
            this.cb_nombre_admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_nombre_admin.FormattingEnabled = true;
            this.cb_nombre_admin.Location = new System.Drawing.Point(520, 15);
            this.cb_nombre_admin.Name = "cb_nombre_admin";
            this.cb_nombre_admin.Size = new System.Drawing.Size(224, 28);
            this.cb_nombre_admin.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(90, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "REGISTRO DE COBROS";
            // 
            // ReporteCobros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(1074, 632);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteCobros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteCobros";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Clientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView_Clientes;
        private System.Windows.Forms.Button B_Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_nombre_admin;
        private System.Windows.Forms.Label label3;
    }
}