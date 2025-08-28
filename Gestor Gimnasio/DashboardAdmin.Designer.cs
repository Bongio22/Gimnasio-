namespace Gestor_Gimnasio
{
    partial class DashboardAdmin
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
            this.panel_menu = new System.Windows.Forms.Panel();
            this.BEntrenadores = new System.Windows.Forms.Button();
            this.BClientes = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BSalir = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.BPagos = new System.Windows.Forms.Button();
            this.BCuotas = new System.Windows.Forms.Button();
            this.panel_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel_menu.Controls.Add(this.BCuotas);
            this.panel_menu.Controls.Add(this.BPagos);
            this.panel_menu.Controls.Add(this.BSalir);
            this.panel_menu.Controls.Add(this.pbox_logo);
            this.panel_menu.Controls.Add(this.BEntrenadores);
            this.panel_menu.Controls.Add(this.BClientes);
            this.panel_menu.Location = new System.Drawing.Point(3, 0);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(244, 695);
            this.panel_menu.TabIndex = 2;
            // 
            // BEntrenadores
            // 
            this.BEntrenadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BEntrenadores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BEntrenadores.FlatAppearance.BorderSize = 0;
            this.BEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEntrenadores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEntrenadores.ForeColor = System.Drawing.Color.GreenYellow;
            this.BEntrenadores.Location = new System.Drawing.Point(3, 238);
            this.BEntrenadores.Name = "BEntrenadores";
            this.BEntrenadores.Size = new System.Drawing.Size(238, 61);
            this.BEntrenadores.TabIndex = 1;
            this.BEntrenadores.Text = "ENTRENADORES";
            this.BEntrenadores.UseVisualStyleBackColor = false;
            // 
            // BClientes
            // 
            this.BClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BClientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BClientes.FlatAppearance.BorderSize = 0;
            this.BClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClientes.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClientes.ForeColor = System.Drawing.Color.GreenYellow;
            this.BClientes.Location = new System.Drawing.Point(3, 180);
            this.BClientes.Name = "BClientes";
            this.BClientes.Size = new System.Drawing.Size(238, 52);
            this.BClientes.TabIndex = 0;
            this.BClientes.Text = "CLIENTES";
            this.BClientes.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Gestor_Gimnasio.Properties.Resources.marcadeagua;
            this.pictureBox2.Location = new System.Drawing.Point(395, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(508, 404);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BSalir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BSalir.FlatAppearance.BorderSize = 0;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Malgun Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.Color.GreenYellow;
            this.BSalir.Image = global::Gestor_Gimnasio.Properties.Resources.cerrar_sesion;
            this.BSalir.Location = new System.Drawing.Point(43, 544);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(166, 100);
            this.BSalir.TabIndex = 1;
            this.BSalir.Text = "Cerrar Sesion";
            this.BSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BSalir.UseVisualStyleBackColor = false;
            // 
            // pbox_logo
            // 
            this.pbox_logo.ErrorImage = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.Image = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.InitialImage = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.Location = new System.Drawing.Point(3, 0);
            this.pbox_logo.Name = "pbox_logo";
            this.pbox_logo.Size = new System.Drawing.Size(233, 129);
            this.pbox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_logo.TabIndex = 0;
            this.pbox_logo.TabStop = false;
            this.pbox_logo.Click += new System.EventHandler(this.pbox_logo_Click);
            // 
            // BPagos
            // 
            this.BPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BPagos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BPagos.FlatAppearance.BorderSize = 0;
            this.BPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BPagos.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPagos.ForeColor = System.Drawing.Color.GreenYellow;
            this.BPagos.Location = new System.Drawing.Point(0, 363);
            this.BPagos.Name = "BPagos";
            this.BPagos.Size = new System.Drawing.Size(244, 52);
            this.BPagos.TabIndex = 3;
            this.BPagos.Text = "PAGOS";
            this.BPagos.UseVisualStyleBackColor = false;
            // 
            // BCuotas
            // 
            this.BCuotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BCuotas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BCuotas.FlatAppearance.BorderSize = 0;
            this.BCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCuotas.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCuotas.ForeColor = System.Drawing.Color.GreenYellow;
            this.BCuotas.Location = new System.Drawing.Point(0, 305);
            this.BCuotas.Name = "BCuotas";
            this.BCuotas.Size = new System.Drawing.Size(244, 52);
            this.BCuotas.TabIndex = 4;
            this.BCuotas.Text = "CUOTAS";
            this.BCuotas.UseVisualStyleBackColor = false;
            // 
            // DashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1021, 656);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel_menu);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DashboardAdmin";
            this.Text = "DashboardAdmin";
            this.panel_menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbox_logo;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BEntrenadores;
        private System.Windows.Forms.Button BClientes;
        private System.Windows.Forms.Button BPagos;
        private System.Windows.Forms.Button BCuotas;
    }
}