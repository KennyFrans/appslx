using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Appslx.Common;
using Microsoft.EntityFrameworkCore;

namespace Appslx.Repository.Base
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly DbSet<T> _dbset;
        
        public GenericRepository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual List<T> GetAll()
        {
            return _dbset.ToListAsync<T>().Result;
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IEnumerable<T> query = _dbset.Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity).Entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.Set<T>().AddRange(entities);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity).Entity;
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
