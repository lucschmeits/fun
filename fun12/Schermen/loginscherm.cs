using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace fun12
{
    public partial class loginscherm : Form
    {
        public loginscherm()
        {
            InitializeComponent();
            this.Cursor = Cursors.Default;
            
        }
        
        homescreen home = new homescreen();

       /* public void setPictureColor()
        {
            Color kleur = Color.Green;
            pictureBox6.BackColor = kleur;

        }

        public PictureBox picturbox6()
        {
            return pictureBox6;
        }
        */
        private void checkVeld()
        {
           
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                //pictureBox6.BackColor = Color.DarkRed;
                ErrGebruikersnaam.Text = "Dit veld mag niet leeg zijn.";
            }
            else
            {
                ErrGebruikersnaam.Text = "";
               // pictureBox6.BackColor = Color.Green;
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                //pictureBox7.BackColor = Color.DarkRed;
                ErrWachtwoord.Text = "Dit veld mag niet leeg zijn.";
            }
            else
            {
                //pictureBox7.BackColor = Color.Green;
                ErrWachtwoord.Text = "";
            }
        }

       
        public PictureBox MyPictureBox
        {
            get
            {
                return pictureBox6;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //check user
            Users checkUsers = new Users();
           
            checkUsers.gebruikersnaam = textBox1.Text;
            checkUsers.wachtwoord = textBox2.Text;

            // Controleer of de velden zijn ingevuld
            checkVeld();
            // Controleer of de ingevoerde gegevens overeen komen met de gegevens in de database
            if (checkUsers.check())
            {
                home.Show();
                this.Hide();

            }else
            {

            }
            

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            regristreren registreer = new regristreren();
            registreer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addproduct product = new addproduct();
            product.Show();
        }
    }
}
