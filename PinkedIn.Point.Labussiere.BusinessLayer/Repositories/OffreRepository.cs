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
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
