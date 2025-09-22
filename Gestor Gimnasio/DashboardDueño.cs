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
        public DashboardDueño()
        {
            InitializeComponent();
            InicioBienvenida();


        }

    
        //metodo para abrir el form de lista de entrenadores en el panel
        private void AbrirFormularioEnPanel(Form formListaEntrenadores)
        {
            // limpia el panel 
            panelDashboaerdDueño.Controls.Clear();

            formListaEntrenadores.TopLevel = false; // para que este en el panel y no independiente
            formListaEntrenadores.Dock = DockStyle.Fill; 
            panelDashboaerdDueño.Controls.Add(formListaEntrenadores);  // se agrega al panel

            formListaEntrenadores.Show();
        }
        private void MostrarEntrenadores()
        {
            ListaEntrenadores formLista = new ListaEntrenadores();

            AbrirFormularioEnPanel(formLista);//llama al metodo

            formLista.CargarEntrenadores(); // llama a los entrenadores
        }


        private void B_VerEntrenadores_Click(object sender, EventArgs e)
        {
            MostrarEntrenadores();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            //CON ESTO VOLVEMOS A EL INICIO DE SESION SIN CERRAR COMPLETAMENTE LA APLICACION
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void DashboardDueño_Load(object sender, EventArgs e)
        {

        }

        //metodo para mostrar el mensaje de bienvenida y la hora
        private void InicioBienvenida()
        {
            //nombre del panel en el form
            panelDashboaerdDueño.Controls.Clear();

            var bienvenida = new InicioBienvenidaControl();
            bienvenida.Dock = DockStyle.Fill;

            panelDashboaerdDueño.Controls.Add(bienvenida);
        }

        private void imagenFondo_Click(object sender, EventArgs e)
        {

        }

        private void panelDashboaerdDueño_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
