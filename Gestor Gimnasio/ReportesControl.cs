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
    public partial class ReportesControl : UserControl
    {
        public ReportesControl()
        {
            InitializeComponent();
            ListaIngresos();
        }

        private void B_VerReporteClientes_Click(object sender, EventArgs e)
        {
            var frm = new ReporteCliente();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(this.FindForm()); // 
        }

        private void B_VerReporteEntrenadores_Click(object sender, EventArgs e)
        {
            var frm = new ReporteEntrenador();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Show(this.FindForm()); // 
        }

        private void ListaIngresos()
        {
            var dgv = dataGridView_Ingresos;

            //  general
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // id ocultos para usar dsp
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdAlumno",
                HeaderText = "ID Alumno",
                DataPropertyName = "id_alumno",
                Visible = false
            });


            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdTurno",
                HeaderText = "ID Turno",
                DataPropertyName = "id_turno",
                Visible = false
            });
            
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdPago",
                HeaderText = "ID Pago",
                DataPropertyName = "id_pago",
                Visible = false
            });

            // visibles
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
                DataPropertyName = "dni",
                Width = 120
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTurno",
                HeaderText = "Turno",
                DataPropertyName = "turno" // descripción del turno
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaAlta",
                HeaderText = "Fecha de alta",
                DataPropertyName = "fecha_alta",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 120
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMonto",
                HeaderText = "Monto",
                DataPropertyName = "monto",
                DefaultCellStyle = {
            Format = "N2",
            Alignment = DataGridViewContentAlignment.MiddleRight
        },
                Width = 100
            });
        }

    }
}
