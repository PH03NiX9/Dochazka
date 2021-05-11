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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            NactiRegistry();
            this.Show();
            textBoxLogin.Focus();
            
        }

        private void NactiRegistry()
        {
            tbServer.Text = Registry.GetKey("MySQLServer", Parametry.mysqlserver);
            tbDatabaze.Text = Registry.GetKey("MySQLDatabaze", Parametry.mysqldatabase);
            tbJmenoData.Text = Registry.GetKey("MySQLJmeno", Parametry.mysqluser);
            tbHesloData.Text = Registry.GetKey("MySQLHeslo", Parametry.mysqlpassword);
        
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Parametry.UlozNastaveniSQL(tbServer.Text, tbDatabaze.Text, tbJmenoData.Text, tbHesloData.Text);
            try 
            { 
                DatabaseConect.Connect(); 
            }
            catch
            { 
                Functions.MsgBox("Neplatná databáze!");
                tabControl1.TabPages[1].Select();
                return;
            }
            Program.oUzivatele = new Uzivatele();
            Program.oSkupiny = new Skupiny();
            Program.oSvatky = new Svatky();


            if (Program.oUzivatele.Over(textBoxLogin.Text, textBoxHeslo.Text).GetIsUserValid())
            {
                //Functions.MsgBox(Program.oUzivatele.GetCurentUser().jmeno);
                this.Close();
            }
            else
            {
                Functions.MsgBox("Neplatné uživatelské jméno nebo heslo.", MessageBoxIcon.Exclamation);
                textBoxHeslo.Select();
            
            }
            
        }

    }
}
