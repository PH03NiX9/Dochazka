using System;
using System.Collections.Generic;
using System.Text;

namespace Dochazka
{
    static class Parametry
    {
        public static string mysqlserver = "localhost";
        public static string mysqluser = "dochazka";
        public static string mysqlpassword = "dochazka";
        public static string mysqldatabase = "dochazka";

        public static void UlozNastaveniSQL(string sServer,string sDatabaze,string sJmenoData,string sHesloData)
        {
            Registry.UpdateKey("MySQLServer", sServer);
            mysqlserver = sServer;
            Registry.UpdateKey("MySQLDatabaze", sDatabaze);
            mysqldatabase = sDatabaze;
            Registry.UpdateKey("MySQLJmeno", sJmenoData);
            mysqluser = sJmenoData;
            Registry.UpdateKey("MySQLHeslo", sHesloData);
            mysqlpassword = sHesloData;
        
        }

    }
}
