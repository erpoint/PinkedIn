using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Dal.Entity
{
    /// <summary>
    /// Classe qui represente une postulation d'unn employé
    /// </summary>
    public class Postulation
    {
        /// <summary>
        /// Id de la postulation
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Id de l'employé qui possède la postulation
        /// </summary>
        public int EmployeId { get; set; }

        /// <summary>
        /// Date de la postulation
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Statut de la postulation
        /// </summary>
        public string Statut { get; set; }
    }
}
