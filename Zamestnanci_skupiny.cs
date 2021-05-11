using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Dochazka
{
    class Zamestnanec_skupina
    {
        public string id, popis, id_zamestnance;
    }

    class Zamestnanci_skupiny
    {
        private List<Zamestnanec_skupina> _Zamestnanci_skupiny;
        private string _sSQL = "";
        private Zamestnanec_skupina _vybranaZamestnanec_skupina;
        private string _id_zamestnance;
        
        public Zamestnanci_skupiny()
        {
            this.NactiZamestnanci_skupiny();
        }

        private Zamestnanci_skupiny NactiZamestnanci_skupiny()
        {
            this._id_zamestnance=Program.oUzivatele.GetSelectUser().id;
            //this._id_zamestnance = Program.oUzivatele.GetCurentUser().id;
            this._sSQL = "SELECT skupiny.id, skupiny.popis, zamestnanci.id AS id_zamestnance FROM skupiny LEFT OUTER JOIN r_zamestnanci_skupiny ON id_skupiny=skupiny.id LEFT OUTER JOIN zamestnanci ON r_zamestnanci_skupiny.id_zamestnance = zamestnanci.id WHERE r_zamestnanci_skupiny.id_zamestnance='" + this._id_zamestnance + "' UNION SELECT skupiny.id, skupiny.popis, 0 AS id_zamestnance FROM skupiny WHERE id NOT IN (SELECT skupiny.id FROM skupiny LEFT OUTER JOIN r_zamestnanci_skupiny ON id_skupiny=skupiny.id LEFT OUTER JOIN zamestnanci ON r_zamestnanci_skupiny.id_zamestnance = zamestnanci.id WHERE r_zamestnanci_skupiny.id_zamestnance='" + this._id_zamestnance + "')" ;       
            
            this._Zamestnanci_skupiny = new List<Zamestnanec_skupina>();
            MySqlDataReader aReader = DatabaseConect.GetRS(this._sSQL);
            //Naplni 
            while (aReader.Read())
            {
                //vytvořime třidu uzivatel a naplníme data
                Zamestnanec_skupina oZamestnanec_skupina = new Zamestnanec_skupina();
                oZamestnanec_skupina.id = aReader["id"].ToString();
                oZamestnanec_skupina.popis = aReader["popis"].ToString();
                oZamestnanec_skupina.id_zamestnance = aReader["id_zamestnance"].ToString();
                //vytvorili jsme kolekci uzivatelu= _uzivatele
                this._Zamestnanci_skupiny.Add(oZamestnanec_skupina);
            }
            aReader.Close();
            return this;
        }

        public Zamestnanci_skupiny VyberZamestnanec_skupina(string id_Zamestnanec_skupina)
        {
            foreach (Zamestnanec_skupina oZamestnanec_skupina in this._Zamestnanci_skupiny)
            {
                if (id_Zamestnanec_skupina.Equals(oZamestnanec_skupina.id))
                {
                    this._vybranaZamestnanec_skupina = oZamestnanec_skupina;
                    return this;
                }
            }
            this._vybranaZamestnanec_skupina = null;
            return this;
        }

        public Zamestnanci_skupiny GetSelectZamestnanec_skupina()
        {
            return this;
        }

        public string OpravneniZamestnance()
        {
            string osSQL="";
            foreach (Zamestnanec_skupina oZamestnanec_skupina in this._Zamestnanci_skupiny)
            {
                if(oZamestnanec_skupina.id_zamestnance.Equals(this._id_zamestnance))
                    osSQL += " OR id_skupiny= " + oZamestnanec_skupina.id;
            }
            return osSQL;
        }
       
        public Zamestnanci_skupiny FillListview(ListView oListView)
        {
            int isSelectedIndex = 0;
            if (oListView.SelectedItems.Count > 0)
                isSelectedIndex = oListView.FocusedItem.Index;

            oListView.Items.Clear();

            foreach (Zamestnanec_skupina oZamestnanec_skupina in this._Zamestnanci_skupiny)
            {
                ListViewItem lviDochazka = new ListViewItem();
                lviDochazka.Text = oZamestnanec_skupina.popis;
                lviDochazka.Tag =oZamestnanec_skupina.id;
                if(oZamestnanec_skupina.id_zamestnance.Equals(this._id_zamestnance))
                    lviDochazka.Checked=true;
                oListView.Items.Add(lviDochazka);
            }
            if (oListView.Items.Count > 0)
            {
                try
                {
                    oListView.Items[isSelectedIndex].Selected = true;
                    oListView.Items[isSelectedIndex].EnsureVisible();//soupne aby byla viditelna
                    oListView.Items[isSelectedIndex].Focused = true;
                }
                catch
                {
                    oListView.Items[0].Selected = true;
                    oListView.Items[0].EnsureVisible();
                    oListView.Items[0].Focused = true;
                }
            }
            return this;
        }

        public Zamestnanci_skupiny UlozZamestnance_skupinu(ListView oListView)
        {
            DatabaseConect.Execute("DELETE FROM r_zamestnanci_skupiny WHERE id_zamestnance='"+ Program.oUzivatele.GetSelectUser().id + "'");

            foreach (ListViewItem oPolozka in oListView.Items)
            { 
                if(oPolozka.Checked)
                    DatabaseConect.Execute("INSERT INTO r_zamestnanci_skupiny SET id_zamestnance='" + Program.oUzivatele.GetSelectUser().id + "',id_skupiny='" + oPolozka.Tag.ToString() + "'");
            }
            
             return this;
        }
        
    }
}
