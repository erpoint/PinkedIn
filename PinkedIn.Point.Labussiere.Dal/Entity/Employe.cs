﻿using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.Modele.Entity
{
    /// <summary>
    /// Classe représentant un employé.
    /// </summary>
    public class Employe : IEntity
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

        /// <summary>
        /// Formations associées à l'employé.
        /// </summary>
        public List<Formation> Formations { get; set; }

        /// <summary>
        /// Expériences associées à l'employé.
        /// </summary>
        public List<Experience> Experiences { get; set; }
        
        /// <summary>
        /// Postulations associées à l'employé.
        /// </summary>
        public List<Postulation> Postulations { get; set; }
    }
}