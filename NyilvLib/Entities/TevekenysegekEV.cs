namespace NyilvLib.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TevekenysegekEV")]
    public partial class TevekenysegekEV
    {
        [StringLength(16)]
        public string ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Megnevezes { get; set; }
    }
}
