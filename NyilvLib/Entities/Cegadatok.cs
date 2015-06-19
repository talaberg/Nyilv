namespace NyilvLib.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cegadatok")]
    public partial class Cegadatok
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CegID { get; set; }

        public string Ceg_teljes_nev { get; set; }

        public string Telephely { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Telefon { get; set; }

        public int? Tarifa { get; set; }
    }
}
