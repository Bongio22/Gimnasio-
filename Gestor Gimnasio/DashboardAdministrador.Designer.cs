namespace Gestor_Gimnasio
{
    partial class DashboardAdministrador
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
            this.panel_admin = new System.Windows.Forms.Panel();
            this.B_Cobros = new System.Windows.Forms.Button();
            this.B_Entrenadores = new System.Windows.Forms.Button();
            this.B_EstadoCuota = new System.Windows.Forms.Button();
            this.B_Clientes = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.panel_DashBoardAdm = new System.Windows.Forms.Panel();
            this.button_reportesAlta = new System.Windows.Forms.Button();
            this.panel_admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_admin
            // 
            this.panel_admin.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel_admin.Controls.Add(this.button_reportesAlta);
            this.panel_admin.Controls.Add(this.B_Cobros);
            this.panel_admin.Controls.Add(this.B_Entrenadores);
            this.panel_admin.Controls.Add(this.B_EstadoCuota);
            this.panel_admin.Controls.Add(this.B_Clientes);
            this.panel_admin.Controls.Add(this.BSalir);
            this.panel_admin.Controls.Add(this.pbox_logo);
            this.panel_admin.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_admin.Location = new System.Drawing.Point(0, 0);
            this.panel_admin.Name = "panel_admin";
            this.panel_admin.Size = new System.Drawing.Size(362, 784);
            this.panel_admin.TabIndex = 1;
            // 
            // B_Cobros
            // 
            this.B_Cobros.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Cobros.FlatAppearance.BorderSize = 0;
            this.B_Cobros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Cobros.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Cobros.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_Cobros.Image = global::Gestor_Gimnasio.Properties.Resources.cobrar;
            this.B_Cobros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Cobros.Location = new System.Drawing.Point(27, 376);
            this.B_Cobros.Name = "B_Cobros";
            this.B_Cobros.Size = new System.Drawing.Size(181, 54);
            this.B_Cobros.TabIndex = 8;
            this.B_Cobros.Text = "COBRAR";
            this.B_Cobros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Cobros.UseVisualStyleBackColor = true;
            this.B_Cobros.Click += new System.EventHandler(this.B_Cobros_Click);
            // 
            // B_Entrenadores
            // 
            this.B_Entrenadores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Entrenadores.FlatAppearance.BorderSize = 0;
            this.B_Entrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Entrenadores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Entrenadores.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_Entrenadores.Image = global::Gestor_Gimnasio.Properties.Resources.users;
            this.B_Entrenadores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Entrenadores.Location = new System.Drawing.Point(24, 234);
            this.B_Entrenadores.Name = "B_Entrenadores";
            this.B_Entrenadores.Size = new System.Drawing.Size(282, 73);
            this.B_Entrenadores.TabIndex = 6;
            this.B_Entrenadores.Text = "ENTRENADORES";
            this.B_Entrenadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Entrenadores.UseVisualStyleBackColor = true;
            this.B_Entrenadores.Click += new System.EventHandler(this.B_Entrenadores_Click);
            // 
            // B_EstadoCuota
            // 
            this.B_EstadoCuota.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_EstadoCuota.FlatAppearance.BorderSize = 0;
            this.B_EstadoCuota.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_EstadoCuota.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_EstadoCuota.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_EstadoCuota.Image = global::Gestor_Gimnasio.Properties.Resources.cuota;
            this.B_EstadoCuota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_EstadoCuota.Location = new System.Drawing.Point(27, 304);
            this.B_EstadoCuota.Name = "B_EstadoCuota";
            this.B_EstadoCuota.Size = new System.Drawing.Size(328, 66);
            this.B_EstadoCuota.TabIndex = 7;
            this.B_EstadoCuota.Text = "ESTADO DE CUOTAS";
            this.B_EstadoCuota.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_EstadoCuota.UseVisualStyleBackColor = true;
            this.B_EstadoCuota.Click += new System.EventHandler(this.B_EstadoCuota_Click);
            // 
            // B_Clientes
            // 
            this.B_Clientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Clientes.FlatAppearance.BorderSize = 0;
            this.B_Clientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Clientes.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Clientes.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_Clientes.Image = global::Gestor_Gimnasio.Properties.Resources.users;
            this.B_Clientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.B_Clientes.Location = new System.Drawing.Point(24, 170);
            this.B_Clientes.Name = "B_Clientes";
            this.B_Clientes.Size = new System.Drawing.Size(198, 61);
            this.B_Clientes.TabIndex = 4;
            this.B_Clientes.Text = "CLIENTES";
            this.B_Clientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.B_Clientes.UseVisualStyleBackColor = true;
            this.B_Clientes.Click += new System.EventHandler(this.B_Clientes_Click);
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
            // panel_DashBoardAdm
            // 
            this.panel_DashBoardAdm.AutoScroll = true;
            this.panel_DashBoardAdm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DashBoardAdm.Location = new System.Drawing.Point(362, 0);
            this.panel_DashBoardAdm.Name = "panel_DashBoardAdm";
            this.panel_DashBoardAdm.Size = new System.Drawing.Size(845, 784);
            this.panel_DashBoardAdm.TabIndex = 2;
            // 
            // button_reportesAlta
            // 
            this.button_reportesAlta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button_reportesAlta.FlatAppearance.BorderSize = 0;
            this.button_reportesAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_reportesAlta.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reportesAlta.ForeColor = System.Drawing.Color.GreenYellow;
            this.button_reportesAlta.Image = global::Gestor_Gimnasio.Properties.Resources.users;
            this.button_reportesAlta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_reportesAlta.Location = new System.Drawing.Point(24, 436);
            this.button_reportesAlta.Name = "button_reportesAlta";
            this.button_reportesAlta.Size = new System.Drawing.Size(216, 61);
            this.button_reportesAlta.TabIndex = 9;
            this.button_reportesAlta.Text = "MIS ALTAS";
            this.button_reportesAlta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_reportesAlta.UseVisualStyleBackColor = true;
            this.button_reportesAlta.Click += new System.EventHandler(this.button_reportesAlta_Click);
            // 
            // DashboardAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1207, 784);
            this.Controls.Add(this.panel_DashBoardAdm);
            this.Controls.Add(this.panel_admin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DashboardAdministrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_admin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_admin;
        private System.Windows.Forms.Button B_Entrenadores;
        private System.Windows.Forms.Button B_Clientes;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.PictureBox pbox_logo;
        private System.Windows.Forms.Panel panel_DashBoardAdm;
        private System.Windows.Forms.Button B_Cobros;
        private System.Windows.Forms.Button B_EstadoCuota;
        private System.Windows.Forms.Button button_reportesAlta;
    }
}