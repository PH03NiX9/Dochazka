using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Dochazka
{
    class Svatek
    {
        public string id, popis, datum, opak;
    }
    class Svatky
    {
        private List<Svatek> _svatky;
        private string _sSQL = "";
        private Svatek _vybranySvatek;

        //Konstruktor (public fce třidy se stejnym jmenem)
        public Svatky()
        {
            this.NactiSvatek();
        }
        private Svatky NactiSvatek()
        {
            this._svatky = new List<Svatek>();
            MySqlDataReader aReader = DatabaseConect.GetRS("SELECT * FROM svatky " + this._sSQL + " ");
            //Naplni 
            while (aReader.Read())
            {
                //vytvořime třidu svatky a naplníme data
                Svatek oSvatky = new Svatek();
                oSvatky.id = aReader["id"].ToString();
                oSvatky.datum = aReader["datum_sv"].ToString();
                oSvatky.popis = aReader["nazev_sv"].ToString();
                oSvatky.opak = aReader["opakovani_sv"].ToString();
                //vytvorili jsme kolekci uzivatelu= _uzivatele
                this._svatky.Add(oSvatky);
            }
            aReader.Close();
            return this;
            
        }

        public Svatky FillLvSvatky(ListView oListView)
        {
            int isSelectedIndex = 0;
            if (oListView.SelectedItems.Count > 0)
                isSelectedIndex = oListView.FocusedItem.Index;
            oListView.Items.Clear();

            this.NactiSvatek();
            foreach (Svatek oSvatek in this._svatky)
            {
                ListViewItem lvSvatky = new ListViewItem();
                lvSvatky.Tag = oSvatek.id;
                lvSvatky.Text = (Convert.ToDateTime(oSvatek.datum).ToString("yyyy-MM-dd")).ToString();
                lvSvatky.SubItems.Add(oSvatek.popis);
                lvSvatky.SubItems.Add(Functions.GetStringFromBool( int.Parse(oSvatek.opak),"ANO","NE"));
                oListView.Items.Add(lvSvatky);
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

        public Svatky SmazSvatek(string id_svatku)
        {
            DatabaseConect.Execute("DELETE FROM svatky WHERE id='" + id_svatku + "'");
            return this;
        }

        public Svatky UlozSvatek(Svatek oSvatek)
        {
            this._vybranySvatek = oSvatek;
            this.UlozData();
            return this;
        }

        private Svatky UlozData()
        {
            //pokud je nový záznam
            if (this._vybranySvatek.id.Equals("0"))
                DatabaseConect.Execute("INSERT INTO svatky SET nazev_sv='" + this._vybranySvatek.popis + "',datum_sv='" + this._vybranySvatek.datum + "',opakovani_sv='" +  this._vybranySvatek.opak + "'");
            else  //zmenit stary zaznam
                DatabaseConect.Execute("UPDATE svatky SET nazev_sv='" + this._vybranySvatek.popis + "',opakovani_sv='" + Convert.ToBoolean( this._vybranySvatek.opak) + "' WHERE id='" + this._vybranySvatek.id + "' ");
            return this;
        }

        public Svatky VyberSvatek(string id_svatku)
        {
            foreach (Svatek oSvatek in this._svatky)
            {
                if (id_svatku.Equals(oSvatek.id))
                {
                    this._vybranySvatek = oSvatek;
                    return this;
                }
            }
            this._vybranySvatek = null;
            return this;
        }

        public Svatek GetSelectSvatek()
        {
            return this._vybranySvatek;
        }

        public bool ExistujeSv(string sDatum)
        {
            foreach (Svatek oSvatek  in this._svatky)
                //jestli se svatek opakuje pak porovnej jen mesic a den
                if (oSvatek.opak == "True")
                {
                    if ((Convert.ToDateTime(oSvatek.datum).ToString("MM-dd")).Equals(Convert.ToDateTime(sDatum).ToString("MM-dd")))
                    {
                        return true;
                    }
                }
                else
                {
                    if ((Convert.ToDateTime(oSvatek.datum).ToString("yyyy-MM-dd")).Equals(Convert.ToDateTime(sDatum).ToString("yyyy-MM-dd")))
                        return true;
                }
            return false;
        }

        internal void UlozSvatek(Svatky svatky)
        {
            throw new NotImplementedException();
        }
    }
}
