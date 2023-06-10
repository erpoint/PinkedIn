using PinkedIn.Point.Labussiere.Modele.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PinkedIn.Point.Labussiere.Modele.Mapping
{
    public class OffreMapping : EntityTypeConfiguration<Offre>
    {
        public OffreMapping()
        {
            ToTable("APP_OFFRE");
            HasKey(e => e.Id);

            Property(offre => offre.Id)
                .HasColumnName("OFF_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(offre => offre.Intitule)
                .HasColumnName("OFF_INTITULE")
                .IsRequired()
                .HasMaxLength(255);
            
            Property(offre => offre.Date)
                .HasColumnName("OFF_DATE")
                .IsRequired();
            
            Property(offre => offre.Salaire)
                .HasColumnName("OFF_SALAIRE")
                .IsRequired();
            
            Property(offre => offre.Description)
                .HasColumnName("OFF_DESCRIPTION")
                .IsRequired()
                .HasMaxLength(1024);
            
            Property(offre => offre.Responsable)
                .IsRequired()
                .HasColumnName("OFF_RESPONSSABLE")
                .HasMaxLength(255);
            
            Property(offre => offre.StatutId)
                .IsRequired()
                .HasColumnName("STA_ID");
            
            HasRequired(offre => offre.Statut)
                .WithMany()
                .HasForeignKey(offre=>offre.StatutId);
        }
    }
}
