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
    public partial class FormEditSv : Form
    {
        public FormEditSv()
        {
            InitializeComponent();
        }

        private void FormEditSv_Load(object sender, EventArgs e)
        {
            if (this.Text.Equals("Nový záznam"))
            {
                //dtpDatum.Text = DateTime.Now(); 
            }
            else
            {
                //dtpDatum.Text = Convert.ToDateTime(Program.oSvatky.GetSelectSvatek().datum).ToString();
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals("Nový záznam"))
            {
                if (Program.oSvatky.ExistujeSv(dtpDatum.Text))
                {
                    Functions.MsgBox("Zvolené datum svátku existuje, zvolte jiné datum!");
                    return;
                }
                else
                {
                    UlozSvatek("0");
                }
            }
            else
            {
                UlozSvatek(Program.oSvatky.GetSelectSvatek().id.ToString());
            }
            this.Close();
        }
        private void UlozSvatek(string sId)
        {
            Svatek oSvatek = new Svatek();
            oSvatek.id = sId;
            oSvatek.popis = texbNazev.Text;
            oSvatek.datum = DateTime.Parse(dtpDatum.Text).ToString("yyyy-MM-dd");
            oSvatek.opak = Functions.GetStringFromBool(chbOpak.Checked.ToString(), "1", "0"); 
            Program.oSvatky.UlozSvatek(oSvatek);
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
