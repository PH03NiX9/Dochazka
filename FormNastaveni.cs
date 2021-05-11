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
    public partial class FormNastaveni : Form
    {
        public FormNastaveni()
        {
            InitializeComponent();
        }

        private void FormNastaveni_Load(object sender, EventArgs e)
        {

            cmbComPort.SelectedIndex=int.Parse( Registry.GetKey("ComPort","COM1").Substring(3,1))-1;
            int index = cmbBaudrate.FindString(Registry.GetKey("Baoudrate", "9600"));
            cmbBaudrate.SelectedIndex = index;
            
            numUpDownZaokrouh.Value = int.Parse(Registry.GetKey("Zaokrouh", "0"));
            numericUpDownOdecet.Value = int.Parse(Registry.GetKey("Odecti", "0"));
            //cmbBaudrate.SelectedText = Registry.GetKey("Baoudrate", "9600");
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Registry.UpdateKey("ComPort", cmbComPort.SelectedItem.ToString());
            Registry.UpdateKey("Baoudrate", cmbBaudrate.SelectedItem.ToString());
            Registry.UpdateKey("Zaokrouh", numUpDownZaokrouh.Value.ToString() );
            
            Registry.UpdateKey("Odecti", numericUpDownOdecet.Value.ToString());
            this.Close();
        }

        

       
    }
}
