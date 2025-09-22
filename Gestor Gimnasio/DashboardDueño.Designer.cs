namespace Gestor_Gimnasio
{
    partial class DashboardDueño
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
            this.panel_dueño = new System.Windows.Forms.Panel();
            this.B_VerEntrenadores = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panelDashboaerdDueño = new System.Windows.Forms.Panel();
            this.BSalir = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_dueño.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_dueño
            // 
            this.panel_dueño.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel_dueño.Controls.Add(this.B_VerEntrenadores);
            this.panel_dueño.Controls.Add(this.button2);
            this.panel_dueño.Controls.Add(this.button1);
            this.panel_dueño.Controls.Add(this.BSalir);
            this.panel_dueño.Controls.Add(this.pbox_logo);
            this.panel_dueño.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_dueño.Location = new System.Drawing.Point(0, 0);
            this.panel_dueño.Name = "panel_dueño";
            this.panel_dueño.Size = new System.Drawing.Size(293, 784);
            this.panel_dueño.TabIndex = 0;
            // 
            // B_VerEntrenadores
            // 
            this.B_VerEntrenadores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_VerEntrenadores.FlatAppearance.BorderSize = 0;
            this.B_VerEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_VerEntrenadores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_VerEntrenadores.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_VerEntrenadores.Location = new System.Drawing.Point(32, 242);
            this.B_VerEntrenadores.Name = "B_VerEntrenadores";
            this.B_VerEntrenadores.Size = new System.Drawing.Size(235, 65);
            this.B_VerEntrenadores.TabIndex = 6;
            this.B_VerEntrenadores.Text = "ENTRENADORES";
            this.B_VerEntrenadores.UseVisualStyleBackColor = true;
            this.B_VerEntrenadores.Click += new System.EventHandler(this.B_VerEntrenadores_Click);
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.GreenYellow;
            this.button2.Location = new System.Drawing.Point(32, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(235, 65);
            this.button2.TabIndex = 5;
            this.button2.Text = "REPORTES";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panelDashboaerdDueño
            // 
            this.panelDashboaerdDueño.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDashboaerdDueño.Location = new System.Drawing.Point(293, 0);
            this.panelDashboaerdDueño.Name = "panelDashboaerdDueño";
            this.panelDashboaerdDueño.Size = new System.Drawing.Size(914, 784);
            this.panelDashboaerdDueño.TabIndex = 1;
            this.panelDashboaerdDueño.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDashboaerdDueño_Paint);
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.Color.GreenYellow;
            this.BSalir.Image = global::Gestor_Gimnasio.Properties.Resources.cerrar_sesion;
            this.BSalir.Location = new System.Drawing.Point(0, 684);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(293, 100);
            this.BSalir.TabIndex = 3;
            this.BSalir.Text = "Cerrar Sesion";
            this.BSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // pbox_logo
            // 
            this.pbox_logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbox_logo.ErrorImage = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.Image = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.InitialImage = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.Location = new System.Drawing.Point(0, 0);
            this.pbox_logo.Name = "pbox_logo";
            this.pbox_logo.Size = new System.Drawing.Size(293, 152);
            this.pbox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_logo.TabIndex = 2;
            this.pbox_logo.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.GreenYellow;
            this.button1.Location = new System.Drawing.Point(29, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 65);
            this.button1.TabIndex = 4;
            this.button1.Text = "CLIENTES";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DashboardDueño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1207, 784);
            this.Controls.Add(this.panelDashboaerdDueño);
            this.Controls.Add(this.panel_dueño);
            this.Name = "DashboardDueño";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "panel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardDueño_Load);
            this.panel_dueño.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_dueño;
        private System.Windows.Forms.PictureBox pbox_logo;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Button B_VerEntrenadores;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelDashboaerdDueño;
        private System.Windows.Forms.Button button1;
    }
}