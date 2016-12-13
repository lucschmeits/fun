using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace fun12.Class
{
    internal class categorietoevoegen
    {
        private string con = new db().connstring;

        private string _categorieNaam;

        private string _categorieOmschrijving;

        private int _categorieNummer;

        public int categorieNummer
        {
            get { return _categorieNummer; }
            set { _categorieNummer = value; }
        }

        public string categorieNaam
        {
            get { return _categorieNaam; }
            set { _categorieNaam = value; }
        }

        public string categorieOmschrijving
        {
            get { return _categorieOmschrijving; }
            set { _categorieOmschrijving = value; }
        }

        public void save()
        {
            String str = this.con;
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO `categorie`(`catId`, `catNaam`, `CatBeschrijving`, `catNummer`) VALUES ('', '" + _categorieNaam + "', '" + _categorieOmschrijving + "', '" + _categorieNummer + "');";
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