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
        }
    }
}
