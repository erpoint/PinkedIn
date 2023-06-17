using System;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
