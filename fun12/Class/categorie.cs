using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace fun12
{
    
   public static class categorie
    {
        public static DataTable getCategory()
        {
            string con = new db().connstring;
            String cmdText = "SELECT * FROM `categorie`";
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
        public static DataTable getCatnummer(string catNaam)
        {
            string con = new db().connstring;
            String cmdText = "SELECT `catNummer` FROM `categorie` WHERE `catNaam` = '"+ catNaam +"'";
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
    

