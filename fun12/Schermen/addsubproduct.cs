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
    public partial class addsubproduct : Form
    {
        private List<string> CategorieList = new List<string>();

        public addsubproduct()
        {
            InitializeComponent();
            DataTable tb = categorie.getCategory();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                CategorieList.Add(tb.Rows[i][1].ToString());
            }
            listBox1.DataSource = CategorieList;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox2.Items.Clear();
                DataTable dt = categorie.getCatnummer(listBox1.SelectedItem.ToString());
                if (dt.Rows.Count > 0)
                {
                    var catNummer = dt.Rows[0][0].ToString();
                    //MessageBox.Show(catNummer);
                    dt = hoofdproducten.getHoofdproducten(catNummer);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            listBox2.Items.Add(dt.Rows[i][1].ToString());
                        }
                    }
                }
            }
        }

        private bool check()
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Niet alle velden zijn ingevuld.");
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
        }

        private void btnToevoegenSub_Click(object sender, EventArgs e)
        {
            addsubproducten addsub = new addsubproducten();

            if (check())
            {
                addsub.getHoofdNr(listBox2.SelectedItem.ToString());
                addsub.subnaam = textBox1.Text;
                addsub.subomschrijving = richTextBox1.Text;
                addsub.save();
                cleartext();
            }
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}