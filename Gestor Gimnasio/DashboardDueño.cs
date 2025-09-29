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
    public partial class DashboardDueño : Form
    {
        private Control controlActivo;
        public DashboardDueño()
        {
            InitializeComponent();
            InicioBienvenida();

        }

        //metodo para abrir el form de lista de entrenadores en el panel
        private void AbrirControlEnPanel(Control ctrl)
        {
            try
            {
                // liberar control previo si lo hubiera
                if (controlActivo != null && !controlActivo.IsDisposed)
                {
                    controlActivo.Dispose();
                    controlActivo = null;
                }

                panel_DashboardDueño.Controls.Clear();

                ctrl.Dock = DockStyle.Fill;          // o centrado si preferís
                panel_DashboardDueño.Controls.Add(ctrl);
                panel_DashboardDueño.Tag = ctrl;

                controlActivo = ctrl;
                ctrl.BringToFront();
                ctrl.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el formulario: " + ex.Message);
            }
        }
        
        private void MostrarEntrenadores()
        {
            var ctrl = new ListaEntrenadoresControl();
            AbrirControlEnPanel(ctrl);

            if (ctrl is ListaEntrenadoresControl eCtrl)
                eCtrl.CargarEntrenadores();
        }

        private void MostrarClientes()
        {
            var ctrl = new ListaClientesControl();
            AbrirControlEnPanel(ctrl);

            if (ctrl is ListaClientesControl cCtrl)
                cCtrl.CargarClientes();
        }


        private void MostrarReportes()
        {
            var ctrl = new ReportesControl();
            AbrirControlEnPanel(ctrl);
        }

        private void B_VerEntrenadores_Click(object sender, EventArgs e)
        {
            MostrarEntrenadores();
        }

        private void B_VerClientes_Click(object sender, EventArgs e)
        {
            MostrarClientes();
        }

         private void B_Reportes_Click(object sender, EventArgs e)
        {
            MostrarReportes();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            //CON ESTO VOLVEMOS A EL INICIO DE SESION SIN CERRAR COMPLETAMENTE LA APLICACION
            Login login = new Login();
            login.Show();
            this.Hide();
        }


        //metodo para mostrar el mensaje de bienvenida y la hora
        private void InicioBienvenida()
        {
            //nombre del panel en el form
            panel_DashboardDueño.Controls.Clear();

            var bienvenida = new InicioBienvenidaControl();
            bienvenida.Dock = DockStyle.Fill;

            panel_DashboardDueño.Controls.Add(bienvenida);
        }

        private void BUsuarios_Click(object sender, EventArgs e)
        {
            AbrirControlEnPanel(new UsuariosControl());
        }

         private void DashboardDueño_Load(object sender, EventArgs e)
        {

        }

       
        private void imagenFondo_Click(object sender, EventArgs e)
        {

        }

        
    }
}
