using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Dochazka
{
    static class DatabaseConect
    {
        public static MySqlConnection serverLink;
        public static string sLastError;

        // Pripojeni na mySQL dat.
        public static void Connect()
        {
            try
            {
                serverLink = new MySqlConnection("datasource=" + Parametry.mysqlserver + ";username=" + Parametry.mysqluser + ";password=" + Parametry.mysqlpassword + ";database=" + Parametry.mysqldatabase + ";");
                serverLink.Open();
            }
            catch
            {
                throw new Exception("Neplatna databaze.");
            }

        }
        // 
        public static MySqlDataReader GetRS(string sSQL)
        {
            MySqlCommand aCommand = new MySqlCommand(sSQL, serverLink);
            return aCommand.ExecuteReader();
        }


        public static string GetSimpleField(string sSQL)
        {
            MySqlCommand aCommand = new MySqlCommand(sSQL, serverLink);

            string sReturn = "";
            try
            {
                sReturn = aCommand.ExecuteScalar().ToString();
            }
            catch { }

            return sReturn;
        }

        //Vykonej 
        public static int Execute(string sSQL)
        {
            MySqlCommand aCommand = new MySqlCommand(sSQL, serverLink);
            return aCommand.ExecuteNonQuery();
        }

        // Zjisteni posledniho pridaneho ID
        public static string GetLastID()
        {
            MySqlCommand aCommand = new MySqlCommand("SELECT LAST_INSERT_ID() AS id ", serverLink);
            return aCommand.ExecuteScalar().ToString();
        } 
    }
}
