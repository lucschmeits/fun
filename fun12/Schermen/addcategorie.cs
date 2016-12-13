using fun12.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fun12.Schermen
{
    public partial class addcategorie : Form
    {
        public addcategorie()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addproduct hoofd = new addproduct();
            hoofd.Show();
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

        private void clear()
        {
            textBox1.Text = "";
            richTextBox1.Text = "";
            textBox2.Text = "";
        }

        private void btnToevoegen_Click(object sender, EventArgs e)
        {
            categorietoevoegen addcat = new categorietoevoegen();

            if (check())
            {
                addcat.categorieNaam = textBox1.Text;
                addcat.categorieOmschrijving = richTextBox1.Text;
                addcat.categorieNummer = Convert.ToInt32(textBox2.Text);
                addcat.save();
                clear();
            }
        }
    }
}