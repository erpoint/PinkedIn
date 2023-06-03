using PinkedIn.Point.Labussiere.Dal.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Dal.Mapping
{
    public class ExperienceMapping : EntityTypeConfiguration<Experience>
    {
        public ExperienceMapping()
        {
            ToTable("APP_EXPERIENCE");
            HasKey(e => e.Id);

            Property(e => e.Id)
                    .HasColumnName("EXP_ID")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(e => e.EmployeId)
                .HasColumnName("EMP_ID")
                .IsRequired();

            HasRequired(e => e.Employe)
                .WithMany(e => e.Experiences)
                .HasForeignKey(e => e.EmployeId);

            Property(e => e.Intitule)
                .HasColumnName("EXP_INTITULE")
                .IsRequired();

            Property(e => e.Date)
                .HasColumnName("EXP_DATE")
                .IsRequired();
        }
    }
}
