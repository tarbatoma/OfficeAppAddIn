namespace AgentieTurism2025
{
    partial class FormOferta
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDestinatie = new System.Windows.Forms.TextBox();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.txtPerioada = new System.Windows.Forms.TextBox();
            this.txtNumarZile = new System.Windows.Forms.TextBox();
            this.cmbTransport = new System.Windows.Forms.ComboBox();
            this.btnSalveaza = new System.Windows.Forms.Button();
            this.btnAnuleaza = new System.Windows.Forms.Button();
            this.btnInchide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destinație:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Preț:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Perioada:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Număr Zile:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Transport:";
            // 
            // txtDestinatie
            // 
            this.txtDestinatie.Location = new System.Drawing.Point(100, 22);
            this.txtDestinatie.Name = "txtDestinatie";
            this.txtDestinatie.Size = new System.Drawing.Size(200, 20);
            this.txtDestinatie.TabIndex = 5;
            // 
            // txtPret
            // 
            this.txtPret.Location = new System.Drawing.Point(100, 52);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(200, 20);
            this.txtPret.TabIndex = 6;
            // 
            // txtPerioada
            // 
            this.txtPerioada.Location = new System.Drawing.Point(100, 82);
            this.txtPerioada.Name = "txtPerioada";
            this.txtPerioada.Size = new System.Drawing.Size(200, 20);
            this.txtPerioada.TabIndex = 7;
            // 
            // txtNumarZile
            // 
            this.txtNumarZile.Location = new System.Drawing.Point(100, 112);
            this.txtNumarZile.Name = "txtNumarZile";
            this.txtNumarZile.Size = new System.Drawing.Size(200, 20);
            this.txtNumarZile.TabIndex = 8;
            // 
            // cmbTransport
            // 
            this.cmbTransport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransport.FormattingEnabled = true;
            this.cmbTransport.Location = new System.Drawing.Point(100, 142);
            this.cmbTransport.Name = "cmbTransport";
            this.cmbTransport.Size = new System.Drawing.Size(200, 21);
            this.cmbTransport.TabIndex = 9;
            // 
            // btnSalveaza
            // 
            this.btnSalveaza.Location = new System.Drawing.Point(25, 185);
            this.btnSalveaza.Name = "btnSalveaza";
            this.btnSalveaza.Size = new System.Drawing.Size(85, 23);
            this.btnSalveaza.TabIndex = 10;
            this.btnSalveaza.Text = "Salvează";
            this.btnSalveaza.UseVisualStyleBackColor = true;
            this.btnSalveaza.Click += new System.EventHandler(this.btnSalveaza_Click);
            // 
            // btnAnuleaza
            // 
            this.btnAnuleaza.Location = new System.Drawing.Point(125, 185);
            this.btnAnuleaza.Name = "btnAnuleaza";
            this.btnAnuleaza.Size = new System.Drawing.Size(85, 23);
            this.btnAnuleaza.TabIndex = 11;
            this.btnAnuleaza.Text = "Anulează";
            this.btnAnuleaza.UseVisualStyleBackColor = true;
            this.btnAnuleaza.Click += new System.EventHandler(this.btnAnuleaza_Click);
            // 
            // btnInchide
            // 
            this.btnInchide.Location = new System.Drawing.Point(225, 185);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(75, 23);
            this.btnInchide.TabIndex = 12;
            this.btnInchide.Text = "Închide";
            this.btnInchide.UseVisualStyleBackColor = true;
            this.btnInchide.Click += new System.EventHandler(this.btnInchide_Click);
            // 
            // FormOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 231);
            this.Controls.Add(this.btnInchide);
            this.Controls.Add(this.btnAnuleaza);
            this.Controls.Add(this.btnSalveaza);
            this.Controls.Add(this.cmbTransport);
            this.Controls.Add(this.txtNumarZile);
            this.Controls.Add(this.txtPerioada);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.txtDestinatie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOferta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adăugare Ofertă Turistică";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDestinatie;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.TextBox txtPerioada;
        private System.Windows.Forms.TextBox txtNumarZile;
        private System.Windows.Forms.ComboBox cmbTransport;
        private System.Windows.Forms.Button btnSalveaza;
        private System.Windows.Forms.Button btnAnuleaza;
        private System.Windows.Forms.Button btnInchide;
    }
}