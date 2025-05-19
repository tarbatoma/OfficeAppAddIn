using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace AgentieTurism2025
{
    public partial class ThisDocument
    {
        private dateDataSetTableAdapters.Sheet1TableAdapter oferteAdapter;
        private dateDataSet.Sheet1DataTable oferteTable;

        private void ThisDocument_Startup(object sender, EventArgs e)
        {
            try
            {
                oferteAdapter = new dateDataSetTableAdapters.Sheet1TableAdapter();
                oferteTable = new dateDataSet.Sheet1DataTable();
                oferteAdapter.Fill(oferteTable);

                AddHeaderWithAdvancedLogo();
                AddComplexFooter();

                InsertStyledParagraph("🌍 AGENȚIE DE TURISM 2025 🌴", "Georgia", 28, true, Word.WdParagraphAlignment.wdAlignParagraphCenter, Word.WdColor.wdColorDarkRed);
                InsertStyledParagraph("Călătorește, Descoperă, Explorează!", "Calibri", 18, true, Word.WdParagraphAlignment.wdAlignParagraphCenter, Word.WdColor.wdColorDarkBlue);
                InsertStyledParagraph("Oferte Exclusive & Destinații Unice", "Calibri", 14, false, Word.WdParagraphAlignment.wdAlignParagraphCenter, Word.WdColor.wdColorBlack);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message, "Eroare la inițializare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GenereazaDocumentOferta()
        {
            try
            {
                oferteAdapter.Fill(oferteTable);

                if (oferteTable.Rows.Count == 0)
                {
                    MessageBox.Show("Nu există oferte în baza de date!", "Informație", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (FormSelectieOferta formSelectie = new FormSelectieOferta(oferteTable))
                {
                    if (formSelectie.ShowDialog() == DialogResult.OK)
                    {
                        dateDataSet.Sheet1Row oferta = oferteTable.FindByID1(formSelectie.IdOfertaSelectata);

                        if (oferta != null)
                        {
                            this.Content.Text = "";

                            AddHeaderWithAdvancedLogo();
                            AddComplexFooter();

                            InsertStyledParagraph($"🌟 OFERTĂ SPECIALĂ: {oferta.Destinatie.ToUpper()} 🌟", "Georgia", 22, true, Word.WdParagraphAlignment.wdAlignParagraphCenter, Word.WdColor.wdColorDarkGreen);

                            InsertStyledParagraph("Detalii Ofertă", "Calibri", 16, true, Word.WdParagraphAlignment.wdAlignParagraphLeft, Word.WdColor.wdColorDarkRed);

                            Word.Table ofertaDetailsTable = this.Content.Tables.Add(this.Content.Paragraphs.Last.Range, 5, 2);
                            ofertaDetailsTable.Borders.Enable = 1;
                            ofertaDetailsTable.set_Style("Medium Grid 3 - Accent 5");

                            PopulateAdvancedOfferTable(ofertaDetailsTable, oferta);

                            InsertStyledParagraph("Descriere Detaliată", "Calibri", 16, true, Word.WdParagraphAlignment.wdAlignParagraphLeft, Word.WdColor.wdColorBlack);
                            InsertStyledParagraph($"Acest pachet premium include {oferta.NumarZile} zile fascinante în {oferta.Destinatie}, " +
                                                 $"cu transport {oferta.Transport.ToLower()}, cazare premium, ghid specializat și activități personalizate pentru fiecare zi.",
                                                 "Calibri", 12, false, Word.WdParagraphAlignment.wdAlignParagraphJustify, Word.WdColor.wdColorBlack);

                            InsertStyledParagraph("Contact Rapid", "Calibri", 16, true, Word.WdParagraphAlignment.wdAlignParagraphLeft, Word.WdColor.wdColorBlack);
                            InsertBulletList(new[]
                            {
                                "📞 Telefon: +40 712 345 678",
                                "📧 Email: premium@agentie-turism.ro",
                                "📍 Adresa: Bd. Turismului Nr. 123, București, România"
                            });

                            MessageBox.Show("Documentul a fost generat cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la generarea documentului: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertStyledParagraph(string text, string fontName, int size, bool bold, Word.WdParagraphAlignment alignment, Word.WdColor color)
        {
            Word.Paragraph paragraph = this.Content.Paragraphs.Add();
            paragraph.Range.Text = text;
            paragraph.Range.Font.Name = fontName;
            paragraph.Range.Font.Size = size;
            paragraph.Range.Font.Bold = bold ? 1 : 0;
            paragraph.Range.Font.Color = color;
            paragraph.Range.ParagraphFormat.Alignment = alignment;
            paragraph.Range.InsertParagraphAfter();
        }

        private void InsertBulletList(string[] items)
        {
            foreach (var item in items)
            {
                Word.Paragraph bulletParagraph = this.Content.Paragraphs.Add();
                bulletParagraph.Range.Text = item;
                bulletParagraph.Range.ListFormat.ApplyBulletDefault();
                bulletParagraph.Range.Font.Name = "Calibri";
                bulletParagraph.Range.Font.Size = 12;
                bulletParagraph.Range.InsertParagraphAfter();
            }
        }

        private void PopulateAdvancedOfferTable(Word.Table table, dateDataSet.Sheet1Row oferta)
        {
            string[] labels = { "Destinație", "Perioada", "Durata", "Transport", "Preț Total" };
            string[] values = {
                oferta.Destinatie,
                oferta.Perioada,
                oferta.NumarZile + " zile",
                oferta.Transport,
                oferta.Pret.ToString("C", new CultureInfo("ro-RO"))
            };

            for (int i = 0; i < labels.Length; i++)
            {
                table.Cell(i + 1, 1).Range.Text = labels[i];
                table.Cell(i + 1, 1).Range.Font.Bold = 1;
                table.Cell(i + 1, 2).Range.Text = values[i];
            }

            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);
        }

        private void AddHeaderWithAdvancedLogo()
        {
            Word.HeaderFooter header = this.Sections[1].Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
            header.Range.Text = "🚀 AGENȚIA DE TURISM PREMIUM 2025 🚀";
            header.Range.Font.Name = "Georgia";
            header.Range.Font.Bold = 1;
            header.Range.Font.Size = 18;
            header.Range.Font.Color = Word.WdColor.wdColorDarkBlue;
            header.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }

        private void AddComplexFooter()
        {
            Word.HeaderFooter footer = this.Sections[1].Footers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary];
            footer.Range.Text = $"🗓 Generat pe: {DateTime.Now:dddd, dd MMMM yyyy HH:mm} | 🌐 www.agentie-turism-premium.ro";
            footer.Range.Font.Italic = 1;
            footer.Range.Font.Size = 10;
            footer.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
        }

        private void InternalStartup()
        {
            this.Startup += ThisDocument_Startup;
        }
    }
}