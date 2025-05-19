using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Web.UI;
using Microsoft.VisualBasic;


namespace AgentieTurism2025
{
    public partial class FormTemplates : Form
    {
        private string templateFolderPath;
        private List<TemplateInfo> templates;

        public FormTemplates()
        {
            InitializeComponent();

            // Inițializăm calea către directorul cu template-uri
            string applicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            templateFolderPath = Path.Combine(applicationDirectory, "Templates");

            // Verificăm dacă directorul cu template-uri există, dacă nu, îl creăm
            if (!Directory.Exists(templateFolderPath))
            {
                Directory.CreateDirectory(templateFolderPath);
            }

            // Inițializăm lista de template-uri
            templates = new List<TemplateInfo>();

            // Populăm lista cu template-uri
            LoadTemplates();

            // Actualizăm interfața
            UpdateUI();
        }

        private void LoadTemplates()
        {
            try
            {
                // Golim lista curentă
                templates.Clear();

                // Obținem toate fișierele .dotx și .docx din directorul de template-uri
                string[] templateFiles = Directory.GetFiles(templateFolderPath, "*.dot*")
                    .Concat(Directory.GetFiles(templateFolderPath, "*.doc*"))
                    .ToArray();

                foreach (string filePath in templateFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string extension = Path.GetExtension(filePath);
                    string fileType = "";

                    // Determinăm tipul fișierului
                    switch (extension.ToLower())
                    {
                        case ".dotx":
                            fileType = "Template Word (*.dotx)";
                            break;
                        case ".docx":
                            fileType = "Document Word (*.docx)";
                            break;
                        case ".dot":
                            fileType = "Template Word (*.dot)";
                            break;
                        case ".doc":
                            fileType = "Document Word (*.doc)";
                            break;
                        default:
                            fileType = "Fișier necunoscut";
                            break;
                    }

                    // Creăm un nou obiect TemplateInfo
                    TemplateInfo template = new TemplateInfo
                    {
                        Name = fileName,
                        FilePath = filePath,
                        FileType = fileType,
                        Description = GetTemplateDescription(fileName)
                    };

                    // Adăugăm la lista de template-uri
                    templates.Add(template);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la încărcarea template-urilor: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTemplateDescription(string templateName)
        {
            // Aici putem implementa logica pentru a extrage descrieri din fișiere sau dintr-o bază de date
            // Pentru acest exemplu, vom folosi descrieri predefinite pentru câteva template-uri

            switch (templateName.ToLower())
            {
                case "contract_standard":
                    return "Template pentru contractele standard cu clienții.";
                case "oferta_familie":
                    return "Template pentru ofertele destinate familiilor cu copii.";
                case "oferta_corporate":
                    return "Template pentru ofertele corporative și de business.";
                case "voucher_cazare":
                    return "Template pentru voucherele de cazare.";
                case "factura_turism":
                    return "Template pentru facturi.";
                default:
                    return "Template pentru documente turistice.";
            }
        }

        private void UpdateUI()
        {
            // Actualizăm ListView cu template-urile disponibile
            lvTemplates.Items.Clear();

            foreach (TemplateInfo template in templates)
            {
                ListViewItem item = new ListViewItem(template.Name);
                item.SubItems.Add(template.FileType);
                item.SubItems.Add(template.Description);
                item.Tag = template; // Stocăm obiectul template pentru referințe ulterioare

                lvTemplates.Items.Add(item);
            }

            // Dezactivăm butoanele care necesită selectarea unui template
            UpdateButtonsState();
        }

        private void UpdateButtonsState()
        {
            bool hasSelection = lvTemplates.SelectedItems.Count > 0;

            btnEditTemplate.Enabled = hasSelection;
            btnDeleteTemplate.Enabled = hasSelection;
            btnUseTemplate.Enabled = hasSelection;
        }

        private void btnAddTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                // Configurăm OpenFileDialog pentru selectarea template-urilor
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Template-uri Word (*.dotx;*.dot)|*.dotx;*.dot|Documente Word (*.docx;*.doc)|*.docx;*.doc|Toate fișierele (*.*)|*.*";
                openFileDialog.Title = "Selectați un template";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(selectedFilePath);
                    string destinationPath = Path.Combine(templateFolderPath, fileName);

                    // Verificăm dacă există deja un fișier cu același nume
                    if (File.Exists(destinationPath))
                    {
                        DialogResult result = MessageBox.Show(
                            "Există deja un template cu acest nume. Doriți să îl înlocuiți?",
                            "Template existent",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.No)
                        {
                            return;
                        }
                    }

                    // Copiem fișierul în directorul de template-uri
                    File.Copy(selectedFilePath, destinationPath, true);

                    // Reîncărcăm template-urile
                    LoadTemplates();
                    UpdateUI();

                    MessageBox.Show("Template-ul a fost adăugat cu succes!",
                        "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la adăugarea template-ului: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditTemplate_Click(object sender, EventArgs e)
        {
            if (lvTemplates.SelectedItems.Count == 0)
                return;

            try
            {
                TemplateInfo selectedTemplate = (TemplateInfo)lvTemplates.SelectedItems[0].Tag;

                // Deschidem template-ul cu aplicația implicită (de obicei Word)
                System.Diagnostics.Process.Start(selectedTemplate.FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la deschiderea template-ului: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteTemplate_Click(object sender, EventArgs e)
        {
            if (lvTemplates.SelectedItems.Count == 0)
                return;

            try
            {
                TemplateInfo selectedTemplate = (TemplateInfo)lvTemplates.SelectedItems[0].Tag;

                DialogResult result = MessageBox.Show(
                    $"Sunteți sigur că doriți să ștergeți template-ul '{selectedTemplate.Name}'?",
                    "Confirmare ștergere",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Ștergem fișierul
                    File.Delete(selectedTemplate.FilePath);

                    // Reîncărcăm template-urile
                    LoadTemplates();
                    UpdateUI();

                    MessageBox.Show("Template-ul a fost șters cu succes!",
                        "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la ștergerea template-ului: {ex.Message}",
                    "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUseTemplate_Click(object sender, EventArgs e)
        {
            if (lvTemplates.SelectedItems.Count == 0)
                return;

            try
            {
                TemplateInfo selectedTemplate = (TemplateInfo)lvTemplates.SelectedItems[0].Tag;

                // Obținem documentul activ (ThisDocument)
                var wordApp = Globals.ThisDocument.Application;
                var activeDoc = wordApp.ActiveDocument;

                // Ștergem tot conținutul actual
                activeDoc.Content.Delete();

                // Inserăm conținutul template-ului în documentul activ
                object range = activeDoc.Range(0, 0);
                activeDoc.Application.Selection.InsertFile(selectedTemplate.FilePath);

                MessageBox.Show("Template-ul a fost inserat în documentul activ.",
                                "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Poți lăsa formularul deschis sau închide
                // this.DialogResult = DialogResult.OK;
                // this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la aplicarea template-ului: {ex.Message}",
                                "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvTemplates_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();

            // Dacă avem un element selectat, actualizăm panoul de previzualizare
            if (lvTemplates.SelectedItems.Count > 0)
            {
                TemplateInfo selectedTemplate = (TemplateInfo)lvTemplates.SelectedItems[0].Tag;
                lblPreviewName.Text = selectedTemplate.Name;
                lblPreviewType.Text = selectedTemplate.FileType;
                lblPreviewDescription.Text = selectedTemplate.Description;

                // Aici am putea adăuga cod pentru a genera o previzualizare a template-ului
                // dar pentru simplitate, nu vom implementa această funcționalitate acum
            }
            else
            {
                // Resetăm informațiile de previzualizare
                lblPreviewName.Text = "-";
                lblPreviewType.Text = "-";
                lblPreviewDescription.Text = "-";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ShowTextPreview(string filePath)
        {
            try
            {
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var document = wordApp.Documents.Open(filePath, ReadOnly: true, Visible: false);

                string previewText = "";
                if (document.Paragraphs.Count > 0)
                {
                    for (int i = 1; i <= Math.Min(5, document.Paragraphs.Count); i++)
                    {
                        previewText += document.Paragraphs[i].Range.Text + Environment.NewLine;
                    }
                }

                document.Close(false);
                wordApp.Quit(false);

                txtPreviewContent.Text = previewText; // un TextBox multiline adăugat în UI
            }
            catch (Exception ex)
            {
                txtPreviewContent.Text = $"Eroare la previzualizare: {ex.Message}";
            }
        }
        private void btnRenameTemplate_Click(object sender, EventArgs e)
        {
            if (lvTemplates.SelectedItems.Count == 0)
                return;

            TemplateInfo selectedTemplate = (TemplateInfo)lvTemplates.SelectedItems[0].Tag;

            string newName = Prompt.ShowDialog("Introduceți noul nume pentru template:", "Redenumire Template");


            if (string.IsNullOrWhiteSpace(newName))
                return;

            string newPath = Path.Combine(templateFolderPath, newName + Path.GetExtension(selectedTemplate.FilePath));
            if (File.Exists(newPath))
            {
                MessageBox.Show("Există deja un fișier cu acest nume.");
                return;
            }

            File.Move(selectedTemplate.FilePath, newPath);
            LoadTemplates();
            UpdateUI();
        }
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };

                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, AutoSize = true };
                TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
                Button confirmation = new Button() { Text = "OK", Left = 280, Width = 80, Top = 80, DialogResult = DialogResult.OK };

                confirmation.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            lvTemplates.Items.Clear();

            foreach (var template in templates.Where(t => t.Name.ToLower().Contains(searchText) || t.Description.ToLower().Contains(searchText)))
            {
                ListViewItem item = new ListViewItem(template.Name);
                item.SubItems.Add(template.FileType);
                item.SubItems.Add(template.Description);
                item.Tag = template;

                lvTemplates.Items.Add(item);
            }

            UpdateButtonsState();
        }
        private void btnExportList_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Fișier CSV (*.csv)|*.csv";
            saveDialog.Title = "Exportă lista de template-uri";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Nume,Tip,Descriere");

                foreach (var template in templates)
                {
                    sb.AppendLine($"\"{template.Name}\",\"{template.FileType}\",\"{template.Description}\"");
                }

                File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Export realizat cu succes!");
            }
        }
    }

    // Clasa pentru stocarea informațiilor despre template-uri
    public class TemplateInfo
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
       

    }
     
    }