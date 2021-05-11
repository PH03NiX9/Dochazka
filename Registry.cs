using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace Dochazka
{
    class Registry
    {
        public enum FormActions { FormActionLoad = 1, FormActionSave = 2 };

        // Funkce pro najiti vsech ListView na formu. iAction=0 Save, iAction=1 Load.
        private static void IterateControl(Control.ControlCollection ctrControls, FormActions iAction, string sFormPrefix)
        {
            foreach (Control ctrControl in ctrControls)
            {
                if (ctrControl.Controls.Count > 0)
                    IterateControl(ctrControl.Controls, iAction, sFormPrefix);

                // Pokud je to listviw, prolezeme jeho columny a ulozime
                if (ctrControl.GetType().ToString() == "System.Windows.Forms.ListView")
                {
                    ListView lsvListView = (ListView)ctrControl;

                    foreach (ColumnHeader colColumn in lsvListView.Columns)
                    {
                        // Pokud se jedna o Load, tak nacteme, jinak ulozime
                        if (iAction == FormActions.FormActionLoad)
                        {
                            //MessageBox.Show(sFormPrefix + "_" + lsvListView.Name + "_column" + colColumn.Index.ToString() + " = " + regKeySize.GetValue(sFormPrefix + "_" + lsvListView.Name + "_column" + colColumn.Index.ToString(), "80"));
                            //MessageBox.Show(Convert.ToString(Convert.ToInt32(regKeySize.GetValue(sFormPrefix + "_" + lsvListView.Name + "_column" + colColumn.Index.ToString(), "80"))));
                            //colColumn.Width = Convert.ToInt32(regKeySize.GetValue(sFormPrefix + "_" + lsvListView.Name + "_column" + colColumn.Index.ToString(), "80"));
                            colColumn.Width = Convert.ToInt32(INIFiles.INI_GetSetting("Size", sFormPrefix + "_" + lsvListView.Name + "_column" + colColumn.Index.ToString(), "80"));
                        }
                        else
                        {
                            // Ukladame
                            //regKeySize.SetValue(sFormPrefix + "_" + lsvListView.Name + "_column" + colColumn.Index.ToString(), colColumn.Width.ToString());
                            INIFiles.INI_SetSetting("Size", sFormPrefix + "_" + lsvListView.Name + "_column" + colColumn.Index.ToString(), colColumn.Width.ToString());
                        }
                    }
                }
                else if (ctrControl.GetType().ToString() == "System.Windows.Forms.SplitContainer")
                {
                    // Pretypujeme objekt na spravny
                    SplitContainer scSplit = (SplitContainer)ctrControl;

                    if (iAction == FormActions.FormActionLoad)
                        scSplit.SplitterDistance = Convert.ToInt32(INIFiles.INI_GetSetting("Size", sFormPrefix + "_" + scSplit.Name + "_distance", "20"));
                    else
                        INIFiles.INI_SetSetting("Size", sFormPrefix + "_" + scSplit.Name + "_distance", scSplit.SplitterDistance.ToString());
                }

            }
        }

        // Funkce pro ukladani pozic oken
        public static void FormSettingSave(Form frmForm)
        {
            // Pokud je okno minimalizovany, tak neukladame
            if (frmForm.WindowState != FormWindowState.Minimized && frmForm.Visible)
            {
                // Ulozeni pozice okna
                INIFiles.INI_SetSetting("Size", frmForm.Name + "Top", frmForm.Top.ToString());
                INIFiles.INI_SetSetting("Size", frmForm.Name + "Left", frmForm.Left.ToString());

                if (frmForm.FormBorderStyle == FormBorderStyle.Sizable || frmForm.FormBorderStyle == FormBorderStyle.SizableToolWindow)
                {
                    INIFiles.INI_SetSetting("Size", frmForm.Name + "Width", frmForm.Width.ToString());
                    INIFiles.INI_SetSetting("Size", frmForm.Name + "Height", frmForm.Height.ToString());
                }

                IterateControl(frmForm.Controls, FormActions.FormActionSave, frmForm.Name);
            }

        }

        // Funkce pro nacteni pozic oken
        public static void FormSettingLoad(Form frmForm)
        {
            // Osetreni na zaporny hodnoty
            int iTop = int.Parse(INIFiles.INI_GetSetting("Size", frmForm.Name + "Top", "0").ToString());
            int iLeft = int.Parse(INIFiles.INI_GetSetting("Size", frmForm.Name + "Left", "0").ToString());
            if (iTop < 0) iTop = 0;
            if (iLeft < 0) iLeft = 0;

            frmForm.Top = iTop;
            frmForm.Left = iLeft;

            if ((frmForm.FormBorderStyle == FormBorderStyle.Sizable || frmForm.FormBorderStyle == FormBorderStyle.SizableToolWindow) &&
                int.Parse(INIFiles.INI_GetSetting("Size", frmForm.Name + "Width", "100").ToString()) > 0)
            {
                frmForm.Width = int.Parse(INIFiles.INI_GetSetting("Size", frmForm.Name + "Width", "300").ToString());
                frmForm.Height = int.Parse(INIFiles.INI_GetSetting("Size", frmForm.Name + "Height", "300").ToString());
            }

            // Vynutime zobrazeni okna
            Application.DoEvents();

            IterateControl(frmForm.Controls, FormActions.FormActionLoad, frmForm.Name);
        }

        // Ulozeni hodnoty do registru
        public static void UpdateKey(string sKey, string sValue)
        {
            INIFiles.INI_SetSetting("General", sKey, sValue);
        }

        // Nacteni hodnoty z registru
        public static string GetKey(string sKey, string sDefaultValue)
        {
            return INIFiles.INI_GetSetting("General", sKey, sDefaultValue);
        }

        // Overload Nacteni hodnoty z registru
        public static string GetKey(string sKey)
        {
            return GetKey(sKey, "");
        }

    }

    class INIFiles
    {
        // Deklarace API pro pristup k INI files
        [DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnString, int nSize, string lpFilename);

        [DllImport("KERNEL32.DLL", EntryPoint = "WritePrivateProfileStringW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern int WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFilename);

        // Cesta k INI souboru naplnena pri vzniku instance
        public static string sINIPath = "";

        // Zvenku viditelna funkce pro cteni z INI souboru bez specifikace vychozi hodnoty
        public static string INI_GetSetting(string sKategorie, string sKlic)
        {
            return INI_GetSetting(sKategorie, sKlic, "");
        }

        // Zvenku viditelna funkce pro cteni z INI souboru
        public static string INI_GetSetting(string sKategorie, string sKlic, string sDefault)
        {
            string sReturn = new string(' ', 1024);
            //GetPrivateProfileString(sKategorie, sKlic, sDefault, sReturn, 1024, sINIPath);
            GetPrivateProfileString(sKategorie, sKlic, "", sReturn, 1024, sINIPath);

            if (sReturn.Trim().Equals("\0"))
                return sDefault;
            else
                return sReturn.Split('\0')[0];
        }

        // Zvenku viditelna funkce pro zapis do ini souboru
        public static void INI_SetSetting(string sKategorie, string sKlic, string sHodnota)
        {
            WritePrivateProfileString(sKategorie, sKlic, sHodnota, sINIPath);
        }
    }
}
