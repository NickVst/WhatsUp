using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DbContext _context;
        protected DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public TEntity Get(TEntity entity)
        {
            return _dbSet.Find(entity.Id);
        }

        public IEnumerable<TEntity> Query(TEntity entity)
        {
            var entities = this.GetAll();

            var entityType = typeof(TEntity);
            return entities
                .Where(x =>
                {
                    foreach (var prop in entityType.GetProperties())
                    {
                        var queryPropValue = prop.GetValue(entity);

                        // Do not query not-given properties
                        if (queryPropValue.Equals(null)) continue;

                        // If the current prop mismatches, reject the entity.
                        // In other words, ALL given props must match.
                        var entityPropValue = prop.GetValue(x);
                        if (!queryPropValue.Equals(entityPropValue))
                        {
                            return false;
                        }
                    }
                    // If all given props pass, the entity belongs in the query.
                    return true;
                });
        }

        public TEntity QueryOne(TEntity entity)
        {
            return this.Query(entity).FirstOrDefault();
        }
    }
}