using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Modele.Mapping
{
    public class StatutMapping : EntityTypeConfiguration<Statut>
    {
        public StatutMapping()
        {
            ToTable("APP_SATUT");
            HasKey(statut => statut.Id);
            Property(statut => statut.Id).IsRequired()
                .HasColumnName("STA_ID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(statut => statut.Libelle).IsRequired()
                .HasColumnName("STA_LIBELLE");
        }
    }
}
