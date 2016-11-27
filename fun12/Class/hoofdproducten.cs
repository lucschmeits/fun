using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace fun12.Class
{
    public static class hoofdproducten
    {
        public static DataTable getHoofdproducten(string catNummer)
        {
            string con = new db().connstring;
            String cmdText = "SELECT * FROM `hoofdproducten` WHERE `catNummer` = '" + catNummer + "'";
            DataTable hoofdProducten = new DataTable();
            try
            {
                MySqlConnection connectie = new MySqlConnection(con);
                connectie.Open(); //open the connection
                MySqlCommand cmd = new MySqlCommand(cmdText, connectie);
                MySqlDataReader reader = cmd.ExecuteReader();

                hoofdProducten.Load(reader);
                reader.Close();

                //catListbox.Items.Add(reader.GetString(2));
                //MessageBox.Show(reader.GetString(1));
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error: " + err.ToString());
            }

            return hoofdProducten;
        }

        public static DataTable getHoofdProductNr(string hoofdNaam)
        {
            string con = new db().connstring;
            String cmdText = "SELECT `hoofdProductNr` FROM `hoofdproducten` WHERE `hoofdnaam` = '" + hoofdNaam + "'";
            DataTable tabel = new DataTable();
            try
            {
                MySqlConnection connectie = new MySqlConnection(con);
                connectie.Open(); //open the connection
                MySqlCommand cmd = new MySqlCommand(cmdText, connectie);
                MySqlDataReader reader = cmd.ExecuteReader();
                tabel.Load(reader);
                reader.Close();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error: " + err.ToString());
            }

            return tabel;
        }
    }
}