using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Dochazka
{
    static class Program
    {
        
        public static Uzivatele oUzivatele;
        public static Skupiny oSkupiny;
        public static Svatky oSvatky;
        public static string sRFIDnew;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Vytvorime instanci tridy pro vytvořeni INI
            INIFiles.sINIPath = (Path.Combine(Functions.GetApplicationDataPath(), "dochazka.ini"));
            /*
            // Pripojime databazi
            DatabaseConect.Connect();

            // Inicializujeme uzivatelsky ucty
            
             */
            FormHlavni oFormHlavni = new FormHlavni();
            Application.Run(oFormHlavni);


        }
    }
}
