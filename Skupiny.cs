using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Dochazka
{

    class Skupina
    {
        public string id, popis;
    }

    class Skupiny
    {
        private List<Skupina> _skupiny;
        private string _sSQL = "";
        private Skupina _vybranaSkupina;
        private Zamestnanec_skupina _Zamestnanec_skupina;

        //Konstruktor (public fce třidy se stejnym jmenem)
        public Skupiny()
        {
            this.NactiSkupiny();
        }

        private Skupiny NactiSkupiny()
        {
            this._skupiny = new List<Skupina>();
            MySqlDataReader aReader = DatabaseConect.GetRS("SELECT * FROM skupiny " + this._sSQL + " ");
            //Naplni 
            while (aReader.Read())
            {
                //vytvořime třidu uzivatel a naplníme data
                Skupina oSkupina = new Skupina();
                oSkupina.id = aReader["id"].ToString();
                oSkupina.popis = aReader["popis"].ToString();
                //vytvorili jsme kolekci uzivatelu= _uzivatele
                this._skupiny.Add(oSkupina);
            }
            aReader.Close();
            return this;
        }

        public Skupiny FillLvSkupiny(ListView oListView)
        {
            int isSelectedIndex = 0;
            if (oListView.SelectedItems.Count > 0)
                isSelectedIndex = oListView.FocusedItem.Index;
            oListView.Items.Clear();

            this.NactiSkupiny();
            foreach (Skupina oSkupina in this._skupiny)
            {
                ListViewItem lvGroup = new ListViewItem();
                lvGroup.Tag = oSkupina.id; 
                lvGroup.Text = oSkupina.popis;
                oListView.Items.Add(lvGroup);
            }
            // Oznaci v listview polozku
            if (oListView.Items.Count > 0)
            {
                try
                {
                    oListView.Items[isSelectedIndex].Focused = true;
                    oListView.Items[isSelectedIndex].Selected = true;
                    oListView.Items[isSelectedIndex].EnsureVisible();//soupne listview aby byla viditelna polozka
                }
                catch
                {
                    oListView.Items[0].Focused = true;
                    oListView.Items[0].Selected = true;
                    oListView.Items[0].EnsureVisible();
                }
            }
            return this;
        }

        public Skupiny SmazSkupinu(string id_skupiny)
        {
            DatabaseConect.Execute("DELETE FROM skupiny WHERE id='" + id_skupiny + "'");
            return this;
        }

        public Skupiny UlozSkupinu(Skupina oSkupina)
        {
            this._vybranaSkupina = oSkupina;
            this.UlozData();
            return this;
        }

        private Skupiny UlozData()
        {
            //pokud je nový záznam
            if (this._vybranaSkupina.id.Equals("0"))
                DatabaseConect.Execute("INSERT INTO skupiny SET popis='" + this._vybranaSkupina.popis + "'");
            else  //zmenit stary zaznam
                DatabaseConect.Execute("UPDATE skupiny SET popis='" + this._vybranaSkupina.popis + "' WHERE id='" + this._vybranaSkupina.id + "' ");
            return this;
        }

        public Skupiny VyberSkupinu(string id_skupiny)
        {
            foreach (Skupina oSkupina in this._skupiny)
            {
                if (id_skupiny.Equals(oSkupina.id))
                {
                    this._vybranaSkupina = oSkupina;
                    return this;
                }
            }
            this._vybranaSkupina = null;
            return this;
        }

        public Skupina GetSelectGroup()
        {
            return this._vybranaSkupina;
        }


        public bool ExistujeSkupina(string sSkupina)
        {
            foreach (Skupina oSkupina in this._skupiny)
                if (oSkupina.popis.Equals(sSkupina))
                    return true;
            return false;
        }

        internal void UlozSkupinu(Skupiny skupiny)
        {
            throw new NotImplementedException();
        }
        /*
        public void OznacLv(ListView oListView,Uzivatel oUzivatel)
        {
            Zamestnanci_skupiny oZamestnanci_skupiny = new Zamestnanci_skupiny();
            oZamestnanci_skupiny.VyberZamestnanec_skupina(oUzivatel.id.ToString());
            
            //this._Zamestnanec_skupina=oZamestnanci_skupiny.GetSelectZamestnanec_skupina();

            this.NactiSkupiny();
            foreach (Skupina oSkupina in this._skupiny)
            {
                ListViewItem lvGroup = new ListViewItem();
                foreach(Zamestnanec_skupina oZamestnanec_skupina in oZamestnanci_skupiny())
                {
                    if (oSkupina.id.Equals(oZamestnanci_skupiny.GetSelectZamestnanec_skupina().id_skupiny.ToString()))
                    {
                        lvGroup.Checked = true;
                    }
                }
                
                
                

                lvGroup.Tag = oSkupina.id;
                lvGroup.Text = oSkupina.popis;
                oListView.Items.Add(lvGroup);
            }
        
        }
        */
    }
}
