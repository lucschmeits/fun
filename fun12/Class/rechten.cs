using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fun12.Class
{
    internal class rechten
    {
        private string con = new db().connstring;
        private string _gebruikersNaam;

        public string gebruikersnaam
        {
            get { return this._gebruikersNaam; }
            set { this._gebruikersNaam = value; }
        }

        public bool CheckRechten()
        {
            string str = this.con;
            MySqlConnection con = null;

            try
            {
                MySqlDataReader reader = null;
                con = new MySqlConnection(str);
                con.Open();
                String cmdText = "SELECT * FROM `login` WHERE `gebruikersnaam` = '" + gebruikersnaam + "'";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string username = reader.GetString(1);
                    string recht = reader.GetString(4);

                    if (username == _gebruikersNaam && recht == 1.ToString())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}