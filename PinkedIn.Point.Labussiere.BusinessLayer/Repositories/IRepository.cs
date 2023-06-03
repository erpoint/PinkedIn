using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkedIn.Point.Labussiere.BusinessLayer.Repositories
{
    /// <summary>
    /// Interface de repertoire d'entités.
    /// </summary>
    /// <typeparam name="IEntity"></typeparam>
    public interface IRepository<IEntity>
    {
        /// <summary>
        /// Permet de récupérer une entité grâce a son identifiant.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEntity FindEntity(int id);

        /// <summary>
        /// Permet de récupérer toutes les entités d'une collection.
        /// </summary>
        /// <returns></returns>
        List<IEntity> FindAll();

        /// <summary>
        /// Permet d'ajouter une entité à la collection.
        /// </summary>
        /// <param name="entity"></param>
        void InsertEntity(IEntity entity);

        /// <summary>
        /// Permet de supprimer une entité de la collection.
        /// </summary>
        /// <param name="id"></param>
        void DeleteEntity(IEntity entity);

        /// <summary>
        /// Permet de modifier une entité de la collection.
        /// </summary>
        /// <param name="entity"></param>
        void UpdateEntity(IEntity entity);

    }
}
