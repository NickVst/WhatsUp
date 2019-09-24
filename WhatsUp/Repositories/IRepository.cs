using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Gets an entity whose ID matches the parameter entity's.
        /// </summary>
        TEntity Get(TEntity entity);
        /// <summary>
        /// Gets all entities of this type in the database.
        /// </summary>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Adds the given entity to the database.
        /// </summary>
        void Insert(TEntity entity);
        /// <summary>
        /// Removes the given entity from the database.
        /// </summary>
        void Delete(TEntity entity);
        /// <summary>
        /// Gets a list of entities whose properties match
        /// the ones given in the parameter's.
        /// </summary>
        IEnumerable<TEntity> Query(TEntity entity);
        /// <summary>
        /// Gets the first entity whose properties match
        /// the ones given in the parameter's.
        /// </summary>
        TEntity QueryOne(TEntity entity);
        

    }
}