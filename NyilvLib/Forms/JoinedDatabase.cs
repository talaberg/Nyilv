using NyilvLib.Entities;
using NyilvLib.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyilvLib
{
    public partial class JoinedDatabase
    {
        public Alapadatok Container { get; set; }

        public List<Telephelyek> TelephelyekList { get { return telephelyekList; } set { telephelyekList = value; TelephelyekText = value.ToString(); } }
        private List<Telephelyek> telephelyekList = new List<Telephelyek>();
        public string TelephelyekText { get { return (telephelyekList.Count != 0) ? telephelyekList.ExtendedToString() : GuiConstants.DefaultXmlText; } set { } }

        public Telephelyek SzekhelyData { get { return szekhelyData; } set { szekhelyData = value; SzekhelyDataText = value.ToString(); } }
        private Telephelyek szekhelyData = new Telephelyek();
        public string SzekhelyDataText { get { return (szekhelyData.ToString() != "") ? szekhelyData.ToString() : GuiConstants.DefaultXmlText; } set { } }

        public List<CegesSzemelyek> CegesSzemelyekList { get { return cegesSzemelyekList; } set { cegesSzemelyekList = value; CegesSzemelyekListText = value.ToString(); } }
        private List<CegesSzemelyek> cegesSzemelyekList = new List<CegesSzemelyek>();
        public string CegesSzemelyekListText { get { return (cegesSzemelyekList.Count != 0 ) ? cegesSzemelyekList.ExtendedToString() : GuiConstants.DefaultXmlText; } set { } }

        public Inaktiv_idoszakok Inaktiv_idoszakokList { get { return inaktiv_idoszakokList; } set { inaktiv_idoszakokList = value; Inaktiv_idoszakokListText = value.ToString(); } }
        private Inaktiv_idoszakok inaktiv_idoszakokList = new Inaktiv_idoszakok();
        public string Inaktiv_idoszakokListText { get { return (inaktiv_idoszakokList.Inaktiv_idoszak.Count != 0) ? inaktiv_idoszakokList.ToString() : GuiConstants.DefaultXmlText; } set { } }

        public List<Tevekenysegek> TevekenysegekList { get { return tevekenysegekList; } set { tevekenysegekList = value; TevekenysegekListText = value.ToString(); } }
        private List<Tevekenysegek> tevekenysegekList = new List<Tevekenysegek>();
        public string TevekenysegekListText { get { return (tevekenysegekList.Count != 0) ? tevekenysegekList.ExtendedToString() : GuiConstants.DefaultXmlText; } set { } }

        public Tevekenysegek FotevekenysegData { get { return fotevekenysegData; } set { fotevekenysegData = value; FotevekenysegDataText = value.ToString(); } }
        private Tevekenysegek fotevekenysegData = new Tevekenysegek();
        public string FotevekenysegDataText { get { return (fotevekenysegData.ID != null) ? fotevekenysegData.ToString() : GuiConstants.DefaultXmlText; } set { } }

        //-------------------------------------------------------
        //Alapadatok
        public int CegID { get; set; }

        public int? Azonosito { get; set; }

        [Required]
        [StringLength(64)]
        public string Cegnev { get; set; }

        [StringLength(32)]
        public string Adoszam { get; set; }

        [StringLength(32)]
        public string Ceg_forma { get; set; }

        [StringLength(32)]
        public string Stat_szamjel { get; set; }

        [StringLength(32)]
        public string EU_adoszam { get; set; }

        [StringLength(32)]
        public string Cegjegyzek_szam { get; set; }

        [StringLength(32)]
        public string Nyilv_szam { get; set; }

        [StringLength(32)]
        public string Szerzodott_AZNAP_ceg { get; set; }

        public string Felelos1 { get; set; }

        public string Felelos2 { get; set; }

        public string Email { get; set; }

        public string Hosszunev { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Megalakulas { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Bejegyzes { get; set; }

        [StringLength(32)]
        public string Fotevekenyseg { get; set; }

        [Column(TypeName = "xml")]
        public string Tevekenyseg { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tevekenyseg_vege { get; set; }

        public int? Szekhely { get; set; }

        [Column(TypeName = "xml")]
        public string Telephelyek { get; set; }

        [StringLength(64)]
        public string Felhasznalonev { get; set; }

        [StringLength(64)]
        public string Jelszo { get; set; }

        [Column(TypeName = "xml")]
        public string Ugyvez_tagok { get; set; }

        public int? Toke { get; set; }

        [StringLength(64)]
        public string Nyilvantarto_birosag { get; set; }

        [StringLength(64)]
        public string Ugyszam { get; set; }

        [StringLength(64)]
        public string Birosagi_hatarozat_szam { get; set; }

        [StringLength(64)]
        public string Kozhasznusag_fokozat { get; set; }

        [Column(TypeName = "xml")]
        public string Inaktiv_idoszakok { get; set; }

        public bool? Felfuggesztett { get; set; }

        [Column(TypeName = "xml")]
        public string Egyeb_adatok { get; set; }


    }

    public class AdatParok
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
