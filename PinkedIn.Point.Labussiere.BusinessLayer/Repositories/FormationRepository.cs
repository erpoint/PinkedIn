using PinkedIn.Point.Labussiere.Modele;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PinkedIn.Point.Labussiere.BusinessLayer.Repositories
{
    /// <summary>
    /// Repertoire de formations.
    /// </summary>
    public class FormationRepository : IRepository<Formation>
    {
        /// <summary>
        /// Contexte de la base de données.
        /// </summary>
        private ContextDA _context;

        /// <summary>
        /// Collection de formations.
        /// </summary>
        private DbSet<Formation> _formations;

        /// <summary>
        /// Constructeur de la clase.
        /// </summary>
        public FormationRepository()
        {
            _context = new ContextDA();
            _formations = _context.Formations;
        }

        /// <inheritdoc />
        /// <param name="id"></param>
        /// <returns></returns>
        public Formation FindEntity(int id)
        {
            return _formations.Find(id);
        }

        /// <inheritdoc />
        /// <returns></returns>
        public List<Formation> FindAll()
        {
            return _formations.ToList();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void InsertEntity(Formation entity)
        {
            _formations.Add(entity);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void DeleteEntity(Formation entity)
        {
            _formations.Remove(entity);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void UpdateEntity(Formation entity)
        {
            var entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
