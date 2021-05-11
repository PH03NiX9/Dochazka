using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Dochazka
{
    public partial class FormHlavni : Form
    {
        public FormHlavni()
        {
            InitializeComponent();
        }

        private void FormHlavni_Load(object sender, EventArgs e)
        {
            //Login-přihlášeni do systemu 
            FormLogin oFormLogin = new FormLogin();
            oFormLogin.ShowDialog();
            try
            {
                if (Program.oUzivatele.GetIsUserValid())
                {
                    // Poloha okna a ovladacu
                    Registry.FormSettingLoad(this);
                    //Naplni comboboxy
                    NaplnComboBoxy();
                    //Resi Opravneni
                    if (Program.oUzivatele.GetCurentUser().opravneni.Equals("1"))
                    {
                        BezPrav();
                    }
                    //Nacteme zamestnance do lvZamestnance
                    NactiLvZamestnanci();
                    NactiLvDochazka();
                    //Vypise pocet zamestnancu
                    toolStripStatusLabelZamestnanci.Text = "Počet zaměstnanců: " + lvZamestnanci.Items.Count;


                }
                else
                    this.Close();
            }
            catch { this.Close(); }
        }

        private void mnuKonec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void lvZamestnanci_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            if (e.IsSelected)
                Program.oUzivatele.VyberUzivatele(lvZamestnanci.FocusedItem.Tag.ToString());
                //Functions.MsgBox(Program.oUzivatele.VyberUzivatele(lvZamestnanci.FocusedItem.Tag.ToString()).GetSelectUser().jmeno);
            //Naplni lvDochazka
            NactiLvDochazka();

        }
        
        private void BezPrav()
        {
            //Zamestnanci
            mnuNovy.Enabled = false;
            mnuEdit.Enabled=false;
            mnuOdstranit.Enabled = false;
            //Dochazka
            mnuEditDochazky.Enabled = false;
        }

        private void NaplnComboBoxy()
        {
            //Naplni combo mesic
            for (int i = 1; i <= 12; i++)
            { 
                tsCombMesic.Items.Add(i);
            }
            //naplni combo rok
            for(int a=2010; a <=2020; a++)
            {
                tsCombRok.Items.Add(a);
            }

            tsCombMesic.SelectedIndex = DateTime.Now.Month-1;
            tsCombRok.Text = Convert.ToString(DateTime.Now.Year);

        }

        private void ZobrazEdit(string FormName)
        {
            FormEditace oFormEdit = new FormEditace();
            oFormEdit.Text = FormName;
            oFormEdit.ShowDialog();
            //Znovu načte lvZamestnance po editaci
            NactiLvZamestnanci();
        }

        private void ZobrazEditDochazka(string iId)
        {
            FormEditDochazka oFormEdit = new FormEditDochazka();
            if (iId.Equals("0"))
            {
                oFormEdit.Name = "Nový záznam";
            }
            Program.oUzivatele.SetPohyb(this.tsCombRok.Text, this.tsCombMesic.Text, iId); 
            oFormEdit.ShowDialog();
            //Znovu načte lvDochazka po editaci
            NactiLvDochazka();
        }

        private void SmazatPohyb(string sId)
        {
            //Potvrzeni smazani
            DialogResult dlgRes;
            Pohyb oPohyb = new Pohyb();
            dlgRes=MessageBox.Show("Opravdu chcete smazat záznam: "
                + Program.oUzivatele.SetPohyb(this.tsCombRok.Text, this.tsCombMesic.Text, sId).GetCurentPohyb().typ_popis
                +" "+Program.oUzivatele.SetPohyb(this.tsCombRok.Text, this.tsCombMesic.Text, sId).GetCurentPohyb().datum, 
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgRes == DialogResult.Yes)
            { 
                oPohyb.OdsranPohyb(sId);
                NactiLvDochazka();
            }
        }

        private void SmazatUzivatele()
        {
            //Potvrzeni smazani
            DialogResult dlgRes;
            if (Program.oUzivatele.VyberUzivatele(lvZamestnanci.FocusedItem.Tag.ToString()).GetSelectUser().login.Equals("admin"))
                Functions.MsgBox("Nelze odstranit systémový účet administrátora");
            else
            {
                dlgRes = MessageBox.Show("Opravdu chcete smazat: "
                    + Program.oUzivatele.VyberUzivatele(lvZamestnanci.FocusedItem.Tag.ToString()).GetSelectUser().jmeno
                    + " " + Program.oUzivatele.VyberUzivatele(lvZamestnanci.FocusedItem.Tag.ToString()).GetSelectUser().prijmeni,
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlgRes == DialogResult.Yes)
                {
                    //smaze zaznam podle id
                    Program.oUzivatele.SmazUzivatele(lvZamestnanci.FocusedItem.Tag.ToString());
                    //Znovu načte lvZamestnance po editaci
                    NactiLvZamestnanci();
                }
            }
        }

        private void NactiLvDochazka()
        {
            Pohyby oDochazka = new Pohyby(Program.oUzivatele, tsCombRok.Text,tsCombMesic.Text);
            oDochazka.FillListview(lvDochazka);
            lbSumaHodin.Text = ((oDochazka.GetSumaHodin()).ToString());// Convert.ToDateTime(TimeSpan.ParseExact( oDochazka.GetSumaHodin()).Hours.ToString).ToString("HH:mm");
            lbLekar.Text = Convert.ToString(Convert.ToDateTime(oDochazka.GetSumaLekar()).ToString("HH:mm"));
            lbDovolena.Text = oDochazka.GetSumaDovolena();
            lbNemoc.Text = oDochazka.GetSumaNemoc();
            lbOCR.Text = oDochazka.GetSumaOCR();
            lbVikend.Text = oDochazka.GetSumaVikendy();
            lbSvatky.Text = oDochazka.GetSumaSvatky();

        }

        private void NactiLvZamestnanci()
        {
            Program.oUzivatele.FillLvZamestnanci(lvZamestnanci);
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            ZobrazEdit("Editace");
        }

        private void lvZamestnanci_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter && lvZamestnanci.Items.Count>0)
                ZobrazEdit("Editace");

        }   

        private void mnuNovy_Click(object sender, EventArgs e)
        {
            ZobrazEdit("Nový");
        }

        private void mnuOdstranit_Click(object sender, EventArgs e)
        {
           SmazatUzivatele();
        }

        private void tsCombRok_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tsCombRok.Items.Count>0 && lvZamestnanci.Items.Count>0)
            NactiLvDochazka();
            //Dochazka oDochazka = new Dochazka(Program.oUzivatele, tsCombRok.Text);
            //oDochazka.FillListview(lvDochazka); 
        }

        private void mnuEditDochazky_Click(object sender, EventArgs e)
        {
            try
            {
                ZobrazEditDochazka(lvDochazka.FocusedItem.Tag.ToString());
            }
            catch
            { }
        }

        private void mnuNovyDochazka_Click(object sender, EventArgs e)
        {
            ZobrazEditDochazka("0");
        }

        private void mnuOdstranitDochazka_Click(object sender, EventArgs e)
        {
            try
            {
                SmazatPohyb(lvDochazka.FocusedItem.Tag.ToString());
            }
            catch { }
        }

        private void lvDochazka_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && lvDochazka.Items.Count > 0)
                ZobrazEditDochazka(lvDochazka.FocusedItem.Tag.ToString());
        }

        private void lvDochazka_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ZobrazEditDochazka(lvDochazka.FocusedItem.Tag.ToString());
        }

        private void lvZamestnanci_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ZobrazEdit("Editace");
        }

        private void lvDochazka_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mnuSkupiny_Click(object sender, EventArgs e)
        {
             FormGroup oFormSkupiny = new FormGroup();
            oFormSkupiny.ShowDialog();
        }

        private void mnuNastaveni_Click(object sender, EventArgs e)
        {
            FormNastaveni oFormNastaveni = new FormNastaveni();
            oFormNastaveni.ShowDialog();
        }

        private void FormHlavni_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registry.FormSettingSave(this);
        }

        private void tsCombMesic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsCombMesic.Items.Count > 0 && lvZamestnanci.Items.Count > 0)
                NactiLvDochazka();
        }

        private void mnuTisk_Click(object sender, EventArgs e)
        {
            Tisk oTisk = new Tisk();
            
            //otevrit sestavu
            ProcessStartInfo psiStart = new ProcessStartInfo(oTisk.Tiskni(this));
            Process.Start(psiStart);
        }

        private void lvZamestnanci_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete && lvZamestnanci.Items.Count>0)
                SmazatUzivatele();
            
        }

        private void lvDochazka_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Delete && lvDochazka.Items.Count>0)
                SmazatPohyb(lvDochazka.FocusedItem.Tag.ToString());
     
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            Functions.MsgBox("Docházkový systém v.1.  Autor: Martin Zůza");
        }

        private void mnuSvatky_Click(object sender, EventArgs e)
        {
            FormSvat oFormSvatky = new FormSvat();
            oFormSvatky.ShowDialog();
        }

     



        

        

       
    }
}

