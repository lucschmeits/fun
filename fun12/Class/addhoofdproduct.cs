using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace fun12.Class
{
    class addhoofdproduct
    {
        string con = new db().connstring;

        private string _hoofdProductNaam;
        private string _hoofdProductOmschrijving;
        private string _hoofdProductNr;

        public string hoofdProductNaam
        {
            get { return this._hoofdProductNaam; }
            set { this._hoofdProductNaam = value; }
        }

        public string hoofdProductOmschrijving
        {
            get { return this._hoofdProductOmschrijving; }
            set { this._hoofdProductOmschrijving = value; }
        }

        public string hoofdProductNr
        {
            get { return this._hoofdProductNr; }
            set { this._hoofdProductNr = value; }
        }

        public void save()
        {

            String str = this.con;
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO `hoofdproducten` (`productid`, `hoofdnaam`, `hoofdomschrijving`, `catNummer`, `hoofdProductNr`) VALUES ('', '" + _hoofdProductNaam + "', '" + _hoofdProductOmschrijving + "', '', '" + _hoofdProductNr + "');";
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
