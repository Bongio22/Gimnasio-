namespace Gestor_Gimnasio
{
    partial class CobrosControl
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView_Cobros = new System.Windows.Forms.DataGridView();
            this.B_BuscarCuotas = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Periodo = new System.Windows.Forms.ComboBox();
            this.textBox_DNI = new System.Windows.Forms.TextBox();
            this.textBox_Monto = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Pagar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cobros)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(374, 531);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(206, 28);
            this.comboBox1.TabIndex = 4;
            // 
            // dataGridView_Cobros
            // 
            this.dataGridView_Cobros.BackgroundColor = System.Drawing.Color.GreenYellow;
            this.dataGridView_Cobros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_Cobros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Cobros.Location = new System.Drawing.Point(277, 580);
            this.dataGridView_Cobros.Name = "dataGridView_Cobros";
            this.dataGridView_Cobros.RowHeadersWidth = 51;
            this.dataGridView_Cobros.RowTemplate.Height = 24;
            this.dataGridView_Cobros.Size = new System.Drawing.Size(1180, 335);
            this.dataGridView_Cobros.TabIndex = 6;
            this.dataGridView_Cobros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Cobros_CellContentClick);
            // 
            // B_BuscarCuotas
            // 
            this.B_BuscarCuotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_BuscarCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_BuscarCuotas.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_BuscarCuotas.ForeColor = System.Drawing.Color.White;
            this.B_BuscarCuotas.Location = new System.Drawing.Point(1351, 524);
            this.B_BuscarCuotas.Name = "B_BuscarCuotas";
            this.B_BuscarCuotas.Size = new System.Drawing.Size(106, 36);
            this.B_BuscarCuotas.TabIndex = 9;
            this.B_BuscarCuotas.Text = "Buscar";
            this.B_BuscarCuotas.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(73, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ingresar DNI";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(73, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(270, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Correspondiente al periodo de";
            // 
            // comboBox_Periodo
            // 
            this.comboBox_Periodo.FormattingEnabled = true;
            this.comboBox_Periodo.Location = new System.Drawing.Point(381, 152);
            this.comboBox_Periodo.Name = "comboBox_Periodo";
            this.comboBox_Periodo.Size = new System.Drawing.Size(163, 31);
            this.comboBox_Periodo.TabIndex = 14;
            // 
            // textBox_DNI
            // 
            this.textBox_DNI.Location = new System.Drawing.Point(78, 91);
            this.textBox_DNI.Name = "textBox_DNI";
            this.textBox_DNI.Size = new System.Drawing.Size(215, 30);
            this.textBox_DNI.TabIndex = 15;
            // 
            // textBox_Monto
            // 
            this.textBox_Monto.Location = new System.Drawing.Point(394, 91);
            this.textBox_Monto.Name = "textBox_Monto";
            this.textBox_Monto.Size = new System.Drawing.Size(150, 30);
            this.textBox_Monto.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btn_Pagar);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_Monto);
            this.groupBox1.Controls.Add(this.textBox_DNI);
            this.groupBox1.Controls.Add(this.comboBox_Periodo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(552, 143);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 300);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pagar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(331, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 37);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(366, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "$";
            // 
            // btn_Pagar
            // 
            this.btn_Pagar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Pagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pagar.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Pagar.ForeColor = System.Drawing.Color.White;
            this.btn_Pagar.Location = new System.Drawing.Point(184, 234);
            this.btn_Pagar.Name = "btn_Pagar";
            this.btn_Pagar.Size = new System.Drawing.Size(109, 37);
            this.btn_Pagar.TabIndex = 18;
            this.btn_Pagar.Text = "Pagar";
            this.btn_Pagar.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(366, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(96, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 28);
            this.label3.TabIndex = 18;
            this.label3.Text = "COBRAR CUOTAS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(272, 532);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Periodo";
            // 
            // CobrosControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_BuscarCuotas);
            this.Controls.Add(this.dataGridView_Cobros);
            this.Controls.Add(this.comboBox1);
            this.Name = "CobrosControl";
            this.Size = new System.Drawing.Size(1480, 996);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Cobros)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView_Cobros;
        private System.Windows.Forms.Button B_BuscarCuotas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Periodo;
        private System.Windows.Forms.TextBox textBox_DNI;
        private System.Windows.Forms.TextBox textBox_Monto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Pagar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
    }
}
