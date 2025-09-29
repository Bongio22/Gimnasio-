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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 30D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 15D);
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TotalIngresos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.B_BuscarTurnosMes = new System.Windows.Forms.Button();
            this.comboBox_TurnosMes = new System.Windows.Forms.ComboBox();
            this.B_BuscarIngresosMes = new System.Windows.Forms.Button();
            this.comboBox_IngresosMes = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.B_VerReporteEntrenadores = new System.Windows.Forms.Button();
            this.B_VerReporteClientes = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView_Ingresos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ingresos)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(1265, 625);
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
            this.textBox_TotalIngresos.Location = new System.Drawing.Point(1315, 619);
            this.textBox_TotalIngresos.Name = "textBox_TotalIngresos";
            this.textBox_TotalIngresos.Size = new System.Drawing.Size(86, 30);
            this.textBox_TotalIngresos.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(828, 574);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Pagos de";
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
            // comboBox_TurnosMes
            // 
            this.comboBox_TurnosMes.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_TurnosMes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_TurnosMes.FormattingEnabled = true;
            this.comboBox_TurnosMes.Location = new System.Drawing.Point(574, 120);
            this.comboBox_TurnosMes.Name = "comboBox_TurnosMes";
            this.comboBox_TurnosMes.Size = new System.Drawing.Size(222, 31);
            this.comboBox_TurnosMes.TabIndex = 18;
            // 
            // B_BuscarIngresosMes
            // 
            this.B_BuscarIngresosMes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_BuscarIngresosMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BuscarIngresosMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_BuscarIngresosMes.ForeColor = System.Drawing.Color.White;
            this.B_BuscarIngresosMes.Location = new System.Drawing.Point(1141, 566);
            this.B_BuscarIngresosMes.Name = "B_BuscarIngresosMes";
            this.B_BuscarIngresosMes.Size = new System.Drawing.Size(113, 37);
            this.B_BuscarIngresosMes.TabIndex = 17;
            this.B_BuscarIngresosMes.Text = "Buscar";
            this.B_BuscarIngresosMes.UseVisualStyleBackColor = false;
            // 
            // comboBox_IngresosMes
            // 
            this.comboBox_IngresosMes.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_IngresosMes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_IngresosMes.FormattingEnabled = true;
            this.comboBox_IngresosMes.Location = new System.Drawing.Point(916, 569);
            this.comboBox_IngresosMes.Name = "comboBox_IngresosMes";
            this.comboBox_IngresosMes.Size = new System.Drawing.Size(209, 31);
            this.comboBox_IngresosMes.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
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
            this.pictureBox1.Location = new System.Drawing.Point(83, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 148);
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
            this.B_VerReporteEntrenadores.Location = new System.Drawing.Point(72, 284);
            this.B_VerReporteEntrenadores.Name = "B_VerReporteEntrenadores";
            this.B_VerReporteEntrenadores.Size = new System.Drawing.Size(223, 54);
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
            this.B_VerReporteClientes.Location = new System.Drawing.Point(72, 211);
            this.B_VerReporteClientes.Name = "B_VerReporteClientes";
            this.B_VerReporteClientes.Size = new System.Drawing.Size(223, 53);
            this.B_VerReporteClientes.TabIndex = 1;
            this.B_VerReporteClientes.Text = "CLIENTES";
            this.B_VerReporteClientes.UseVisualStyleBackColor = false;
            this.B_VerReporteClientes.Click += new System.EventHandler(this.B_VerReporteClientes_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(362, 194);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.IsValueShownAsLabel = true;
            series2.Label = "#PERCENT{P0}";
            series2.Legend = "Legend1";
            series2.LegendText = "#VALX";
            series2.Name = "Series1";
            dataPoint4.AxisLabel = "MAÑANA";
            dataPoint4.Color = System.Drawing.Color.OliveDrab;
            dataPoint4.LegendText = "MAÑANA";
            dataPoint5.AxisLabel = "TARDE";
            dataPoint5.Color = System.Drawing.Color.GreenYellow;
            dataPoint5.LegendText = "TARDE";
            dataPoint6.Color = System.Drawing.Color.YellowGreen;
            dataPoint6.LegendText = "NOCHE";
            series2.Points.Add(dataPoint4);
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(495, 309);
            this.chart1.TabIndex = 14;
            this.chart1.Text = "chart1";
            // 
            // dataGridView_Ingresos
            // 
            this.dataGridView_Ingresos.BackgroundColor = System.Drawing.Color.GreenYellow;
            this.dataGridView_Ingresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Ingresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Ingresos.Location = new System.Drawing.Point(160, 615);
            this.dataGridView_Ingresos.Name = "dataGridView_Ingresos";
            this.dataGridView_Ingresos.RowHeadersWidth = 51;
            this.dataGridView_Ingresos.RowTemplate.Height = 24;
            this.dataGridView_Ingresos.Size = new System.Drawing.Size(1094, 389);
            this.dataGridView_Ingresos.TabIndex = 13;
            // 
            // ReportesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_TotalIngresos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_BuscarTurnosMes);
            this.Controls.Add(this.comboBox_TurnosMes);
            this.Controls.Add(this.B_BuscarIngresosMes);
            this.Controls.Add(this.comboBox_IngresosMes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView_Ingresos);
            this.Name = "ReportesControl";
            this.Size = new System.Drawing.Size(1534, 1243);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Ingresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_TotalIngresos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_BuscarTurnosMes;
        private System.Windows.Forms.ComboBox comboBox_TurnosMes;
        private System.Windows.Forms.Button B_BuscarIngresosMes;
        private System.Windows.Forms.ComboBox comboBox_IngresosMes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button B_VerReporteEntrenadores;
        private System.Windows.Forms.Button B_VerReporteClientes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView_Ingresos;
    }
}
