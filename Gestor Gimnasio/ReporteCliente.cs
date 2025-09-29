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
    public partial class ReporteCliente : Form
    {
        public ReporteCliente()
        {
            InitializeComponent();
            EstadoCuotas();
        }

        private void EstadoCuotas()
        {
            var dgv = dataGridView_Clientes;

            // (solo vista)
            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // id ocultos (para usar dsp) 
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
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIdTurno",
                HeaderText = "ID Turno",
                DataPropertyName = "id_turno",
                Visible = false
            });

            // datso del alumno
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
                DataPropertyName = "turno" // descripción del turno
            });

            // periodo y estado
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
                Name = "colEstado",
                HeaderText = "Estado",
                DataPropertyName = "estado" // al dia, vencido, pendiente
            });

            //  fechas / montos (detalle)
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaVenc",
                HeaderText = "Vencimiento",
                DataPropertyName = "fecha_vencimiento",
                DefaultCellStyle = { Format = "dd/MM/yyyy" },
                Width = 120
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFechaPago",
                HeaderText = "Fecha de pago",
                DataPropertyName = "fecha_pago",     // si no hay pago será NULL
                DefaultCellStyle = {
            Format = "dd/MM/yyyy",
            NullValue = "No pagó"           // lo que se muestra si no pagó
        },
                Width = 120
            });

            // monto
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMonto",
                HeaderText = "Monto",
                DataPropertyName = "monto",
                DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 90
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPagado",
                HeaderText = "Pagado",
                DataPropertyName = "total_pagado",
                DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 90
            });
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colSaldo",
                HeaderText = "Saldo",
                DataPropertyName = "saldo", //  calcular en la consulta dsp
                DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight },
                Width = 90
            });
        
    }
}
}