using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class DashboardAdmin : Form
    {
        public DashboardAdmin()
        {
            InitializeComponent();
            // Enganches de eventos para Profesores
            BEntrenadores.Click += BEntrenadores_Click;
            BProfesorAgregar.Click += BProfesorAgregar_Click;
            BProfesorBuscar.Click += BProfesorBuscar_Click;
            BProfesorModificar.Click += BProfesorModificar_Click;
            BProfesorEliminar.Click += BProfesorEliminar_Click;
        }

        private void MostrarNavbar(Panel navbar)
        {
            panel_contenido.Controls.Clear();
            navbar.Visible = true;
            if (!panel_contenido.Controls.Contains(navbar))
                panel_contenido.Controls.Add(navbar);

            // El índice 0 queda arriba del z-order (navbar “encima”).
            panel_contenido.Controls.SetChildIndex(navbar, 0);    // tope del z-order
                                                                  // Alternativa visual: navbar.BringToFront();          // trae al frente. :contentReference[oaicite:2]{index=2}
        }

        private void CargarContenidoBajoNavbar(UserControl ctrl, Panel navbar)
        {
            while (panel_contenido.Controls.Count > 1)
                panel_contenido.Controls.RemoveAt(1);

            ctrl.Dock = DockStyle.Fill;                            // usa el resto del espacio
            panel_contenido.Controls.Add(ctrl);
            panel_contenido.Controls.SetChildIndex(navbar, 0);     // mantener navbar arriba
        }

        // Sidebar: CLIENTES (tu versión actual sirve; si querés usar helper:)
        private void BClientes_Click(object sender, EventArgs e)
        {
            navbarProfesor.Visible = false;
            MostrarNavbar(navbarCliente);
        }

        // Sidebar: ENTRENADORES
        private void BEntrenadores_Click(object sender, EventArgs e)
        {
            navbarCliente.Visible = false;
            MostrarNavbar(navbarProfesor);
        }

        // Navbar Profesores
        private void BProfesorAgregar_Click(object sender, EventArgs e)
        {
            var alta = new ProfesorAgregarControl();
            CargarContenidoBajoNavbar(alta, navbarProfesor);
        }

        private void BProfesorBuscar_Click(object sender, EventArgs e)
        {
            // TODO: var buscar = new ProfesorBuscarControl();
            // CargarContenidoBajoNavbar(buscar, navbarProfesor);
        }

        private void BProfesorModificar_Click(object sender, EventArgs e)
        {
            // TODO: var mod = new ProfesorModificarControl();
            // CargarContenidoBajoNavbar(mod, navbarProfesor);
        }

        private void BProfesorEliminar_Click(object sender, EventArgs e)
        {
            // TODO: var del = new ProfesorEliminarControl();
            // CargarContenidoBajoNavbar(del, navbarProfesor);
        }

        private void pbox_logo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

  
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_contenido_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel_contenido.ClientRectangle, Color.DarkGreen, ButtonBorderStyle.Solid);
        }

        private void BClienteAgregar_Click(object sender, EventArgs e)
        {
            // Elimina cualquier control debajo del navbar
            while (panel_contenido.Controls.Count > 1)
                panel_contenido.Controls.RemoveAt(1);

            var clienteControl = new ClienteAgregarControl();
            clienteControl.Dock = DockStyle.Fill;
            panel_contenido.Controls.Add(clienteControl);
            panel_contenido.Controls.SetChildIndex(navbarCliente, 0); // Navbar siempre arriba
        }

        private void CargarControl(UserControl control)
        {
            panel_contenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel_contenido.Controls.Add(control);
        }

   




    }
}
