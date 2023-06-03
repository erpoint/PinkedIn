using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Dal.Entity
{
    /// <summary>
    /// Classe représentant une offre.
    /// </summary>
    public class Offre : IEntity
    {
        /// <summary>
        /// Identifiant de l'offre.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Intitulé de l'offre.
        /// </summary>
        public string Intitule { get; set; }

        /// <summary>
        /// Date de l'offre.
        /// </summary>
        public DateTime Date { get; set; }
        
        /// <summary>
        /// Salaire de l'offre.
        /// </summary>
        public int Salaire { get; set; }

        /// <summary>
        /// Description de l'offre.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Identifiant du statut de l'offre.
        /// </summary>
        public int StatutId { get; set; }

        /// <summary>
        /// Statut de l'offre.
        /// </summary>
        public Statut Statut { get; set; }

        /// <summary>
        /// Responsable de l'offre.
        /// </summary>
        public string Responsable { get; set; }

        /// <summary>
        /// Identifiant de la postulation associée à l'offre.
        /// </summary>
        public string IdPostulation { get; set; }

        /// <summary>
        /// Postulation associée à l'offre.
        /// </summary>
        public Postulation Postulation { get; set; }
    }
}
