namespace NyilvLib.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Munkatarsak")]
    public partial class Munkatarsak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MunkatarsID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nev { get; set; }
    }
}
