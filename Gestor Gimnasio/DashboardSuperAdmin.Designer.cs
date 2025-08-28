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
            this.BSalir = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BClientes = new System.Windows.Forms.Button();
            this.BEntrenadores = new System.Windows.Forms.Button();
            this.B_backup = new System.Windows.Forms.Button();
            this.BCuotas = new System.Windows.Forms.Button();
            this.BReportes = new System.Windows.Forms.Button();
            this.BAdministradores = new System.Windows.Forms.Button();
            this.panel_superadmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_superadmin
            // 
            this.panel_superadmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel_superadmin.Controls.Add(this.BAdministradores);
            this.panel_superadmin.Controls.Add(this.BReportes);
            this.panel_superadmin.Controls.Add(this.BEntrenadores);
            this.panel_superadmin.Controls.Add(this.BClientes);
            this.panel_superadmin.Controls.Add(this.BCuotas);
            this.panel_superadmin.Controls.Add(this.B_backup);
            this.panel_superadmin.Controls.Add(this.BSalir);
            this.panel_superadmin.Controls.Add(this.pbox_logo);
            this.panel_superadmin.Location = new System.Drawing.Point(3, 0);
            this.panel_superadmin.Name = "panel_superadmin";
            this.panel_superadmin.Size = new System.Drawing.Size(244, 695);
            this.panel_superadmin.TabIndex = 0;
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
            this.BSalir.Location = new System.Drawing.Point(38, 544);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(166, 100);
            this.BSalir.TabIndex = 2;
            this.BSalir.Text = "Cerrar Sesion";
            this.BSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BSalir.UseVisualStyleBackColor = false;
            // 
            // pbox_logo
            // 
            this.pbox_logo.ErrorImage = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.Image = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.InitialImage = global::Gestor_Gimnasio.Properties.Resources.logo;
            this.pbox_logo.Location = new System.Drawing.Point(5, 0);
            this.pbox_logo.Name = "pbox_logo";
            this.pbox_logo.Size = new System.Drawing.Size(233, 129);
            this.pbox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_logo.TabIndex = 1;
            this.pbox_logo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox2.BackgroundImage = global::Gestor_Gimnasio.Properties.Resources.marcadeagua;
            this.pictureBox2.Location = new System.Drawing.Point(400, 120);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(508, 404);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // BClientes
            // 
            this.BClientes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BClientes.FlatAppearance.BorderSize = 0;
            this.BClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClientes.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClientes.ForeColor = System.Drawing.Color.GreenYellow;
            this.BClientes.Location = new System.Drawing.Point(5, 158);
            this.BClientes.Name = "BClientes";
            this.BClientes.Size = new System.Drawing.Size(231, 59);
            this.BClientes.TabIndex = 3;
            this.BClientes.Text = "CLIENTES";
            this.BClientes.UseVisualStyleBackColor = true;
            // 
            // BEntrenadores
            // 
            this.BEntrenadores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BEntrenadores.FlatAppearance.BorderSize = 0;
            this.BEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEntrenadores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEntrenadores.ForeColor = System.Drawing.Color.GreenYellow;
            this.BEntrenadores.Location = new System.Drawing.Point(9, 288);
            this.BEntrenadores.Name = "BEntrenadores";
            this.BEntrenadores.Size = new System.Drawing.Size(227, 59);
            this.BEntrenadores.TabIndex = 4;
            this.BEntrenadores.Text = "ENTRENADORES";
            this.BEntrenadores.UseVisualStyleBackColor = true;
            // 
            // B_backup
            // 
            this.B_backup.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.B_backup.FlatAppearance.BorderSize = 0;
            this.B_backup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.B_backup.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_backup.ForeColor = System.Drawing.Color.GreenYellow;
            this.B_backup.Location = new System.Drawing.Point(9, 483);
            this.B_backup.Name = "B_backup";
            this.B_backup.Size = new System.Drawing.Size(227, 59);
            this.B_backup.TabIndex = 5;
            this.B_backup.Text = "BACK UP";
            this.B_backup.UseVisualStyleBackColor = true;
            // 
            // BCuotas
            // 
            this.BCuotas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BCuotas.FlatAppearance.BorderSize = 0;
            this.BCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCuotas.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCuotas.ForeColor = System.Drawing.Color.GreenYellow;
            this.BCuotas.Location = new System.Drawing.Point(9, 353);
            this.BCuotas.Name = "BCuotas";
            this.BCuotas.Size = new System.Drawing.Size(227, 59);
            this.BCuotas.TabIndex = 6;
            this.BCuotas.Text = "CUOTAS";
            this.BCuotas.UseVisualStyleBackColor = true;
            // 
            // BReportes
            // 
            this.BReportes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BReportes.FlatAppearance.BorderSize = 0;
            this.BReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BReportes.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BReportes.ForeColor = System.Drawing.Color.GreenYellow;
            this.BReportes.Location = new System.Drawing.Point(11, 418);
            this.BReportes.Name = "BReportes";
            this.BReportes.Size = new System.Drawing.Size(227, 59);
            this.BReportes.TabIndex = 7;
            this.BReportes.Text = "REPORTES";
            this.BReportes.UseVisualStyleBackColor = true;
            // 
            // BAdministradores
            // 
            this.BAdministradores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BAdministradores.FlatAppearance.BorderSize = 0;
            this.BAdministradores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BAdministradores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAdministradores.ForeColor = System.Drawing.Color.GreenYellow;
            this.BAdministradores.Location = new System.Drawing.Point(3, 223);
            this.BAdministradores.Name = "BAdministradores";
            this.BAdministradores.Size = new System.Drawing.Size(241, 59);
            this.BAdministradores.TabIndex = 8;
            this.BAdministradores.Text = "ADMINISTRADORES";
            this.BAdministradores.UseVisualStyleBackColor = true;
            // 
            // DashboardSuperAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1021, 656);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel_superadmin);
            this.Name = "DashboardSuperAdmin";
            this.Text = "DashboardSuperAdmin";
            this.panel_superadmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_superadmin;
        private System.Windows.Forms.PictureBox pbox_logo;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BReportes;
        private System.Windows.Forms.Button BCuotas;
        private System.Windows.Forms.Button B_backup;
        private System.Windows.Forms.Button BEntrenadores;
        private System.Windows.Forms.Button BClientes;
        private System.Windows.Forms.Button BAdministradores;
    }
}