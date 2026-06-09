using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace du_lich_bien_ba_dong.Models
{
    public class BienBaDongDbContext : DbContext
    {
        public BienBaDongDbContext() : base("name=BienBaDongDB")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<TinTuc> TinTucs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Doctor>()
            //    .HasRequired(d => d.Specialty)
            //    .WithMany(s => s.Doctors)
            //    .HasForeignKey(d => d.SpecialtyId)
            //    .WillCascadeOnDelete(false);
        }
    }
}
