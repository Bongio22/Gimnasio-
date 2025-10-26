namespace Gestor_Gimnasio
{
    partial class EstadoCuotasControl
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            this.dataGridView_Cuotas = new System.Windows.Forms.DataGridView();
            this.B_BuscarCuotasDni = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();      // “Cuota correspondiente al mes de”
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox(); // oculto (Estado)
            this.label1 = new System.Windows.Forms.Label();       // oculto (Estado)
            this.txtPersona = new System.Windows.Forms.TextBox();
            this.lblPersona = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.comboBoxAnio = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cuotas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Cuotas
            // 
            this.dataGridView_Cuotas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Cuotas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView_Cuotas.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_Cuotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridView_Cuotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cuotas.Location = new System.Drawing.Point(292, 364);
            this.dataGridView_Cuotas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_Cuotas.Name = "dataGridView_Cuotas";
            this.dataGridView_Cuotas.RowHeadersWidth = 51;
            this.dataGridView_Cuotas.RowTemplate.Height = 24;
            this.dataGridView_Cuotas.Size = new System.Drawing.Size(1282, 632);
            this.dataGridView_Cuotas.TabIndex = 7;
            // 
            // B_BuscarCuotasDni
            // 
            this.B_BuscarCuotasDni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_BuscarCuotasDni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BuscarCuotasDni.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.B_BuscarCuotasDni.ForeColor = System.Drawing.Color.White;
            this.B_BuscarCuotasDni.Location = new System.Drawing.Point(1455, 301);
            this.B_BuscarCuotasDni.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.B_BuscarCuotasDni.Name = "B_BuscarCuotasDni";
            this.B_BuscarCuotasDni.Size = new System.Drawing.Size(120, 48);
            this.B_BuscarCuotasDni.TabIndex = 11;
            this.B_BuscarCuotasDni.Text = "Buscar";
            this.B_BuscarCuotasDni.UseVisualStyleBackColor = false;
            // 
            // label3 (título)
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
            this.label3.Location = new System.Drawing.Point(107, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 32);
            this.label3.TabIndex = 12;
            this.label3.Text = "ESTADO DE CUOTAS";
            // 
            // label2 (mes)
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
            this.label2.Location = new System.Drawing.Point(287, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(354, 30);
            this.label2.TabIndex = 13;
            this.label2.Text = "Cuota correspondiente al mes de";
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(650, 311);
            this.comboBoxMes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(180, 33);
            this.comboBoxMes.TabIndex = 14;
            // 
            // comboBox2 (estado) — oculto
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1032, 311);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(229, 33);
            this.comboBox2.TabIndex = 15;
            // 
            // label1 (estado) — oculto
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
            this.label1.Location = new System.Drawing.Point(915, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "Estado";
            // 
            // lblPersona
            // 
            this.lblPersona.AutoSize = true;
            this.lblPersona.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblPersona.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
            this.lblPersona.Location = new System.Drawing.Point(287, 270);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(93, 30);
            this.lblPersona.TabIndex = 17;
            this.lblPersona.Text = "Persona";
            // 
            // txtPersona
            // 
            this.txtPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.txtPersona.Location = new System.Drawing.Point(390, 270);
            this.txtPersona.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Size = new System.Drawing.Size(250, 31);
            this.txtPersona.TabIndex = 18;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblAnio.ForeColor = System.Drawing.Color.FromArgb(0, 64, 0);
            this.lblAnio.Location = new System.Drawing.Point(845, 315);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(55, 30);
            this.lblAnio.TabIndex = 19;
            this.lblAnio.Text = "Año";
            // 
            // comboBoxAnio
            // 
            this.comboBoxAnio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.comboBoxAnio.FormattingEnabled = true;
            this.comboBoxAnio.Location = new System.Drawing.Point(906, 311);
            this.comboBoxAnio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxAnio.Name = "comboBoxAnio";
            this.comboBoxAnio.Size = new System.Drawing.Size(100, 33);
            this.comboBoxAnio.TabIndex = 20;
            // 
            // EstadoCuotasControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.comboBoxAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.txtPersona);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBoxMes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.B_BuscarCuotasDni);
            this.Controls.Add(this.dataGridView_Cuotas);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "EstadoCuotasControl";
            this.Size = new System.Drawing.Size(1591, 1176);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cuotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Cuotas;
        private System.Windows.Forms.Button B_BuscarCuotasDni;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.ComboBox comboBox2; // oculto (estado)
        private System.Windows.Forms.Label label1;       // oculto (estado)
        private System.Windows.Forms.TextBox txtPersona;
        private System.Windows.Forms.Label lblPersona;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox comboBoxAnio;
    }
}
