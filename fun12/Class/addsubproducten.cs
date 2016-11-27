using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fun12.Class
{
    class addsubproducten
    {
        string con = new db().connstring;

        private string _subnaam;
        private string _subomschrijving;
        private string _hoofdProductNr;
        private string _hoofdNaam;

        public string subnaam
        {
            get { return this._subnaam; }
            set { this._subnaam = value; }
        }

        public string subomschrijving
        {
            get { return this._subomschrijving; }
            set { this._subomschrijving = value; }
        }

        public string hoofdProductNr
        {
            get { return this._hoofdProductNr; }
            set { this._hoofdProductNr = value; }
        }

        public string hoofdNaam
        {
            get { return this._hoofdNaam; }
            set { this._hoofdNaam = value; }
        }


        public void getHoofdNr(string hoofdNaam)
        {
            String cmdText = "SELECT `hoofdProductNr` FROM `hoofdproducten` WHERE `hoofdnaam` = '" + hoofdNaam + "'";
            DataTable dt = new DataTable();
            try
            {
                MySqlConnection connectie = new MySqlConnection(con);
                connectie.Open(); //open the connection
                MySqlCommand cmd = new MySqlCommand(cmdText, connectie);
                MySqlDataReader reader = cmd.ExecuteReader();

                dt.Load(reader);


            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error: " + err.ToString());
            }


            _hoofdProductNr = dt.Rows[0][0].ToString();
        }

        public void save()
        {
            String str = this.con;
            MySqlConnection con = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "INSERT INTO `subproducten`(`subproductid`, `subnaam`, `subomschrijving`, `hoofdProductNr`) VALUES ('', '" + _subnaam + "', '" + _subomschrijving + "', '" + _hoofdProductNr + "');";
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
