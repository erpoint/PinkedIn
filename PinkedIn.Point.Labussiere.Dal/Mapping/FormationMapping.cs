using PinkedIn.Point.Labussiere.Dal.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Dal.Mapping
{
    public class FormationMapping : EntityTypeConfiguration<Formation>
    {
        public FormationMapping()
        {
            ToTable("APP_FORMATION");
            HasKey(e => e.Id);

            Property(e => e.Id)
                    .HasColumnName("FOR_ID")
                    .IsRequired()
                    .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(e => e.EmployeId)
                .HasColumnName("EMP_ID")
                .IsRequired();

            HasRequired(e => e.Employe)
                .WithMany(e => e.Formations)
                .HasForeignKey(e => e.EmployeId);

            Property(e => e.Intitule)
                .HasColumnName("FOR_INTITULE")
                .IsRequired();

            Property(e => e.Date)
                .HasColumnName("FOR_DATE")
                .IsRequired();
        }
    }
}
