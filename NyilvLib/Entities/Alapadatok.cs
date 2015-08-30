namespace NyilvLib.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alapadatok")]
    public partial class Alapadatok
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public int? Felelos1 { get; set; }

        public int? Felelos2 { get; set; }

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
}
