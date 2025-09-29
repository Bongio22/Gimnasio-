using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;     // ConfigurationManager
using System.Data.SqlClient;    // SqlConnection, SqlCommand

namespace Gestor_Gimnasio
{
    public partial class DashboardSuperAdmin : Form
    {
        private Control controlActivo;
        public DashboardSuperAdmin()
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

                panelContenedor.Controls.Clear();

                ctrl.Dock = DockStyle.Fill;                 // ocupa todo el panel
                panelContenedor.Controls.Add(ctrl);
                panelContenedor.Tag = ctrl;

                controlActivo = ctrl;
                ctrl.BringToFront();
                ctrl.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir la vista: " + ex.ToString());
            }
        }

        private void BEntrenadores_Click(object sender, EventArgs e)
        {
            //carga el profesoragregarcontrol en el panel de este form
            panelContenedor.Controls.Clear();

            ProfesorAgregarControl profesorControl = new ProfesorAgregarControl();
            profesorControl.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(profesorControl);
        }



        private void BSalir_Click(object sender, EventArgs e)
        {
            //CON ESTO VOLVEMOS A EL INICIO DE SESION SIN CERRAR COMPLETAMENTE LA APLICACION
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void DashboardSuperAdmin_Load(object sender, EventArgs e)
        {

        }
        //metodo para mostrar el mensaje de bienvenida y la hora
        private void InicioBienvenida()
        {
            //nombre del panel en el form
            panelContenedor.Controls.Clear();

            var bienvenida = new InicioBienvenidaControl();
            bienvenida.Dock = DockStyle.Fill;

            panelContenedor.Controls.Add(bienvenida);
        }

        private void BClientes_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new ClienteAgregarControl());
        }

        private void BUsuarios_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new UsuariosControl());
        }

        private void BCuotas_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new EstadoCuotasControl());
        }


        private void B_backup_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new BackUp()); 
        }
    }
}
