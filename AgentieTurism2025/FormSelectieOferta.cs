using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AgentieTurism2025
{
    public partial class FormSelectieOferta : Form
    {
        private dateDataSet.Sheet1DataTable oferteTable;
        public int IdOfertaSelectata { get; private set; }

        public FormSelectieOferta(dateDataSet.Sheet1DataTable oferteTable)
        {
            InitializeComponent();
            this.oferteTable = oferteTable;

            // Populează lista cu oferte
            foreach (dateDataSet.Sheet1Row oferta in oferteTable)
            {
                ListViewItem item = new ListViewItem(oferta.ID1.ToString());
                item.SubItems.Add(oferta.Destinatie);
                item.SubItems.Add(oferta.Pret.ToString("C"));
                item.SubItems.Add(oferta.Perioada);
                item.SubItems.Add(oferta.NumarZile.ToString());
                item.SubItems.Add(oferta.Transport);
                item.Tag = oferta.ID1;

                lvOferte.Items.Add(item);
            }
        }

        private void btnSelecteaza_Click(object sender, EventArgs e)
        {
            if (lvOferte.SelectedItems.Count > 0)
            {
                IdOfertaSelectata = (int)lvOferte.SelectedItems[0].Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vă rugăm să selectați o ofertă!", "Atenție", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}