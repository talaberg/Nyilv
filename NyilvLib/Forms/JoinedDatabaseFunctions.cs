using NyilvLib.Entities;
using NyilvLib.Forms;
using NyilvLib.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyilvLib
{
    public partial class JoinedDatabase
    {
        public JoinedDatabase()
        {
        }
        public JoinedDatabase(string s)
        {
            CegID = -1;
            Azonosito = null;
            Cegnev = s;
            Adoszam = s;
            Ceg_forma = s;
            Stat_szamjel = s;
            EU_adoszam = s;
            Cegjegyzek_szam = s;
            Nyilv_szam = s;
            Szerzodott_AZNAP_ceg = s;
            Email = s;
            Hosszunev = s;
            Megalakulas = null;
            Bejegyzes = null;
            Fotevekenyseg = null;
            Tevekenyseg = s;
            Tevekenyseg_vege = null;
            Szekhely = null;
            Telephelyek = null;
            Felhasznalonev = s;
            Jelszo = s;
            Ugyvez_tagok = s;
            Toke = null;
            Nyilvantarto_birosag = s;
            Ugyszam = s;
            Birosagi_hatarozat_szam = s;
            Kozhasznusag_fokozat = s;
            Inaktiv_idoszakok = s;
            Felfuggesztett = null;
            Egyeb_adatok = s;

            Container = null;
            TelephelyekList = null;
            SzekhelyData = null;
        }

        public void SetData()
        {
            SetAlapadatok();
        }

        private void SetAlapadatok()
        {

            CegID                       = Container.CegID;
            Azonosito                   = Container.Azonosito;
            Cegnev                      = Container.Cegnev;
            Adoszam                     = Container.Adoszam;
            Ceg_forma                   = Container.Ceg_forma;
            Stat_szamjel                = Container.Stat_szamjel;
            EU_adoszam                  = Container.EU_adoszam;
            Cegjegyzek_szam             = Container.Cegjegyzek_szam;
            Nyilv_szam                  = Container.Nyilv_szam;
            Szerzodott_AZNAP_ceg        = Container.Szerzodott_AZNAP_ceg;
            Email                       = Container.Email;
            Hosszunev                   = Container.Hosszunev;
            Megalakulas                 = Container.Megalakulas;
            Bejegyzes                   = Container.Bejegyzes;
            Fotevekenyseg               = Container.Fotevekenyseg;
            Tevekenyseg                 = Container.Tevekenyseg;
            Tevekenyseg_vege            = Container.Tevekenyseg_vege;
            Szekhely                    = Container.Szekhely;
            Telephelyek                 = Container.Telephelyek; 
            Felhasznalonev              = Container.Felhasznalonev;
            Jelszo                      = Container.Jelszo;
            Ugyvez_tagok                = Container.Ugyvez_tagok;
            Toke                        = Container.Toke;
            Nyilvantarto_birosag        = Container.Nyilvantarto_birosag;
            Ugyszam                     = Container.Ugyszam;
            Birosagi_hatarozat_szam     = Container.Birosagi_hatarozat_szam;
            Kozhasznusag_fokozat        = Container.Kozhasznusag_fokozat;
            Inaktiv_idoszakok           = Container.Inaktiv_idoszakok;
            Felfuggesztett              = Container.Felfuggesztett;
            Egyeb_adatok                = Container.Egyeb_adatok;

            Container = null;
            TelephelyekList = null;
            SzekhelyData = null;
        }
        private Alapadatok GetAlapadatok()
        {
            Alapadatok A = new Alapadatok();

            A.CegID = CegID;
            A.Azonosito = Azonosito;
            A.Cegnev = Cegnev;
            A.Adoszam = Adoszam;
            A.Ceg_forma = Ceg_forma;
            A.Stat_szamjel = Stat_szamjel;
            A.EU_adoszam = EU_adoszam;
            A.Cegjegyzek_szam = Cegjegyzek_szam;
            A.Nyilv_szam = Nyilv_szam;
            A.Szerzodott_AZNAP_ceg = Szerzodott_AZNAP_ceg;
            A.Email = Email;
            A.Hosszunev = Hosszunev;
            A.Megalakulas = Megalakulas;
            A.Bejegyzes = Bejegyzes;
            A.Fotevekenyseg = Fotevekenyseg;
            A.Tevekenyseg = Tevekenyseg;
            A.Tevekenyseg_vege = Tevekenyseg_vege;
            A.Szekhely = Szekhely;
            A.Telephelyek = Telephelyek;
            A.Felhasznalonev = Felhasznalonev;
            A.Jelszo = Jelszo;
            A.Ugyvez_tagok = Ugyvez_tagok;
            A.Toke = Toke;
            A.Nyilvantarto_birosag = Nyilvantarto_birosag;
            A.Ugyszam = Ugyszam;
            A.Birosagi_hatarozat_szam = Birosagi_hatarozat_szam;
            A.Kozhasznusag_fokozat = Kozhasznusag_fokozat;
            A.Inaktiv_idoszakok = Inaktiv_idoszakok;
            A.Felfuggesztett = Felfuggesztett;
            A.Egyeb_adatok = Egyeb_adatok;

            return A;
        }




    }
}
