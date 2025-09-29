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
            this.panel_DashboardDueño = new System.Windows.Forms.Panel();
            this.BUsuarios = new System.Windows.Forms.Button();
            this.B_Reportes = new System.Windows.Forms.Button();
            this.B_VerEntrenadores = new System.Windows.Forms.Button();
            this.B_VerClientes = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.panel_dueño.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_dueño
            // 
            this.panel_dueño.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel_dueño.Controls.Add(this.BUsuarios);
            this.panel_dueño.Controls.Add(this.B_Reportes);
            this.panel_dueño.Controls.Add(this.B_VerEntrenadores);
            this.panel_dueño.Controls.Add(this.B_VerClientes);
            this.panel_dueño.Controls.Add(this.BSalir);
            this.panel_dueño.Controls.Add(this.pbox_logo);
            this.panel_dueño.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_dueño.Location = new System.Drawing.Point(0, 0);
            this.panel_dueño.Name = "panel_dueño";
            this.panel_dueño.Size = new System.Drawing.Size(362, 784);
            this.panel_dueño.TabIndex = 0;
            // 
            // panel_DashboardDueño
            // 
            this.panel_DashboardDueño.AutoScroll = true;
            this.panel_DashboardDueño.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DashboardDueño.Location = new System.Drawing.Point(362, 0);
            this.panel_DashboardDueño.Name = "panel_DashboardDueño";
            this.panel_DashboardDueño.Size = new System.Drawing.Size(845, 784);
            this.panel_DashboardDueño.TabIndex = 3;
            // 
            // BUsuarios
            // 
            this.BUsuarios.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BUsuarios.FlatAppearance.BorderSize = 0;
            this.BUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BUsuarios.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BUsuarios.ForeColor = System.Drawing.Color.GreenYellow;
            this.BUsuarios.Image = global::Gestor_Gimnasio.Properties.Resources.users;
            this.BUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BUsuarios.Location = new System.Drawing.Point(24, 311);
            this.BUsuarios.Name = "BUsuarios";
            this.BUsuarios.Size = new System.Drawing.Size(201, 65);
            this.BUsuarios.TabIndex = 8;
            this.BUsuarios.Text = "USUARIOS";
            this.BUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BUsuarios.UseVisualStyleBackColor = true;
            this.BUsuarios.Click += new System.EventHandler(this.BUsuarios_Click);
            // 
            // B_Reportes
            // 
            this.B_Reportes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Reportes.FlatAppearance.BorderSize = 0;
            this.B_Reportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Reportes.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Reportes.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_Reportes.Image = global::Gestor_Gimnasio.Properties.Resources.report;
            this.B_Reportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Reportes.Location = new System.Drawing.Point(24, 382);
            this.B_Reportes.Name = "B_Reportes";
            this.B_Reportes.Size = new System.Drawing.Size(197, 65);
            this.B_Reportes.TabIndex = 7;
            this.B_Reportes.Text = "REPORTES";
            this.B_Reportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Reportes.UseVisualStyleBackColor = true;
            this.B_Reportes.Click += new System.EventHandler(this.B_Reportes_Click);
            // 
            // B_VerEntrenadores
            // 
            this.B_VerEntrenadores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_VerEntrenadores.FlatAppearance.BorderSize = 0;
            this.B_VerEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_VerEntrenadores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_VerEntrenadores.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_VerEntrenadores.Image = global::Gestor_Gimnasio.Properties.Resources.users;
            this.B_VerEntrenadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_VerEntrenadores.Location = new System.Drawing.Point(24, 240);
            this.B_VerEntrenadores.Name = "B_VerEntrenadores";
            this.B_VerEntrenadores.Size = new System.Drawing.Size(281, 65);
            this.B_VerEntrenadores.TabIndex = 6;
            this.B_VerEntrenadores.Text = "ENTRENADORES";
            this.B_VerEntrenadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_VerEntrenadores.UseVisualStyleBackColor = true;
            this.B_VerEntrenadores.Click += new System.EventHandler(this.B_VerEntrenadores_Click);
            // 
            // B_VerClientes
            // 
            this.B_VerClientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_VerClientes.FlatAppearance.BorderSize = 0;
            this.B_VerClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_VerClientes.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_VerClientes.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_VerClientes.Image = global::Gestor_Gimnasio.Properties.Resources.users;
            this.B_VerClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_VerClientes.Location = new System.Drawing.Point(24, 169);
            this.B_VerClientes.Name = "B_VerClientes";
            this.B_VerClientes.Size = new System.Drawing.Size(197, 65);
            this.B_VerClientes.TabIndex = 4;
            this.B_VerClientes.Text = "CLIENTES";
            this.B_VerClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_VerClientes.UseVisualStyleBackColor = true;
            this.B_VerClientes.Click += new System.EventHandler(this.B_VerClientes_Click);
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.Color.GreenYellow;
            this.BSalir.Image = global::Gestor_Gimnasio.Properties.Resources.cerrar_sesion;
            this.BSalir.Location = new System.Drawing.Point(0, 684);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(362, 100);
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
            this.pbox_logo.Size = new System.Drawing.Size(362, 152);
            this.pbox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_logo.TabIndex = 2;
            this.pbox_logo.TabStop = false;
            // 
            // DashboardDueño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1207, 784);
            this.Controls.Add(this.panel_DashboardDueño);
            this.Controls.Add(this.panel_dueño);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
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
        private System.Windows.Forms.Button B_VerClientes;
        private System.Windows.Forms.Panel panel_DashboardDueño;
        private System.Windows.Forms.Button B_Reportes;
        private System.Windows.Forms.Button BUsuarios;
    }
}