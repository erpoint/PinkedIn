using PinkedIn.Point.Labussiere.Modele.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PinkedIn.Point.Labussiere.Modele.Mapping
{
    public class PostulationMapping : EntityTypeConfiguration<Postulation>
    {
        public PostulationMapping()
        {
            ToTable("APP_POSTULATION");
            
            HasKey(postulation => new {postulation.Id, postulation.EmployeId});
            
            Property(postulation => postulation.Id)
                .HasColumnName("POS_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(postulation => postulation.OffreId)
                .HasColumnName("OFF_ID")
                .IsRequired();

            HasRequired(e => e.Offre)
                .WithMany(e => e.Postulations)
                .HasForeignKey(e => e.OffreId);

            Property(postulation => postulation.EmployeId)
                .HasColumnName("EMP_ID")
                .IsRequired();

            HasRequired(e => e.Employe)
                .WithMany(e => e.Postulations)
                .HasForeignKey(e => e.EmployeId);
            
            Property(postulation => postulation.Date)
                .HasColumnName("POS_DATE")
                .IsRequired();
            
            Property(postulation => postulation.Statut)
                .HasColumnName("POS_STATUT")
                .IsRequired();
        }
    }
}
