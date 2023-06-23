using PinkedIn.Point.Labussiere.Modele;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.BusinessLayer.Repositories
{
    public class OffreRepository : IRepository<Offre>
    {
        private ContextDA _context;
        private DbSet<Offre> _offres;
        public OffreRepository()
        {
            this._context = new ContextDA();
            this._offres = this._context.Offres;
        }

        public void DeleteAll()
        {
            foreach (Offre offre in _offres)
            {
                _offres.Remove(offre);
            }

            _context.SaveChanges();
        }

        public void DeleteEntity(Offre entity)
        {
            _offres.Remove(entity);
            _context.SaveChanges();
        }

        public List<Offre> FindAll()
        {
            return _offres.ToList();
        }

        public List<Offre> FindByIntitule(string name)
        {
            return _offres.Where(o => o.Intitule.ToUpper().Contains(name.ToUpper())).ToList();
        }
        public List<Offre> FindByDescription(string description)
        {
            return _offres.Where(o => o.Description.ToUpper().Contains(description.ToUpper())).ToList();
        }
        public List<Offre> FindByInitiuleOrDescription(string searchString)
        {
            return FindByIntitule(searchString).Concat(FindByDescription(searchString)).Distinct().ToList();
        }
        public Offre FindEntity(int id)
        {
            return _offres.Find(id);
        }

        public void InsertEntity(Offre entity)
        {
            _offres.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateEntity(Offre entity)
        {
            var entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
