using fun12.Class;
using fun12.Schermen;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace fun12
{
    public partial class loginscherm : Form
    {
        public loginscherm()
        {
            InitializeComponent();
            this.Cursor = Cursors.Default;
        }

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

            string user = checkUsers.gebruikersnaam = textBox1.Text;
            checkUsers.gebruikersnaam = textBox1.Text;
            checkUsers.wachtwoord = textBox2.Text;

            // Controleer of de velden zijn ingevuld
            checkVeld();
            // Controleer of de ingevoerde gegevens overeen komen met de gegevens in de database
            if (checkUsers.check())
            {
                homescreen home = new homescreen(textBox1.Text);
                home.Show();
                this.Hide();
            }
            else
            {
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        /* private void button2_Click(object sender, EventArgs e)
         {
             regristreren registreer = new regristreren();
             registreer.Show();
         } */
    }
}