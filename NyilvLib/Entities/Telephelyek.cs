namespace NyilvLib.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Telephelyek")]
    public partial class Telephelyek
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TelepID { get; set; }

        [StringLength(255)]
        public string Cim { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Mettol { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Meddig { get; set; }

        [StringLength(255)]
        public string Megjegyzes { get; set; }
    }
}
