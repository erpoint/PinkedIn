using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkdIn.Point.Labussiere.gui.ViewModel
{
    public class StatutVM: BaseViewModel
    {
        private int id;
        private string libelle;
        private Statut statut;

        public StatutVM(Statut statut)
        {
            this.statut = statut;
            this.id = statut.Id;
            this.libelle = statut.Libelle;
        }

        /// <summary>
        /// Identifiant du statut.
        /// </summary>
        public int Id { get { return id; } set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            } }

        /// <summary>
        /// Libellé du statut.
        /// </summary>
        public string Libelle
        {
            get { return libelle; }
            set
            {
                libelle = value;
                OnPropertyChanged(nameof(Libelle));
            }
        }
    }
}
