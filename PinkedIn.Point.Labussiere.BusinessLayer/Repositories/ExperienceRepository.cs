using PinkedIn.Point.Labussiere.Modele;
using PinkedIn.Point.Labussiere.Modele.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PinkedIn.Point.Labussiere.BusinessLayer.Repositories
{
    /// <summary>
    /// Repertoire d'expériences.
    /// </summary>
    public class ExperienceRepository : IRepository<Experience>
    {
        /// <summary>
        /// Contexte de la base de données.
        /// </summary>
        private ContextDA _context;

        /// <summary>
        /// Collection d'expériences.
        /// </summary>
        private DbSet<Experience> _experiences;

        /// <summary>
        /// Constructeur de la classe.
        /// </summary>
        public ExperienceRepository(string connectionString)
        {
            _context = new ContextDA(connectionString);
            _experiences = _context.Experiences;
        }

        /// <inheritdoc />
        /// <param name="id"></param>
        /// <returns></returns>
        public Experience FindEntity(int id)
        {
            return _experiences.Find(id);
        }

        /// <inheritdoc />
        /// <returns></returns>
        public List<Experience> FindAll()
        {
            return _experiences.ToList();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void InsertEntity(Experience entity)
        {
            _experiences.Add(entity);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void DeleteEntity(Experience entity)
        {
            _experiences.Remove(entity);

            _context.SaveChanges();
        }

        /// <inheritdoc />
        /// <param name="entity"></param>
        public void UpdateEntity(Experience entity)
        {
            var entry = _context.Entry(entity);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
