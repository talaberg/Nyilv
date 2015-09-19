﻿using NyilvLib.Entities;
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
            Container = new Alapadatok();
            TelephelyekList = new List<Entities.Telephelyek>();
            SzekhelyData = new Entities.Telephelyek();
            CegesSzemelyekList = new List<CegesSzemelyek>();
            Inaktiv_idoszakokList = new Inaktiv_idoszakok();
            FotevekenysegData  = new Tevekenysegek();
            TevekenysegekList = new List<Tevekenysegek>();
        }
        public void SetData()
        {
            SetAlapadatok();

            Inaktiv_idoszakokList = new Inaktiv_idoszakok();
            Inaktiv_idoszakokList.Parse(Inaktiv_idoszakok);
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
        }
        public Alapadatok GetAlapadatok(List<Munkatarsak> munkatarsak = null)
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

            if (munkatarsak != null)
	        {
                Munkatarsak m = munkatarsak.Find(c => c.Nev == Felelos1);
                if (m != null)
                {
                    A.Felelos1 = m.MunkatarsID;
	            }
                else
                {
                    A.Felelos1 = null;
                }

                m = munkatarsak.Find(c => c.Nev == Felelos2);
                if (m != null)
                {
                    A.Felelos2 = m.MunkatarsID;
                }
                else
                {
                    A.Felelos2 = null;
                }
	        }
            

            return A;
        }




    }
}
