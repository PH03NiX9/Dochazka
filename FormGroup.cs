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
    public partial class FormGroup : Form
    {
        public FormGroup()
        {
            InitializeComponent();
        }

        private void FormGroup_Load(object sender, EventArgs e)
        {
            NaplnSkupiny();
            Registry.FormSettingLoad(this);
        }

        private void NaplnSkupiny()
        {
            // Nacteme z databaze tabulku pohybu do comboboxu
            Program.oSkupiny.FillLvSkupiny(lvGroup);
        }
        private void OdstranSkupinu()
        {
            //Potvrzeni smazani
            DialogResult dlgRes;
            if(Program.oSkupiny.VyberSkupinu(lvGroup.FocusedItem.Tag.ToString()).GetSelectGroup().popis.Equals("administrators"))
                Functions.MsgBox("Nelze odstranit systémovou skupinu administrators");
            else
            {
            dlgRes = MessageBox.Show("Opravdu chcete smazat skupinu: "
                + Program.oSkupiny.VyberSkupinu(lvGroup.FocusedItem.Tag.ToString()).GetSelectGroup().popis+ " " ,
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlgRes == DialogResult.Yes)
            {
                //smaze zaznam podle id
                Program.oSkupiny.SmazSkupinu(lvGroup.FocusedItem.Tag.ToString());
                //Znovu načte lvZamestnance po editaci
                NaplnSkupiny();
            }
            }
        }
        private void UlozSkupinu(string sId)
        {
            Skupina oSkupina = new Skupina();
            string sSkupina;
            if (sId.Equals("0"))
            {
                sSkupina = "Nová skupina";
                InputBoxResult result = InputBox.Show("Název skupiny:", sSkupina, sSkupina, new InputBoxValidatingHandler(inputBox_Validating));
                if (result.OK)
                {
                    oSkupina.id = sId;
                    oSkupina.popis = result.Text;
                    if (Program.oSkupiny.ExistujeSkupina(oSkupina.popis))
                    {
                        Functions.MsgBox("Zvolená skupina existuje, zvolte jiný název!");
                        return;
                    }
                    else
                    {
                        
                        Program.oSkupiny.UlozSkupinu(oSkupina);
                        //Znovu načte po editaci
                        NaplnSkupiny();
                    }
                }
            }
            else
            {
                sSkupina = Program.oSkupiny.VyberSkupinu(sId).GetSelectGroup().popis.ToString();
                if (Program.oSkupiny.VyberSkupinu(lvGroup.FocusedItem.Tag.ToString()).GetSelectGroup().popis.Equals("administrators"))
                    Functions.MsgBox("Nelze upravovat systémovou skupinu administrators");
                else
                {
                    InputBoxResult result = InputBox.Show("Název skupiny:", sSkupina, sSkupina, new InputBoxValidatingHandler(inputBox_Validating));
                    if (result.OK)
                    {
                        oSkupina.id = sId;
                        oSkupina.popis = result.Text;
                        Program.oSkupiny.UlozSkupinu(oSkupina);
                        //Znovu načte po editaci
                        NaplnSkupiny();
                    }
                }
            }
        }

        private void inputBox_Validating(object sender, InputBoxValidatingArgs e)
        {
            if (e.Text.Trim().Length == 0)
            {
                e.Cancel = true;
                e.Message = "Required";
            }
        }

        private void mnuOdstranit_Click(object sender, EventArgs e)
        {
            OdstranSkupinu();
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            UlozSkupinu(lvGroup.FocusedItem.Tag.ToString());
        }

        private void mnuNova_Click(object sender, EventArgs e)
        {
            UlozSkupinu("0");
        }

        private void lvGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && lvGroup.Items.Count > 0)
                UlozSkupinu(lvGroup.FocusedItem.Tag.ToString());
        }

        private void lvGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            UlozSkupinu(lvGroup.FocusedItem.Tag.ToString());
        }

        private void lvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && lvGroup.Items.Count > 0)
                OdstranSkupinu();
        }

        private void FormGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registry.FormSettingSave(this);
        }

        
    }
}
