namespace AgentieTurism2025
{
    partial class FormStatistici
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDurataMedia = new System.Windows.Forms.Label();
            this.lblPretMaxim = new System.Windows.Forms.Label();
            this.lblPretMinim = new System.Windows.Forms.Label();
            this.lblPretMediu = new System.Windows.Forms.Label();
            this.lblNumarOferte = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstTopDestinatii = new System.Windows.Forms.ListBox();
            this.chartTransport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPreturi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnActualizeaza = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnInchide = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTransport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPreturi)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDurataMedia);
            this.groupBox1.Controls.Add(this.lblPretMaxim);
            this.groupBox1.Controls.Add(this.lblPretMinim);
            this.groupBox1.Controls.Add(this.lblPretMediu);
            this.groupBox1.Controls.Add(this.lblNumarOferte);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistici Generale";
            // 
            // lblDurataMedia
            // 
            this.lblDurataMedia.AutoSize = true;
            this.lblDurataMedia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDurataMedia.Location = new System.Drawing.Point(150, 135);
            this.lblDurataMedia.Name = "lblDurataMedia";
            this.lblDurataMedia.Size = new System.Drawing.Size(11, 13);
            this.lblDurataMedia.TabIndex = 9;
            this.lblDurataMedia.Text = "-";
            // 
            // lblPretMaxim
            // 
            this.lblPretMaxim.AutoSize = true;
            this.lblPretMaxim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPretMaxim.Location = new System.Drawing.Point(150, 105);
            this.lblPretMaxim.Name = "lblPretMaxim";
            this.lblPretMaxim.Size = new System.Drawing.Size(11, 13);
            this.lblPretMaxim.TabIndex = 8;
            this.lblPretMaxim.Text = "-";
            // 
            // lblPretMinim
            // 
            this.lblPretMinim.AutoSize = true;
            this.lblPretMinim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPretMinim.Location = new System.Drawing.Point(150, 75);
            this.lblPretMinim.Name = "lblPretMinim";
            this.lblPretMinim.Size = new System.Drawing.Size(11, 13);
            this.lblPretMinim.TabIndex = 7;
            this.lblPretMinim.Text = "-";
            // 
            // lblPretMediu
            // 
            this.lblPretMediu.AutoSize = true;
            this.lblPretMediu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPretMediu.Location = new System.Drawing.Point(150, 45);
            this.lblPretMediu.Name = "lblPretMediu";
            this.lblPretMediu.Size = new System.Drawing.Size(11, 13);
            this.lblPretMediu.TabIndex = 6;
            this.lblPretMediu.Text = "-";
            // 
            // lblNumarOferte
            // 
            this.lblNumarOferte.AutoSize = true;
            this.lblNumarOferte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumarOferte.Location = new System.Drawing.Point(150, 25);
            this.lblNumarOferte.Name = "lblNumarOferte";
            this.lblNumarOferte.Size = new System.Drawing.Size(11, 13);
            this.lblNumarOferte.TabIndex = 5;
            this.lblNumarOferte.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Durata medie:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Preț maxim:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Preț minim:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Preț mediu:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Număr oferte:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstTopDestinatii);
            this.groupBox2.Location = new System.Drawing.Point(298, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Top Destinații";
            // 
            // lstTopDestinatii
            // 
            this.lstTopDestinatii.FormattingEnabled = true;
            this.lstTopDestinatii.Location = new System.Drawing.Point(16, 19);
            this.lstTopDestinatii.Name = "lstTopDestinatii";
            this.lstTopDestinatii.Size = new System.Drawing.Size(243, 134);
            this.lstTopDestinatii.TabIndex = 0;
            // 
            // chartTransport
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTransport.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTransport.Legends.Add(legend1);
            this.chartTransport.Location = new System.Drawing.Point(12, 188);
            this.chartTransport.Name = "chartTransport";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Transport";
            this.chartTransport.Series.Add(series1);
            this.chartTransport.Size = new System.Drawing.Size(280, 250);
            this.chartTransport.TabIndex = 2;
            this.chartTransport.Text = "Distribuție Transport";
            this.chartTransport.Titles.Add("Distribuție Transport");
            // 
            // chartPreturi
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPreturi.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPreturi.Legends.Add(legend2);
            this.chartPreturi.Location = new System.Drawing.Point(298, 188);
            this.chartPreturi.Name = "chartPreturi";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Prețuri";
            this.chartPreturi.Series.Add(series2);
            this.chartPreturi.Size = new System.Drawing.Size(274, 250);
            this.chartPreturi.TabIndex = 3;
            this.chartPreturi.Text = "Distribuție Prețuri";
            this.chartPreturi.Titles.Add("Distribuție Prețuri");
            // 
            // btnActualizeaza
            // 
            this.btnActualizeaza.Location = new System.Drawing.Point(12, 455);
            this.btnActualizeaza.Name = "btnActualizeaza";
            this.btnActualizeaza.Size = new System.Drawing.Size(110, 30);
            this.btnActualizeaza.TabIndex = 4;
            this.btnActualizeaza.Text = "Actualizează";
            this.btnActualizeaza.UseVisualStyleBackColor = true;
            this.btnActualizeaza.Click += new System.EventHandler(this.btnActualizeaza_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(237, 455);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(110, 30);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnInchide
            // 
            this.btnInchide.Location = new System.Drawing.Point(462, 455);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(110, 30);
            this.btnInchide.TabIndex = 6;
            this.btnInchide.Text = "Închide";
            this.btnInchide.UseVisualStyleBackColor = true;
            this.btnInchide.Click += new System.EventHandler(this.btnInchide_Click);
            // 
            // FormStatistici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 500);
            this.Controls.Add(this.btnInchide);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnActualizeaza);
            this.Controls.Add(this.chartPreturi);
            this.Controls.Add(this.chartTransport);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStatistici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistici Oferte Turistice";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTransport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPreturi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDurataMedia;
        private System.Windows.Forms.Label lblPretMaxim;
        private System.Windows.Forms.Label lblPretMinim;
        private System.Windows.Forms.Label lblPretMediu;
        private System.Windows.Forms.Label lblNumarOferte;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstTopDestinatii;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTransport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPreturi;
        private System.Windows.Forms.Button btnActualizeaza;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnInchide;
    }
}