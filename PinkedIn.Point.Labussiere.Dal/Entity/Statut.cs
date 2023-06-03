using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Modele.Entity
{
    /// <summary>
    /// Statut de l'offre.
    /// </summary>
    public class Statut : IEntity
    {
        /// <summary>
        /// Identifiant du statut.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Libellé du statut.
        /// </summary>
        public string Libelle { get; set; }
    }
}
