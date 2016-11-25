using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace fun12.Class
{
    class subproducten
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
