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
    public partial class DashboardAdministrador : Form
    {
        private Control controlActivo;

        public DashboardAdministrador()
        {
            InitializeComponent();
            InicioBienvenida();

        
        }

        
        private void AbrirControlEnPanel(Control ctrl)
        {
            try
            {
                if (controlActivo != null && !controlActivo.IsDisposed)
                {
                    controlActivo.Dispose();
                    controlActivo = null;
                }

                panel_DashBoardAdm.Controls.Clear();

                ctrl.Dock = DockStyle.Fill;                
                panel_DashBoardAdm.Controls.Add(ctrl);
                panel_DashBoardAdm.Tag = ctrl;

                controlActivo = ctrl;
                ctrl.BringToFront();
                ctrl.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la vista: " + ex.ToString());
            }
        }

 
        private void B_Entrenadores_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new ProfesorAgregarControl());
        }

        private void B_Clientes_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new ClienteAgregarControl());
        }


      


        private void InicioBienvenida()
        {
            panel_DashBoardAdm.Controls.Clear();

            var bienvenida = new InicioBienvenidaControl
            {
                Dock = DockStyle.Fill
            };

            panel_DashBoardAdm.Controls.Add(bienvenida);
        }

     
        private void BSalir_Click(object sender, EventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Hide();
        }

        private void B_EstadoCuota_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new EstadoCuotasControl());
        }

        private void B_Cobros_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new CobrosControl());
        }
    }
}
