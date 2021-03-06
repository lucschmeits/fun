﻿using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace fun12
{
    internal class Users
    {
        private loginscherm login = new loginscherm();

        private string con = new db().connstring;

        private string _gebruikersNaam;
        private string _wachtWoord;

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

        public bool check()
        {
            String str = this.con;
            MySqlConnection con = null;

            MySqlDataReader reader = null;
            try
            {
                con = new MySqlConnection(str);
                con.Open(); //open the connection
                String cmdText = "SELECT * FROM `login` WHERE gebruikersnaam = '" + _gebruikersNaam + "'";
                MySqlCommand cmd = new MySqlCommand(cmdText, con);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string username = reader.GetString(1);
                    string password = reader.GetString(2);

                    if (username == _gebruikersNaam && password == _wachtWoord)
                    {
                        MessageBox.Show("Gebruikersnaam en wachtwoord is juist.");

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Gebruikersnaam of wachtwoord is onjuist.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Gebruiker niet gevonden.");

                    return false;
                }
            }
            catch (MySqlException err)
            {
                MessageBox.Show("Error: " + err.ToString());
                return false;
            }
        }
    }
}