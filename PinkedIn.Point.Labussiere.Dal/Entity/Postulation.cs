using System;
using System.ComponentModel.DataAnnotations;

namespace PinkedIn.Point.Labussiere.Modele.Entity
{
    /// <summary>
    /// Classe qui represente une postulation d'unn employé
    /// </summary>
    public class Postulation : IEntity
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
        /// Employé asscocié à la postulation.
        /// </summary>
        public Employe Employe { get; set; }

        /// <summary>
        /// Id de l'offre qui possède la postulation.
        /// </summary>
        public int OffreId { get; set; }

        /// <summary>
        /// Offre associée à la postulation.
        /// </summary>
        public Offre Offre { get; set; }

        /// <summary>
        /// Date de la postulation
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Statut de la postulation
        /// </summary>
        public string Statut { get; set; }
    }
}
