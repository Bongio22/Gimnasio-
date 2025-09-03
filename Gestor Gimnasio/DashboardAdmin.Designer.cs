using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

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
            this.BCuotas = new System.Windows.Forms.Button();
            this.BPagos = new System.Windows.Forms.Button();
            this.BSalir = new System.Windows.Forms.Button();
            this.pbox_logo = new System.Windows.Forms.PictureBox();
            this.BEntrenadores = new System.Windows.Forms.Button();
            this.BClientes = new System.Windows.Forms.Button();
            this.panel_contenido = new System.Windows.Forms.Panel();
            this.navbarCliente = new System.Windows.Forms.Panel();
            this.BClienteEliminar = new System.Windows.Forms.Button();
            this.BClienteModificar = new System.Windows.Forms.Button();
            this.BClienteBuscar = new System.Windows.Forms.Button();
            this.BClienteAgregar = new System.Windows.Forms.Button();
            this.panel_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).BeginInit();
            this.panel_contenido.SuspendLayout();
            this.navbarCliente.SuspendLayout();
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
            this.panel_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_menu.Location = new System.Drawing.Point(0, 0);
            this.panel_menu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(274, 820);
            this.panel_menu.TabIndex = 2;
            // 
            // BCuotas
            // 
            this.BCuotas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BCuotas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BCuotas.FlatAppearance.BorderSize = 0;
            this.BCuotas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BCuotas.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BCuotas.ForeColor = System.Drawing.Color.GreenYellow;
            this.BCuotas.Location = new System.Drawing.Point(0, 381);
            this.BCuotas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BCuotas.Name = "BCuotas";
            this.BCuotas.Size = new System.Drawing.Size(274, 65);
            this.BCuotas.TabIndex = 4;
            this.BCuotas.Text = "CUOTAS";
            this.BCuotas.UseVisualStyleBackColor = false;
            // 
            // BPagos
            // 
            this.BPagos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BPagos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BPagos.FlatAppearance.BorderSize = 0;
            this.BPagos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BPagos.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BPagos.ForeColor = System.Drawing.Color.GreenYellow;
            this.BPagos.Location = new System.Drawing.Point(0, 454);
            this.BPagos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BPagos.Name = "BPagos";
            this.BPagos.Size = new System.Drawing.Size(274, 65);
            this.BPagos.TabIndex = 3;
            this.BPagos.Text = "PAGOS";
            this.BPagos.UseVisualStyleBackColor = false;
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
            this.BSalir.Location = new System.Drawing.Point(48, 680);
            this.BSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(187, 125);
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
            this.pbox_logo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbox_logo.Name = "pbox_logo";
            this.pbox_logo.Size = new System.Drawing.Size(262, 161);
            this.pbox_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_logo.TabIndex = 0;
            this.pbox_logo.TabStop = false;
            this.pbox_logo.Click += new System.EventHandler(this.pbox_logo_Click);
            // 
            // BEntrenadores
            // 
            this.BEntrenadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BEntrenadores.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BEntrenadores.FlatAppearance.BorderSize = 0;
            this.BEntrenadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEntrenadores.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEntrenadores.ForeColor = System.Drawing.Color.GreenYellow;
            this.BEntrenadores.Location = new System.Drawing.Point(3, 298);
            this.BEntrenadores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BEntrenadores.Name = "BEntrenadores";
            this.BEntrenadores.Size = new System.Drawing.Size(268, 76);
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
            this.BClientes.Location = new System.Drawing.Point(3, 225);
            this.BClientes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BClientes.Name = "BClientes";
            this.BClientes.Size = new System.Drawing.Size(268, 65);
            this.BClientes.TabIndex = 0;
            this.BClientes.Text = "CLIENTES";
            this.BClientes.UseVisualStyleBackColor = false;
            this.BClientes.Click += new System.EventHandler(this.BClientes_Click);
            // 
            // panel_contenido
            // 
            this.panel_contenido.BackgroundImage = global::Gestor_Gimnasio.Properties.Resources.marcaagua;
            this.panel_contenido.Controls.Add(this.navbarCliente);
            this.panel_contenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_contenido.Location = new System.Drawing.Point(274, 0);
            this.panel_contenido.Name = "panel_contenido";
            this.panel_contenido.Size = new System.Drawing.Size(1080, 820);
            this.panel_contenido.TabIndex = 4;
            this.panel_contenido.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_contenido_Paint);
            // 
            // navbarCliente
            // 
            this.navbarCliente.BackColor = System.Drawing.Color.DarkGreen;
            this.navbarCliente.Controls.Add(this.BClienteEliminar);
            this.navbarCliente.Controls.Add(this.BClienteModificar);
            this.navbarCliente.Controls.Add(this.BClienteBuscar);
            this.navbarCliente.Controls.Add(this.BClienteAgregar);
            this.navbarCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.navbarCliente.Location = new System.Drawing.Point(0, 0);
            this.navbarCliente.Name = "navbarCliente";
            this.navbarCliente.Size = new System.Drawing.Size(1080, 100);
            this.navbarCliente.TabIndex = 0;
            this.navbarCliente.Visible = false;
            this.navbarCliente.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BClienteEliminar
            // 
            this.BClienteEliminar.BackColor = System.Drawing.Color.DarkGreen;
            this.BClienteEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BClienteEliminar.FlatAppearance.BorderSize = 0;
            this.BClienteEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClienteEliminar.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClienteEliminar.ForeColor = System.Drawing.Color.GreenYellow;
            this.BClienteEliminar.Location = new System.Drawing.Point(815, 9);
            this.BClienteEliminar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BClienteEliminar.Name = "BClienteEliminar";
            this.BClienteEliminar.Size = new System.Drawing.Size(193, 87);
            this.BClienteEliminar.TabIndex = 3;
            this.BClienteEliminar.Text = "Eliminar Cliente";
            this.BClienteEliminar.UseVisualStyleBackColor = false;
            // 
            // BClienteModificar
            // 
            this.BClienteModificar.BackColor = System.Drawing.Color.DarkGreen;
            this.BClienteModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BClienteModificar.FlatAppearance.BorderSize = 0;
            this.BClienteModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClienteModificar.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClienteModificar.ForeColor = System.Drawing.Color.GreenYellow;
            this.BClienteModificar.Location = new System.Drawing.Point(586, 9);
            this.BClienteModificar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BClienteModificar.Name = "BClienteModificar";
            this.BClienteModificar.Size = new System.Drawing.Size(193, 87);
            this.BClienteModificar.TabIndex = 2;
            this.BClienteModificar.Text = "Modificar Cliente";
            this.BClienteModificar.UseVisualStyleBackColor = false;
            // 
            // BClienteBuscar
            // 
            this.BClienteBuscar.BackColor = System.Drawing.Color.DarkGreen;
            this.BClienteBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BClienteBuscar.FlatAppearance.BorderSize = 0;
            this.BClienteBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClienteBuscar.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClienteBuscar.ForeColor = System.Drawing.Color.GreenYellow;
            this.BClienteBuscar.Location = new System.Drawing.Point(344, 9);
            this.BClienteBuscar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BClienteBuscar.Name = "BClienteBuscar";
            this.BClienteBuscar.Size = new System.Drawing.Size(204, 87);
            this.BClienteBuscar.TabIndex = 2;
            this.BClienteBuscar.Text = "Buscar Cliente";
            this.BClienteBuscar.UseVisualStyleBackColor = false;
            // 
            // BClienteAgregar
            // 
            this.BClienteAgregar.BackColor = System.Drawing.Color.DarkGreen;
            this.BClienteAgregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BClienteAgregar.FlatAppearance.BorderSize = 0;
            this.BClienteAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BClienteAgregar.Font = new System.Drawing.Font("Malgun Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BClienteAgregar.ForeColor = System.Drawing.Color.GreenYellow;
            this.BClienteAgregar.Location = new System.Drawing.Point(124, 9);
            this.BClienteAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BClienteAgregar.Name = "BClienteAgregar";
            this.BClienteAgregar.Size = new System.Drawing.Size(185, 87);
            this.BClienteAgregar.TabIndex = 1;
            this.BClienteAgregar.Text = "Agregar Cliente";
            this.BClienteAgregar.UseVisualStyleBackColor = false;
            this.BClienteAgregar.Click += new System.EventHandler(this.BClienteAgregar_Click);
            // 
            // DashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1354, 820);
            this.Controls.Add(this.panel_contenido);
            this.Controls.Add(this.panel_menu);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DashboardAdmin";
            this.Text = "DashboardAdmin";
            this.panel_menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbox_logo)).EndInit();
            this.panel_contenido.ResumeLayout(false);
            this.navbarCliente.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbox_logo;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.Button BSalir;
        private System.Windows.Forms.Button BEntrenadores;
        private System.Windows.Forms.Button BClientes;
        private System.Windows.Forms.Button BPagos;
        private System.Windows.Forms.Button BCuotas;
        private System.Windows.Forms.Panel panel_contenido;
        private System.Windows.Forms.Panel navbarCliente;
        private System.Windows.Forms.Button BClienteModificar;
        private System.Windows.Forms.Button BClienteBuscar;
        private System.Windows.Forms.Button BClienteAgregar;
        private System.Windows.Forms.Button BClienteEliminar;   
        
    }


}