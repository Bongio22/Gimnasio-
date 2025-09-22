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
    public partial class InicioBienvenidaControl : UserControl
    {
        public InicioBienvenidaControl()
        {
            InitializeComponent();
        }

        private void InicioBlienvenidaControl_Load(object sender, EventArgs e)
        {
           
            labelFecha.Text = DateTime.Now.ToString("dddd dd 'de' MMMM yyyy - HH:mm");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
