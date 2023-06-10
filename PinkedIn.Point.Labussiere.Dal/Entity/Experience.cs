using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Modele.Entity
{
    /// <summary>
    /// Classe représentant une expérience.
    /// </summary>
    public class Experience : IEntity
    {
        /// <summary>
        /// Identifiant de l'expérience.
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Identifiant de l'employé associé à l'expérience.
        /// </summary>
        public int EmployeId { get; set; }

        /// <summary>
        /// Employé asscocié à la formation.
        /// </summary>
        public Employe Employe { get; set; }

        /// <summary>
        /// Intitulé de l'expérience.
        /// </summary>
        public string Intitule { get; set; }

        /// <summary>
        /// Date d'obtention de l'expérience.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
