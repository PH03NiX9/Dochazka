using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Dochazka
{
    //třida uzivatel
    class Uzivatel
    {
        public string jmeno, prijmeni, heslo, login, id, rfid, aktivni, opravneni, id_skupiny,dovolena;

    }
    class Uzivatele
    {
        //_promena = privatni
        private int _pocet = 0;
        private List<Uzivatel> _uzivatele;
        private bool _isUserValid = false;
        private string _curentUserID;
        private Uzivatel _vybranyUzivatel;
        private Uzivatel _curentUser;
        private string _sSQL;
        private string _sRok;
        private string _sMesic;
        private string _vybranyId_pohyb;
        private Pohyb _vybranyPohyb;


        //Konstruktor (public fce třidy se stejnym jmenem)
        public Uzivatele()
        {
            this.NactiData();
        }

        public int GetPocet()
        {
            return this._pocet;
        }

        public bool GetIsUserValid()
        {
            return this._isUserValid;
        }

        public Uzivatele Over(string login, string heslo)
        {
           
            foreach (Uzivatel oUzivatel in this._uzivatele)
            {
                if (oUzivatel.login.Equals(login) && oUzivatel.heslo.Equals(heslo)&& oUzivatel.aktivni.Equals("1")&& int.Parse(oUzivatel.opravneni) > 0)
                {
                    this._isUserValid = true;
                    this._curentUserID = oUzivatel.id;
                    this._curentUser=oUzivatel;
                    //Opravneni
                    if (_curentUser.opravneni.Equals("1"))
                        _sSQL = "WHERE id=" + this._curentUser.id;
                    else if (_curentUser.opravneni.Equals("2"))
                    {
                        _sSQL = "WHERE id_skupiny=" + this._curentUser.id_skupiny;
                        this._vybranyUzivatel = this._curentUser;
                        _sSQL += new Zamestnanci_skupiny().OpravneniZamestnance().ToString();
                    }
                    else
                        _sSQL = " ";
                    
                    return this;
                }
            }

            this._isUserValid = false;
            this._curentUserID = "0";
            return this;
        }

        public Uzivatele SetPohyb(string oRok,string oMesic,string oId_Pohyb)
        {
            this._vybranyId_pohyb = oId_Pohyb;
            
            Pohyby oPohyby = new Pohyby(Program.oUzivatele, oRok, oMesic);
            
            oPohyby.VyberPohyb(oId_Pohyb);
            this._vybranyPohyb = oPohyby.GetSelectPohyb();
            return this;
        }

        
        public Pohyb GetCurentPohyb()
        {
            return this._vybranyPohyb;
        }

        public Uzivatel GetCurentUser()
        {
            return this._curentUser;
        }

        public Uzivatele FillLvZamestnanci(ListView oListView)
        {
            int isSelectedIndex = 0;
            if (oListView.SelectedItems.Count > 0)
                isSelectedIndex = oListView.FocusedItem.Index;
            oListView.Items.Clear();

            this.NactiData();
            foreach(Uzivatel oUzivatel in this._uzivatele )
            {
                ListViewItem lviZamestnanec = new ListViewItem();
                lviZamestnanec.Text = oUzivatel.prijmeni ;
                lviZamestnanec.SubItems.Add(oUzivatel.jmeno);
                lviZamestnanec.SubItems.Add(oUzivatel.rfid);
                lviZamestnanec.SubItems.Add(Functions.GetStringFromBool(oUzivatel.aktivni));
                lviZamestnanec.SubItems.Add(Program.oSkupiny.VyberSkupinu(oUzivatel.id_skupiny).GetSelectGroup().popis);
                lviZamestnanec.Tag = oUzivatel.id;

                oListView.Items.Add(lviZamestnanec);
             
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

        private Uzivatele NactiData()
        {
            
            this._uzivatele = new List<Uzivatel>();
            

            MySqlDataReader aReader = DatabaseConect.GetRS("SELECT * FROM zamestnanci " + this._sSQL + " ");
            //Naplni 

            while (aReader.Read())
            {
                //vytvořime třidu uzivatel a naplníme data
                Uzivatel oUzivatel = new Uzivatel();
                oUzivatel.jmeno = aReader["jmeno"].ToString();
                oUzivatel.prijmeni = aReader["prijmeni"].ToString();
                oUzivatel.login = aReader["login"].ToString();
                oUzivatel.heslo = aReader["heslo"].ToString();
                oUzivatel.id = aReader["id"].ToString();
                oUzivatel.rfid = aReader["rfid"].ToString();
                oUzivatel.aktivni = aReader["aktivni"].ToString();
                oUzivatel.opravneni = aReader["opravneni"].ToString();
                oUzivatel.id_skupiny = aReader["id_skupiny"].ToString();
                oUzivatel.dovolena = aReader["dovolena"].ToString();
                //vytvorili jsme kolekci uzivatelu= _uzivatele
                this._uzivatele.Add(oUzivatel);
            }
            aReader.Close();
            return this;
        }

        public bool ExistujeLogin(string sLogin)
        {
            foreach (Uzivatel oUzivatel in this._uzivatele)
                if (oUzivatel.login.Equals(sLogin))
                    return true;
            return false;
        }

        public bool ExistujeRFID(string sRFID)
        {
            foreach (Uzivatel oUzivatel in this._uzivatele)
                if (oUzivatel.rfid.Equals(sRFID))
                    return true;
            return false;
        }


        private Uzivatele UlozData()
        {
            //pokud je nový záznam
            if(this._vybranyUzivatel.id.Equals("001"))
                DatabaseConect.Execute("INSERT INTO zamestnanci SET jmeno='" + this._vybranyUzivatel.jmeno + "',prijmeni='" + this._vybranyUzivatel.prijmeni + "',rfid='" + this._vybranyUzivatel.rfid + "',aktivni='" + this._vybranyUzivatel.aktivni + "',login='" + this._vybranyUzivatel.login + "', heslo='" + this._vybranyUzivatel.heslo + "',opravneni='" + this._vybranyUzivatel.opravneni + "',id_skupiny='" + this._vybranyUzivatel.id_skupiny + "',dovolena='" + this._vybranyUzivatel.dovolena + "'");
            else  //zmenit stary zaznam
                DatabaseConect.Execute("UPDATE zamestnanci SET jmeno='" + this._vybranyUzivatel.jmeno + "',prijmeni='" + this._vybranyUzivatel.prijmeni + "',rfid='" + this._vybranyUzivatel.rfid + "',aktivni='" + this._vybranyUzivatel.aktivni + "',login='" + this._vybranyUzivatel.login + "', heslo='" + this._vybranyUzivatel.heslo + "',opravneni='" + this._vybranyUzivatel.opravneni + "',id_skupiny='" + this._vybranyUzivatel.id_skupiny + "',dovolena='" + this._vybranyUzivatel.dovolena + "' WHERE id='" + this._vybranyUzivatel.id + "' ");
            
            return this;
        }

        public Uzivatel GetSelectUser()
        {
            return this._vybranyUzivatel;
        }
        
        public Uzivatele VyberUzivatele(string id_uzivatele)
        {
            foreach (Uzivatel oUzivatel in this._uzivatele)
            {
                if (id_uzivatele.Equals(oUzivatel.id))
                {
                    this._vybranyUzivatel = oUzivatel;
                    return this;
                }
                
            }
            this._vybranyUzivatel = null;
            return this;
        }
        public Uzivatele UlozUzivatele(Uzivatel oUzivatel)
        {
            this._vybranyUzivatel = oUzivatel;
            this.UlozData();
            return this;
        }
        
        public Uzivatele SmazUzivatele(string id_uzivatele)
        {
            DatabaseConect.Execute("DELETE FROM zamestnanci WHERE id='" + id_uzivatele + "' ");
            return this;
            
        }


        internal Uzivatel VyberUzivatele()
        {
            throw new NotImplementedException();
        }
    }

}
