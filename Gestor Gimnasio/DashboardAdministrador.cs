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
        public DashboardAdministrador()
        {
            InitializeComponent();
            InicioBienvenida();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            //CON ESTO VOLVEMOS A EL INICIO DE SESION SIN CERRAR COMPLETAMENTE LA APLICACION
            Login login = new Login();
            login.Show();
            this.Hide();

        }

        private void B_Entrenadores_Click(object sender, EventArgs e)
        {
            // Limpiamos el panel antes de cargar el control
            panel_DashBoardAdm.Controls.Clear();

            // Creamos la instancia del UserControl
            ProfesorAgregarControl ucProfesor = new ProfesorAgregarControl();
            ucProfesor.Dock = DockStyle.Fill; // Que ocupe todo el panel
            panel_DashBoardAdm.Controls.Add(ucProfesor); // Lo agregamos al panel
        }

        private void B_Clientes_Click(object sender, EventArgs e)
        {
            // Limpiamos el panel antes de cargar el control
            panel_DashBoardAdm.Controls.Clear();

            // Creamos la instancia del UserControl
            ClienteAgregarControl ucCliente = new ClienteAgregarControl();
            ucCliente.Dock = DockStyle.Fill; // Que ocupe todo el panel
            panel_DashBoardAdm.Controls.Add(ucCliente); // Lo agregamos al panel
        }

        private void InicioBienvenida()
        {
            //nombre del panel en el form
            panel_DashBoardAdm.Controls.Clear();

            var bienvenida = new InicioBienvenidaControl();
            bienvenida.Dock = DockStyle.Fill;

            panel_DashBoardAdm.Controls.Add(bienvenida);
        }
    }
}
