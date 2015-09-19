using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyilvLib.Forms
{
    public class DataGridViewOptions
    {
        public List<DataField> Fields
        {
            get
            {
                List<DataField> fields = new List<DataField>();
                return fields;
            }
        }
    }
    public class DataField
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
    public static class GuiConstants
    {
        public static class Azonosito
        {
            public const string Name = "Azonosito";
            public const string Text = "Azonosító";
            public const int Group = 1;
        }
        public static class Cegnev
        {
            public const string Name = "Cegnev";
            public const string Text = "Cégnév";
            public const int Group = 1;
        }
        public static class Adoszam
        {
            public const string Name = "Adoszam";
            public const string Text = "Adószám";
            public const int Group = 1;
        }
        public static class Ceg_forma
        {
            public const string Name = "Ceg_forma";
            public const string Text = "Cég forma";
            public const int Group = 1;
        }
        public static class Stat_szamjel
        {
            public const string Name = "Stat_szamjel";
            public const string Text = "Statisztikai számjel";
            public const int Group = 1;
        }
        public static class EU_adoszam
        {
            public const string Name = "EU_adoszam";
            public const string Text = "EU adószám";
            public const int Group = 1;
        }
        public static class Cegjegyzek_szam
        {
            public const string Name = "Cegjegyzek_szam";
            public const string Text = "Cégjegyzék szám";
            public const int Group = 1;
        }
        public static class Nyilv_szam
        {
            public const string Name = "Nyilv_szam";
            public const string Text = "Nyilvántartási szám";
            public const int Group = 1;
        }
        public static class Szerzodott_AZNAP_ceg
        {
            public const string Name = "Szerzodott_AZNAP_ceg";
            public const string Text = "Szerződött AZNAP cég";
            public const int Group = 2;
        }
        public static class Felelos1
        {
            public const string Name = "Felelos1";
            public const string Text = "Felelős 1";
            public const int Group = 2;
        }
        public static class Felelos2
        {
            public const string Name = "Felelos2";
            public const string Text = "Felelős 2";
            public const int Group = 2;
        }
        public static class Email
        {
            public const string Name = "Email";
            public const string Text = "E-mail";
            public const int Group = 3;
        }
        public static class Hosszunev
        {
            public const string Name = "Hosszunev";
            public const string Text = "Hosszú név";
            public const int Group = 3;
        }
        public static class Megalakulas
        {
            public const string Name = "Megalakulas";
            public const string Text = "Megalakulás";
            public const int Group = 3;
        }  
        public static class Bejegyzes
        {
            public const string Name = "Bejegyzes";
            public const string Text = "Bejegyzés";
            public const int Group = 3;
        }   
        public static class Fotevekenyseg
        {
            public const string Name = "Fotevekenyseg";
            public const string Text = "Fő tevékenység";
            public const int Group = 3;
        }  
        public static class Tevekenyseg
        {
            public const string Name = "Tevekenyseg";
            public const string Text = "Tevékenység";
            public const int Group = 3;
        }             
        public static class Tevekenyseg_vege
        {
            public const string Name = "Tevekenyseg_vege";
            public const string Text = "Tevékenység vége";
            public const int Group = 3;
        }   
        public static class Szekhely
        {
            public const string Name = "Szekhely";
            public const string Text = "Székhely";
            public const int Group = 4;
        }   
        public static class Telephelyek
        {
            public const string Name = "Telephelyek";
            public const string Text = "Telephelyek";
            public const int Group = 4;
        }    
        public static class Felhasznalonev
        {
            public const string Name = "Felhasznalonev";
            public const string Text = "Felhasznalónév";
            public const int Group = 4;
        }  
        public static class Jelszo
        {
            public const string Name = "Jelszo";
            public const string Text = "Jelszó";
            public const int Group = 4;
        }  
        public static class Ugyvez_tagok
        {
            public const string Name = "Ugyvez_tagok";
            public const string Text = "Ügyvezetők, tagok";
            public const int Group = 5;
        }
        public static class Toke
        {
            public const string Name = "Toke";
            public const string Text = "Jegyzett tőke";
            public const int Group = 6;
        }
        public static class Nyilvantarto_birosag
        {
            public const string Name = "Nyilvantarto_birosag";
            public const string Text = "Nyilvántartó bíróság";
            public const int Group = 6;
        }
        public static class Ugyszam
        {
            public const string Name = "Ugyszam";
            public const string Text = "Ügyszám";
            public const int Group = 6;
        }
        public static class Birosagi_hatarozat_szam
        {
            public const string Name = "Birosagi_hatarozat_szam";
            public const string Text = "Bírósági határozat száma";
            public const int Group = 6;
        }    
        public static class Kozhasznusag_fokozat
        {
            public const string Name = "Kozhasznusag_fokozat";
            public const string Text = "Közhasznúsági fokozat";
            public const int Group = 6;
        }  
        public static class Inaktiv_idoszakok
        {
            public const string Name = "Inaktiv_idoszakok";
            public const string Text = "Inakítv időszakok";
            public const int Group = 7;
        }  
        public static class Felfuggesztett
        {
            public const string Name = "Felfuggesztett";
            public const string Text = "Felfüggesztett";
            public const int Group = 7;
        }
        public static class Egyeb_adatok
        {
            public const string Name = "Egyeb_adatok";
            public const string Text = "Egyéb adatok";
            public const int Group = 8;
        }
        //---------------------------------------------------
        // Telephelyek
        public static class Telephely_Cim
        {
            public const string Name = "Telephely_Cim";
            public const string Text = "Cím";
            public const int Group = 4;
        }
        public static class Telephely_Mettol
        {
            public const string Name = "Telephely_Mettol";
            public const string Text = "Mettől";
            public const int Group = 4;
        }
        public static class Telephely_Meddig
        {
            public const string Name = "Telephely_Meddig";
            public const string Text = "Meddig";
            public const int Group = 4;
        }
        //---------------------------------------------------

        //---------------------------------------------------
        // CegesSzemelyek

        public static class CegesSzemely_Nev
        {
            public const string Name = "CegesSzemely_Nev";
            public const string Text = "Név";
            public const int Group = 5;
        }
        public static class CegesSzemely_Taj
        {
            public const string Name = "CegesSzemely_Taj";
            public const string Text = "TAJ szám";
            public const int Group = 5;
        }
        public static class CegesSzemely_Szul_Ido
        {
            public const string Name = "CegesSzemely_Szul_Ido";
            public const string Text = "Születési idő";
            public const int Group = 5;
        }
        public static class CegesSzemely_Anyja
        {
            public const string Name = "CegesSzemely_Anyja";
            public const string Text = "Anyja neve";
            public const int Group = 5;
        }
        public static class CegesSzemely_Cime
        {
            public const string Name = "CegesSzemely_Cime";
            public const string Text = "Címe";
            public const int Group = 5;
        }
        public static class CegesSzemely_Adoazon
        {
            public const string Name = "CegesSzemely_Adoazon";
            public const string Text = "Adóazonosító";
            public const int Group = 5;
        }
        public static class CegesSzemely_Mettol
        {
            public const string Name = "CegesSzemely_Mettol";
            public const string Text = "Mettől";
            public const int Group = 5;
        }
        public static class CegesSzemely_Meddig
        {
            public const string Name = "CegesSzemely_Meddig";
            public const string Text = "Meddig";
            public const int Group = 5;
        }
        public static class CegesSzemely_Megbizas_minosege
        {
            public const string Name = "CegesSzemely_Megbizas_minosege";
            public const string Text = "Megbízás minősége";
            public const int Group = 5;
        }
        //---------------------------------------------------

        //---------------------------------------------------
        // Inaktiv idoszakok
        public static class Inaktiv_idoszakok_Mettol
        {
            public const string Name = "Mettol";
            public const string Text = "Mettől";
            public const int Group = 7;
        }
        public static class Inaktiv_idoszakok_Meddig
        {
            public const string Name = "Meddig";
            public const string Text = "Meddig";
            public const int Group = 7;
        }
        //---------------------------------------------------

        //---------------------------------------------------
        // Tevekenysegek
        public static class Tevekenyseg_ID
        {
            public const string Name = "Tevekenyseg_ID";
            public const string Text = "Tevékenység azonosító";
            public const int Group = 7;
        }
        public static class Tevekenyseg_Megnevezes
        {
            public const string Name = "Tevekenyseg_Megnevezes";
            public const string Text = "Tevékenység megnevezése";
            public const int Group = 7;
        }
        //---------------------------------------------------
        public static class TelephelyekText
        {
            public const string Name = "TelephelyekText";
            public const string Text = GuiConstants.Telephelyek.Text;
            public const int Group = GuiConstants.Telephelyek.Group;
        }
        public static class SzekhelyDataText
        {
            public const string Name = "SzekhelyDataText";
            public const string Text = GuiConstants.Szekhely.Text;
            public const int Group = GuiConstants.Szekhely.Group;
        }
        public static class CegesSzemelyekListText
        {
            public const string Name = "CegesSzemelyekListText";
            public const string Text = GuiConstants.Ugyvez_tagok.Text;
            public const int Group = GuiConstants.Ugyvez_tagok.Group;
        }
        public static class Inaktiv_idoszakokListText
        {
            public const string Name = "Inaktiv_idoszakokListText";
            public const string Text = GuiConstants.Inaktiv_idoszakok.Text;
            public const int Group = GuiConstants.Inaktiv_idoszakok.Group;
        }
        public static class TevekenysegekListText
        {
            public const string Name = "TevekenysegekListText";
            public const string Text = GuiConstants.Tevekenyseg.Text;
            public const int Group = GuiConstants.Tevekenyseg.Group;
        }
        public static class FotevekenysegDataText
        {
            public const string Name = "FotevekenysegDataText";
            public const string Text = GuiConstants.Fotevekenyseg.Text;
            public const int Group = GuiConstants.Fotevekenyseg.Group;
        }

        // Others ------------------------------------------
        public static class KulcsElvalasztojel
        {
            public const string Name = "KulcsElvalasztojel";
            public const string Text = ": ";
        }
        public static class MezoElvalasztojel
        {
            public const string Name = "MezoElvalasztojel";
            public const string Text = "; ";
        }


        public const string DefaultXmlText = "< ... >";


        public static string GetHeader(string s)
        {
            switch (s)
            {
                case GuiConstants.Adoszam.Name:                   return GuiConstants.Adoszam.Text;
                case GuiConstants.Azonosito.Name:                 return GuiConstants.Azonosito.Text;
                case GuiConstants.Bejegyzes.Name:                 return GuiConstants.Bejegyzes.Text;
                case GuiConstants.Birosagi_hatarozat_szam.Name:   return GuiConstants.Birosagi_hatarozat_szam.Text;
                case GuiConstants.Ceg_forma.Name:                 return GuiConstants.Ceg_forma.Text;
                case GuiConstants.Cegjegyzek_szam.Name:           return GuiConstants.Cegjegyzek_szam.Text;
                case GuiConstants.Cegnev.Name:                    return GuiConstants.Cegnev.Text;
                case GuiConstants.Egyeb_adatok.Name:              return GuiConstants.Egyeb_adatok.Text;
                case GuiConstants.Email.Name:                     return GuiConstants.Email.Text;
                case GuiConstants.EU_adoszam.Name:                return GuiConstants.EU_adoszam.Text;
                case GuiConstants.Felelos1.Name:                  return GuiConstants.Felelos1.Text;
                case GuiConstants.Felelos2.Name:                  return GuiConstants.Felelos2.Text;
                case GuiConstants.Felfuggesztett.Name:            return GuiConstants.Felfuggesztett.Text;
                case GuiConstants.Felhasznalonev.Name:            return GuiConstants.Felhasznalonev.Text;
                case GuiConstants.Fotevekenyseg.Name:             return GuiConstants.Fotevekenyseg.Text;
                case GuiConstants.Hosszunev.Name:                 return GuiConstants.Hosszunev.Text;
                case GuiConstants.Inaktiv_idoszakok.Name:         return GuiConstants.Inaktiv_idoszakok.Text;
                case GuiConstants.Jelszo.Name:                    return GuiConstants.Jelszo.Text;
                case GuiConstants.Kozhasznusag_fokozat.Name:      return GuiConstants.Kozhasznusag_fokozat.Text;
                case GuiConstants.Megalakulas.Name:               return GuiConstants.Megalakulas.Text;
                case GuiConstants.Nyilv_szam.Name:                return GuiConstants.Nyilv_szam.Text;
                case GuiConstants.Nyilvantarto_birosag.Name:      return GuiConstants.Nyilvantarto_birosag.Text;
                case GuiConstants.Stat_szamjel.Name:              return GuiConstants.Stat_szamjel.Text;
                case GuiConstants.Szekhely.Name:                  return GuiConstants.Szekhely.Text;
                case GuiConstants.Szerzodott_AZNAP_ceg.Name:      return GuiConstants.Szerzodott_AZNAP_ceg.Text;
                case GuiConstants.Telephelyek.Name:               return GuiConstants.Telephelyek.Text;
                case GuiConstants.Tevekenyseg.Name:               return GuiConstants.Tevekenyseg.Text;
                case GuiConstants.Tevekenyseg_vege.Name:          return GuiConstants.Tevekenyseg_vege.Text;
                case GuiConstants.Toke.Name:                      return GuiConstants.Toke.Text;
                case GuiConstants.Ugyszam.Name:                   return GuiConstants.Ugyszam.Text;
                case GuiConstants.Ugyvez_tagok.Name:              return GuiConstants.Ugyvez_tagok.Text;
                case GuiConstants.TelephelyekText.Name:           return GuiConstants.TelephelyekText.Text;
                case GuiConstants.SzekhelyDataText.Name:          return GuiConstants.SzekhelyDataText.Text;
                case GuiConstants.CegesSzemelyekListText.Name:    return GuiConstants.CegesSzemelyekListText.Text;
                case GuiConstants.Inaktiv_idoszakokListText.Name: return GuiConstants.Inaktiv_idoszakokListText.Text;
                case GuiConstants.TevekenysegekListText.Name:     return GuiConstants.TevekenysegekListText.Text;
                case GuiConstants.FotevekenysegDataText.Name:     return GuiConstants.FotevekenysegDataText.Text;
                default: return "";
            }
        }
        public static int GetGroup(string s)
        {
            switch (s)
            {
                case GuiConstants.Adoszam.Name:                   return GuiConstants.Adoszam.Group;
                case GuiConstants.Azonosito.Name:                 return GuiConstants.Azonosito.Group;
                case GuiConstants.Bejegyzes.Name:                 return GuiConstants.Bejegyzes.Group;
                case GuiConstants.Birosagi_hatarozat_szam.Name:   return GuiConstants.Birosagi_hatarozat_szam.Group;
                case GuiConstants.Ceg_forma.Name:                 return GuiConstants.Ceg_forma.Group;
                case GuiConstants.Cegjegyzek_szam.Name:           return GuiConstants.Cegjegyzek_szam.Group;
                case GuiConstants.Cegnev.Name:                    return GuiConstants.Cegnev.Group;
                case GuiConstants.Egyeb_adatok.Name:              return GuiConstants.Egyeb_adatok.Group;
                case GuiConstants.Email.Name:                     return GuiConstants.Email.Group;
                case GuiConstants.EU_adoszam.Name:                return GuiConstants.EU_adoszam.Group;
                case GuiConstants.Felelos1.Name:                  return GuiConstants.Felelos1.Group;
                case GuiConstants.Felelos2.Name:                  return GuiConstants.Felelos2.Group;
                case GuiConstants.Felfuggesztett.Name:            return GuiConstants.Felfuggesztett.Group;
                case GuiConstants.Felhasznalonev.Name:            return GuiConstants.Felhasznalonev.Group;
                case GuiConstants.Fotevekenyseg.Name:             return GuiConstants.Fotevekenyseg.Group;
                case GuiConstants.Hosszunev.Name:                 return GuiConstants.Hosszunev.Group;
                case GuiConstants.Inaktiv_idoszakok.Name:         return GuiConstants.Inaktiv_idoszakok.Group;
                case GuiConstants.Jelszo.Name:                    return GuiConstants.Jelszo.Group;
                case GuiConstants.Kozhasznusag_fokozat.Name:      return GuiConstants.Kozhasznusag_fokozat.Group;
                case GuiConstants.Megalakulas.Name:               return GuiConstants.Megalakulas.Group;
                case GuiConstants.Nyilv_szam.Name:                return GuiConstants.Nyilv_szam.Group;
                case GuiConstants.Nyilvantarto_birosag.Name:      return GuiConstants.Nyilvantarto_birosag.Group;
                case GuiConstants.Stat_szamjel.Name:              return GuiConstants.Stat_szamjel.Group;
                case GuiConstants.Szekhely.Name:                  return GuiConstants.Szekhely.Group;
                case GuiConstants.Szerzodott_AZNAP_ceg.Name:      return GuiConstants.Szerzodott_AZNAP_ceg.Group;
                case GuiConstants.Telephelyek.Name:               return GuiConstants.Telephelyek.Group;
                case GuiConstants.Tevekenyseg.Name:               return GuiConstants.Tevekenyseg.Group;
                case GuiConstants.Tevekenyseg_vege.Name:          return GuiConstants.Tevekenyseg_vege.Group;
                case GuiConstants.Toke.Name:                      return GuiConstants.Toke.Group;
                case GuiConstants.Ugyszam.Name:                   return GuiConstants.Ugyszam.Group;
                case GuiConstants.Ugyvez_tagok.Name:              return GuiConstants.Ugyvez_tagok.Group;
                case GuiConstants.TelephelyekText.Name:           return GuiConstants.TelephelyekText.Group;
                case GuiConstants.SzekhelyDataText.Name:          return GuiConstants.SzekhelyDataText.Group;
                case GuiConstants.CegesSzemelyekListText.Name:    return GuiConstants.CegesSzemelyekListText.Group;
                case GuiConstants.Inaktiv_idoszakokListText.Name: return GuiConstants.Inaktiv_idoszakokListText.Group;
                case GuiConstants.TevekenysegekListText.Name:     return GuiConstants.TevekenysegekListText.Group;
                case GuiConstants.FotevekenysegDataText.Name:     return GuiConstants.FotevekenysegDataText.Group;

                default: return -1;
            }
        }

        public static class GroupDescription
        {
            public static int GroupSize(int group)
            {
                switch (group)
	            {
                    case 1: return 8;
                    case 2: return 3;
                    case 3: return 7;
                    case 4: return 4;
                    case 5: return 1;
                    case 6: return 5;
                    case 7: return 2;
                    case 8: return 1;
		            default: return -1;
	            }
            }
        }
    }
}
