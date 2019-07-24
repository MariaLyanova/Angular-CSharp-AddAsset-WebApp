using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> FindAll();
        TEntity Add(TEntity entity);
        void Remove(TEntity entity);
    }
}