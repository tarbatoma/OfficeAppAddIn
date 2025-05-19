using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;

namespace AgentieTurism2025
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            CustomizeRibbonAppearance();
        }

        private void CustomizeRibbonAppearance()
        {
            // Setăm Office-built-in icons via OfficeImageId
            btnAdaugaOferta.OfficeImageId = "ListAdd";
            btnGenereazaDocument.OfficeImageId = "DocumentWord";
            btnExportExcel.OfficeImageId = "ExcelWorkbook";
            btnStatistici.OfficeImageId = "ChartSeries";
            btnDashboard.OfficeImageId = "PaneDashboard";    // sau "ChartPerformance"
            btnTemplates.OfficeImageId = "Template";
            btnPrint.OfficeImageId = "Print";
            btnHelp.OfficeImageId = "Help";

            // Forţăm mari + afișare imagine
            foreach (var btn in new[] {
        btnAdaugaOferta, btnGenereazaDocument, btnExportExcel, btnStatistici,
        btnDashboard,    btnTemplates,          btnPrint,       btnHelp })
            {
                btn.ControlSize = RibbonControlSize.RibbonControlSizeLarge;
                btn.ShowImage = true;
            }
            // --- SuperTip-urile ---
            btnAdaugaOferta.SuperTip = "Adaugă o nouă ofertă turistică…";
            btnGenereazaDocument.SuperTip = "Generează un document Word formatat profesional…";
            btnExportExcel.SuperTip = "Exportă ofertele în Excel pentru analiză și raportare…";
            btnStatistici.SuperTip = "Vizualizează statistici și grafice despre ofertele turistice…";
            btnDashboard.SuperTip = "Deschide panoul de control cu toate informațiile importante…";
            btnTemplates.SuperTip = "Alege și personalizează template-uri pentru documente…";
            btnPrint.SuperTip = "Imprimă documentul curent sau generează un PDF…";
            btnHelp.SuperTip = "Obține ajutor și informații despre utilizarea aplicației.";
        }

        private void SetImageByName(RibbonButton button, string resourceName)
        {
            try
            {
                // ResourceManager vine automat în orice Resources.* generat
                var obj = Properties.Resources.ResourceManager.GetObject(resourceName);
                if (obj is Bitmap bmp)
                    button.Image = bmp;
            }
            catch
            {
                // dacă lipsește resursa, ignorăm
            }
        }

        // ---------- Event Handlers ----------
        private void btnAdaugaOferta_Click(object sender, RibbonControlEventArgs e)
        {
            try { new FormOferta().Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnGenereazaDocument_Click(object sender, RibbonControlEventArgs e)
        {
            try { Globals.ThisDocument.GenereazaDocumentOferta(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnExportExcel_Click(object sender, RibbonControlEventArgs e)
        {
            try { new FormExcel().Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnStatistici_Click(object sender, RibbonControlEventArgs e)
        {
            try { new FormStatistici().Show(); }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnDashboard_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                // Înlocuim mesajul temporar cu deschiderea reală a formularului Dashboard
                FormDashboard dashboard = new FormDashboard();
                dashboard.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la deschiderea dashboard-ului: {ex.Message}",
                                 "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemplates_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                FormTemplates formTemplates = new FormTemplates();
                formTemplates.Show(); // sau ShowDialog() dacă vrei să fie modal
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la deschiderea template-urilor: {ex.Message}",
                                 "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnPrint_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                var wordApp = Globals.ThisDocument.Application;
                wordApp.Dialogs[Word.WdWordDialog.wdDialogFilePrint].Show();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnHelp_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                // Deschidem formularul de ajutor modern
                FormHelp helpForm = new FormHelp();
                helpForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la deschiderea ajutorului: {ex.Message}",
                                 "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
