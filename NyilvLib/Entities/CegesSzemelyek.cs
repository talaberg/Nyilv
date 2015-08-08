namespace NyilvLib.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CegesSzemelyek")]
    public partial class CegesSzemelyek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CegSzemID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nev { get; set; }

        public int? Taj { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Szul_Ido { get; set; }

        [StringLength(50)]
        public string Anyja { get; set; }

        [StringLength(255)]
        public string Cime { get; set; }

        public int? Adoazon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Mettol { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Meddig { get; set; }

        [StringLength(50)]
        public string Megbizas_minosege { get; set; }
    }
}
