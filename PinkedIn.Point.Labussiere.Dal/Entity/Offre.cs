using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PinkedIn.Point.Labussiere.Modele.Entity
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
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
        /// Postulations associées à l'offre.
        /// </summary>
        public List<Postulation> Postulations { get; set; }
    }
}
