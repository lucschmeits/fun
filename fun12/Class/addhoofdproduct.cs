using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace fun12.Class
{
    internal class addhoofdproduct
    {
        private string con = new db().connstring;

        private string _hoofdProductNaam;
        private string _hoofdProductOmschrijving;
        private string _hoofdProductNr;
        private string _catNr;
        private string _catNaam;

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

        public string catNr
        {
            get { return this._catNr; }
            set { this._catNr = value; }
        }

        public string catNaam
        {
            get { return this._catNaam; }
            set { this._catNaam = value; }
        }

        public void getCatNr(string catNaam)
        {
            string con = new db().connstring;
            String cmdText = "SELECT `catNummer` FROM `categorie` WHERE `catNaam` = '" + catNaam + "'";
            DataTable categorieNr = new DataTable();
            try
            {
                MySqlConnection connectie = new MySqlConnection(con);
                connectie.Open(); //open the connection
                MySqlCommand cmd = new MySqlCommand(cmdText, connectie);
                MySqlDataReader reader = cmd.ExecuteReader();

                categorieNr.Load(reader);
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error: " + err.ToString());
            }

            _catNr = categorieNr.Rows[0][0].ToString();
        }

        public void save()
        {
            String str = this.con;
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO `hoofdproducten` (`productid`, `hoofdnaam`, `hoofdomschrijving`, `catNummer`, `hoofdProductNr`) VALUES ('', '" + _hoofdProductNaam + "', '" + _hoofdProductOmschrijving + "', '" + _catNr + "', '" + _hoofdProductNr + "');";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error: " + err);
            }
        }
    }
}