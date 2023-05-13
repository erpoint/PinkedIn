using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Dal.Entity
{
    /// <summary>
    /// Classe représentant un employé.
    /// </summary>
    public class Employe
    {
        /// <summary>
        /// Identifiant de l'employé.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom de l'employé.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom de l'employé.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Date de naissance de l'empoyé.
        /// </summary>
        public DateTime DateDeNaissance { get; set; }

        /// <summary>
        /// Ancienneté en année de l'employé.
        /// </summary>
        public int Anciennete { get; set; }

        /// <summary>
        /// Biographie de l'empoyé.
        /// </summary>
        public string Biographie { get; set; }
    }
}
