using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_Gimnasio
{
    public partial class ClienteControl : UserControl
    {
        public ClienteControl()
        {
            InitializeComponent();
        }

        private void ClienteControl_Load(object sender, EventArgs e)
        {
            // Simulación (más adelante lo podés reemplazar por datos de BD)
            comboBoxProfesor.Items.Add("Martín Gómez");
            comboBoxProfesor.Items.Add("Carla Pérez");
            comboBoxProfesor.Items.Add("Laura Díaz");
            comboBoxProfesor.Items.Add("Sin asignar"); // Opción libre

            comboBoxProfesor.SelectedIndex = 0; // Por defecto
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = textBoxNombre.Text;
            string dni = textBoxDNI.Text;
            string telefono = textBoxTelefono.Text;
            string profesor = comboBoxProfesor.SelectedItem.ToString();

            MessageBox.Show($"Alumno guardado:\nNombre: {nombre}\nDNI: {dni}\nTeléfono: {telefono}\nProfesor: {profesor}",
                            "Registro Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Clear();
            textBoxDNI.Clear();
            textBoxTelefono.Clear();
        }

        


    }
}
