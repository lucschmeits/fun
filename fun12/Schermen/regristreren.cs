﻿using System;
using System.Windows.Forms;

namespace fun12
{
    public partial class regristreren : Form
    {
        public regristreren()
        {
            InitializeComponent();
        }

        private void checkInput()
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Alle velden moeten worden ingevuld.");
            }
        }

        private bool checkPassword()
        {
            string password = textBox2.Text;
            string passwordCheck = textBox3.Text;
            if (password != passwordCheck)
            {
                MessageBox.Show("Wachtwoorden komen niet overeen.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user newUser = new user();

            newUser.gebruikersnaam = textBox1.Text;
            newUser.wachtwoord = textBox3.Text;
            newUser.email = textBox4.Text;
            newUser.rechten = comboBox1.SelectedIndex;
            checkInput();
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text) && !String.IsNullOrEmpty(textBox4.Text) && !String.IsNullOrEmpty(comboBox1.Text))
            {
                if (checkPassword())
                {
                    newUser.save();
                    MessageBox.Show("U bent geregristreerd. U kunt vanaf nu inloggen.");
                    this.Close();
                }
            }
        }
    }
}