namespace NyilvLib.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelNyilv : DbContext
    {
        public ModelNyilv()
            : base("name=ModelNyilv")
        {
        }

        public virtual DbSet<Alapadatok> Alapadatok { get; set; }
        public virtual DbSet<Cegadatok> Cegadatok { get; set; }
        public virtual DbSet<CegesSzemelyek> CegesSzemelyek { get; set; }
        public virtual DbSet<Dokumentumok> Dokumentumok { get; set; }
        public virtual DbSet<Munkatarsak> Munkatarsak { get; set; }
        public virtual DbSet<Telephelyek> Telephelyek { get; set; }
        public virtual DbSet<Tevekenysegek> Tevekenysegek { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
