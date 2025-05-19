namespace AgentieTurism2025
{
    partial class Ribbon1 : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        private System.ComponentModel.IContainer components = null;

        public Ribbon1() : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon1));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.groupGestionare = this.Factory.CreateRibbonGroup();
            this.btnAdaugaOferta = this.Factory.CreateRibbonButton();
            this.btnGenereazaDocument = this.Factory.CreateRibbonButton();
            this.btnExportExcel = this.Factory.CreateRibbonButton();
            this.btnStatistici = this.Factory.CreateRibbonButton();
            this.groupAvansat = this.Factory.CreateRibbonGroup();
            this.btnDashboard = this.Factory.CreateRibbonButton();
            this.btnTemplates = this.Factory.CreateRibbonButton();
            this.groupUtils = this.Factory.CreateRibbonGroup();
            this.btnPrint = this.Factory.CreateRibbonButton();
            this.btnHelp = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.groupGestionare.SuspendLayout();
            this.groupAvansat.SuspendLayout();
            this.groupUtils.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.groupGestionare);
            this.tab1.Groups.Add(this.groupAvansat);
            this.tab1.Groups.Add(this.groupUtils);
            this.tab1.Label = "Agenție Turism";
            this.tab1.Name = "tab1";
            // 
            // groupGestionare
            // 
            this.groupGestionare.Items.Add(this.btnAdaugaOferta);
            this.groupGestionare.Items.Add(this.btnGenereazaDocument);
            this.groupGestionare.Items.Add(this.btnExportExcel);
            this.groupGestionare.Items.Add(this.btnStatistici);
            this.groupGestionare.Label = "Gestionare Oferte";
            this.groupGestionare.Name = "groupGestionare";
            // 
            // btnAdaugaOferta
            // 
            this.btnAdaugaOferta.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnAdaugaOferta.Image = global::AgentieTurism2025.Properties.Resources.add;
            this.btnAdaugaOferta.Label = "Adaugă Ofertă";
            this.btnAdaugaOferta.Name = "btnAdaugaOferta";
            this.btnAdaugaOferta.ScreenTip = "Adaugă o nouă ofertă turistică";
            this.btnAdaugaOferta.ShowImage = true;
            this.btnAdaugaOferta.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnAdaugaOferta_Click);
            // 
            // btnGenereazaDocument
            // 
            this.btnGenereazaDocument.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnGenereazaDocument.Image = global::AgentieTurism2025.Properties.Resources.document;
            this.btnGenereazaDocument.Label = "Generează Document";
            this.btnGenereazaDocument.Name = "btnGenereazaDocument";
            this.btnGenereazaDocument.ScreenTip = "Generează un document Word cu oferta selectată";
            this.btnGenereazaDocument.ShowImage = true;
            this.btnGenereazaDocument.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnGenereazaDocument_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnExportExcel.Image = global::AgentieTurism2025.Properties.Resources.excel;
            this.btnExportExcel.Label = "Export Excel";
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.ScreenTip = "Exportă ofertele în Excel";
            this.btnExportExcel.ShowImage = true;
            this.btnExportExcel.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnExportExcel_Click);
            // 
            // btnStatistici
            // 
            this.btnStatistici.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnStatistici.Image = global::AgentieTurism2025.Properties.Resources.chart;
            this.btnStatistici.Label = "Statistici";
            this.btnStatistici.Name = "btnStatistici";
            this.btnStatistici.ScreenTip = "Afișează statistici despre ofertele turistice";
            this.btnStatistici.ShowImage = true;
            this.btnStatistici.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnStatistici_Click);
            // 
            // groupAvansat
            // 
            this.groupAvansat.Items.Add(this.btnDashboard);
            this.groupAvansat.Items.Add(this.btnTemplates);
            this.groupAvansat.Label = "Funcții Avansate";
            this.groupAvansat.Name = "groupAvansat";
            // 
            // btnDashboard
            // 
            this.btnDashboard.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnDashboard.Image = global::AgentieTurism2025.Properties.Resources.dashboard;
            this.btnDashboard.Label = "Dashboard";
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.ScreenTip = "Deschide dashboard-ul general";
            this.btnDashboard.ShowImage = true;
            this.btnDashboard.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnDashboard_Click);
            // 
            // btnTemplates
            // 
            this.btnTemplates.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnTemplates.Image = global::AgentieTurism2025.Properties.Resources.template;
            this.btnTemplates.Label = "Template-uri";
            this.btnTemplates.Name = "btnTemplates";
            this.btnTemplates.ScreenTip = "Gestionează template-urile de documente";
            this.btnTemplates.ShowImage = true;
            this.btnTemplates.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnTemplates_Click);
            // 
            // groupUtils
            // 
            this.groupUtils.Items.Add(this.btnPrint);
            this.groupUtils.Items.Add(this.btnHelp);
            this.groupUtils.Label = "Utilitare";
            this.groupUtils.Name = "groupUtils";
            // 
            // btnPrint
            // 
            this.btnPrint.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnPrint.Image = global::AgentieTurism2025.Properties.Resources.print;
            this.btnPrint.Label = "Imprimare";
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ScreenTip = "Imprimă documentul curent";
            this.btnPrint.ShowImage = true;
            this.btnPrint.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnPrint_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.btnHelp.Image = ((System.Drawing.Image)(resources.GetObject("btnHelp.Image")));
            this.btnHelp.Label = "Ajutor";
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.ScreenTip = "Obține ajutor și informații";
            this.btnHelp.ShowImage = true;
            this.btnHelp.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnHelp_Click);
            // 
            // Ribbon1
            // 
            this.Name = "Ribbon1";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon1_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.groupGestionare.ResumeLayout(false);
            this.groupGestionare.PerformLayout();
            this.groupAvansat.ResumeLayout(false);
            this.groupAvansat.PerformLayout();
            this.groupUtils.ResumeLayout(false);
            this.groupUtils.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupGestionare;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnAdaugaOferta;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnGenereazaDocument;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnExportExcel;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnStatistici;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupAvansat;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnDashboard;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnTemplates;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupUtils;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnPrint;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnHelp;
    }
}
