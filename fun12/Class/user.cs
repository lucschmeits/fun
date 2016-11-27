using MySql.Data.MySqlClient;
using System;

namespace fun12
{
    internal class user
    {
        private string con = new db().connstring;

        private string _gebruikersNaam;
        private string _wachtWoord;
        private string _email;

        public string gebruikersnaam
        {
            get { return this._gebruikersNaam; }
            set { this._gebruikersNaam = value; }
        }

        public string wachtwoord
        {
            get { return this._wachtWoord; }
            set { this._wachtWoord = value; }
        }

        public string email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public void save()
        {
            /* System.Windows.Forms.MessageBox.Show(_gebruikersNaam + _wachtWoord + _email); */
            String str = this.con;
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO `login` (`gebruikersid`, `gebruikersnaam`, `wachtwoord`, `email`) VALUES ('', '" + _gebruikersNaam + "', '" + _wachtWoord + "', '" + _email + "');";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + err.ToString());
            }
        }
    }
}