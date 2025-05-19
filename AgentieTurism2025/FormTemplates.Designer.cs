using System;
using System.Windows.Forms;

namespace AgentieTurism2025
{
    partial class FormTemplates
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView lvTemplates;
        private System.Windows.Forms.Button btnAddTemplate;
        private System.Windows.Forms.Button btnEditTemplate;
        private System.Windows.Forms.Button btnDeleteTemplate;
        private System.Windows.Forms.Button btnUseTemplate;
        private System.Windows.Forms.Button btnRenameTemplate;
        private System.Windows.Forms.Button btnExportList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtPreviewContent;
        private System.Windows.Forms.Label lblPreviewName;
        private System.Windows.Forms.Label lblPreviewType;
        private System.Windows.Forms.Label lblPreviewDescription;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvTemplates = new ListView();
            this.btnAddTemplate = new Button();
            this.btnEditTemplate = new Button();
            this.btnDeleteTemplate = new Button();
            this.btnUseTemplate = new Button();
            this.btnRenameTemplate = new Button();
            this.btnExportList = new Button();
            this.txtSearch = new TextBox();
            this.txtPreviewContent = new TextBox();
            this.lblPreviewName = new Label();
            this.lblPreviewType = new Label();
            this.lblPreviewDescription = new Label();
            this.lblSearch = new Label();
            this.btnClose = new Button();

            this.SuspendLayout();

            // lvTemplates
            this.lvTemplates.Location = new System.Drawing.Point(12, 50);
            this.lvTemplates.Size = new System.Drawing.Size(400, 300);
            this.lvTemplates.View = View.Details;
            this.lvTemplates.FullRowSelect = true;
            this.lvTemplates.Columns.Add("Nume", 150);
            this.lvTemplates.Columns.Add("Tip", 120);
            this.lvTemplates.Columns.Add("Descriere", 200);
            this.lvTemplates.SelectedIndexChanged += new EventHandler(this.lvTemplates_SelectedIndexChanged);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(65, 20);
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);

            // lblSearch
            this.lblSearch.Text = "Căutare:";
            this.lblSearch.Location = new System.Drawing.Point(12, 23);
            this.lblSearch.Size = new System.Drawing.Size(50, 15);

            // txtPreviewContent
            this.txtPreviewContent.Location = new System.Drawing.Point(430, 130);
            this.txtPreviewContent.Size = new System.Drawing.Size(340, 220);
            this.txtPreviewContent.Multiline = true;
            this.txtPreviewContent.ReadOnly = true;
            this.txtPreviewContent.ScrollBars = ScrollBars.Vertical;

            // lblPreviewName
            this.lblPreviewName.Location = new System.Drawing.Point(430, 20);
            this.lblPreviewName.Size = new System.Drawing.Size(340, 20);
            this.lblPreviewName.Text = "-";

            // lblPreviewType
            this.lblPreviewType.Location = new System.Drawing.Point(430, 45);
            this.lblPreviewType.Size = new System.Drawing.Size(340, 20);
            this.lblPreviewType.Text = "-";

            // lblPreviewDescription
            this.lblPreviewDescription.Location = new System.Drawing.Point(430, 70);
            this.lblPreviewDescription.Size = new System.Drawing.Size(340, 50);
            this.lblPreviewDescription.Text = "-";

            // btnAddTemplate
            this.btnAddTemplate.Location = new System.Drawing.Point(12, 370);
            this.btnAddTemplate.Size = new System.Drawing.Size(80, 30);
            this.btnAddTemplate.Text = "Adaugă";
            this.btnAddTemplate.Click += new EventHandler(this.btnAddTemplate_Click);

            // btnEditTemplate
            this.btnEditTemplate.Location = new System.Drawing.Point(98, 370);
            this.btnEditTemplate.Size = new System.Drawing.Size(80, 30);
            this.btnEditTemplate.Text = "Editează";
            this.btnEditTemplate.Click += new EventHandler(this.btnEditTemplate_Click);

            // btnDeleteTemplate
            this.btnDeleteTemplate.Location = new System.Drawing.Point(184, 370);
            this.btnDeleteTemplate.Size = new System.Drawing.Size(80, 30);
            this.btnDeleteTemplate.Text = "Șterge";
            this.btnDeleteTemplate.Click += new EventHandler(this.btnDeleteTemplate_Click);

            // btnUseTemplate
            this.btnUseTemplate.Location = new System.Drawing.Point(270, 370);
            this.btnUseTemplate.Size = new System.Drawing.Size(80, 30);
            this.btnUseTemplate.Text = "Folosește";
            this.btnUseTemplate.Click += new EventHandler(this.btnUseTemplate_Click);

            // btnRenameTemplate
            this.btnRenameTemplate.Location = new System.Drawing.Point(430, 370);
            this.btnRenameTemplate.Size = new System.Drawing.Size(80, 30);
            this.btnRenameTemplate.Text = "Redenumește";
            this.btnRenameTemplate.Click += new EventHandler(this.btnRenameTemplate_Click);

            // btnExportList
            this.btnExportList.Location = new System.Drawing.Point(516, 370);
            this.btnExportList.Size = new System.Drawing.Size(80, 30);
            this.btnExportList.Text = "Exportă";
            this.btnExportList.Click += new EventHandler(this.btnExportList_Click);

            // btnClose
            this.btnClose.Location = new System.Drawing.Point(690, 370);
            this.btnClose.Size = new System.Drawing.Size(80, 30);
            this.btnClose.Text = "Închide";
            this.btnClose.Click += new EventHandler(this.btnClose_Click);

            // FormTemplates
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.lvTemplates);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtPreviewContent);
            this.Controls.Add(this.lblPreviewName);
            this.Controls.Add(this.lblPreviewType);
            this.Controls.Add(this.lblPreviewDescription);
            this.Controls.Add(this.btnAddTemplate);
            this.Controls.Add(this.btnEditTemplate);
            this.Controls.Add(this.btnDeleteTemplate);
            this.Controls.Add(this.btnUseTemplate);
            this.Controls.Add(this.btnRenameTemplate);
            this.Controls.Add(this.btnExportList);
            this.Controls.Add(this.btnClose);
            this.Text = "Gestionare Template-uri";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
