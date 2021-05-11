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
    public partial class FormSvat : Form
    {

        public FormSvat()
        {
            InitializeComponent();
        }

        private void FormSvat_Load(object sender, EventArgs e)
        {
            NaplnSvatky();
            Registry.FormSettingLoad(this);
        }


        private void NaplnSvatky()
        {
            // Nacteme z databaze tabulku pohybu do comboboxu
            Program.oSvatky.FillLvSvatky(lvSvatky);
        }

        private void OdstranSvatek()
        {
            //Potvrzeni smazani
            DialogResult dlgRes;
            if (Program.oSvatky.VyberSvatek(lvSvatky.FocusedItem.Tag.ToString()).GetSelectSvatek().popis.Equals("administrators"))
                Functions.MsgBox("Nelze odstranit svátek");
            else
            {
                dlgRes = MessageBox.Show("Opravdu chcete odstranit svátek: "
                    + Program.oSvatky.VyberSvatek(lvSvatky.FocusedItem.Tag.ToString()).GetSelectSvatek().popis + " ",
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlgRes == DialogResult.Yes)
                {
                    //smaze zaznam podle id
                    Program.oSvatky.SmazSvatek(lvSvatky.FocusedItem.Tag.ToString());
                    //Znovu načte lvZamestnance po editaci
                    NaplnSvatky();
                }
            }
        }
 
       private void lvSvatky_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && lvSvatky.Items.Count > 0)
                ZobrazEditSv("Editace");
                //UlozSvatek(lvSvatky.FocusedItem.Tag.ToString());
        }

        private void lvSvatky_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ZobrazEditSv("Editace");
            //UlozSvatek(lvSvatky.FocusedItem.Tag.ToString());
        }

        private void lvSvatky_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lvSvatky.Items.Count > 0)
                OdstranSvatek();
        }

        private void mnuNovySv_Click_1(object sender, EventArgs e)
        {
            ZobrazEditSv("0");
        }

        private void mnuEditSv_Click_1(object sender, EventArgs e)
        {
            ZobrazEditSv("Editace");
        }

        private void mnuSmazatSv_Click(object sender, EventArgs e)
        {
            OdstranSvatek();
        }

        private void ZobrazEditSv(string FormName)
        {
            //if (lvSvatky.FocusedItem.Tag.ToString() == null) lvSvatky.FocusedItem.Tag = 0;
            FormEditSv oFormEdit = new FormEditSv();
            if (lvSvatky.Items.Count > 0|| FormName=="0")
            { 
                oFormEdit.Text = "Nový záznam";  
            }
            else
            {
                oFormEdit.Text = "Editovat";
            }
            oFormEdit.ShowDialog();
            NaplnSvatky();
        }

        private void FormSvat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Registry.FormSettingSave(this);
        }

    }
}
