using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace fun12.Class
{
    internal class subproducten
    {
        public static DataTable getSubproducten(string hoofdNaam)
        {
            string con = new db().connstring;
            String cmdText = "SELECT * FROM `subproducten` WHERE `hoofdProductNr` = '" + hoofdNaam + "'";
            DataTable subProducten = new DataTable();
            try
            {
                MySqlConnection connectie = new MySqlConnection(con);
                connectie.Open(); //open the connection
                MySqlCommand cmd = new MySqlCommand(cmdText, connectie);
                MySqlDataReader reader = cmd.ExecuteReader();
                subProducten.Load(reader);
                reader.Close();
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error: " + err.ToString());
            }

            return subProducten;
        }
    }
}