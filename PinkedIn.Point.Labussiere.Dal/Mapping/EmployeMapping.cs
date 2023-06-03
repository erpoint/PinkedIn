using PinkedIn.Point.Labussiere.Dal.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Dal.Mapping
{
    public class EmployeMapping : EntityTypeConfiguration<Employe>
    {
        public EmployeMapping()
        {
            ToTable("APP_EMPLOYE");
            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("EMP_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            
            Property(e => e.Nom)
                .HasColumnName("EMP_NOM")
                .IsRequired();

            Property(e => e.Prenom)
                .HasColumnName("EMP_PRENOM")
                .IsRequired();

            Property(e => e.DateDeNaissance)
                .HasColumnName("EMP_DATENAISSANCE")
                .IsRequired();

            Property(e => e.Anciennete)
                .HasColumnName("EMP_ANCIENNETE")
                .IsRequired();

            Property(e => e.Biographie)
                .HasColumnName("EMP_BIOGRAPHIE")
                .IsRequired();
        }
    }
}
