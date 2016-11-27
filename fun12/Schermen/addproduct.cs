using fun12.Class;
using fun12.Schermen;
using System;
using System.Data;
using System.Windows.Forms;

namespace fun12
{
    public partial class addproduct : Form
    {
        public addproduct()
        {
            InitializeComponent();
            DataTable tb = categorie.getCategory();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                listBox1.Items.Add(tb.Rows[i][1]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addsubproduct sub = new addsubproduct();
            sub.Show();
        }

        private bool check()
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(richTextBox1.Text) || String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Alle velden moeten worden ingevuld.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cleartext()
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            textBox2.Text = "";
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            addhoofdproduct addhoofd = new addhoofdproduct();

            addhoofd.getCatNr(listBox1.SelectedItem.ToString());
            addhoofd.hoofdProductNaam = textBox1.Text;
            addhoofd.hoofdProductOmschrijving = richTextBox1.Text;
            addhoofd.hoofdProductNr = textBox2.Text;
            if (check())
            {
                addhoofd.save();
                cleartext();
            }
        }
    }
}