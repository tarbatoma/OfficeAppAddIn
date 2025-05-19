namespace AgentieTurism2025
{
    partial class FormSelectieOferta
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
            this.lvOferte = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelecteaza = new System.Windows.Forms.Button();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selectați oferta pentru care doriți să generați documentul:";
            // 
            // lvOferte
            // 
            this.lvOferte.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvOferte.FullRowSelect = true;
            this.lvOferte.GridLines = true;
            this.lvOferte.HideSelection = false;
            this.lvOferte.Location = new System.Drawing.Point(12, 34);
            this.lvOferte.MultiSelect = false;
            this.lvOferte.Name = "lvOferte";
            this.lvOferte.Size = new System.Drawing.Size(640, 266);
            this.lvOferte.TabIndex = 1;
            this.lvOferte.UseCompatibleStateImageBehavior = false;
            this.lvOferte.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Destinație";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Preț";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Perioada";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Număr Zile";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Transport";
            this.columnHeader6.Width = 130;
            // 
            // btnSelecteaza
            // 
            this.btnSelecteaza.Location = new System.Drawing.Point(200, 315);
            this.btnSelecteaza.Name = "btnSelecteaza";
            this.btnSelecteaza.Size = new System.Drawing.Size(120, 30);
            this.btnSelecteaza.TabIndex = 2;
            this.btnSelecteaza.Text = "Selectează";
            this.btnSelecteaza.UseVisualStyleBackColor = true;
            this.btnSelecteaza.Click += new System.EventHandler(this.btnSelecteaza_Click);
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Location = new System.Drawing.Point(340, 315);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(120, 30);
            this.btnAnuleaza.TabIndex = 3;
            this.btnAnuleaza.Text = "Anulează";
            this.btnAnuleaza.UseVisualStyleBackColor = true;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
            // 
            // FormSelectieOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 361);
            this.Controls.Add(this.btnAnuleaza);
            this.Controls.Add(this.btnSelecteaza);
            this.Controls.Add(this.lvOferte);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectieOferta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selectare Ofertă Turistică";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvOferte;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnSelecteaza;
        private System.Windows.Forms.Button btnAnuleaza;
    }
}