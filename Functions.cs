using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Dochazka
{
    public static class Functions
    {
        public static string GetStringFromBool(bool bStatus, string sReturnTrue, string sReturnFalse)
        {
            if (bStatus)
                return sReturnTrue;
            else
                return sReturnFalse;
        }

        public static string GetStringFromBool(bool bStatus)
        {
            return GetStringFromBool(bStatus, "Ano", "Ne");
        }

        public static string GetStringFromBool(int iStatus)
        {
            return GetStringFromBool(Convert.ToBoolean(iStatus), "Ano", "Ne");
        }
        public static string GetStringFromBool(int iStatus, string sReturnTrue, string sReturnFalse)
        {
            return GetStringFromBool(Convert.ToBoolean(iStatus), sReturnTrue, sReturnFalse);
        }

        public static string GetStringFromBool(string sStatus)
        {
            return GetStringFromBool(Convert.ToBoolean(Convert.ToInt16(sStatus)), "Ano", "Ne");
        }
        public static string GetStringFromBool(string sStatus, string sReturnTrue, string sReturnFalse)
        {
            return GetStringFromBool(Convert.ToBoolean(sStatus), sReturnTrue, sReturnFalse);
        }
        //vrati z TimeSpan celkove hodiny : minuty
        public static string GetTotalHourMin(TimeSpan tsSuma)
        {
            return Convert.ToString(Math.Round(tsSuma.TotalHours,0)+ " : " + tsSuma.Minutes);
        }
        //Zaokrouhleni casu (datetime) nahoru
        public static DateTime ZaokrouhlRoundUpDt (DateTime dtRound, int iNaKolik)
        {
            TimeSpan ts;
            ts = TimeSpan.FromMinutes(iNaKolik);
            return new DateTime(((dtRound.Ticks+ts.Ticks-1)/ts.Ticks)*ts.Ticks);
        }
        // Ziskani aplikacni cesty kde by meli mit pravo zapisu vsichni uzivatele i bez Admina
        public static string GetApplicationDataPath()
        {
            return GetApplicationDataPath("ZuzaSoft Dochazka");
        }

        // Ziskani aplikacni cesty kde by meli mit pravo zapisu vsichni uzivatele i bez Admina
        public static string GetApplicationDataPath(string sFinalPath)
        {
            string sPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), sFinalPath);

            // Vytvorime cestu pokud neexistuje
            try { Directory.CreateDirectory(sPath); }
            catch { }

            return sPath;
        }

        // Ziskani aplikacni cesty k exe
        public static string GetAppPath()
        {
            return System.Windows.Forms.Application.StartupPath + "\\";
        }

        
        // Jednodussi zobrazzovani message boxu bez navratu
        public static void MsgBox(string sText, MessageBoxIcon oIcon)
        {
            MessageBox.Show(sText, Application.ProductName, MessageBoxButtons.OK, oIcon);
        }

        // Jednodussi zobrazzovani message boxu bez navratu
        public static void MsgBox(string sText)
        {
            MsgBox(sText, MessageBoxIcon.Information);
        }


        // Funkce vrati subretezec splitnutej 
        public static string GetSplitedString(string sString, string sDelim)
        {
            return GetSplitedString(sString, sDelim, 0);
        }

        public static string GetSplitedString(string sString, string sDelim, int iOrder)
        {
            try
            {
                string[] sSplit = sString.Split(new char[] { char.Parse(sDelim) });
                return sSplit[iOrder].ToString();
            }
            catch
            {
                return sString;
            }
        }
    }
}
