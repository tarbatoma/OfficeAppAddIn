namespace AgentieTurism2025
{
    partial class FormExcel
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportToate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNumarOferte = new System.Windows.Forms.TextBox();
            this.btnExportTop = new System.Windows.Forms.Button();
            this.btnInchide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exportă toate ofertele turistice într-un fișier Excel:";
            // 
            // btnExportToate
            // 
            this.btnExportToate.Location = new System.Drawing.Point(327, 18);
            this.btnExportToate.Name = "btnExportToate";
            this.btnExportToate.Size = new System.Drawing.Size(145, 30);
            this.btnExportToate.TabIndex = 1;
            this.btnExportToate.Text = "Exportă Toate";
            this.btnExportToate.UseVisualStyleBackColor = true;
            this.btnExportToate.Click += new System.EventHandler(this.btnExportToate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportTop);
            this.groupBox1.Controls.Add(this.txtNumarOferte);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exportă Top Oferte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Număr de oferte în top (după preț):";
            // 
            // txtNumarOferte
            // 
            this.txtNumarOferte.Location = new System.Drawing.Point(208, 32);
            this.txtNumarOferte.Name = "txtNumarOferte";
            this.txtNumarOferte.Size = new System.Drawing.Size(91, 20);
            this.txtNumarOferte.TabIndex = 1;
            this.txtNumarOferte.Text = "5";
            // 
            // btnExportTop
            // 
            this.btnExportTop.Location = new System.Drawing.Point(315, 27);
            this.btnExportTop.Name = "btnExportTop";
            this.btnExportTop.Size = new System.Drawing.Size(130, 30);
            this.btnExportTop.TabIndex = 2;
            this.btnExportTop.Text = "Exportă Top";
            this.btnExportTop.UseVisualStyleBackColor = true;
            this.btnExportTop.Click += new System.EventHandler(this.btnExportTop_Click);
            // 
            // btnInchide
            // 
            this.btnInchide.Location = new System.Drawing.Point(180, 168);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(120, 30);
            this.btnInchide.TabIndex = 3;
            this.btnInchide.Text = "Închide";
            this.btnInchide.UseVisualStyleBackColor = true;
            this.btnInchide.Click += new System.EventHandler(this.btnInchide_Click);
            // 
            // FormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.btnInchide);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExportToate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export Date în Excel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportToate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumarOferte;
        private System.Windows.Forms.Button btnExportTop;
        private System.Windows.Forms.Button btnInchide;
    }
}