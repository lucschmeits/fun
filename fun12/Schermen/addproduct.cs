﻿using fun12.Schermen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}