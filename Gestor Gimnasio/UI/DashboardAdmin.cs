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
        }

        private void pbox_logo_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void BClientes_Click(object sender, EventArgs e)
        {
            panel_contenido.Controls.Clear();
            navbarCliente.Visible = true;
            panel_contenido.Controls.Add(navbarCliente);
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

            var clienteControl = new ClienteControl();
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

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var buscarCliente = new ClienteBuscarControl();
            CargarControl(buscarCliente); // Método que limpia y carga el UserControl en el panel
        }




    }
}
