using PinkedIn.Point.Labussiere.Modele;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PinkedIn.Point.Labussiere.BusinessLayer.Repositories
{
    public class EmployeRepository : IRepository<Employe>
    {
        private ContextDA _context;
        private DbSet<Employe> _employes;

        public EmployeRepository() 
        {
            _context = new ContextDA();
            _employes = _context.Employes;
        }
        public Employe FindEntity(int id)
        {
            return _employes.Find(id);
        }

        public List<Employe> FindAll()
        {
            return _employes.ToList();
        }

        public void InsertEntity(Employe entity)
        {
            _employes.Add(entity);

            _context.SaveChanges();
        }

        public void DeleteEntity(Employe entity)
        {
            _employes.Remove(entity);

            _context.SaveChanges();
        }

        public void UpdateEntity(Employe entity)
        {
            var entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
