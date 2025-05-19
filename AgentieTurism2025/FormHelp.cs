using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace AgentieTurism2025
{
    public partial class FormHelp : Form
    {
        // Conținut help pentru fiecare secțiune
        private string[] helpSections = new string[]
        {
            "Introducere",
            "Adăugare oferte",
            "Generare documente",
            "Export Excel",
            "Statistici",
            "Dashboard",
            "Template-uri",
            "Imprimare",
            "Întrebări frecvente",
            "Contact suport"
        };

        // Declarăm SearchBox aici pentru a putea o adăuga la searchPanel
      

        // Variabile pentru imprimare
        private PrintDocument printDocument = new PrintDocument();
        private int currentCharIndex = 0;

        public FormHelp()
        {
            InitializeComponent();

            // Adăugăm căsuța de căutare la searchPanel
            searchBox = new SearchBox
            {
                Width = 300,
                Height = 30,
                Location = new Point(10, 5),
                Placeholder = "Căutați în ajutor..."
            };
            searchPanel.Controls.Add(searchBox);

            // Inițializarea PrintDocument
            printDocument.BeginPrint += PrintDocument_BeginPrint;
            printDocument.PrintPage += PrintDocument_PrintPage;

            LoadHelpContent();
            PopulateHelpTopics();
            RegisterEvents();
        }

        private void PopulateHelpTopics()
        {
            // Adaugă nodul rădăcină
            TreeNode rootNode = new TreeNode("Agenție Turism 2025");
            helpTopics.Nodes.Add(rootNode);

            // Adaugă noduri pentru fiecare secțiune
            foreach (string section in helpSections)
            {
                TreeNode sectionNode = new TreeNode(section);
                rootNode.Nodes.Add(sectionNode);

                // Adaugă subsecțiuni pentru anumite categorii
                if (section == "Adăugare oferte")
                {
                    sectionNode.Nodes.Add(new TreeNode("Crearea unei oferte noi"));
                    sectionNode.Nodes.Add(new TreeNode("Editarea ofertelor existente"));
                    sectionNode.Nodes.Add(new TreeNode("Ștergerea ofertelor"));
                    sectionNode.Nodes.Add(new TreeNode("Validarea datelor"));
                }
                else if (section == "Dashboard")
                {
                    sectionNode.Nodes.Add(new TreeNode("Vizualizarea statisticilor"));
                    sectionNode.Nodes.Add(new TreeNode("Interpretarea graficelor"));
                    sectionNode.Nodes.Add(new TreeNode("Filtrarea datelor"));
                    sectionNode.Nodes.Add(new TreeNode("Exportarea rapoartelor PDF"));
                }
                else if (section == "Întrebări frecvente")
                {
                    sectionNode.Nodes.Add(new TreeNode("Probleme la adăugarea ofertelor"));
                    sectionNode.Nodes.Add(new TreeNode("Erori la generarea documentelor"));
                    sectionNode.Nodes.Add(new TreeNode("Probleme de performanță"));
                    sectionNode.Nodes.Add(new TreeNode("Probleme de afișare"));
                }
            }

            // Expandă toate nodurile
            rootNode.Expand();
        }

        private void LoadHelpContent()
        {
            // Incarcam continutul initial
            string welcomeText = @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}}
{\colortbl ;\red41\green128\blue185;\red60\green60\blue60;}
\viewkind4\uc1\pard\qc\cf1\f0\fs32\b Bine a-ti venit in sistemul de ajutor\cf0\par
\pard\cf2\fs22\b0\par
Aceasta aplicatie va permite sa gestionati ofertele turistice ale agentiei dumneavoastra, sa generati documente profesionale si sa analizati datele prin grafice si statistici.\par
\par
Utilizati arborele din partea stanga pentru a naviga prin diferitele sectiuni de ajutor sau utilizati casuta de cautare pentru a gasi rapid informatii specifice.\par
\par
\b Functionalitati principale:\b0\par
\pard{\pntext\f0 \u8226?\tab}{\*\pn\pnlvlblt\pnf0\pnindent0{\pntxtb\u8226?}}\fi-360\li720\cf2 Adaugarea si gestionarea ofertelor turistice\par
{\pntext\f0 \u8226?\tab}Generarea documentelor Word formatate profesional\par
{\pntext\f0 \u8226?\tab}Exportul datelor in Excel pentru analiza detaliata\par
{\pntext\f0 \u8226?\tab}Vizualizarea statisticilor si graficelor\par
{\pntext\f0 \u8226?\tab}Dashboard interactiv cu indicatori importanti\par
{\pntext\f0 \u8226?\tab}Gestionarea template-urilor pentru documente\par
{\pntext\f0 \u8226?\tab}Printarea si exportul in PDF\par
\pard\cf2\par
Selectati o sectiune din meniul din stanga pentru a afla mai multe detalii.\par
}";
            richTextContent.Rtf = welcomeText;

            // Incarcam pagina web initiala
            webBrowser.Navigate("https://example.com/help");  // In mod real, aici ar fi URL-ul real de ajutor
        }


        private void RegisterEvents()
        {
            // Eveniment pentru selecția din tree view
            helpTopics.AfterSelect += (sender, e) =>
            {
                LoadContentForTopic(e.Node);
            };

            // Eveniment pentru căutare
            searchBox.SearchClicked += (sender, term) =>
            {
                PerformSearch(term);
            };

            // Eveniment pentru butonul de printare
            btnPrintHelp.Click += (sender, e) =>
            {
                PrintHelp();
            };

            // Eveniment pentru butonul de feedback
            btnSendFeedback.Click += (sender, e) =>
            {
                ShowFeedbackForm();
            };

            // Eveniment pentru butonul de manual PDF

        }

        private void LoadContentForTopic(TreeNode node)
        {
            if (node == null) return;

            string topicTitle = node.Text;
            string content = "";

            switch (topicTitle)
            {
                case "Adăugare oferte":
                    content = GetOfertaContent();
                    break;
                case "Dashboard":
                    content = GetDashboardContent();
                    break;
                case "Exportarea rapoartelor PDF":
                    content = GetPdfExportContent();
                    break;
                default:
                    content = GetDefaultContent(topicTitle);
                    break;
            }

            // Setăm conținutul în Rich Text Box
            richTextContent.Rtf = content;

            // Încarcă și conținutul web corespunzător (dacă există)
            LoadWebContent(topicTitle);
        }

        private string GetOfertaContent()
        {
            return @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}}
{\colortbl ;\red41\green128\blue185;\red60\green60\blue60;\red192\green80\blue77;}
\viewkind4\uc1\pard\qc\cf1\f0\fs28\b Adaugare oferte turistice\cf0\b0\par
\pard\cf2\fs22\par
Modulul de adaugare oferte va permite sa introduceti si sa gestionati toate ofertele turistice ale agentiei dumneavoastra.\par
\par
\b Pasi pentru adaugarea unei noi oferte:\b0\par
\pard{\pntext\f0 1.\tab}{\*\pn\pnlvlbody\pnf0\pnindent0\pnstart1\pndec{\pntxta.}}
\fi-360\li720\cf2 Apasati butonul \b Adauga Oferta\b0 din panglica aplicatiei\par
{\pntext\f0 2.\tab}Completeaza toate campurile din formular (destinatie, pret, perioada, transport, etc.)\par
{\pntext\f0 3.\tab}Incarcati imagini reprezentative pentru oferta (optional)\par
{\pntext\f0 4.\tab}Verificati datele introduse\par
{\pntext\f0 5.\tab}Apasati butonul \b Salveaza\b0 pentru a finaliza\par
\pard\cf2\par
\cf3\b Nota importanta: \cf2\b0 Toate campurile marcate cu * sunt obligatorii. Pretul trebuie introdus fara simbol monetar.\par
\par
\b Editarea ofertelor existente:\b0\par
Pentru a edita o oferta existenta, navigati la lista de oferte, selectati oferta dorita si apasati butonul \b Editeaza\b0.\par
\par
\b Stergerea ofertelor:\b0\par
Ofertele care nu mai sunt valabile pot fi sterse selectandu-le din lista si apasand butonul \b Sterge\b0. Vei primi o confirmare inainte de stergerea definitiva.\par
}";
        }


        private string GetDashboardContent()
        {
            return @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}}
{\colortbl ;\red41\green128\blue185;\red60\green60\blue60;\red0\green128\blue0;}
\viewkind4\uc1\pard\qc\cf1\f0\fs28\b Dashboard Agentie Turism\cf0\b0\par
\pard\cf2\fs22\par
Dashboard-ul ofera o privire de ansamblu asupra indicatorilor cheie de performanta si a statisticilor importante pentru agentia dumneavoastra.\par
\par
\b Componente principale ale dashboard-ului:\b0\par
\pard{\pntext\f0 \u8226?\tab}{\*\pn\pnlvlblt\pnf0\pnindent0{\pntxtb\u8226?}}\fi-360\li720\cf2 Carduri cu statistici generale (numar de oferte, vanzari totale, pret mediu, etc.)\par
{\pntext\f0 \u8226?\tab}Grafic circular cu distributia destinatiilor populare\par
{\pntext\f0 \u8226?\tab}Grafic de tip coloana cu analiza preturilor medii pe destinatii\par
{\pntext\f0 \u8226?\tab}Grafic inelar cu distributia tipurilor de transport\par
{\pntext\f0 \u8226?\tab}Lista cu cele mai recente oferte adaugate\par
{\pntext\f0 \u8226?\tab}Harta cu ofertele populare\par
\pard\cf2\par
\b Filtrarea datelor:\b0\par
Puteti filtra informatiile afisate pe dashboard in functie de perioada folosind combobox-ul din partea de sus a ecranului.\par
\par
\cf3\b Sfat: \cf2 Actualizati dashboard-ul regulat apasand butonul \i Actualizeaza\i0 pentru a vedea cele mai recente date.\b0\par
\par
\b Exportarea ca PDF:\b0\par
Puteti exporta intregul dashboard ca document PDF apasand butonul \b Export PDF\b0. Documentul generat va include toate graficele si statisticile afisate in dashboard.\par
}";
        }


        private string GetPdfExportContent()
        {
            return @"{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Segoe UI;}}
{\colortbl ;\red41\green128\blue185;\red60\green60\blue60;\red192\green80\blue77;}
\viewkind4\uc1\pard\qc\cf1\f0\fs28\b Exportarea rapoartelor in format PDF\cf0\b0\par
\pard\cf2\fs22\par
Functionalitatea de export PDF va permite sa salvati rapoartele si dashboard-ul in format PDF pentru a le distribui mai usor sau pentru a le arhiva.\par
\par
\b Pasi pentru exportarea Dashboard-ului in PDF:\b0\par
\pard{\pntext\f0 1.\tab}{\*\pn\pnlvlbody\pnf0\pnindent0\pnstart1\pndec{\pntxta.}}
\fi-360\li720\cf2 Deschideti dashboard-ul cu statisticile dorite\par
{\pntext\f0 2.\tab}Selectati perioada relevanta pentru raport\par
{\pntext\f0 3.\tab}Apasati butonul \b Export PDF\b0 din partea de jos a ecranului\par
{\pntext\f0 4.\tab}Alegeti locatia unde doriti sa salvati fisierul PDF\par
{\pntext\f0 5.\tab}Asteptati finalizarea generarii documentului\par
{\pntext\f0 6.\tab}Vizualizati documentul generat (optional)\par
\pard\cf2\par
\b Continutul PDF-ului generat:\b0\par
\pard{\pntext\f0 \u8226?\tab}{\*\pn\pnlvlblt\pnf0\pnindent0{\pntxtb\u8226?}}\fi-360\li720\cf2 Titlu si informatii despre perioada\par
{\pntext\f0 \u8226?\tab}Tabel cu statisticile generale\par
{\pntext\f0 \u8226?\tab}Toate graficele din dashboard\par
{\pntext\f0 \u8226?\tab}Lista cu ofertele recente\par
{\pntext\f0 \u8226?\tab}Footer cu data generarii\par
\pard\cf2\par
\cf3\b Nota: \cf2\b0 PDF-urile generate sunt optimizate pentru imprimare pe hartie A4 in format landscape.\par
\par
\b Distribuirea rapoartelor:\b0\par
Rapoartele PDF pot fi distribuite prin email, incarcate in sistemele de management de documente sau tiparite pentru prezentari.\par
}";
        }


        private string GetDefaultContent(string topic)
        {
            // Generam un continut generic pentru topicurile fara continut specific
            return $@"{{\rtf1\ansi\ansicpg1252\deff0\deflang1033{{\fonttbl{{\f0\fnil\fcharset0 Segoe UI;}}}}
{{\colortbl ;\red41\green128\blue185;\red60\green60\blue60;\red169\green169\blue169;}}
\viewkind4\uc1\pard\qc\cf1\f0\fs28\b {topic}\cf0\b0\par
\pard\cf2\fs22\par
Aceasta sectiune ofera ghiduri si informatii legate de functionalitatea {topic.ToLower()}.\par
\par
Daca ai nevoie de instructiuni clare despre cum sa folosesti aceasta optiune, consulta manualul PDF sau foloseste casuta de cautare din partea de sus.\par
\par
\cf3 Sfat: \cf2 Incearca sa navighezi in submeniurile din stanga pentru mai multe detalii legate de acest subiect.\par
}}";
        }


        private void LoadWebContent(string topic)
        {
            // In mod real, am naviga catre o pagina web specifica pentru topic
            // Pentru demo, vom crea un HTML simplu
            string html = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <title>Help - {topic}</title>
            <style>
                body {{ font-family: 'Segoe UI', sans-serif; margin: 20px; color: #333; }}
                h1 {{ color: #2980b9; text-align: center; }}
                .note {{ background-color: #f8f9fa; padding: 10px; border-left: 4px solid #2980b9; margin: 15px 0; }}
                img {{ max-width: 100%; }}
            </style>
        </head>
        <body>
            <h1>{topic}</h1>
            <p>Aceasta este versiunea online a ajutorului pentru <b>{topic}</b>.</p>
            <div class='note'>
                <p><b>Nota:</b> Continutul online poate fi actualizat mai frecvent decat versiunea offline.</p>
            </div>
            <p>Pentru cele mai recente informatii si tutoriale video, vizitati site-ul nostru web oficial.</p>
        </body>
        </html>";

            // Incarcam HTML-ul in WebBrowser
            webBrowser.DocumentText = html;
        }


        private void PerformSearch(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return;

            // In implementarea reala, am cauta in continutul de ajutor
            // Pentru demo, vom afisa rezultate simulate
            string searchResults = $@"{{\rtf1\ansi\ansicpg1252\deff0\deflang1033{{\fonttbl{{\f0\fnil\fcharset0 Segoe UI;}}}}
{{\colortbl ;\red41\green128\blue185;\red60\green60\blue60;\red0\green0\blue255;}}
\viewkind4\uc1\pard\qc\cf1\f0\fs28\b Rezultate cautare pentru: ""{searchTerm}""\cf0\b0\par
\pard\cf2\fs22\par
S-au gasit 3 rezultate pentru cautarea dumneavoastra:\par
\par
\pard{{\pntext\f0 1.\tab}}{{*\pn\pnlvlbody\pnf0\pnindent0\pnstart1\pndec{{\pntxta.}}}}
\fi-360\li720\cf2\cf3\ul Adaugare oferte\cf2\ulnone : Documentatie despre adaugarea ofertelor turistice.\par
{{\pntext\f0 2.\tab}}\cf3\ul Dashboard\cf2\ulnone : Informatii despre utilizarea panoului de control.\par
{{\pntext\f0 3.\tab}}\cf3\ul Exportarea rapoartelor PDF\cf2\ulnone : Ghid pentru exportarea rapoartelor in format PDF.\par
\pard\cf2\par
Faceti clic pe unul dintre rezultate pentru a vedea informatiile complete.\par
}}";

            richTextContent.Rtf = searchResults;
        }


        private void PrintHelp()
        {
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.DocumentName = "Ajutor Agenție Turism";
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    printDocument.Print();
                    MessageBox.Show("Conținutul a fost trimis la imprimantă.", "Imprimare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la imprimare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metode pentru imprimare
        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            currentCharIndex = 0;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Definirea fontului și dimensiunii pentru imprimare
            Font printFont = new Font("Segoe UI", 10);
            float lineHeight = printFont.GetHeight(e.Graphics);
            int linesPerPage = (int)(e.MarginBounds.Height / lineHeight);
            float yPos = e.MarginBounds.Top;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            int chars = 0;

            // Calculăm zona de afișare (margins)
            RectangleF printArea = e.MarginBounds;

            // Dacă imprimăm titlul, îl adăugăm
            Font titleFont = new Font("Segoe UI", 14, FontStyle.Bold);
            string title = this.Text;
            SizeF titleSize = e.Graphics.MeasureString(title, titleFont);
            e.Graphics.DrawString(title, titleFont, Brushes.DarkBlue, (e.MarginBounds.Width - titleSize.Width) / 2 + leftMargin, yPos);
            yPos += titleSize.Height + 20;

            // Imprimăm conținutul RichTextBox
            while (count < linesPerPage && currentCharIndex < richTextContent.TextLength)
            {
                line = GetLineFromRichTextBox(richTextContent, currentCharIndex, out chars);
                if (line == null)
                    break;

                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos);
                currentCharIndex += chars;
                yPos += lineHeight;
                count++;
            }

            // Verificăm dacă mai sunt pagini de imprimat
            e.HasMorePages = (currentCharIndex < richTextContent.TextLength);
        }

        private string GetLineFromRichTextBox(RichTextBox rtb, int startIndex, out int charCount)
        {
            // Obținem o linie din RichTextBox pentru imprimare
            charCount = 0;
            if (startIndex >= rtb.TextLength)
                return null;

            // Obținem textul de la poziția curentă
            string text = rtb.Text.Substring(startIndex);
            if (text.Length == 0)
                return null;

            // Căutăm sfârșitul liniei
            int endIndex = text.IndexOf('\n');
            if (endIndex >= 0)
            {
                charCount = endIndex + 1;
                return text.Substring(0, endIndex);
            }
            else
            {
                charCount = text.Length;
                return text;
            }
        }

        private void ShowFeedbackForm()
        {
            // În implementarea reală, am deschide un formular de feedback
            // Pentru demo, afișăm un dialog simplu
            MessageBox.Show(
                "Ne dorim să îmbunătățim constant aplicația noastră.\n\n" +
                "Dacă aveți sugestii, întrebări sau probleme, vă rugăm să ne trimiteți un email la adresa:\n" +
                "support@agentieturism2025.ro\n\n" +
                "Vă mulțumim pentru feedback!",
                "Trimite Feedback",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

     
    }

    // Clasa SearchBox personalizată pentru căutare
    public class SearchBox : Panel
    {
        private TextBox txtSearch;
        private Button btnSearch;
        private string _placeholder = "Caută...";

        public event EventHandler<string> SearchClicked;

        public string Placeholder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value;
                txtSearch.Text = value;
            }
        }

        public SearchBox()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.BorderStyle = BorderStyle.FixedSingle;

            txtSearch = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Location = new Point(5, 5),
                Width = this.Width - 35,
                Height = this.Height - 10,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Text = _placeholder
            };
            this.Controls.Add(txtSearch);

            btnSearch = new Button
            {
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Size = new Size(25, 25),
                Location = new Point(this.Width - 30, 2),
                Text = "🔍",
                Cursor = Cursors.Hand
            };
            this.Controls.Add(btnSearch);

            // Ajustează dimensiunile și pozițiile când se modifică dimensiunea panoului
            this.SizeChanged += (sender, e) =>
            {
                txtSearch.Width = this.Width - 35;
                btnSearch.Location = new Point(this.Width - 30, 2);
            };

            // Eveniment de focus
            txtSearch.GotFocus += (sender, e) =>
            {
                if (txtSearch.Text == _placeholder)
                {
                    txtSearch.Text = "";
                    txtSearch.ForeColor = Color.Black;
                }
            };

            txtSearch.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    txtSearch.Text = _placeholder;
                    txtSearch.ForeColor = Color.Gray;
                }
            };

            // Eveniment de căutare
            btnSearch.Click += (sender, e) =>
            {
                PerformSearch();
            };

            txtSearch.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    PerformSearch();
                    e.SuppressKeyPress = true;
                }
            };
        }

        private void PerformSearch()
        {
            if (txtSearch.Text != _placeholder && !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                SearchClicked?.Invoke(this, txtSearch.Text);
            }
        }
    }
}