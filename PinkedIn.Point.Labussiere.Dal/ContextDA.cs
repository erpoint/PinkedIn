using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Modele
{
    public class ContextDA : DbContext
    {
        public ContextDA() : base("name=PinkedInConnectionString") { }

        public DbSet<Employe> Employes { get; set; }
        public DbSet<Employe> Formations { get; set; }
        public DbSet<Employe> Experiences { get; set; }
        public DbSet<Employe> Offres { get; set; }
        public DbSet<Employe> Postulations { get; set; }
        public DbSet<Employe> Status { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
