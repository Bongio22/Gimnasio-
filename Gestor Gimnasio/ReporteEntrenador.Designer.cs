namespace Gestor_Gimnasio
{
    partial class ReporteEntrenador
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
            this.cb_nombre_entrenador = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Buscar = new System.Windows.Forms.Button();
            this.dataGridView_Entrenadores = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Entrenadores)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_nombre_entrenador
            // 
            this.cb_nombre_entrenador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_nombre_entrenador.FormattingEnabled = true;
            this.cb_nombre_entrenador.Location = new System.Drawing.Point(520, 15);
            this.cb_nombre_entrenador.Name = "cb_nombre_entrenador";
            this.cb_nombre_entrenador.Size = new System.Drawing.Size(224, 28);
            this.cb_nombre_entrenador.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(383, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Entrenador";
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
            // dataGridView_Entrenadores
            // 
            this.dataGridView_Entrenadores.BackgroundColor = System.Drawing.Color.GreenYellow;
            this.dataGridView_Entrenadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Entrenadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Entrenadores.Location = new System.Drawing.Point(21, 62);
            this.dataGridView_Entrenadores.Name = "dataGridView_Entrenadores";
            this.dataGridView_Entrenadores.RowHeadersWidth = 51;
            this.dataGridView_Entrenadores.RowTemplate.Height = 24;
            this.dataGridView_Entrenadores.Size = new System.Drawing.Size(861, 414);
            this.dataGridView_Entrenadores.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.GreenYellow;
            this.label3.Location = new System.Drawing.Point(25, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "ENTRENADORES A CARGO";
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
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView_Entrenadores);
            this.panel2.Controls.Add(this.B_Buscar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cb_nombre_entrenador);
            this.panel2.Location = new System.Drawing.Point(18, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 496);
            this.panel2.TabIndex = 7;
            // 
            // ReporteEntrenador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(944, 602);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReporteEntrenador";
            this.Text = "ReporteEntrenador";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Entrenadores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_nombre_entrenador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Buscar;
        private System.Windows.Forms.DataGridView dataGridView_Entrenadores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}