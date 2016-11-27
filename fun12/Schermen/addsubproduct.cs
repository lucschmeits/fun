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
        public addsubproduct()
        {
            InitializeComponent();
            DataTable tb = categorie.getCategory();
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                listBox1.Items.Add(tb.Rows[i][1]);
            }
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
                    MessageBox.Show(catNummer);
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
    }
}
