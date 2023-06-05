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
    /// <summary>
    /// Conexte de la base de données.
    /// </summary>
    public class ContextDA : DbContext
    {
        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ContextDA(string connectionString) : base($"name={connectionString}") { }

        public DbSet<Employe> Employes { get; set; }
        public DbSet<Formation> Formations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Offre> Offres { get; set; }
        public DbSet<Postulation> Postulations { get; set; }
        public DbSet<Statut> Statuts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
