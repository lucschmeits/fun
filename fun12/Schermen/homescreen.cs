using fun12.Class;
using fun12.Schermen;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace fun12
{
    public partial class homescreen : Form
    {
        private List<string> CategorieList = new List<string>();

        public homescreen(string username)
        {
            InitializeComponent();

            DataTable tb = categorie.getCategory();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                CategorieList.Add(tb.Rows[i][1].ToString());
            }
            catListbox.DataSource = CategorieList;
            string user = username;
            rechten recht = new rechten();
            recht.gebruikersnaam = user;
            if (recht.CheckRechten())
            {
                button2.Show();
                button4.Show();
            }
            else
            {
                button2.Hide();
                button4.Hide();
            }
        }

        private void vulCategory()
        {
            CategorieList.Clear();
            hoofdListbox.Items.Clear();
            subListbox.Items.Clear();
            DataTable tb = categorie.getCategory();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                CategorieList.Add(tb.Rows[i][1].ToString());
            }
            catListbox.DataSource = CategorieList;
        }

        private void catListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (catListbox.SelectedIndex != -1)
            {
                hoofdListbox.Items.Clear();
                subListbox.Items.Clear();
                DataTable dt = categorie.getCatnummer(catListbox.SelectedItem.ToString());
                if (dt.Rows.Count > 0)
                {
                    var catNummer = dt.Rows[0][0].ToString();
                    // MessageBox.Show(catNummer);
                    dt = hoofdproducten.getHoofdproducten(catNummer);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            hoofdListbox.Items.Add(dt.Rows[i][1].ToString());
                        }
                    }
                }
            }
        }

        private void subListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void hoofdListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hoofdListbox.SelectedIndex != -1)
            {
                subListbox.Items.Clear();
                DataTable hoofdPr = hoofdproducten.getHoofdProductNr(hoofdListbox.SelectedItem.ToString());
                if (hoofdPr.Rows.Count > 0)
                {
                    var hoofdNaam = hoofdPr.Rows[0][0].ToString();
                    // MessageBox.Show(hoofdNaam);
                    hoofdPr = subproducten.getSubproducten(hoofdNaam);
                    if (hoofdPr.Rows.Count > 0)
                    {
                        for (int i = 0; i < hoofdPr.Rows.Count; i++)
                        {
                            subListbox.Items.Add(hoofdPr.Rows[i][1].ToString() + " " + hoofdPr.Rows[i][2].ToString());
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vulCategory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addcategorie cat = new addcategorie();
            cat.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            regristreren registreer = new regristreren();
            registreer.Show();
        }

        private void btnUitloggen_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void homescreen_Load(object sender, EventArgs e)
        {
        }
    }
}