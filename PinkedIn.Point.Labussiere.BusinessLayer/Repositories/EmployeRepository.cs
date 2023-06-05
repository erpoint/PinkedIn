using PinkedIn.Point.Labussiere.Modele;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PinkedIn.Point.Labussiere.BusinessLayer.Repositories
{
    /// <summary>
    /// Repertoire d'employés.
    /// </summary>
    public class EmployeRepository : IRepository<Employe>
    {
        /// <summary>
        /// Contexte de la base de données.
        /// </summary>
        private ContextDA _context;

        /// <summary>
        /// Collection d'employés.
        /// </summary>
        private DbSet<Employe> _employes;

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public EmployeRepository() 
        {
            _context = new ContextDA();
            _employes = _context.Employes;
        }

        /// <inheritdoc />
        /// <param name="id"></param>
        /// <returns></returns>
        public Employe FindEntity(int id)
        {
            return _employes.Find(id);
        }

        /// <inheritdoc />
        /// <returns></returns>
        public List<Employe> FindAll()
        {
            return _employes.ToList();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void InsertEntity(Employe entity)
        {
            _employes.Add(entity);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void DeleteEntity(Employe entity)
        {
            _employes.Remove(entity);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void UpdateEntity(Employe entity)
        {
            var entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }

        /// <inheritdoc />
        public void DeleteAll()
        {
            foreach(Employe employe in _employes)
            {
                _employes.Remove(employe); 
            }

            _context.SaveChanges();
        }
    }
}
