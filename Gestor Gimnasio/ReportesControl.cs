using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestor_Gimnasio
{
    public partial class ReportesControl : UserControl
    {
        private string CS => ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public ReportesControl()
        {
            InitializeComponent();

            comboBox_IngresosMes.DropDownStyle = ComboBoxStyle.DropDownList;

            ConfigurarGrilla();
            ConfigurarChart();           // usa chart1 internamente
            CargarPeriodos();            // llena comboBox_IngresosMes
            comboBox_IngresosMes.SelectedIndex = 0;
            RefrescarDatosPeriodoActual();

            // C# 7.3 compatible
            B_BuscarIngresosMes.Click += (s, e) => BuscarPeriodoSeleccionado();
            B_VerReporteClientes.Click += B_VerReporteClientes_Click;
            B_VerReporteEntrenadores.Click += B_VerReporteEntrenadores_Click;
        }

        private void B_VerReporteClientes_Click(object sender, EventArgs e)
        {
            var frm = new ReporteCliente { StartPosition = FormStartPosition.CenterParent };
            frm.Show(this.FindForm());
        }

        private void B_VerReporteEntrenadores_Click(object sender, EventArgs e)
        {
            var frm = new ReporteEntrenador { StartPosition = FormStartPosition.CenterParent };
            frm.Show(this.FindForm());
        }

        // =============== UI ===============
        private void ConfigurarGrilla()
        {
            var dgv = dataGridView_Ingresos;

            dgv.AutoGenerateColumns = false;
            dgv.Columns.Clear();
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ocultas (ids)
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colIdAlumno", HeaderText = "ID Alumno", DataPropertyName = "id_alumno", Visible = false });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colIdTurno", HeaderText = "ID Turno", DataPropertyName = "id_turno", Visible = false });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colIdPago", HeaderText = "ID Pago", DataPropertyName = "id_pago", Visible = false });

            // visibles
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colNombre", HeaderText = "Nombre", DataPropertyName = "nombre" });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colDni", HeaderText = "DNI", DataPropertyName = "dni", Width = 120 });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colTurno", HeaderText = "Turno", DataPropertyName = "turno" });

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
                DefaultCellStyle =
                {
                    Format = "N2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                },
                Width = 100
            });
        }
        private void ConfigurarChart()
        {
            // Limpia cualquier configuración previa
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();

            // Área principal del gráfico
            var area = new ChartArea("main");
            chart1.ChartAreas.Add(area);

            // Serie principal tipo pastel
            var series = new Series("Pagos por turno")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "P0" // muestra porcentajes sin decimales
            };
            chart1.Series.Add(series);

            // Leyenda
            chart1.Legends.Add(new Legend("leyenda"));
        }


        private void CargarPeriodos()
        {
            // Últimos 12 meses (index 0 = mes actual)
            comboBox_IngresosMes.Items.Clear();
            var hoy = DateTime.Today;

            for (int i = 0; i < 12; i++)
            {
                var dt = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-i);
                var texto = CultureInfo.GetCultureInfo("es-AR")
                             .TextInfo.ToTitleCase(dt.ToString("MMMM yyyy", new CultureInfo("es-AR")));
                comboBox_IngresosMes.Items.Add(new PeriodoItem(texto, dt.Year, dt.Month));
            }
        }

        private void RefrescarDatosPeriodoActual()
        {
            if (comboBox_IngresosMes.Items.Count == 0) return;
            comboBox_IngresosMes.SelectedIndex = 0;
            BuscarPeriodoSeleccionado();
        }


        private void BuscarPeriodoSeleccionado()
        {
            // obtengo el ítem seleccionado del combo real
            var per = comboBox_IngresosMes.SelectedItem as PeriodoItem;
            if (per == null) return;

            var desde = new DateTime(per.Year, per.Month, 1);
            var hasta = new DateTime(per.Year, per.Month, DateTime.DaysInMonth(per.Year, per.Month));

            var tabla = ObtenerIngresos(desde, hasta);
            dataGridView_Ingresos.DataSource = tabla;

            // Si no hay datos, limpiamos el gráfico y el total
            if (tabla.Rows.Count == 0)
            {
                textBox_TotalIngresos.Text = "0,00";
                chart1.Series[0].Points.Clear();
                return;
            }

            ActualizarTotal(tabla);
            ActualizarGrafico(tabla);
        }


        // =============== Datos ===============

        private DataTable ObtenerIngresos(DateTime desde, DateTime hasta)
        {
            const string sql = @"
SELECT
    a.id_alumno,
    a.nombre,
    a.dni,
    t.id_turno,
    t.descripcion AS turno,
    a.fecha_alta,
    p.id_pago,
    p.monto,
    p.fecha_pago
FROM dbo.Pago      AS p
JOIN dbo.Cuota     AS c ON c.id_cuota = p.id_cuota
JOIN dbo.Alumno    AS a ON a.id_alumno = c.id_alumno
JOIN dbo.Turno     AS t ON t.id_turno  = a.id_turno
WHERE p.fecha_pago >= @desde
  AND p.fecha_pago <  DATEADD(DAY, 1, @hasta)
ORDER BY p.fecha_pago DESC, a.nombre;";

            var tabla = new DataTable();
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@desde", SqlDbType.Date).Value = desde.Date;
                da.SelectCommand.Parameters.Add("@hasta", SqlDbType.Date).Value = hasta.Date;
                da.Fill(tabla);
            }
            return tabla;
        }

        private void ActualizarTotal(DataTable tabla)
        {
            // Calcula la suma de la columna 'monto'
            var total = tabla.AsEnumerable().Sum(r => r.Field<decimal>("monto"));

            // Muestra el total formateado con separadores decimales locales
            textBox_TotalIngresos.Text = total.ToString("N2", new CultureInfo("es-AR"));
        }


        private void ActualizarGrafico(DataTable tabla)
        {
            // Obtenemos la primera serie del gráfico (la que configuraste en ConfigurarChart)
            var serie = chart1.Series[0];
            serie.Points.Clear();

            // Agrupamos los registros por "turno" y contamos la cantidad de pagos
            var grupos = tabla.AsEnumerable()
                              .GroupBy(r => r.Field<string>("turno"))
                              .Select(g => new { Turno = g.Key, Cant = g.Count() })
                              .OrderByDescending(x => x.Cant)
                              .ToList();

            // Cargamos los datos en el gráfico
            foreach (var g in grupos)
                serie.Points.AddXY(g.Turno, g.Cant);

            // Si querés que muestre porcentajes basados en el monto total, 
            // cambiá el GroupBy por esto:
            //
            // var grupos = tabla.AsEnumerable()
            //                   .GroupBy(r => r.Field<string>("turno"))
            //                   .Select(g => new { Turno = g.Key, Importe = g.Sum(r => r.Field<decimal>("monto")) })
            //                   .OrderByDescending(x => x.Importe)
            //                   .ToList();
            //
            // Y después:
            // foreach (var g in grupos)
            //     serie.Points.AddXY(g.Turno, g.Importe);
        }


        // =============== Helper ===============
        private sealed class PeriodoItem
        {
            public string Texto { get; }
            public int Year { get; }
            public int Month { get; }
            public PeriodoItem(string texto, int y, int m) { Texto = texto; Year = y; Month = m; }
            public override string ToString() => Texto;
        }
    }
}




  