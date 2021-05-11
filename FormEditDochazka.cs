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
    public partial class FormEditDochazka : Form
    {
        
        
        public FormEditDochazka()
        {
            InitializeComponent();
        }

        private void FormEditDochazka_Load(object sender, EventArgs e)
        {
            NaplnCmbDuvod();
            //if ( Convert.ToInt32(Program.oUzivatele.GetCurentPohyb().id).Equals("001"))
            //if(string.IsNullOrEmpty(Program.oUzivatele.GetCurentPohyb().id)==true)
            if (this.Name.Equals("Nový záznam"))
            { }
            //this.Name = "Nový záznam";
            else
                NaplnDatum();
        }
        private void NaplnCmbDuvod()
        {
            // Nacteme z databaze tabulku pohybu do comboboxu
            MySqlDataAdapter oAdapter = new MySqlDataAdapter("SELECT id, popis FROM typ_pohybu ", DatabaseConect.serverLink);
            DataSet oDataset = new DataSet();

            oAdapter.Fill(oDataset, "typ_pohybu");

            cmbDuvod.DataSource = oDataset.Tables["typ_pohybu"].DefaultView;
            cmbDuvod.DisplayMember = "popis";
            cmbDuvod.ValueMember = "id";
        }

        private void NaplnDatum()
        {
            cmbDuvod.SelectedIndex = int.Parse(Program.oUzivatele.GetCurentPohyb().id_typ) - 1;
            dateTimePickerDatum.Text = Convert.ToDateTime(Program.oUzivatele.GetCurentPohyb().datum).ToString();
            numericUpDownHod.Value = int.Parse(Convert.ToDateTime(Program.oUzivatele.GetCurentPohyb().datum).ToString("HH"));
            numericUpDownMin.Value = int.Parse(Convert.ToDateTime(Program.oUzivatele.GetCurentPohyb().datum).ToString("mm"));
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string oDatum = Convert.ToDateTime(dateTimePickerDatum.Text + " " + numericUpDownHod.Value.ToString() + ":" + numericUpDownMin.Value.ToString()).ToString();
            string sId_Novy="1";
            //Functions.MsgBox(oDatum);
            
            Pohyb oPohyb = new Pohyb();
            if (this.Name.Equals("Nový záznam"))
                sId_Novy="0";
            oPohyb.UlozPohyb(cmbDuvod.SelectedValue.ToString(), cmbDuvod.Text.ToString(), DateTime.Parse(oDatum).ToString("yyyy-MM-dd HH:mm:ss"), sId_Novy);
            this.Close();
          
        }

        private void cmbDuvod_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pokud nemoc dovolena OCR je čas 00:00
            if (cmbDuvod.SelectedIndex == 2 || cmbDuvod.SelectedIndex == 4 || cmbDuvod.SelectedIndex == 6)
            {
                numericUpDownHod.Enabled = false;
                numericUpDownMin.Enabled = false;

            }
            else
            {
                numericUpDownHod.Enabled = true;
                numericUpDownMin.Enabled = true;

            }
        }

    }
}
