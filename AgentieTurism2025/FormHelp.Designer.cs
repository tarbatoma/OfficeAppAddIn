namespace AgentieTurism2025
{
    partial class FormHelp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageText = new System.Windows.Forms.TabPage();
            this.richTextContent = new System.Windows.Forms.RichTextBox();
            this.tabPageWeb = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.helpTopics = new System.Windows.Forms.TreeView();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.searchPanel = new System.Windows.Forms.Panel();
           
            this.btnSendFeedback = new System.Windows.Forms.Button();
            this.btnPrintHelp = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageText.SuspendLayout();
            this.tabPageWeb.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageText);
            this.tabControl.Controls.Add(this.tabPageWeb);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(766, 385);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageText
            // 
            this.tabPageText.Controls.Add(this.richTextContent);
            this.tabPageText.Location = new System.Drawing.Point(4, 32);
            this.tabPageText.Name = "tabPageText";
            this.tabPageText.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageText.Size = new System.Drawing.Size(758, 349);
            this.tabPageText.TabIndex = 0;
            this.tabPageText.Text = "Text";
            this.tabPageText.UseVisualStyleBackColor = true;
            // 
            // richTextContent
            // 
            this.richTextContent.BackColor = System.Drawing.Color.White;
            this.richTextContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextContent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextContent.Location = new System.Drawing.Point(3, 3);
            this.richTextContent.Name = "richTextContent";
            this.richTextContent.ReadOnly = true;
            this.richTextContent.Size = new System.Drawing.Size(752, 343);
            this.richTextContent.TabIndex = 0;
            this.richTextContent.Text = "";
            // 
            // tabPageWeb
            // 
            this.tabPageWeb.Controls.Add(this.webBrowser);
            this.tabPageWeb.Location = new System.Drawing.Point(4, 32);
            this.tabPageWeb.Name = "tabPageWeb";
            this.tabPageWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeb.Size = new System.Drawing.Size(758, 349);
            this.tabPageWeb.TabIndex = 1;
            this.tabPageWeb.Text = "Online";
            this.tabPageWeb.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(752, 343);
            this.webBrowser.TabIndex = 0;
            // 
            // helpTopics
            // 
            this.helpTopics.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.helpTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.helpTopics.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpTopics.FullRowSelect = true;
            this.helpTopics.HideSelection = false;
            this.helpTopics.Indent = 20;
            this.helpTopics.ItemHeight = 25;
            this.helpTopics.Location = new System.Drawing.Point(0, 0);
            this.helpTopics.Name = "helpTopics";
            this.helpTopics.ShowLines = false;
            this.helpTopics.ShowPlusMinus = true;
            this.helpTopics.Size = new System.Drawing.Size(766, 250);
            this.helpTopics.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.lblVersion);
            this.mainPanel.Controls.Add(this.splitContainer);
            this.mainPanel.Controls.Add(this.searchPanel);
            this.mainPanel.Controls.Add(this.lblTitle);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.mainPanel.Size = new System.Drawing.Size(900, 700);
            this.mainPanel.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblVersion.Location = new System.Drawing.Point(10, 665);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(880, 25);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Versiune 1.0.0 (build 2025.05.16)";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(10, 90);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.helpTopics);
            this.splitContainer.Panel1MinSize = 150;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl);
            this.splitContainer.Panel2MinSize = 250;
            this.splitContainer.Size = new System.Drawing.Size(766, 550);
            this.splitContainer.SplitterDistance = 250;
            this.splitContainer.TabIndex = 2;
            // 
            // searchPanel
            // 
          
            this.searchPanel.Controls.Add(this.btnSendFeedback);
            this.searchPanel.Controls.Add(this.btnPrintHelp);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(10, 50);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Size = new System.Drawing.Size(880, 40);
            this.searchPanel.TabIndex = 1;

            // btnSendFeedback
            // 
            this.btnSendFeedback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSendFeedback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendFeedback.ForeColor = System.Drawing.Color.White;
            this.btnSendFeedback.Location = new System.Drawing.Point(430, 5);
            this.btnSendFeedback.Name = "btnSendFeedback";
            this.btnSendFeedback.Size = new System.Drawing.Size(100, 30);
            this.btnSendFeedback.TabIndex = 1;
            this.btnSendFeedback.Text = "Feedback";
            this.btnSendFeedback.UseVisualStyleBackColor = false;
            // 
            // btnPrintHelp
            // 
            this.btnPrintHelp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnPrintHelp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintHelp.ForeColor = System.Drawing.Color.White;
            this.btnPrintHelp.Location = new System.Drawing.Point(320, 5);
            this.btnPrintHelp.Name = "btnPrintHelp";
            this.btnPrintHelp.Size = new System.Drawing.Size(100, 30);
            this.btnPrintHelp.TabIndex = 0;
            this.btnPrintHelp.Text = "Imprimă";
            this.btnPrintHelp.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(880, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ajutor Agenție Turism 2025";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.mainPanel);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FormHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajutor Agenție Turism 2025";
            this.tabControl.ResumeLayout(false);
            this.tabPageText.ResumeLayout(false);
            this.tabPageWeb.ResumeLayout(false);
            this.mainPanel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.searchPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageText;
        private System.Windows.Forms.RichTextBox richTextContent;
        private System.Windows.Forms.TabPage tabPageWeb;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TreeView helpTopics;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel searchPanel;
      
        private System.Windows.Forms.Button btnSendFeedback;
        private System.Windows.Forms.Button btnPrintHelp;
        private System.Windows.Forms.Label lblTitle;
        private SearchBox searchBox;
    }
}