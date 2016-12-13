using fun12.Class;
using fun12.Schermen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace fun12
{
    public partial class addproduct : Form
    {
        private List<string> CategorieList = new List<string>();

        public addproduct()
        {
            InitializeComponent();
            DataTable tb = categorie.getCategory();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                CategorieList.Add(tb.Rows[i][1].ToString());
            }
            listBox1.DataSource = CategorieList;
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

            if (check())
            {
                addhoofd.getCatNr(listBox1.SelectedItem.ToString());
                addhoofd.hoofdProductNaam = textBox1.Text;
                addhoofd.hoofdProductOmschrijving = richTextBox1.Text;
                addhoofd.hoofdProductNr = textBox2.Text;
                addhoofd.save();
                cleartext();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}