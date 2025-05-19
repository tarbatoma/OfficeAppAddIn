using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Linq;

namespace AgentieTurism2025
{
    public partial class FormExcel : Form
    {
        private dateDataSetTableAdapters.Sheet1TableAdapter oferteAdapter;
        private dateDataSet.Sheet1DataTable oferteTable;

        public FormExcel()
        {
            InitializeComponent();

            // Inițializare adaptor pentru baza de date
            oferteAdapter = new dateDataSetTableAdapters.Sheet1TableAdapter();
            oferteTable = new dateDataSet.Sheet1DataTable();

            // Populare inițială a datelor
            oferteAdapter.Fill(oferteTable);
        }

        private void btnExportToate_Click(object sender, EventArgs e)
        {
            // Exportă toate ofertele în Excel
            try
            {
                // Verifică dacă există date
                if (oferteTable.Rows.Count == 0)
                {
                    MessageBox.Show("Nu există oferte în baza de date!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Creare instanță Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Oferte Turistice";

                // Setarea antetului
                worksheet.Range["A1"].Value = "ID";
                worksheet.Range["B1"].Value = "Destinație";
                worksheet.Range["C1"].Value = "Preț";
                worksheet.Range["D1"].Value = "Perioadă";
                worksheet.Range["E1"].Value = "Număr Zile";
                worksheet.Range["F1"].Value = "Transport";

                // Formatarea antetului
                Excel.Range headerRange = worksheet.Range["A1:F1"];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Populare date
                for (int i = 0; i < oferteTable.Rows.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = oferteTable[i].ID1;
                    worksheet.Cells[i + 2, 2] = oferteTable[i].Destinatie;
                    worksheet.Cells[i + 2, 3] = oferteTable[i].Pret;
                    worksheet.Cells[i + 2, 4] = oferteTable[i].Perioada;
                    worksheet.Cells[i + 2, 5] = oferteTable[i].NumarZile;
                    worksheet.Cells[i + 2, 6] = oferteTable[i].Transport;
                }

                // Formatare celule
                Excel.Range dataRange = worksheet.Range["A2:F" + (oferteTable.Rows.Count + 1)];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Formatare coloană preț
                Excel.Range priceRange = worksheet.Range["C2:C" + (oferteTable.Rows.Count + 1)];
                priceRange.NumberFormat = "#,##0.00 \"RON\"";

                // Auto-dimensionare coloane
                worksheet.Columns.AutoFit();

                // Creare grafic pentru distribuția prețurilor
                Excel.ChartObjects charts = (Excel.ChartObjects)worksheet.ChartObjects();
                Excel.ChartObject chartObj = charts.Add(400, 10, 300, 200);
                Excel.Chart chart = chartObj.Chart;

                // Selectează datele pentru grafic (doar destinațiile și prețurile)
                Excel.Range chartDataRange = worksheet.Range["B2:C" + (oferteTable.Rows.Count + 1)];
                chart.SetSourceData(chartDataRange);

                // Setare tip grafic și titlu
                chart.ChartType = Excel.XlChartType.xlColumnClustered;
                chart.HasTitle = true;
                chart.ChartTitle.Text = "Prețuri oferte turistice";

                // Creare grafic pentru distribuția transportului
                Excel.ChartObject chartTransportObj = charts.Add(400, 220, 300, 200);
                Excel.Chart chartTransport = chartTransportObj.Chart;

                // Creare foaie nouă pentru date agregate pentru grafic
                Excel.Worksheet worksheetAgregate = workbook.Sheets.Add();
                worksheetAgregate.Name = "Date Agregate";

                // Creare date agregate pentru transport
                worksheetAgregate.Range["A1"].Value = "Transport";
                worksheetAgregate.Range["B1"].Value = "Număr Oferte";

                // Grupare date după tip transport
                var transportGrup = oferteTable.GroupBy(r => r.Transport)
                    .Select(g => new { Transport = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count);

                int row = 2;
                foreach (var item in transportGrup)
                {
                    worksheetAgregate.Cells[row, 1] = item.Transport;
                    worksheetAgregate.Cells[row, 2] = item.Count;
                    row++;
                }

                // Selectează datele pentru grafic transport
                Excel.Range chartTransportRange = worksheetAgregate.Range["A1:B" + (transportGrup.Count() + 1)];
                chartTransport.SetSourceData(chartTransportRange);

                // Setare tip grafic și titlu
                chartTransport.ChartType = Excel.XlChartType.xlPie;
                chartTransport.HasTitle = true;
                chartTransport.ChartTitle.Text = "Distribuție Transport";

                // Afișează etichete pe grafic
                chartTransport.ApplyDataLabels();

                // Ascunde foaia cu date agregate
                worksheetAgregate.Visible = Excel.XlSheetVisibility.xlSheetHidden;

                // Adaugă foaie cu statistici
                Excel.Worksheet worksheetStats = workbook.Sheets.Add();
                worksheetStats.Name = "Statistici";

                // Adaugă statistici de bază
                worksheetStats.Range["A1"].Value = "Statistici Generale";
                worksheetStats.Range["A1"].Font.Bold = true;
                worksheetStats.Range["A1"].Font.Size = 14;

                worksheetStats.Range["A3"].Value = "Număr total oferte:";
                worksheetStats.Range["B3"].Value = oferteTable.Count;

                worksheetStats.Range["A4"].Value = "Preț mediu:";
                worksheetStats.Range["B4"].Value = oferteTable.Average(r => r.Pret);
                worksheetStats.Range["B4"].NumberFormat = "#,##0.00 \"RON\"";

                worksheetStats.Range["A5"].Value = "Preț minim:";
                worksheetStats.Range["B5"].Value = oferteTable.Min(r => r.Pret);
                worksheetStats.Range["B5"].NumberFormat = "#,##0.00 \"RON\"";

                worksheetStats.Range["A6"].Value = "Preț maxim:";
                worksheetStats.Range["B6"].Value = oferteTable.Max(r => r.Pret);
                worksheetStats.Range["B6"].NumberFormat = "#,##0.00 \"RON\"";

                worksheetStats.Range["A7"].Value = "Durată medie sejur:";
                worksheetStats.Range["B7"].Value = oferteTable.Average(r => r.NumarZile);
                worksheetStats.Range["B7"].NumberFormat = "0.0 \"zile\"";

                worksheetStats.Columns.AutoFit();

                // Setează prima foaie ca activă
                worksheet.Activate();

                // Salvează fișierul Excel
                string excelFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Oferte_Turistice.xlsx");
                workbook.SaveAs(excelFileName);

                // Vizibilitate Excel
                excelApp.Visible = true;

                MessageBox.Show($"Fișierul Excel a fost creat cu succes!\nLocație: {excelFileName}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la generarea fișierului Excel: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportTop_Click(object sender, EventArgs e)
        {
            // Exportă doar top N oferte după preț
            try
            {
                // Verifică dacă există date
                if (oferteTable.Rows.Count == 0)
                {
                    MessageBox.Show("Nu există oferte în baza de date!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Obține numărul de oferte de exportat
                int numarOferte;
                if (!int.TryParse(txtNumarOferte.Text, out numarOferte) || numarOferte <= 0)
                {
                    MessageBox.Show("Introduceți un număr valid de oferte!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifică dacă numărul este mai mare decât totalul disponibil
                if (numarOferte > oferteTable.Count)
                {
                    numarOferte = oferteTable.Count;
                    MessageBox.Show($"S-a limitat la numărul total de oferte disponibile: {numarOferte}", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Sortează și limitează la numărul specificat
                var topOferte = oferteTable.OrderByDescending(r => r.Pret).Take(numarOferte).ToList();

                // Creare instanță Excel
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false;
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];
                worksheet.Name = "Top Oferte";

                // Setarea antetului
                worksheet.Range["A1"].Value = "ID";
                worksheet.Range["B1"].Value = "Destinație";
                worksheet.Range["C1"].Value = "Preț";
                worksheet.Range["D1"].Value = "Perioadă";
                worksheet.Range["E1"].Value = "Număr Zile";
                worksheet.Range["F1"].Value = "Transport";

                // Formatarea antetului
                Excel.Range headerRange = worksheet.Range["A1:F1"];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                headerRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Populare date
                for (int i = 0; i < topOferte.Count; i++)
                {
                    worksheet.Cells[i + 2, 1] = topOferte[i].ID1;
                    worksheet.Cells[i + 2, 2] = topOferte[i].Destinatie;
                    worksheet.Cells[i + 2, 3] = topOferte[i].Pret;
                    worksheet.Cells[i + 2, 4] = topOferte[i].Perioada;
                    worksheet.Cells[i + 2, 5] = topOferte[i].NumarZile;
                    worksheet.Cells[i + 2, 6] = topOferte[i].Transport;
                }

                // Formatare celule
                Excel.Range dataRange = worksheet.Range["A2:F" + (topOferte.Count + 1)];
                dataRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Formatare coloană preț
                Excel.Range priceRange = worksheet.Range["C2:C" + (topOferte.Count + 1)];
                priceRange.NumberFormat = "#,##0.00 \"RON\"";

                // Auto-dimensionare coloane
                worksheet.Columns.AutoFit();

                // Creare grafic pentru ofertele din top
                Excel.ChartObjects charts = (Excel.ChartObjects)worksheet.ChartObjects();
                Excel.ChartObject chartObj = charts.Add(400, 10, 300, 200);
                Excel.Chart chart = chartObj.Chart;

                // Selectează datele pentru grafic (doar destinațiile și prețurile)
                Excel.Range chartDataRange = worksheet.Range["B2:C" + (topOferte.Count + 1)];
                chart.SetSourceData(chartDataRange);

                // Setare tip grafic și titlu
                chart.ChartType = Excel.XlChartType.xlColumnClustered;
                chart.HasTitle = true;
                chart.ChartTitle.Text = $"Top {numarOferte} Oferte - Prețuri";

                // Salvează fișierul Excel
                string excelFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"Top_{numarOferte}_Oferte_Turistice.xlsx");
                workbook.SaveAs(excelFileName);

                // Vizibilitate Excel
                excelApp.Visible = true;

                MessageBox.Show($"Fișierul Excel cu top {numarOferte} oferte a fost creat cu succes!\nLocație: {excelFileName}", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la generarea fișierului Excel: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInchide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}