namespace Gestor_Gimnasio
{
    partial class DashboardSuperAdmin
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
            this.panel_superadmin = new System.Windows.Forms.Panel();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.BEntrenadores = new System.Windows.Forms.Button();
            this.BClientes = new System.Windows.Forms.Button();
            this.BCuotas = new System.Windows.Forms.Button();
            this.B_backup = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.panel_superadmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_superadmin
            // 
            this.panel_superadmin.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel_superadmin.Controls.Add(this.BEntrenadores);
            this.panel_superadmin.Controls.Add(this.BClientes);
            this.panel_superadmin.Controls.Add(this.BCuotas);
            this.panel_superadmin.Controls.Add(this.B_backup);
            this.panel_superadmin.Controls.Add(this.BSalir);
            this.panel_superadmin.Controls.Add(this.pbox_logo);
            this.panel_superadmin.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_superadmin.Location = new System.Drawing.Point(0, 0);
            this.panel_superadmin.Name = "panel_superadmin";
            this.panel_superadmin.Size = new System.Drawing.Size(362, 784);
            this.panel_superadmin.TabIndex = 0;
            // 
            // panelContenedor
            // 
            this.panelContenedor.AutoScroll = true;
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(362, 0);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(845, 784);
            this.panelContenedor.TabIndex = 1;
            // 
            // BEntrenadores
            // 
            this.BEntrenadores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BEntrenadores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BEntrenadores.FlatAppearance.BorderSize = 0;
            this.BEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEntrenadores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEntrenadores.ForeColor = System.Drawing.Color.GreenYellow;
            this.BEntrenadores.Image = global::Gestor_Gimnasio.Properties.Resources.users;
            this.BEntrenadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BEntrenadores.Location = new System.Drawing.Point(22, 235);
            this.BEntrenadores.Name = "BEntrenadores";
            this.BEntrenadores.Size = new System.Drawing.Size(279, 59);
            this.BEntrenadores.TabIndex = 4;
            this.BEntrenadores.Text = "ENTRENADORES";
            this.BEntrenadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BEntrenadores.UseVisualStyleBackColor = true;
            this.BEntrenadores.Click += new System.EventHandler(this.BEntrenadores_Click);
            // 
            // BClientes
            // 
            this.BClientes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BClientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BClientes.FlatAppearance.BorderSize = 0;
            this.BClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClientes.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClientes.ForeColor = System.Drawing.Color.GreenYellow;
            this.BClientes.Image = global::Gestor_Gimnasio.Properties.Resources.users;
            this.BClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BClientes.Location = new System.Drawing.Point(22, 170);
            this.BClientes.Name = "BClientes";
            this.BClientes.Size = new System.Drawing.Size(198, 59);
            this.BClientes.TabIndex = 3;
            this.BClientes.Text = "CLIENTES";
            this.BClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BClientes.UseVisualStyleBackColor = true;
            this.BClientes.Click += new System.EventHandler(this.BClientes_Click);
            // 
            // BCuotas
            // 
            this.BCuotas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BCuotas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BCuotas.FlatAppearance.BorderSize = 0;
            this.BCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCuotas.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCuotas.ForeColor = System.Drawing.Color.GreenYellow;
            this.BCuotas.Image = global::Gestor_Gimnasio.Properties.Resources.cuota;
            this.BCuotas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BCuotas.Location = new System.Drawing.Point(22, 300);
            this.BCuotas.Name = "BCuotas";
            this.BCuotas.Size = new System.Drawing.Size(186, 59);
            this.BCuotas.TabIndex = 6;
            this.BCuotas.Text = "CUOTAS";
            this.BCuotas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BCuotas.UseVisualStyleBackColor = true;
            this.BCuotas.Click += new System.EventHandler(this.BCuotas_Click);
            // 
            // B_backup
            // 
            this.B_backup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.B_backup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_backup.FlatAppearance.BorderSize = 0;
            this.B_backup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_backup.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_backup.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_backup.Image = global::Gestor_Gimnasio.Properties.Resources.bkup;
            this.B_backup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_backup.Location = new System.Drawing.Point(22, 365);
            this.B_backup.Name = "B_backup";
            this.B_backup.Size = new System.Drawing.Size(191, 59);
            this.B_backup.TabIndex = 5;
            this.B_backup.Text = "BACK UP";
            this.B_backup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_backup.UseVisualStyleBackColor = true;
            this.B_backup.Click += new System.EventHandler(this.B_backup_Click);
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
            this.BSalir.TabIndex = 2;
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
            this.pbox_logo.TabIndex = 1;
            this.pbox_logo.TabStop = false;
            // 
            // DashboardSuperAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1207, 784);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panel_superadmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DashboardSuperAdmin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardSuperAdmin_Load);
            this.panel_superadmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_superadmin;
        private System.Windows.Forms.PictureBox pbox_logo;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Button BCuotas;
        private System.Windows.Forms.Button B_backup;
        private System.Windows.Forms.Button BEntrenadores;
        private System.Windows.Forms.Button BClientes;
        private System.Windows.Forms.Panel panelContenedor;
    }
}