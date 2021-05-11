using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dochazka
{
    public partial class FormEditRFID : Form
    {
        private RFID oRfid;
        private byte[] g_pKey = new byte[6];      


        public FormEditRFID()
        {
            InitializeComponent();
        }

        private void FormEditRFID_Load(object sender, EventArgs e)
        {
            UzivRFID();
            NactiRFID();

            Registry.FormSettingLoad(this);
        }

        private void UzivRFID()
        {
            if(!FormEditace.ActiveForm.Text.Equals("Nový"))
            tbRFID.Text= Program.oUzivatele.GetCurentUser().rfid.ToString();
        }

        private void NactiRFID()
        {
           oRfid = new RFID();
           oRfid.NactenRFID += new TagHandler(oRfid_NactenRFID);
        }

        void oRfid_NactenRFID(object sender, string rfidkod)
        {
            // Nacten kod
            tbRFIDnew.Text = rfidkod;
        }

        private void FormEditRFID_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registry.FormSettingSave(this);
            oRfid.CloseConection();
            oRfid = null;
            
            
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            
            //Program.oUzivatele.GetSelectUser().rfid = tbRFIDnew.Text;
            Program.sRFIDnew=tbRFIDnew.Text;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

        }


    }
}
    
