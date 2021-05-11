using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Dochazka
{
    public partial class FormEditace : Form
    {
        public FormEditace()
        {
            InitializeComponent();
        }
        
        private void FormEditace_Load(object sender, EventArgs e)
        {
            //Naplnit comboboxOpravneni
            NaplnCmbOpravneni();
            NaplnCmdGroup();
            NaplnLvSkupiny();
            Registry.FormSettingLoad(this);
            // Editace/Novy
            if (this.Text.Equals("Editace"))
            {
                tbLogin.Enabled = false;
                NactiUzivatele();
                Opravneni();
            }
            else
            { 
            
            }
            
        }
        private void NactiUzivatele ()
        { 
            Uzivatel oUzivatel = Program.oUzivatele.GetSelectUser();
            tbJmeno.Text = oUzivatel.jmeno;
            tbPrijmeni.Text = oUzivatel.prijmeni;
            tbLogin.Text = oUzivatel.login;
            tbHeslo.Text = oUzivatel.heslo;
            tbRFID.Text = oUzivatel.rfid;
            numUpDownDovolena.Value = int.Parse(oUzivatel.dovolena);
            string sBool;
            sBool = Functions.GetStringFromBool(int.Parse((Program.oUzivatele.GetSelectUser().aktivni)), "True", "False");
            cbxAktivni.Checked = bool.Parse(sBool);
            cmbOpravneni.SelectedIndex = int.Parse(Program.oUzivatele.GetSelectUser().opravneni)-1;
            //int index = cmbGroup.FindString(Program.oSkupiny.VyberSkupinu(Program.oUzivatele.GetSelectUser().id_skupiny).GetSelectGroup().popis);
            //cmbGroup.SelectedIndex = index;
            cmbGroup.SelectedValue = int.Parse(Program.oUzivatele.GetSelectUser().id_skupiny);
            //cmbGroup.SelectedIndex = int.Parse(Program.oUzivatele.GetSelectUser().id_skupiny) - 1;
        }

        private void Opravneni()
        {
            if (Program.oUzivatele.GetCurentUser().opravneni.Equals("3"))
            {
                cbxAktivni.Enabled = true;
                cmbOpravneni.Enabled = true;
                cmdRFID.Enabled = true;
            }
            else if (Program.oUzivatele.GetCurentUser().id.Equals(Program.oUzivatele.GetSelectUser().id))
            {
                cbxAktivni.Enabled = false;
                cmbOpravneni.Enabled = false;
                cmdRFID.Enabled = false;
                cmbGroup.Enabled = false;
                lvSkupiny.Enabled = false;
            }
            else if (Program.oUzivatele.GetSelectUser().opravneni.Equals("1"))
            {
                cmbOpravneni.Enabled = false;
                lvSkupiny.Enabled = false;
            }
        }

 
        private void NaplnCmbOpravneni()
        {
            //cmbOpravneni.Items.Add("0 - bez oprávnění");
            //cmbOpravneni.ValueMember = "0";
            
            cmbOpravneni.Items.Add("1 - pouze čtení");
            
            cmbOpravneni.Items.Add("2 - editace");
           
            cmbOpravneni.Items.Add("3 - oprávnění");
            
            cmbOpravneni.SelectedIndex = 0;
        }
        private void NaplnLvSkupiny()
        {
            new Zamestnanci_skupiny().FillListview(lvSkupiny);
        }

        private void KontrolaPolozek(object sender, CancelEventArgs e)
        {         
            if (sender.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox tbTextBox = (TextBox)sender;
                if (tbTextBox.Text.Trim().Equals(""))
                {
                    Functions.MsgBox("Pole musí být zadán!", MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                    
                }
            }

            
        }

        private void NaplnCmdGroup()
        {
            // Nacteme z databaze tabulku pohybu do comboboxu
            MySqlDataAdapter oAdapter = new MySqlDataAdapter("SELECT id, popis FROM skupiny ", DatabaseConect.serverLink);
            DataSet oDataset = new DataSet();

            oAdapter.Fill(oDataset, "skupiny");

            cmbGroup.DataSource = oDataset.Tables["skupiny"].DefaultView;
            cmbGroup.DisplayMember = "popis";
            cmbGroup.ValueMember = "id";
            cmbGroup.Tag = "id";
        
        }

      private void cmdOK_Click(object sender, EventArgs e)
        {

            foreach (Control oControl in this.Controls)
            {
                if (oControl.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    if (oControl.Text.Trim().Equals(""))
                    {
                        Functions.MsgBox("Všechna pole musí být zadána!", MessageBoxIcon.Exclamation);
                        return;

                    }

                }

            }
            if ((!this.Text.Equals("Editace")))
            {
                if (Program.oUzivatele.ExistujeLogin(tbLogin.Text))
                {
                    Functions.MsgBox("Zadaný login již existuje!");
                    return;
                }

                if (Program.oUzivatele.ExistujeRFID(tbRFID.Text))
                {
                    Functions.MsgBox("RFID karta je již přiřazena!");
                    return;
                }
            }
          //Vytvoříme objekt Uzivatel a nahrneme editovana data
         Uzivatel oUzivatelUloz= new Uzivatel();
          if (this.Text.Equals("Editace"))
              oUzivatelUloz.id=Program.oUzivatele.GetSelectUser().id;
          else //zjistime posledni id pro nový záznam
            {  
              //Functions.MsgBox(DatabaseConect.GetLastID());
              oUzivatelUloz.id ="001";
            }

          oUzivatelUloz.jmeno=tbJmeno.Text;
          oUzivatelUloz.prijmeni=tbPrijmeni.Text;
          oUzivatelUloz.login=tbLogin.Text;
          oUzivatelUloz.heslo=tbHeslo.Text;
          oUzivatelUloz.id_skupiny = (cmbGroup.SelectedValue).ToString();//SelectedValue.ToString();
          oUzivatelUloz.opravneni=(cmbOpravneni.SelectedIndex+1).ToString();
          oUzivatelUloz.aktivni=Functions.GetStringFromBool(cbxAktivni.Checked.ToString(),"1","0");
          oUzivatelUloz.dovolena = numUpDownDovolena.Value.ToString();
          oUzivatelUloz.rfid=tbRFID.Text;
          Program.oUzivatele.UlozUzivatele(oUzivatelUloz);
          new Zamestnanci_skupiny().UlozZamestnance_skupinu(lvSkupiny);
          this.Close();
        }

      private void cmdRFID_Click(object sender, EventArgs e)
      {
          FormEditRFID oFormEditRFID = new FormEditRFID();
          oFormEditRFID.ShowDialog();
          if (this.Text.Equals("Editace"))
          {
              //znovu nacte edit
              NactiUzivatele();
              tbRFID.Text = Program.sRFIDnew;
          }
          else
              tbRFID.Text = Program.sRFIDnew;
      }

      private void FormEditace_FormClosing(object sender, FormClosingEventArgs e)
      {
          Registry.FormSettingSave(this);
      }
    }
}
