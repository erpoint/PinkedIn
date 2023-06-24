using PinkedIn.Point.Labussiere.BusinessLayer.Repositories;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkdIn.Point.Labussiere.gui.ViewModel
{
    public class OffresVM : BaseViewModel
    {
        private List<OffreVM> _offres;
        private OffreVM _selectedItem;

        public OffresVM() : base()
        {
            OffreRepository offreRepository = new OffreRepository();
            _offres = new List<OffreVM>();
            foreach (Offre offre in offreRepository.FindAll())
            {
                _offres.Add(new OffreVM(offre));
            }
            SelectedOffre = _offres.FirstOrDefault();

        }

        public List<OffreVM> Offres { 
            get { return _offres; }
            set { 
                _offres = value;
                OnPropertyChanged("Offres");
            } 
        }

        public OffreVM SelectedOffre { 
            get { return _selectedItem; }
            set {
                _selectedItem = value;
                OnPropertyChanged("SelectedOffre");
            } 
        }
    }
}
