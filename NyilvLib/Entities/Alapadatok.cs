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

        [StringLength(50)]
        public string Szamlazas { get; set; }

        [StringLength(50)]
        public string Felelos { get; set; }

        [Required]
        [StringLength(50)]
        public string Cegnev { get; set; }

        [StringLength(50)]
        public string Ceg_forma { get; set; }

        public string Hivatkozas { get; set; }

        public bool? Felfuggesztett { get; set; }
    }
}
