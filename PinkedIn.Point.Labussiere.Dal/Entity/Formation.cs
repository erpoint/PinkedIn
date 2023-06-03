using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Modele.Entity
{
    /// <summary>
    /// Classe représentant une formation.
    /// </summary>
    public class Formation : IEntity
    {
        /// <summary>
        /// Identifiant de la formation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifiant de l'employé associé à la formation.
        /// </summary>
        public int EmployeId { get; set; }

        /// <summary>
        /// Employé asscocié à la formation.
        /// </summary>
        public Employe Employe { get; set; }

        /// <summary>
        /// Intitulé de la formation.
        /// </summary>
        public string Intitule { get; set; }

        /// <summary>
        /// Date d'obtention de la formation.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
