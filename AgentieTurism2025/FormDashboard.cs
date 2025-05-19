using System;
using System.Data;
// Creăm aliasuri pentru a evita ambiguitățile
using SDImage = System.Drawing.Image;
using SDFont = System.Drawing.Font;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Collections.Generic;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.Drawing;

namespace AgentieTurism2025
{
    public partial class FormDashboard : Form
    {
        private dateDataSetTableAdapters.Sheet1TableAdapter oferteAdapter;
        private dateDataSet.Sheet1DataTable oferteTable;

        // Statistici generale
        private int totalOferte;
        private decimal totalVanzari;
        private decimal pretMediu;
        private string destinatiaMaiCautata;
        private string transportPreferent;

        public FormDashboard()
        {
            InitializeComponent();

            // Setează proprietățile de imagine pentru a preveni excepții legate de resurse
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pbHarta.Image = null;

            // Încarcă imagini pentru controale
            IncarcaImagini();

            // Selectează prima opțiune din combobox-ul de perioadă
            if (cmbPerioada.Items.Count > 0)
                cmbPerioada.SelectedIndex = 0;

            // Inițializare adaptor pentru baza de date
            oferteAdapter = new dateDataSetTableAdapters.Sheet1TableAdapter();
            oferteTable = new dateDataSet.Sheet1DataTable();

            // Populare inițială a datelor
            IncarcaDate();

            // Setează timer pentru actualizarea automată a datelor (la fiecare 60 secunde)
            Timer refreshTimer = new Timer();
            refreshTimer.Interval = 60000; // 60 secunde
            refreshTimer.Tick += (s, e) => IncarcaDate();
            refreshTimer.Start();

            // Eveniment pentru schimbarea perioadei
            cmbPerioada.SelectedIndexChanged += (s, e) => ActualizeazaGrafice();
        }

        private void IncarcaImagini()
        {
            try
            {
                // Calea către directorul executabil al aplicației
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string imagesDir = Path.Combine(baseDir, "Images");

                // Încarcă imagini pentru carduri
                if (File.Exists(Path.Combine(imagesDir, "offers.png")))
                    pictureBox1.Image = SDImage.FromFile(Path.Combine(imagesDir, "offers.png"));

                if (File.Exists(Path.Combine(imagesDir, "sales.png")))
                    pictureBox2.Image = SDImage.FromFile(Path.Combine(imagesDir, "sales.png"));

                if (File.Exists(Path.Combine(imagesDir, "price.png")))
                    pictureBox3.Image = SDImage.FromFile(Path.Combine(imagesDir, "price.png"));

                if (File.Exists(Path.Combine(imagesDir, "destination.png")))
                    pictureBox4.Image = SDImage.FromFile(Path.Combine(imagesDir, "destination.png"));

                if (File.Exists(Path.Combine(imagesDir, "transport.png")))
                    pictureBox5.Image = SDImage.FromFile(Path.Combine(imagesDir, "transport.png"));

                // Încarcă harta
                if (File.Exists(Path.Combine(imagesDir, "map.png")))
                    pbHarta.Image = SDImage.FromFile(Path.Combine(imagesDir, "map.png"));

                // Configurează ImageList pentru listview
                imageList1.Images.Clear();
                imageList1.ImageSize = new System.Drawing.Size(16, 16);

                // Adaugă imagini pentru tipurile de transport
                if (File.Exists(Path.Combine(imagesDir, "airplane.png")))
                    imageList1.Images.Add(SDImage.FromFile(Path.Combine(imagesDir, "airplane.png")));

                if (File.Exists(Path.Combine(imagesDir, "bus.png")))
                    imageList1.Images.Add(SDImage.FromFile(Path.Combine(imagesDir, "bus.png")));

                if (File.Exists(Path.Combine(imagesDir, "train.png")))
                    imageList1.Images.Add(SDImage.FromFile(Path.Combine(imagesDir, "train.png")));

                if (File.Exists(Path.Combine(imagesDir, "car.png")))
                    imageList1.Images.Add(SDImage.FromFile(Path.Combine(imagesDir, "car.png")));
            }
            catch (Exception ex)
            {
                // Nu afișăm eroarea, doar înregistrăm
                Console.WriteLine("Eroare la încărcarea imaginilor: " + ex.Message);
            }
        }

        private void IncarcaDate()
        {
            try
            {
                // Reîncarcă datele din baza de date
                oferteAdapter.Fill(oferteTable);

                if (oferteTable.Rows.Count == 0)
                {
                    MessageBox.Show("Nu există oferte în baza de date!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Calculează statistici generale
                CalculeazaStatistici();

                // Actualizează elementele de interfață
                ActualizeazaInterfata();

                // Actualizează graficele
                ActualizeazaGrafice();

                // Actualizează lista cu oferte recente
                ActualizeazaListaOferteRecente();

                // Actualizează harta ofertelor populare
                ActualizeazaHarta();

                lblUltimaActualizare.Text = $"Ultima actualizare: {DateTime.Now:dd.MM.yyyy HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea datelor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculeazaStatistici()
        {
            try
            {
                totalOferte = oferteTable.Rows.Count;

                // Calculează suma prețurilor pentru vânzări totale
                totalVanzari = oferteTable.Sum(r => (decimal)r.Pret);

                // Calculează media prețurilor
                pretMediu = totalOferte > 0 ? totalVanzari / totalOferte : 0;

                // Găsește destinația cea mai căutată (cea care apare de cele mai multe ori)
                var destinatiiGrupate = oferteTable.GroupBy(r => r.Destinatie)
                                                .Select(g => new { Destinatie = g.Key, Count = g.Count() })
                                                .OrderByDescending(x => x.Count);

                destinatiaMaiCautata = destinatiiGrupate.Any() ? destinatiiGrupate.First().Destinatie : "-";

                // Găsește tipul de transport preferat (cel mai frecvent)
                var transportGrupat = oferteTable.GroupBy(r => r.Transport)
                                              .Select(g => new { Transport = g.Key, Count = g.Count() })
                                              .OrderByDescending(x => x.Count);

                transportPreferent = transportGrupat.Any() ? transportGrupat.First().Transport : "-";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la calcularea statisticilor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Setează valori implicite în caz de eroare
                totalOferte = 0;
                totalVanzari = 0;
                pretMediu = 0;
                destinatiaMaiCautata = "-";
                transportPreferent = "-";
            }
        }

        private void ActualizeazaInterfata()
        {
            // Actualizează cardurile cu statistici
            lblTotalOferte.Text = totalOferte.ToString();
            lblTotalVanzari.Text = totalVanzari.ToString("C0");
            lblPretMediu.Text = pretMediu.ToString("C0");
            lblDestinatieCautata.Text = destinatiaMaiCautata;
            lblTransportPreferent.Text = transportPreferent;

            // Calculează tendința pentru oferte
            int oferteLunaTrecuta = 0; // În practică, acest număr ar fi extras din istoricul bazei de date
            double procentajCrestere = oferteLunaTrecuta > 0 ? (totalOferte - oferteLunaTrecuta) * 100.0 / oferteLunaTrecuta : 0;

            if (procentajCrestere > 0)
            {
                lblTendintaOferte.Text = $"↑ {procentajCrestere:F1}%";
                lblTendintaOferte.ForeColor = System.Drawing.Color.Green;
            }
            else if (procentajCrestere < 0)
            {
                lblTendintaOferte.Text = $"↓ {Math.Abs(procentajCrestere):F1}%";
                lblTendintaOferte.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblTendintaOferte.Text = "→ 0%";
                lblTendintaOferte.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void ActualizeazaGrafice()
        {
            try
            {
                // Verifică dacă elementele grafice sunt inițializate
                if (chartDestinatii == null || chartVanzariLunare == null || chartTransport == null)
                {
                    Console.WriteLine("Unul dintre controalele de tip Chart nu este inițializat.");
                    return;
                }

                // Verifică dacă există date
                if (oferteTable == null || oferteTable.Rows.Count == 0)
                {
                    Console.WriteLine("Nu există date pentru actualizarea graficelor.");
                    return;
                }

                // Obține perioada selectată
                string perioadaSelectata = cmbPerioada.SelectedItem?.ToString() ?? "Toate perioadele";

                // Verifică și asigură-te că legenda există
                if (chartDestinatii.Legends.Count == 0)
                    chartDestinatii.Legends.Add(new Legend("Destinații"));

                if (chartVanzariLunare.Legends.Count == 0)
                    chartVanzariLunare.Legends.Add(new Legend("Destinații"));

                if (chartTransport.Legends.Count == 0)
                    chartTransport.Legends.Add(new Legend("Transport"));

                // 1. Actualizează graficul de destinații
                chartDestinatii.Series.Clear();
                Series seriesDestinatii = chartDestinatii.Series.Add("Destinații");
                seriesDestinatii.ChartType = SeriesChartType.Pie;
                seriesDestinatii.IsValueShownAsLabel = true;
                seriesDestinatii.Label = "#PERCENT{P0}";

                // Activăm legenda și configurăm-o să arate numele destinațiilor
                chartDestinatii.Legends[0].Enabled = true;
                chartDestinatii.Legends[0].Docking = Docking.Bottom;
                chartDestinatii.Legends[0].Alignment = StringAlignment.Center;
                chartDestinatii.Legends[0].IsTextAutoFit = true;

                // Filtrăm destinațiile care au preț ≤ 2000
                var destinatiiGrupate = oferteTable
                    .Where(r => r.Pret <= 2000)
                    .GroupBy(r => r.Destinatie)
                    .Select(g => new { Destinatie = g.Key, Count = g.Count() })
                    .OrderByDescending(x => x.Count)
                    .ToList(); // Important: convertiți rezultatul în listă pentru verificare

                // Verifică dacă există rezultate după filtrare
                if (destinatiiGrupate.Count == 0)
                {
                    Console.WriteLine("Nu există destinații cu preț <= 2000 pentru grafic.");
                }
                else
                {
                    foreach (var dest in destinatiiGrupate)
                    {
                        if (dest.Destinatie != null)
                        {
                            int pointIndex = seriesDestinatii.Points.AddXY(dest.Destinatie, dest.Count);
                            seriesDestinatii.Points[pointIndex].LegendText = dest.Destinatie;
                        }
                    }
                }

                // Actualizăm titlul graficului pentru a reflecta filtrarea
                chartDestinatii.Titles.Clear();
                chartDestinatii.Titles.Add("Top Destinații (Preț ≤ 2000 RON)");

                // 2. Actualizează graficul de vânzări lunar
                chartVanzariLunare.Series.Clear();

                // Activăm legenda și configurăm-o să arate numele destinațiilor
                chartVanzariLunare.Legends[0].Enabled = true;
                chartVanzariLunare.Legends[0].Docking = Docking.Right;
                chartVanzariLunare.Legends[0].Alignment = StringAlignment.Center;
                chartVanzariLunare.Legends[0].IsTextAutoFit = true;

                // Grupăm ofertele după destinație și calculăm prețul mediu
                var destinatiiPretMediu = oferteTable
                    .GroupBy(r => r.Destinatie)
                    .Select(g => new {
                        Destinatie = g.Key,
                        PretMediu = g.Average(r => (double)r.Pret),
                        NumarOferte = g.Count()
                    })
                    .OrderByDescending(x => x.PretMediu)
                    .Take(10)
                    .ToList(); // Convertim în listă pentru a putea verifica rezultatele

                if (destinatiiPretMediu.Count == 0)
                {
                    Console.WriteLine("Nu există destinații pentru graficul de preț mediu.");
                }
                else
                {
                    // Adăugăm serii separate pentru fiecare destinație pentru a le afișa în legendă
                    Random rand = new Random(DateTime.Now.Millisecond);

                    // Creăm bar chart cu o serie pentru fiecare destinație
                    foreach (var dest in destinatiiPretMediu)
                    {
                        if (dest.Destinatie != null)
                        {
                            Series destSeries = chartVanzariLunare.Series.Add(dest.Destinatie);
                            destSeries.ChartType = SeriesChartType.Column;
                            destSeries.IsValueShownAsLabel = true;

                            // Adăugăm un singur punct pentru această destinație
                            destSeries.Points.AddXY(dest.Destinatie, dest.PretMediu);

                            // Setăm culoarea seriei
                            System.Drawing.Color randomColor = GetRandomColor(rand);
                            destSeries.Color = randomColor;

                            // Adăugăm tooltip cu detalii
                            destSeries.Points[0].ToolTip = $"{dest.Destinatie}: {dest.PretMediu:C0} ({dest.NumarOferte} oferte)";

                            // Configurăm formatul valorii afișate
                            destSeries.Points[0].Label = $"{dest.PretMediu:C0}";
                        }
                    }
                }

                // Verifică dacă ChartArea există
                if (chartVanzariLunare.ChartAreas.Count > 0)
                {
                    // Configurăm axa X pentru a nu mai afișa etichete (deoarece ele sunt redundante cu seriile)
                    chartVanzariLunare.ChartAreas[0].AxisX.LabelStyle.Enabled = false;

                    // Configurăm axa Y pentru a afișa prețurile corespunzător
                    chartVanzariLunare.ChartAreas[0].AxisY.LabelStyle.Format = "C0";
                }

                // Actualizăm titlul graficului
                chartVanzariLunare.Titles.Clear();
                chartVanzariLunare.Titles.Add("Analiză Preț Mediu pe Destinație");

                // 3. Actualizează graficul de distribuție transport
                chartTransport.Series.Clear();
                Series seriesTransport = chartTransport.Series.Add("Transport");
                seriesTransport.ChartType = SeriesChartType.Doughnut;
                seriesTransport.IsValueShownAsLabel = true;

                var transportGrupat = oferteTable
                    .GroupBy(r => r.Transport)
                    .Select(g => new { Transport = g.Key, Count = g.Count() })
                    .ToList(); // Convertim în listă pentru a putea verifica

                if (transportGrupat.Count == 0)
                {
                    Console.WriteLine("Nu există date pentru graficul de transport.");
                }
                else
                {
                    foreach (var t in transportGrupat)
                    {
                        if (t.Transport != null)
                        {
                            int pointIndex = seriesTransport.Points.AddXY(t.Transport, t.Count);
                            seriesTransport.Points[pointIndex].LegendText = t.Transport;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Capturăm eroarea și afișăm mai multe detalii pentru diagnosticare
                Console.WriteLine($"Eroare detaliată la actualizarea graficelor: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                MessageBox.Show($"Eroare la actualizarea graficelor: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizeazaListaOferteRecente()
        {
            try
            {
                lvOferteRecente.Items.Clear();

                // Obține ultimele 5 oferte adăugate (presupunem că ID-ul mai mare = adăugată mai recent)
                var oferteRecente = oferteTable.OrderByDescending(r => r.ID1).Take(5);

                foreach (var oferta in oferteRecente)
                {
                    ListViewItem item = new ListViewItem(oferta.Destinatie);
                    item.SubItems.Add(oferta.Pret.ToString("C0"));
                    item.SubItems.Add(oferta.Perioada);
                    item.SubItems.Add(oferta.Transport);

                    // Adaugă iconița corespunzătoare tipului de transport
                    if (oferta.Transport.Contains("Avion") && imageList1.Images.Count > 0)
                        item.ImageIndex = 0;
                    else if (oferta.Transport.Contains("Autocar") && imageList1.Images.Count > 1)
                        item.ImageIndex = 1;
                    else if (oferta.Transport.Contains("Tren") && imageList1.Images.Count > 2)
                        item.ImageIndex = 2;
                    else if (imageList1.Images.Count > 3)
                        item.ImageIndex = 3;

                    lvOferteRecente.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la actualizarea listei de oferte: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizeazaHarta()
        {
            // Această funcție poate rămâne goală pentru moment
            // În versiunea reală, aici am putea implementa o hartă interactivă
        }

        private System.Drawing.Color GetRandomColor(Random rand)
        {
            // Generează culori aleatorii pentru grafice, cu saturație și luminozitate decente
            return System.Drawing.Color.FromArgb(rand.Next(100, 240), rand.Next(100, 240), rand.Next(100, 240));
        }

        private void btnActualizeaza_Click(object sender, EventArgs e)
        {
            IncarcaDate();
            MessageBox.Show("Datele au fost actualizate cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Configurăm SaveFileDialog pentru a alege locația fișierului PDF
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Fișiere PDF (*.pdf)|*.pdf";
                saveFileDialog.Title = "Salvați raportul ca PDF";
                saveFileDialog.FileName = $"Dashboard_Turism_{DateTime.Now:yyyyMMdd}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Creăm documentul PDF
                    iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 36, 36, 54, 36);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Adăugăm informațiile de header
                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(baseFont, 18, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontSubtitle = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontText = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontBold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);

                    // Titlu raport
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph($"Dashboard Agenție de Turism - {DateTime.Now:dd.MM.yyyy}", fontTitle);
                    title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    document.Add(title);
                    document.Add(new iTextSharp.text.Paragraph(" ")); // Spațiu

                    // Informații despre perioadă
                    iTextSharp.text.Paragraph perioadaInfo = new iTextSharp.text.Paragraph($"Perioada: {cmbPerioada.SelectedItem}", fontSubtitle);
                    perioadaInfo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                    document.Add(perioadaInfo);
                    document.Add(new iTextSharp.text.Paragraph(" ")); // Spațiu

                    // Creăm tabelul pentru statistici
                    PdfPTable statsTable = new PdfPTable(5);
                    statsTable.WidthPercentage = 100;
                    statsTable.SetWidths(new float[] { 1f, 1f, 1f, 1f, 1f });

                    // Adăugăm header-ele tabelului
                    PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase("Statistici Generale", fontBold));
                    cell.Colspan = 5;
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                    cell.BackgroundColor = new BaseColor(41, 128, 185);
                    cell.BorderColor = new BaseColor(41, 128, 185);
                    cell.Padding = 8;
                    statsTable.AddCell(cell);

                    // Adăugăm header-ele pentru fiecare coloană
                    AddStatsCell(statsTable, "Număr de Oferte", fontBold);
                    AddStatsCell(statsTable, "Total Vânzări", fontBold);
                    AddStatsCell(statsTable, "Preț Mediu", fontBold);
                    AddStatsCell(statsTable, "Destinație Populară", fontBold);
                    AddStatsCell(statsTable, "Transport Preferat", fontBold);

                    // Adăugăm valorile
                    AddStatsCell(statsTable, lblTotalOferte.Text, fontText);
                    AddStatsCell(statsTable, lblTotalVanzari.Text, fontText);
                    AddStatsCell(statsTable, lblPretMediu.Text, fontText);
                    AddStatsCell(statsTable, lblDestinatieCautata.Text, fontText);
                    AddStatsCell(statsTable, lblTransportPreferent.Text, fontText);

                    document.Add(statsTable);
                    document.Add(new iTextSharp.text.Paragraph(" ")); // Spațiu

                    // Adăugăm graficele ca imagini
                    document.Add(new iTextSharp.text.Paragraph("Grafice Analiză", fontSubtitle));
                    document.Add(new iTextSharp.text.Paragraph(" "));

                    // Realizăm export pentru grafice
                    AddChartToPdf(document, chartDestinatii, "Distribuție Destinații", 300, 200);
                    AddChartToPdf(document, chartVanzariLunare, "Analiză Preț Mediu pe Destinație", 500, 200);
                    AddChartToPdf(document, chartTransport, "Distribuție Transport", 300, 200);

                    // Adăugăm tabelul cu oferte recente
                    document.Add(new iTextSharp.text.Paragraph("Oferte Recente", fontSubtitle));
                    document.Add(new iTextSharp.text.Paragraph(" "));

                    PdfPTable oferteTable = new PdfPTable(4);
                    oferteTable.WidthPercentage = 100;
                    oferteTable.SetWidths(new float[] { 2f, 1f, 1.5f, 1.5f });

                    // Header tabel oferte
                    string[] headers = new string[] { "Destinație", "Preț", "Perioada", "Transport" };
                    foreach (string header in headers)
                    {
                        cell = new PdfPCell(new iTextSharp.text.Phrase(header, fontBold));
                        cell.BackgroundColor = new BaseColor(220, 220, 220);
                        cell.Padding = 5;
                        oferteTable.AddCell(cell);
                    }

                    // Adăugăm datele din ListView
                    foreach (ListViewItem item in lvOferteRecente.Items)
                    {
                        oferteTable.AddCell(new PdfPCell(new iTextSharp.text.Phrase(item.Text, fontText)));
                        for (int i = 1; i < 4; i++)
                        {
                            oferteTable.AddCell(new PdfPCell(new iTextSharp.text.Phrase(item.SubItems[i].Text, fontText)));
                        }
                    }

                    document.Add(oferteTable);

                    // Adăugăm footer
                    document.Add(new iTextSharp.text.Paragraph(" "));
                    document.Add(new iTextSharp.text.Paragraph(" "));
                    iTextSharp.text.Paragraph footer = new iTextSharp.text.Paragraph($"Raport generat la {DateTime.Now:dd.MM.yyyy HH:mm:ss}", fontText);
                    footer.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
                    document.Add(footer);

                    // Închidem documentul
                    document.Close();

                    // Deschidem PDF-ul generat
                    // Deschidem PDF-ul generat
                    if (MessageBox.Show("PDF-ul a fost generat cu succes! Doriți să îl deschideți?",
                                       "Succes", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start(saveFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la generarea PDF: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddStatsCell(PdfPTable table, string text, iTextSharp.text.Font font)
        {
            PdfPCell cell = new PdfPCell(new iTextSharp.text.Phrase(text, font));
            cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
            cell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE;
            cell.Padding = 8;
            table.AddCell(cell);
        }

        private void AddChartToPdf(iTextSharp.text.Document document, System.Windows.Forms.DataVisualization.Charting.Chart chart, string title, int width, int height)
        {
            try
            {
                // Salvăm temporar graficul ca imagine
                string tempImagePath = Path.Combine(Path.GetTempPath(), $"chart_{Guid.NewGuid()}.png");
                chart.SaveImage(tempImagePath, System.Drawing.Imaging.ImageFormat.Png);

                // Adăugăm titlul graficului
                iTextSharp.text.Paragraph chartTitle = new iTextSharp.text.Paragraph(title,
                    new iTextSharp.text.Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1250, BaseFont.EMBEDDED), 12, iTextSharp.text.Font.BOLD));
                chartTitle.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                document.Add(chartTitle);

                // Adăugăm imaginea în document
                iTextSharp.text.Image chartImage = iTextSharp.text.Image.GetInstance(tempImagePath);
                chartImage.ScaleToFit(width, height);
                chartImage.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                document.Add(chartImage);
                document.Add(new iTextSharp.text.Paragraph(" ")); // Spațiu

                // Ștergem fișierul temporar
                if (File.Exists(tempImagePath))
                {
                    File.Delete(tempImagePath);
                }
            }
            catch (Exception ex)
            {
                // Tratăm eroarea, dar nu întrerupem exportul
                Console.WriteLine($"Eroare la adăugarea graficului: {ex.Message}");
            }
        }

        private void btnInchide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}