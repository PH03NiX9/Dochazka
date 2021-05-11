using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dochazka
{
    //Delegat
    public delegate void TagHandler(object sender, string rfidKod);
    
    class RFID
    {
        private int g_rHandle, g_retCode;
        private byte g_Sec, g_SID;
        private byte[] g_pKey = new byte[6];
        //private bool g_isConnected = false;
        private bool pHaveTag = false;
        private string s_rfidTag;
        
        private Timer oTimer;
        private string _lastError = "";

        public bool isConnected = false;

        // Nacteny kod z ctecky
        private string _nactenyTag;

        public event TagHandler NactenRFID;

        protected virtual void EventNactenRFID(string e)
        {
            if (NactenRFID != null)
                NactenRFID(this, e);

        }
        
        // Konstruktor
        public RFID()
        {
            this.oTimer = new Timer();
            this.oTimer.Interval = 1000;
            
            this.oTimer.Tick += new EventHandler(oTimer_Tick);

            if (ConnectRFID())
            {
                this.oTimer.Enabled = true;
            }
            else
            {
                Functions.MsgBox(this._lastError);
            }
            
        }
        
        // Destruktor
        protected void Dispose()
		{
			if (this.isConnected) 
			{
                ACR120.ACR120_Close(g_rHandle);
			}
		} 

            

        void oTimer_Tick(object sender, EventArgs e)
        {
            // Zkontroluje se pripojenost
            if (this.isConnected)
            {
                string sData = ListTagRFID();
                //if (!sData.Equals(""))
                //{
                    _nactenyTag = sData;
                    EventNactenRFID(_nactenyTag);
                //}
                //else
                //{ 
                
                //}
            }

        }
       
        
        public bool ConnectRFID()//port:COM1, baudRate:9600
        {
            //=====================================================================
            // This function opens the port(connection) to ACR120 reader
            // using BaudRate specified.
            //=====================================================================

            if (this.isConnected)
            {
                this._lastError = "Device is already connected.";
                return false;
            }
            int iPort = int.Parse(Registry.GetKey("ComPort", "COM1").Substring(3));
            g_rHandle = ACR120.ACR120_Open(iPort-1, ACR120.ACR120_COM_BAUDRATE_9600);
            if (g_rHandle != 0)
            {
                this._lastError = "[X] " + ACR120.GetErrMsg(g_rHandle);
            }
            else
            {
                //Functions.MsgBox("Connected to COM" + String.Format("{0}", 1));
                //g_isConnected = true;
                this.isConnected = true;
                // set Station ID =  1 this is factory default
                g_SID = 1;
            }

            return this.isConnected;
        }

        public string ListTagRFID()
        {
            //=====================================================================
            // This function list the serial number of all tags within the
            // readable antenna range
            //=====================================================================
            
            //Variable Declarations
            byte[] Tag = new byte[50];
            byte TagFound = 0;
            byte[] SN = new byte[255];
            int ctr, ctr1, indx, ctr2;
            string snstr;

            g_retCode = ACR120.ACR120_ListTag(g_rHandle, g_SID, ref TagFound, ref pHaveTag, ref Tag[0], ref SN[0]);
            if (g_retCode != 0)
            {
                this._lastError="[X] " + ACR120.GetErrMsg(g_retCode);
                return "";
            }
            else
            {

                //Functions.MsgBox("List Tag Success: " + String.Format("{0}", g_retCode));
                //Functions.MsgBox("Tag Found: " + String.Format("{0}", TagFound));
                indx = 0;
                ctr2 = 0;
                snstr = "";
                // Parse the serial number array
                for (ctr1 = 0; ctr1 < TagFound; ctr1++)
                {
                    if (pHaveTag)
                    {

                        if ((Tag[ctr1] == 4) || (Tag[ctr1] == 5))
                        {
                            snstr = "";
                            for (ctr = indx; ctr < 7; ctr++)
                            {
                                snstr = snstr + string.Format("{0:X2} ", SN[ctr]);
                                indx++;
                            }
                        }
                        else
                        {
                            snstr = "";
                            for (ctr = indx; ctr < 4; ctr++)
                            {
                                snstr = snstr + string.Format("{0:X2} ", SN[ctr]);
                                indx++;
                            }
                        }

                    }
                    else
                    {
                        snstr = "";
                        for (ctr = indx; ctr < Tag[ctr1] + ctr2; ctr++)
                        {
                            snstr = snstr + string.Format("{0:X2} ", SN[ctr]);
                            indx++;
                        }
                        return snstr;
                    }
                    //Functions.MsgBox("Tag(" + string.Format("{0}", ctr1) + ") : " + snstr);
                    ctr2 = indx;
                    return snstr;

                }
                return "";
            }
        }

        public void CloseConection()
        {
            ACR120.ACR120_Close(g_rHandle);
        }

        
   
    
    }

}
