using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gestor_Gimnasio
{
    public partial class ReportesControl : UserControl
    {
        private string CS => ConfigurationManager.ConnectionStrings["BaseDatos"].ConnectionString;

        public ReportesControl()
        {
            InitializeComponent();

            // === UI inicial ===
            ConfigurarGrilla();
            ConfigurarChart();
            ConfigurarDemandaUI();   // llena cboMesDemanda con el mes actual en índice 0
            ConfigurarDataGridView(dataGridView_Ingresos);
            // Date pickers (rango ingresos)
            if (dtpDesde != null)
            {
                dtpDesde.Format = DateTimePickerFormat.Custom;
                dtpDesde.CustomFormat = "dd/MM/yyyy";
                dtpDesde.Value = DateTime.Today.AddDays(-30);
            }
            if (dtpHasta != null)
            {
                dtpHasta.Format = DateTimePickerFormat.Custom;
                dtpHasta.CustomFormat = "dd/MM/yyyy";
                dtpHasta.Value = DateTime.Today;
            }

            // Botones
            B_BuscarIngresosMes.Click += (s, e) => BuscarPorRango();           // SOLO grilla + total
            B_BuscarTurnosMes.Click += (s, e) => ActualizarGraficoDemanda();  // ÚNICO que toca el gráfico


            // === Primera carga ===
            BuscarPorRango();           // ingresos por rango (no toca gráfico)
            ActualizarGraficoDemanda(); // gráfico del MES ACTUAL sin tocar ningún botón
        }

        private void ConfigurarDataGridView(DataGridView dgv)
        {

            Color verdeEncabezado = ColorTranslator.FromHtml("#014A16"); // verde bosque apagado
            Color verdeSeleccion = ColorTranslator.FromHtml("#7BAE7F"); // verde medio selección
            Color verdeAlterna = ColorTranslator.FromHtml("#EDFFEF"); // verde muy claro alternado
            Color grisBorde = ColorTranslator.FromHtml("#C8D3C4"); // gris verdoso claro
            Color hoverSuave = ColorTranslator.FromHtml("#DCEFE6"); // verde pastel para hover

            // --- Comportamiento ---
            dgv.ReadOnly = true;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ScrollBars = ScrollBars.Both;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.EnableHeadersVisualStyles = false;

            // --- Autoajuste ---
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

            // --- Estética general ---
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = grisBorde;

            // Encabezado
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = verdeEncabezado;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.ColumnHeadersHeight = 36;

            // Celdas
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = verdeSeleccion;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(4, 6, 4, 6);

            // Filas alternadas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = verdeAlterna;

            // --- Sin selección inicial ---
            dgv.ClearSelection();
            dgv.DataBindingComplete += (s, e) => ((DataGridView)s).ClearSelection();

            // --- Hover suave (efecto al pasar el mouse) ---
            Color originalBackColor = dgv.DefaultCellStyle.BackColor;
            Color originalAltColor = dgv.AlternatingRowsDefaultCellStyle.BackColor;
            int lastRow = -1;

            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex != lastRow)
                {
                    var fila = dgv.Rows[e.RowIndex];
                    fila.DefaultCellStyle.BackColor = hoverSuave;
                    lastRow = e.RowIndex;
                }
            };

            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    var fila = dgv.Rows[e.RowIndex];
                    fila.DefaultCellStyle.BackColor = (e.RowIndex % 2 == 0) ? originalBackColor : originalAltColor;
                }
            };

            // --- Doble buffer (scroll suave) ---
            try
            {
                typeof(DataGridView)
                    .GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(dgv, true, null);
            }
            catch { }
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
        private void B_Admin_Click(object sender, EventArgs e)
        {
            var frm = new ReporteCobros
            {
                StartPosition = FormStartPosition.CenterParent
            };

            frm.Show(this.FindForm()); 
        }

        private void ConfigurarGrilla()
        {
            var dgv = dataGridView_Ingresos;

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
            grafico.Series.Clear();
            grafico.ChartAreas.Clear();
            grafico.Legends.Clear();

            var area = new ChartArea("main");
            grafico.ChartAreas.Add(area);

            var series = new Series("Distribución por turno")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                // Etiqueta: "Turno: cantidad (porcentaje)"
                Label = "#VALX: #VALY (#PERCENT{P0})"
            };
            grafico.Series.Add(series);

            grafico.Legends.Add(new Legend("leyenda"));

        }

        // =============== DEMANDA (mes actual o seleccionado) ===============
        // Handler separado para evitar duplicar suscripciones
        private void Checkbox_Pagaron_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarGraficoDemanda();
        }

        private void ConfigurarDemandaUI()
        {
            // Cargar últimos 12 meses (index 0 = mes actual)
            if (cboMesDemanda != null)
            {
                cboMesDemanda.DropDownStyle = ComboBoxStyle.DropDownList;
                cboMesDemanda.Items.Clear();

                var hoy = DateTime.Today;
                for (int i = 0; i < 12; i++)
                {
                    var dt = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-i);
                    var texto = CultureInfo.GetCultureInfo("es-AR")
                                 .TextInfo.ToTitleCase(dt.ToString("MMMM yyyy", new CultureInfo("es-AR")));
                    cboMesDemanda.Items.Add(new PeriodoItem(texto, dt.Year, dt.Month));
                }

                if (cboMesDemanda.Items.Count > 0)
                    cboMesDemanda.SelectedIndex = 0;

            }

            // El checkbox SÍ refresca inmediatamente el gráfico
            if (checkbox_pagaron != null)
            {
                // Evita múltiple-suscripción si el método se llamara más de una vez
                checkbox_pagaron.CheckedChanged -= Checkbox_Pagaron_CheckedChanged;
                checkbox_pagaron.CheckedChanged += Checkbox_Pagaron_CheckedChanged;
            }
        }


        private (DateTime desde, DateTime hasta) RangoMensual(int year, int month)
        {
            var desde = new DateTime(year, month, 1);
            var hasta = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            return (desde, hasta);
        }

        /// <summary>
        /// Dibuja el gráfico circular con la distribución por turno para el mes seleccionado en cboMesDemanda.
        /// Respeta el check "checkbox_pagaron". NO se llama desde BuscarPorRango().
        /// </summary>
        private void ActualizarGraficoDemanda()
        {
            var per = cboMesDemanda?.SelectedItem as PeriodoItem;
            if (per == null) return;

            var (desde, hasta) = RangoMensual(per.Year, per.Month);
            bool soloPagaron = checkbox_pagaron?.Checked ?? false;

            // Trae los datos según la opción
            DataTable dt = soloPagaron
                ? ObtenerDemanda_PagaronMes(desde, hasta)
                : ObtenerDemanda_AsignadosAlCierre(hasta);

            // Si no hay datos, limpiar y salir
            if (dt == null || dt.Rows.Count == 0)
            {
                if (grafico.Series.Count > 0)
                    grafico.Series[0].Points.Clear();
                return;
            }

            var serie = grafico.Series[0];
            serie.Points.Clear();
            serie.ChartType = SeriesChartType.Pie;
            serie.IsValueShownAsLabel = true;
            serie.Label = "#VALX: #VALY (#PERCENT{P0})";
            serie.LegendText = "#VALX";

            foreach (DataRow r in dt.Rows)
                serie.Points.AddXY(r["turno"].ToString(), Convert.ToInt32(r["cant"]));

            grafico.Invalidate(); // fuerza repintado
                                  // === Colores personalizados (idénticos a los del ejemplo) ===
            string[] coloresVerdes =
            { "#698B2E","#7FFF00", "#ADFF2F" };
            int i = 0;
            foreach (DataPoint p in serie.Points)
            {
                p.Color = System.Drawing.ColorTranslator.FromHtml(coloresVerdes[i % coloresVerdes.Length]);
                i++;
            }

        }

        private DataTable ObtenerDemanda_AsignadosAlCierre(DateTime finMes)
        {
            const string sql = @"
SELECT
    t.descripcion AS turno,
    COUNT(*)      AS cant
FROM dbo.Alumno a
JOIN dbo.Turno  t ON t.id_turno = a.id_turno
WHERE a.activo = 1
  AND a.fecha_alta <= @finMes
GROUP BY t.descripcion
ORDER BY cant DESC;";

            var dt = new DataTable();
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@finMes", SqlDbType.Date).Value = finMes.Date;
                da.Fill(dt);
            }
            return dt;
        }

        private DataTable ObtenerDemanda_PagaronMes(DateTime desde, DateTime hasta)
        {
            const string sql = @"
SELECT
    t.descripcion AS turno,
    COUNT(DISTINCT c.id_alumno) AS cant
FROM dbo.Pago   p
JOIN dbo.Cuota  c ON c.id_cuota = p.id_cuota
JOIN dbo.Alumno a ON a.id_alumno = c.id_alumno
JOIN dbo.Turno  t ON t.id_turno  = a.id_turno
WHERE p.fecha_pago >= @desde
  AND p.fecha_pago <  DATEADD(DAY, 1, @hasta)
GROUP BY t.descripcion
ORDER BY cant DESC;";

            var dt = new DataTable();
            using (var cn = new SqlConnection(CS))
            using (var da = new SqlDataAdapter(sql, cn))
            {
                da.SelectCommand.Parameters.Add("@desde", SqlDbType.Date).Value = desde.Date;
                da.SelectCommand.Parameters.Add("@hasta", SqlDbType.Date).Value = hasta.Date;
                da.Fill(dt);
            }
            return dt;
        }

        // =============== RANGO (grilla/total) ===============
        private void BuscarPorRango()
        {
            var desde = (dtpDesde?.Value ?? DateTime.Today.AddDays(-30)).Date;
            var hasta = (dtpHasta?.Value ?? DateTime.Today).Date;

            if (hasta < desde)
            {
                MessageBox.Show("La fecha 'hasta' no puede ser menor que 'desde'.", "Rango inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tabla = ObtenerIngresos(desde, hasta);
            dataGridView_Ingresos.DataSource = tabla;

            if (tabla.Rows.Count == 0)
            {
                textBox_TotalIngresos.Text = "0,00";
                // No tocar el gráfico acá
                return;
            }

            ActualizarTotal(tabla);
            // No tocar el gráfico acá
        }

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
            decimal total = 0m;
            foreach (DataRow r in tabla.Rows)
            {
                if (r["monto"] != DBNull.Value)
                    total += Convert.ToDecimal(r["monto"]);
            }

            textBox_TotalIngresos.Text = total.ToString("N2", new CultureInfo("es-AR"));
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
