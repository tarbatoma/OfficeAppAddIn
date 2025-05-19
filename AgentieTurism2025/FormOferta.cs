using AgentieTurism2025;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgentieTurism2025
{
    public partial class FormOferta : Form
    {
        private dateDataSetTableAdapters.Sheet1TableAdapter oferteAdapter;
        private dateDataSet.Sheet1DataTable oferteTable;

        public FormOferta()
        {
            InitializeComponent();

            // Inițializare adaptor pentru baza de date
            oferteAdapter = new dateDataSetTableAdapters.Sheet1TableAdapter();
            oferteTable = new dateDataSet.Sheet1DataTable();

            // Populare inițială a datelor
            oferteAdapter.Fill(oferteTable);

            // Populare ComboBox pentru transport
            cmbTransport.Items.Add("Avion");
            cmbTransport.Items.Add("Autocar");
            cmbTransport.Items.Add("Tren");
            cmbTransport.Items.Add("Individual");
            cmbTransport.SelectedIndex = 0;
        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            try
            {
                // Validare date
                if (string.IsNullOrEmpty(txtDestinatie.Text))
                {
                    MessageBox.Show("Destinația este obligatorie!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtPret.Text, out decimal pret) || pret <= 0)
                {
                    MessageBox.Show("Prețul trebuie să fie un număr pozitiv!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtNumarZile.Text, out int numarZile) || numarZile <= 0)
                {
                    MessageBox.Show("Numărul de zile trebuie să fie un număr întreg pozitiv!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Creează un nou rând în tabel
                dateDataSet.Sheet1Row newRow = oferteTable.NewSheet1Row();
                newRow.Destinatie = txtDestinatie.Text;
                newRow.Pret = (double)decimal.Parse(txtPret.Text);
                newRow.Perioada = txtPerioada.Text;
                newRow.NumarZile = int.Parse(txtNumarZile.Text);
                newRow.Transport = cmbTransport.SelectedItem.ToString();

                // Adaugă rândul la tabel
                oferteTable.Rows.Add(newRow);
                // Actualizează baza de date
                oferteAdapter.Update(oferteTable);

                MessageBox.Show("Oferta a fost salvată cu succes!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Curăță câmpurile
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare la salvare: {ex.Message}", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtDestinatie.Text = string.Empty;
            txtPret.Text = string.Empty;
            txtPerioada.Text = string.Empty;
            txtNumarZile.Text = string.Empty;
            cmbTransport.SelectedIndex = 0;
        }

        private void btnAnuleaza_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnInchide_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
