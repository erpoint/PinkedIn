    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Dal.Entity
{
    public class Offre
    {
        public int Id { get; set; }
        public string Intitule { get; set; }
        public DateTime Date { get; set; }
        public int Salaire { get; set; }
        public string Description { get; set; }
        public int StatutId { get; set; }
        public Statut Statut { get; set; }
        public string Responsable { get; set; }
        public string IdPostulation { get; set; }
        public Postulation Postulation { get; set; }
    }
}
