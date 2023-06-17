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
    public class StatutRepository: IRepository<Statut>
    {
        private ContextDA _context;
        private DbSet<Statut> _statuts;
        public StatutRepository()
        {
            this._context = new ContextDA();
            this._statuts = this._context.Statuts;
        }

        public void DeleteAll()
        {
            foreach(Statut statut in _statuts)
            {
                _statuts.Remove(statut);
            }

            _context.SaveChanges();
        }

        public void DeleteEntity(Statut entity)
        {
            _statuts.Remove(entity);
            _context.SaveChanges();
        }

        public List<Statut> FindAll()
        {
            return _statuts.ToList();
        }

        public Statut FindEntity(int id)
        {
            return _statuts.Find(id);
        }

        public void InsertEntity(Statut entity)
        {
            _statuts.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateEntity(Statut entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
