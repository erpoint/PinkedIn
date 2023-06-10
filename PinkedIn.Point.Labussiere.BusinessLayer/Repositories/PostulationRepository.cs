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
    public class PostulationRepository: IRepository<Postulation>
    {
        private ContextDA _context;
        private DbSet<Postulation> _postulations;
        public PostulationRepository()
        {
            this._context = new ContextDA();
            this._postulations = this._context.Postulations;
        }

        public void DeleteAll()
        {
            foreach (Postulation postulation in _postulations)
            {
                _postulations.Remove(postulation);
            }

            _context.SaveChanges();
        }

        public void DeleteEntity(Postulation entity)
        {
            _postulations.Remove(entity);
            _context.SaveChanges();
        }

        public List<Postulation> FindAll()
        {
            return _postulations.ToList();
        }

        public Postulation FindEntity(int id)
        {
            return _postulations.Find(id);
        }

        public void InsertEntity(Postulation entity)
        {
            _postulations.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateEntity(Postulation entity)
        {
            var entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
