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
            this.B_Entrenadores = new System.Windows.Forms.Button();
            this.B_Cuotas = new System.Windows.Forms.Button();
            this.B_Clientes = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.B_Pagos = new System.Windows.Forms.Button();
            this.panel_DashBoardAdm = new System.Windows.Forms.Panel();
            this.panel_admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_admin
            // 
            this.panel_admin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel_admin.Controls.Add(this.B_Pagos);
            this.panel_admin.Controls.Add(this.B_Entrenadores);
            this.panel_admin.Controls.Add(this.B_Cuotas);
            this.panel_admin.Controls.Add(this.B_Clientes);
            this.panel_admin.Controls.Add(this.BSalir);
            this.panel_admin.Controls.Add(this.pbox_logo);
            this.panel_admin.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_admin.Location = new System.Drawing.Point(0, 0);
            this.panel_admin.Name = "panel_admin";
            this.panel_admin.Size = new System.Drawing.Size(293, 784);
            this.panel_admin.TabIndex = 1;
            // 
            // B_Entrenadores
            // 
            this.B_Entrenadores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Entrenadores.FlatAppearance.BorderSize = 0;
            this.B_Entrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Entrenadores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Entrenadores.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_Entrenadores.Location = new System.Drawing.Point(32, 242);
            this.B_Entrenadores.Name = "B_Entrenadores";
            this.B_Entrenadores.Size = new System.Drawing.Size(235, 65);
            this.B_Entrenadores.TabIndex = 6;
            this.B_Entrenadores.Text = "ENTRENADORES";
            this.B_Entrenadores.UseVisualStyleBackColor = true;
            this.B_Entrenadores.Click += new System.EventHandler(this.B_Entrenadores_Click);
            // 
            // B_Cuotas
            // 
            this.B_Cuotas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Cuotas.FlatAppearance.BorderSize = 0;
            this.B_Cuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Cuotas.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Cuotas.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_Cuotas.Location = new System.Drawing.Point(32, 313);
            this.B_Cuotas.Name = "B_Cuotas";
            this.B_Cuotas.Size = new System.Drawing.Size(235, 65);
            this.B_Cuotas.TabIndex = 5;
            this.B_Cuotas.Text = "CUOTAS";
            this.B_Cuotas.UseVisualStyleBackColor = true;
            // 
            // B_Clientes
            // 
            this.B_Clientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Clientes.FlatAppearance.BorderSize = 0;
            this.B_Clientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Clientes.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Clientes.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_Clientes.Location = new System.Drawing.Point(29, 171);
            this.B_Clientes.Name = "B_Clientes";
            this.B_Clientes.Size = new System.Drawing.Size(238, 65);
            this.B_Clientes.TabIndex = 4;
            this.B_Clientes.Text = "CLIENTES";
            this.B_Clientes.UseVisualStyleBackColor = true;
            this.B_Clientes.Click += new System.EventHandler(this.B_Clientes_Click);
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
            // B_Pagos
            // 
            this.B_Pagos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_Pagos.FlatAppearance.BorderSize = 0;
            this.B_Pagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_Pagos.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Pagos.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_Pagos.Location = new System.Drawing.Point(29, 384);
            this.B_Pagos.Name = "B_Pagos";
            this.B_Pagos.Size = new System.Drawing.Size(235, 65);
            this.B_Pagos.TabIndex = 6;
            this.B_Pagos.Text = "PAGOS";
            this.B_Pagos.UseVisualStyleBackColor = true;
            // 
            // panel_DashBoardAdm
            // 
            this.panel_DashBoardAdm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_DashBoardAdm.Location = new System.Drawing.Point(293, 0);
            this.panel_DashBoardAdm.Name = "panel_DashBoardAdm";
            this.panel_DashBoardAdm.Size = new System.Drawing.Size(914, 784);
            this.panel_DashBoardAdm.TabIndex = 2;
            // 
            // DashboardAdministrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1207, 784);
            this.Controls.Add(this.panel_DashBoardAdm);
            this.Controls.Add(this.panel_admin);
            this.Name = "DashboardAdministrador";
            this.Text = "DashboardAdministrador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_admin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_admin;
        private System.Windows.Forms.Button B_Entrenadores;
        private System.Windows.Forms.Button B_Cuotas;
        private System.Windows.Forms.Button B_Clientes;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.PictureBox pbox_logo;
        private System.Windows.Forms.Button B_Pagos;
        private System.Windows.Forms.Panel panel_DashBoardAdm;
    }
}