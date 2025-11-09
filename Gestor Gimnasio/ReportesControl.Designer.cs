namespace Gestor_Gimnasio
{
    partial class ReportesControl
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint9 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 15D);
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TotalIngresos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.B_BuscarTurnosMes = new System.Windows.Forms.Button();
            this.cboMesDemanda = new System.Windows.Forms.ComboBox();
            this.B_BuscarIngresosMes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.B_VerReporteEntrenadores = new System.Windows.Forms.Button();
            this.B_VerReporteClientes = new System.Windows.Forms.Button();
            this.grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView_Ingresos = new System.Windows.Forms.DataGridView();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkbox_pagaron = new System.Windows.Forms.CheckBox();
            this.B_Admin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ingresos)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(1176, 1048);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "Total";
            // 
            // textBox_TotalIngresos
            // 
            this.textBox_TotalIngresos.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_TotalIngresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_TotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TotalIngresos.Location = new System.Drawing.Point(1226, 1042);
            this.textBox_TotalIngresos.Name = "textBox_TotalIngresos";
            this.textBox_TotalIngresos.Size = new System.Drawing.Size(98, 30);
            this.textBox_TotalIngresos.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(155, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 28);
            this.label2.TabIndex = 21;
            this.label2.Text = "DISPOSICIÓN DE TURNOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(155, 545);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 28);
            this.label1.TabIndex = 20;
            this.label1.Text = "INGRESOS DEL MES";
            // 
            // B_BuscarTurnosMes
            // 
            this.B_BuscarTurnosMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_BuscarTurnosMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BuscarTurnosMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_BuscarTurnosMes.ForeColor = System.Drawing.Color.White;
            this.B_BuscarTurnosMes.Location = new System.Drawing.Point(813, 120);
            this.B_BuscarTurnosMes.Name = "B_BuscarTurnosMes";
            this.B_BuscarTurnosMes.Size = new System.Drawing.Size(113, 31);
            this.B_BuscarTurnosMes.TabIndex = 19;
            this.B_BuscarTurnosMes.Text = "Buscar";
            this.B_BuscarTurnosMes.UseVisualStyleBackColor = false;
            // 
            // cboMesDemanda
            // 
            this.cboMesDemanda.BackColor = System.Drawing.SystemColors.Window;
            this.cboMesDemanda.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMesDemanda.FormattingEnabled = true;
            this.cboMesDemanda.Location = new System.Drawing.Point(574, 120);
            this.cboMesDemanda.Name = "cboMesDemanda";
            this.cboMesDemanda.Size = new System.Drawing.Size(222, 31);
            this.cboMesDemanda.TabIndex = 18;
            // 
            // B_BuscarIngresosMes
            // 
            this.B_BuscarIngresosMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_BuscarIngresosMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BuscarIngresosMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_BuscarIngresosMes.ForeColor = System.Drawing.Color.White;
            this.B_BuscarIngresosMes.Location = new System.Drawing.Point(1211, 566);
            this.B_BuscarIngresosMes.Name = "B_BuscarIngresosMes";
            this.B_BuscarIngresosMes.Size = new System.Drawing.Size(113, 37);
            this.B_BuscarIngresosMes.TabIndex = 17;
            this.B_BuscarIngresosMes.Text = "Buscar";
            this.B_BuscarIngresosMes.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.B_Admin);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.B_VerReporteEntrenadores);
            this.panel1.Controls.Add(this.B_VerReporteClientes);
            this.panel1.Location = new System.Drawing.Point(1029, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 377);
            this.panel1.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Gestor_Gimnasio.Properties.Resources.reporte;
            this.pictureBox1.Location = new System.Drawing.Point(93, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // B_VerReporteEntrenadores
            // 
            this.B_VerReporteEntrenadores.BackColor = System.Drawing.Color.GreenYellow;
            this.B_VerReporteEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_VerReporteEntrenadores.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_VerReporteEntrenadores.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_VerReporteEntrenadores.Location = new System.Drawing.Point(59, 235);
            this.B_VerReporteEntrenadores.Name = "B_VerReporteEntrenadores";
            this.B_VerReporteEntrenadores.Size = new System.Drawing.Size(249, 54);
            this.B_VerReporteEntrenadores.TabIndex = 2;
            this.B_VerReporteEntrenadores.Text = "ENTRENADORES";
            this.B_VerReporteEntrenadores.UseVisualStyleBackColor = false;
            this.B_VerReporteEntrenadores.Click += new System.EventHandler(this.B_VerReporteEntrenadores_Click);
            // 
            // B_VerReporteClientes
            // 
            this.B_VerReporteClientes.BackColor = System.Drawing.Color.GreenYellow;
            this.B_VerReporteClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_VerReporteClientes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_VerReporteClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_VerReporteClientes.Location = new System.Drawing.Point(59, 176);
            this.B_VerReporteClientes.Name = "B_VerReporteClientes";
            this.B_VerReporteClientes.Size = new System.Drawing.Size(249, 53);
            this.B_VerReporteClientes.TabIndex = 1;
            this.B_VerReporteClientes.Text = "CLIENTES";
            this.B_VerReporteClientes.UseVisualStyleBackColor = false;
            this.B_VerReporteClientes.Click += new System.EventHandler(this.B_VerReporteClientes_Click);
            // 
            // grafico
            // 
            chartArea3.Name = "ChartArea1";
            this.grafico.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.grafico.Legends.Add(legend3);
            this.grafico.Location = new System.Drawing.Point(362, 194);
            this.grafico.Name = "grafico";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.IsValueShownAsLabel = true;
            series3.Label = "#PERCENT{P0}";
            series3.Legend = "Legend1";
            series3.LegendText = "#VALX";
            series3.Name = "Series1";
            dataPoint7.AxisLabel = "MAÑANA";
            dataPoint7.Color = System.Drawing.Color.OliveDrab;
            dataPoint7.LegendText = "MAÑANA";
            dataPoint8.AxisLabel = "TARDE";
            dataPoint8.Color = System.Drawing.Color.GreenYellow;
            dataPoint8.LegendText = "TARDE";
            dataPoint9.Color = System.Drawing.Color.YellowGreen;
            dataPoint9.LegendText = "NOCHE";
            series3.Points.Add(dataPoint7);
            series3.Points.Add(dataPoint8);
            series3.Points.Add(dataPoint9);
            this.grafico.Series.Add(series3);
            this.grafico.Size = new System.Drawing.Size(495, 309);
            this.grafico.TabIndex = 14;
            this.grafico.Text = "chart1";
            // 
            // dataGridView_Ingresos
            // 
            this.dataGridView_Ingresos.BackgroundColor = System.Drawing.Color.GreenYellow;
            this.dataGridView_Ingresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Ingresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Ingresos.Location = new System.Drawing.Point(362, 628);
            this.dataGridView_Ingresos.Name = "dataGridView_Ingresos";
            this.dataGridView_Ingresos.RowHeadersWidth = 51;
            this.dataGridView_Ingresos.RowTemplate.Height = 24;
            this.dataGridView_Ingresos.Size = new System.Drawing.Size(962, 389);
            this.dataGridView_Ingresos.TabIndex = 13;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(707, 571);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(159, 30);
            this.dtpDesde.TabIndex = 25;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(1033, 569);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(155, 30);
            this.dtpHasta.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(631, 571);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 28);
            this.label3.TabIndex = 27;
            this.label3.Text = "Desde";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(961, 571);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 28);
            this.label5.TabIndex = 28;
            this.label5.Text = "Hasta";
            // 
            // checkbox_pagaron
            // 
            this.checkbox_pagaron.AutoSize = true;
            this.checkbox_pagaron.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_pagaron.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.checkbox_pagaron.Location = new System.Drawing.Point(171, 194);
            this.checkbox_pagaron.Name = "checkbox_pagaron";
            this.checkbox_pagaron.Size = new System.Drawing.Size(240, 27);
            this.checkbox_pagaron.TabIndex = 29;
            this.checkbox_pagaron.Text = "SOLO LOS QUE PAGARON";
            this.checkbox_pagaron.UseVisualStyleBackColor = true;
            // 
            // B_Admin
            // 
            this.B_Admin.BackColor = System.Drawing.Color.GreenYellow;
            this.B_Admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Admin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Admin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Admin.Location = new System.Drawing.Point(59, 295);
            this.B_Admin.Name = "B_Admin";
            this.B_Admin.Size = new System.Drawing.Size(249, 53);
            this.B_Admin.TabIndex = 4;
            this.B_Admin.Text = "ADMINISTRADORES";
            this.B_Admin.UseVisualStyleBackColor = false;
            this.B_Admin.Click += new System.EventHandler(this.B_Admin_Click);
            // 
            // ReportesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.checkbox_pagaron);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_TotalIngresos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_BuscarTurnosMes);
            this.Controls.Add(this.cboMesDemanda);
            this.Controls.Add(this.B_BuscarIngresosMes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grafico);
            this.Controls.Add(this.dataGridView_Ingresos);
            this.Name = "ReportesControl";
            this.Size = new System.Drawing.Size(1534, 1243);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grafico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ingresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_TotalIngresos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_BuscarTurnosMes;
        private System.Windows.Forms.ComboBox cboMesDemanda;
        private System.Windows.Forms.Button B_BuscarIngresosMes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button B_VerReporteEntrenadores;
        private System.Windows.Forms.Button B_VerReporteClientes;
        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
        private System.Windows.Forms.DataGridView dataGridView_Ingresos;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkbox_pagaron;
        private System.Windows.Forms.Button B_Admin;
    }
}
