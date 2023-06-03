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
    public class PostulationMapping : EntityTypeConfiguration<Postulation>
    {
        public PostulationMapping()
        {
            ToTable("APP_POSTULATION");
            HasKey(postulation => new {postulation.Id, postulation.EmployeId});
            Property(postulation => postulation.Id).HasColumnName("OFF_ID")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(postulation => postulation.EmployeId).HasColumnName("EMP_ID")
                .IsRequired();
            Property(postulation => postulation.Date).HasColumnName("POS_DATE")
                .IsRequired();
            Property(postulation => postulation.Statut).HasColumnName("POS_STATUT")
                .IsRequired();
        }
    }
}
