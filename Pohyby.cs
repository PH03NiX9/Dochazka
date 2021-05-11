using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Dochazka
{
    class Pohyb
    {
        public string id, id_zamestnance, rfid, datum, id_typ, jmeno, prijmeni, aktivni, typ_popis, upraveno, upravil_id;
        public int UlozPohyb(string sId_typ,string sTyp_popis,string sDatum,string sIdNovy)
        {
            string sSQL="UPDATE pohyb SET #data# #where#";
            string sData = "id_zamestnance='" + Program.oUzivatele.GetSelectUser().id + "',rfid='" + Program.oUzivatele.GetSelectUser().rfid + "',jmeno= '" + Program.oUzivatele.GetSelectUser().jmeno + "',prijmeni='" + Program.oUzivatele.GetSelectUser().prijmeni + "',aktivni='" + Program.oUzivatele.GetSelectUser().aktivni + "',upraveno='1',upravil_id='" + Program.oUzivatele.GetCurentUser().id + "'";
            sData += ",id_typ='" + sId_typ + "',typ_popis='" + sTyp_popis + "',datum='" + sDatum + "'";
            if (sIdNovy.Equals("0"))
                sSQL="INSERT pohyb SET #data#";
            else
                sSQL = sSQL.Replace("#data#", sData).Replace("#where#", "WHERE id='" + Program.oUzivatele.GetCurentPohyb().id.ToString() + "'");
           
            sSQL = sSQL.Replace("#data#", sData);
            DatabaseConect.Execute(sSQL);
            return 1;
                
        }
        public int OdsranPohyb(string sId_pohybu)
        {
            DatabaseConect.Execute("DELETE FROM pohyb WHERE id='" + sId_pohybu +"' ");
            return 1;
        }
    
    }
    class Pohyby
    {
        private Uzivatele _oUzivatele;
        private string _oRok;
        private string _oMesic;
        private List<Pohyb> _dochazka;
        private Pohyb _vybranyPohyb;
        private TimeSpan _sumaHodin;
        private TimeSpan _sumaLekar;
        private int _isumaDovolena=0;
        private int _isumaNemoc=0;
        private int _isumaOCR=0;
        private TimeSpan _iSumaVikendy;
        private TimeSpan _iSumaSvatky;
        private string _sPosledniTypOdchodu="0";
        private DateTime _dtPosledniCasOdchodu;
        private int _iZaokrouh = 0;
        private int _iOdecti=0;

        //Konstruktor
        public Pohyby(Uzivatele oUzivatele, string oRok, string oMesic)
        {
            this._oUzivatele = oUzivatele;
            this._oRok = oRok;
            this._oMesic = oMesic;
            this.NactiDochazku();
        }

        private Pohyby NactiDochazku()
            {
                this._dochazka = new List<Pohyb>();
                MySqlDataReader aReader = DatabaseConect.GetRS("SELECT * FROM pohyb WHERE id_zamestnance='" + Program.oUzivatele.GetSelectUser().id + "' AND YEAR(datum)='" + this._oRok + "'AND MONTH(datum)='" + this._oMesic + "'");
                //Naplni 
                while (aReader.Read())
                {
                    //vytvořime třidu uzivatel a naplníme data
                    Pohyb oPohyb = new Pohyb();
                    oPohyb.id = aReader["id"].ToString();
                    oPohyb.id_zamestnance = aReader["id_zamestnance"].ToString();
                    oPohyb.rfid= aReader["rfid"].ToString();
                    oPohyb.datum = aReader["datum"].ToString();
                    oPohyb.id_typ = aReader["id_typ"].ToString();
                    oPohyb.jmeno = aReader["jmeno"].ToString();
                    oPohyb.prijmeni = aReader["prijmeni"].ToString();
                    oPohyb.aktivni = aReader["aktivni"].ToString();
                    oPohyb.typ_popis = aReader["typ_popis"].ToString();
                    oPohyb.upraveno = aReader["upraveno"].ToString();
                    oPohyb.upravil_id = aReader["upravil_id"].ToString();

                    //vytvorili jsme kolekci uzivatelu= _uzivatele
                    this._dochazka.Add(oPohyb);
                }
            aReader.Close();
            return this;
            }
        public string GetSumaHodin()
        {
            return Functions.GetTotalHourMin(this._sumaHodin);
        }

        public string GetSumaLekar()
        {
            return Functions.GetTotalHourMin(this._sumaLekar);
        }

        public string GetSumaDovolena()
        {
            return Convert.ToString(this._isumaDovolena);
        }

        public string GetSumaNemoc()
        {
            return Convert.ToString(this._isumaNemoc);
        }

        public string GetSumaOCR()
        {
            return Convert.ToString(this._isumaOCR);
        }

        public string GetSumaVikendy()
        {
            return Functions.GetTotalHourMin(this._iSumaVikendy);
        }

        public string GetSumaSvatky()
        {
            return Functions.GetTotalHourMin(this._iSumaSvatky);
        }

        public Pohyb GetSelectPohyb()
        {
            return this._vybranyPohyb;
        }

        public Pohyby VyberPohyb(string id_pohyb)
        {
                foreach (Pohyb oPohyb in this._dochazka)
                {
                    if (id_pohyb.Equals(oPohyb.id))
                    {
                        this._vybranyPohyb = oPohyb;
                        return this;
                    }
                }
        this._vybranyPohyb = null;
        return this;
        }

        public Pohyby FillListview(ListView oListView)
        {
            DateTime dtZacatekDoby = DateTime.Now;
            DateTime dtKonecDoby;
            
            int iPruchod = 1;

            

            int isSelectedIndex = 0;
            if (oListView.SelectedItems.Count > 0)
                isSelectedIndex = oListView.FocusedItem.Index;
            
            oListView.Items.Clear();

            foreach (Pohyb oDochazka in this._dochazka)
            {
                ListViewItem lviDochazka = new ListViewItem();
                //pokud byla zmena zaznamu tak cerveny text
                if(oDochazka.upraveno.Equals("1"))
                lviDochazka.ForeColor=Color.Red;
                lviDochazka.Text = Convert.ToDateTime(oDochazka.datum).ToString("ddd - dd.MM.");//den datum
                lviDochazka.SubItems.Add(Convert.ToDateTime(oDochazka.datum).ToString("HH:mm"));//čas
                lviDochazka.SubItems.Add(oDochazka.typ_popis);//duvod
                lviDochazka.Tag = oDochazka.id; //id_pohybu pro editaci

                //pokud zacina den odchodem
                if (iPruchod.Equals(1) && int.Parse(oDochazka.id_typ) >= 2)
                {

                    if (!(oDochazka.id_typ.Equals("8")) && (oDochazka.id_typ.Equals("7")) && (oDochazka.id_typ.Equals("5")))
                    {
                        lviDochazka.SubItems.Add(Convert.ToDateTime(oDochazka.datum).ToString("HH:mm"));    //(VypocetDoby(dtZacatekDoby, dtKonecDoby)));
                        dtZacatekDoby = Convert.ToDateTime("00:00");
                        dtKonecDoby = Convert.ToDateTime(Convert.ToDateTime(oDochazka.datum).ToString("HH:mm"));
                        VypocetDoby(dtZacatekDoby, dtKonecDoby, oDochazka.id_typ);
                        //_sumaHodin.Add(Convert.ToDateTime(oDochazka.datum).ToString("HH:mm"));
                        //dtZacatekDoby = DateTime.Parse(Convert.ToDateTime(oDochazka.datum).ToString("dd.MM."));// DateTime.Parse(oDochazka.datum).ToString("yyyy-MM-dd HH:mm:ss")
                    }
                    else
                    {
                        lviDochazka.SubItems.Add(" ");                    
                    }

                }
                //pokud neni odchod pocita se do pulnoci
                if (iPruchod == this._dochazka.Count() && int.Parse(oDochazka.id_typ) == 1 && !iPruchod.Equals(1))
                {
                    dtKonecDoby = DateTime.Parse(oDochazka.datum).AddHours(23).AddMinutes(59);
                    //DateTime.Parse(Convert.ToDateTime(oDochazka.datum).ToString("dd.MM.") +

                }
                //prichod
                if (int.Parse(oDochazka.id_typ) == 1)//&& iPruchod.Equals(1)
                {
                    dtZacatekDoby = Convert.ToDateTime(oDochazka.datum);

                    if (this._sPosledniTypOdchodu.Equals("3"))
                    {
                        TimeSpan tsLekar = RoundUpDt(KorekceOdchod(Convert.ToDateTime(oDochazka.datum))) - RoundUpDt(KorekceOdchod(this._dtPosledniCasOdchodu));
                        this._sumaLekar += tsLekar;
                        lviDochazka.SubItems.Add(tsLekar.ToString());
                    }
                    else
                    {
                        lviDochazka.SubItems.Add(" ");    
                    }
                }
                //odchod vsechny
                else//if(int.Parse(oDochazka.id_typ) pak mezisoučet
                {
                    if (oDochazka.id_typ.Equals("5")) //dovolena
                        this._isumaDovolena++;
                    if (int.Parse(oDochazka.id_typ) == 8) //dovolena
                        this._isumaNemoc++;
                    if (int.Parse(oDochazka.id_typ) == 7) //dovolena
                        this._isumaOCR++;
                    //odchod || prestavka || sluzebni cesta
                    if (int.Parse(oDochazka.id_typ) == 2 || int.Parse(oDochazka.id_typ) == 4 || int.Parse(oDochazka.id_typ) == 6) 
                    {
                        dtKonecDoby = Convert.ToDateTime(oDochazka.datum);
                        lviDochazka.SubItems.Add((VypocetDoby(dtZacatekDoby, dtKonecDoby, oDochazka.id_typ)));
                    }
                    if (int.Parse(oDochazka.id_typ) == 3) //Lekar
                    {
                        dtKonecDoby = Convert.ToDateTime(oDochazka.datum);
                        lviDochazka.SubItems.Add((VypocetDoby(dtZacatekDoby, dtKonecDoby, oDochazka.id_typ)));
                    }
                    //Je li sobota nebo neděle
                    if ((dtZacatekDoby.DayOfWeek).ToString() == DayOfWeek.Saturday.ToString() || (dtZacatekDoby.DayOfWeek).ToString() == DayOfWeek.Sunday.ToString())
                    {
                        //Cas o vikendu +korekce a zaokrouhleni
                        TimeSpan tsVikend = RoundUpDt(KorekceOdchod(Convert.ToDateTime(oDochazka.datum))) - RoundUpDt(KorekcePrichod(this._dtPosledniCasOdchodu));
                        this._iSumaVikendy += tsVikend;
                    }
       
                    if (Program.oSvatky.ExistujeSv((dtZacatekDoby).ToString())) // kdyz je to svatek
                    {
                        TimeSpan tsSvatky = RoundUpDt(KorekceOdchod(Convert.ToDateTime(oDochazka.datum))) - RoundUpDt(KorekcePrichod(this._dtPosledniCasOdchodu));
                        this._iSumaSvatky += tsSvatky;
                    }
                

                }
                iPruchod++;
                this._sPosledniTypOdchodu = oDochazka.id_typ;
                this._dtPosledniCasOdchodu = Convert.ToDateTime(oDochazka.datum);
                //lviDochazka.SubItems.Add(this.ZjistiDobu());
                
                oListView.Items.Add(lviDochazka);
            }
            //listview
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

        private string VypocetDoby(DateTime dtZacatekDoby, DateTime _dtPosledniCasOdchodu, int p)
        {
            throw new NotImplementedException();
        }
        /*
        private Pohyby ZjistiDobu()
        {
            
            DateTime dtDenDoba;
            DateTime dtZacatekDoby = DateTime.Now;
            DateTime dtKonecDoby;
            int iPruchod = 1;

            foreach (Pohyb oDochazka in this._dochazka)
            {
                
               if(iPruchod.Equals(1)&& int.Parse(oDochazka.id_typ)>=2)
                   dtZacatekDoby=DateTime.Parse(Convert.ToDateTime(oDochazka.datum).ToString("dd.MM."));
               if (iPruchod == this._dochazka.Count() && int.Parse(oDochazka.id_typ) == 1)
               {
                   dtKonecDoby = DateTime.Parse(Convert.ToDateTime(oDochazka.datum).ToString("dd.MM.") + "23:59");
               
               }
               if (int.Parse(oDochazka.id_typ) == 1)
                   dtZacatekDoby = Convert.ToDateTime(oDochazka.datum);
               else
               {
                   
                    dtKonecDoby = Convert.ToDateTime(oDochazka.datum);
                    dtDenDoba=Convert.ToDateTime(VypocetDoby(dtZacatekDoby, dtKonecDoby));
               }
            iPruchod++;
            }     
                //oDenDoba=DateTime.Compare(oZacatekDoby,oKonecDoby);
        
            return this;
        }
        */
        private string VypocetDoby(DateTime dtPrichod, DateTime dtOdchod,string oTyp_pohyb )
        {

            TimeSpan ts = RoundUpDt(KorekceOdchod(dtOdchod)) - RoundUpDt(KorekcePrichod(dtPrichod));
            //TimeSpan ts = dtOdchod - dtPrichod;
            if (!(int.Parse(oTyp_pohyb) == 3))
                //this._sumaLekar += ts;
            //else
                this._sumaHodin += ts;
            
            return ts.ToString(); // dtOdchod.Subtract(dtPrichod); 
        }

        private DateTime KorekcePrichod(DateTime dtPrichod)
        {
            //Nacti nastaveni
           _iOdecti = int.Parse(Registry.GetKey("Odecti", "0"));
            
            DateTime dtPrichodMezi;
            //Casova korekce odchodu a prichodu
            dtPrichodMezi = dtPrichod.AddMinutes(_iOdecti);
            return dtPrichodMezi;
         }
        
        private DateTime KorekceOdchod(DateTime dtOdchod)
        {
            //Nacti nastaveni
            _iOdecti = int.Parse(Registry.GetKey("Odecti", "0"));
            DateTime dtOdchodMezi;
            //Casova korekce odchodu a prichodu
            dtOdchodMezi = dtOdchod.AddMinutes(-_iOdecti);
            return dtOdchodMezi;
        }
        
        private int Zaokrouh(int iSumaHod)
        {
            _iZaokrouh = int.Parse(Registry.GetKey("Zaokrouh", "0"));
            int iZao=0;

            //iZao = Math.Round(iSumaHod, 2, MidpointRounding.AwayFromZero);
            //iZao = Convert.ToInt32(Math.Floor(iSumaHod));
            return iZao;
        }
        private DateTime RoundUpDt(DateTime dtRound)
        {
            _iZaokrouh = int.Parse(Registry.GetKey("Zaokrouh", "0"));
            return Functions.ZaokrouhlRoundUpDt(dtRound, _iZaokrouh);
        }
    }
}
