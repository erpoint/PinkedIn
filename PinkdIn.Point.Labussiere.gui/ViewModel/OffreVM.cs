using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkdIn.Point.Labussiere.gui.ViewModel
{
    public class OffreVM : BaseViewModel
    {
        private int id;

        private string intitule;

        private DateTime date;

        private int salaire;

        private string description;

        private int statutId;

        private StatutVM statut;

        private string responsable;

        private string idPostulation;

        public OffreVM(Offre offre)
        {
            Model = offre;
            this.intitule = offre.Intitule;
            this.date = offre.Date;
            this.salaire = offre.Salaire;
            this.description = offre.Description;
            this.responsable = offre.Responsable;
        }
        public OffreVM()
        {

        }

        //private List<PostulationVM> postulation;

        public int Id {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Intitule {
            get
            {
                return intitule;
            }
            set
            {
                intitule = value;
                OnPropertyChanged(nameof(Intitule));
            } 
        }

        public DateTime Date {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public int Salaire {
            get { return salaire; }
            set { 
                salaire = value;
                OnPropertyChanged(nameof(Salaire));
            }
        }

        public string Description { 
            get { return description; }
            set { 
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public StatutVM Statut {
            get { return statut; }
            set { 
                statut = value;
                OnPropertyChanged(nameof(Statut));
            }
        }

        public string Responsable { get; set; }

        public string IdPostulation { get; set; }
        public Offre Model { get; }

        //public List<PostulationVM> Postulation { get; set; }
    }
}
