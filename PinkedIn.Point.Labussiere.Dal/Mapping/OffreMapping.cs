using PinkedIn.Point.Labussiere.Dal.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Dal.Mapping
{
    public class OffreMapping : EntityTypeConfiguration<Offre>
    {
        public OffreMapping()
        {
            ToTable("APP_OFFRE");
            HasKey(e => e.Id);

            Property(offre => offre.Id).HasColumnName("OFF_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(offre => offre.Intitule).HasColumnName("OFF_INTITULE")
                .IsRequired()
                .HasMaxLength(255);
            Property(offre => offre.Date).HasColumnName("OFF_DATE")
                .IsRequired();
            Property(offre => offre.Salaire).HasColumnName("OFF_SALAIRE")
                .IsRequired();
            Property(offre => offre.Description).HasColumnName("OFF_DESCRIPTION")
                .IsRequired()
                .HasMaxLength(1024);
            Property(offre => offre.Responsable).IsRequired()
                .HasColumnName("OFF_RESPONSSABLE")
                .HasMaxLength(255);
            Property(offre => offre.StatutId)
                .IsRequired()
                .HasColumnName("STA_ID");
            HasRequired(offre => offre.Statut).WithMany()
                .HasForeignKey(offre=>offre.StatutId);
            Property(offre => offre.IdPostulation).IsRequired()
                .HasColumnName("POS_ID");
            HasRequired(offre => offre.Postulation).WithMany()
                .HasForeignKey(offre => offre.IdPostulation);
        }
    }
}
