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
    public partial class CobrosControl : UserControl
    {
        public CobrosControl()
        {
            InitializeComponent();
            cuotasVencidas();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_Cobros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cuotasVencidas()
        {
            var dgv = dataGridView_Cobros;

            //muestra general
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ids ocultos (para operar el pago dsp)
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdAlumno",
                HeaderText = "ID Alumno",
                DataPropertyName = "id_alumno",
                Visible = false
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdCuota",
                HeaderText = "ID Cuota",
                DataPropertyName = "id_cuota",
                Visible = false
            });

            // solo vencidas
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colNombre",
                HeaderText = "Nombre",
                DataPropertyName = "nombre"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "dni"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTurno",
                HeaderText = "Turno",
                DataPropertyName = "turno"  // ej. descripción del turno
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colAnio",
                HeaderText = "Año",
                DataPropertyName = "anio",
                Width = 70
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMes",
                HeaderText = "Mes",
                DataPropertyName = "mes",
                Width = 60
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVencimiento",
                HeaderText = "Vencimiento",
                DataPropertyName = "fecha_vencimiento",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 110
            });

            //  columna de texto fija para indicar que la fila es VENCIDA
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "Estado", // para setear vencidos cuando conecte datos
                Width = 90
            });

            // boton pagar
            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "colPagar",
                HeaderText = "Acción",
                Text = "Pagar",
                UseColumnTextForButtonValue = true
            });
        }

    }
}
