using Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.Linq;
using System.Web.UI.DataVisualization.Charting;
using System.Windows.Forms;
using ChartSeries = System.Windows.Forms.DataVisualization.Charting.Chart;
namespace AgentieTurism2025
{
    public partial class FormStatistici : Form
    {
        private dateDataSetTableAdapters.Sheet1TableAdapter oferteAdapter;
        private dateDataSet.Sheet1DataTable oferteTable;

        public FormStatistici()
        {
            InitializeComponent();

            // Inițializare adaptor pentru baza de date
            oferteAdapter = new dateDataSetTableAdapters.Sheet1TableAdapter();
            oferteTable = new dateDataSet.Sheet1DataTable();

            // Populare inițială a datelor
            oferteAdapter.Fill(oferteTable);

            // Încarcă statisticile la deschiderea formularului
            IncarcaStatistici();
        }

        private void IncarcaStatistici()
        {
            try
            {
                // Verifică dacă există date
                if (oferteTable.Rows.Count == 0)
                {
                    MessageBox.Show("Nu există oferte în baza de date!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Calculează și afișează statistica de bază
                decimal pretMediu = (decimal)oferteTable.Average(r => r.Pret);
                decimal pretMinim = (decimal)oferteTable.Min(r => r.Pret);
                decimal pretMaxim = (decimal)oferteTable.Max(r => r.Pret);
                int numarOferte = oferteTable.Count;
                double durataMediaZile = oferteTable.Average(r => r.NumarZile);

                lblNumarOferte.Text = numarOferte.ToString();
                lblPretMediu.Text = pretMediu.ToString("C");
                lblPretMinim.Text = pretMinim.ToString("C");
                lblPretMaxim.Text = pretMaxim.ToString("C");
                lblDurataMedia.Text = durataMediaZile.ToString("F1") + " zile";

                // Calculează top destinații
                var topDestinatii = oferteTable
                    .GroupBy(r => r.Destinatie)
                    .Select(g => new { Destinatie = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .Take(5)
                    .ToList();

                lstTopDestinatii.Items.Clear();
                foreach (var dest in topDestinatii)
                {
                    lstTopDestinatii.Items.Add($"{dest.Destinatie} ({dest.Count} oferte)");
                }

                // Distribuția transportului
                var transportDistribution = oferteTable
                    .GroupBy(r => r.Transport)
                    .Select(g => new { Transport = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToList();

                // Configurează graficul pentru transport
                chartTransport.Series.Clear();
                System.Windows.Forms.DataVisualization.Charting.Series series = chartTransport.Series.Add("Transport");
                series.ChartType = (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)SeriesChartType.Pie;

                foreach (var item in transportDistribution)
                {
                    series.Points.AddXY(item.Transport, item.Count);
                }

                // Configurează graficul pentru prețuri
                chartPreturi.Series.Clear();
                System.Windows.Forms.DataVisualization.Charting.Series seriesPreturi = chartPreturi.Series.Add("Prețuri");
                seriesPreturi.ChartType = (System.Windows.Forms.DataVisualization.Charting.SeriesChartType)SeriesChartType.Column;

                // Creează intervale de preț pentru graficul de distribuție
                int intervalSize = (int)((pretMaxim - pretMinim) / 5) + 1;
                for (int i = 0; i < 5; i++)
                {
                    decimal limitaInferioara = pretMinim + (decimal)(i * intervalSize);
                    decimal limitaSuperioara = pretMinim + (decimal)((i + 1) * intervalSize);

                    int count = oferteTable.Count(r => {
                        decimal pret = Convert.ToDecimal(r.Pret);
                        return pret >= limitaInferioara && pret < limitaSuperioara;
                    });
                    string label = $"{limitaInferioara:C} - {limitaSuperioara:C}";
                    seriesPreturi.Points.AddXY(label, count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la calcularea statisticilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            // Deschide formularul de export Excel
            FormExcel formExcel = new FormExcel();
            formExcel.Show();
        }

        private void btnInchide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            // Reîncarcă datele și actualizează statisticile
            oferteAdapter.Fill(oferteTable);
            IncarcaStatistici();
        }
    }
}