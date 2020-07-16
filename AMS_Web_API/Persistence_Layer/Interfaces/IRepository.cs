using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence_Layer.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<TEntity> Get(int id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<bool> Exists(Expression<Func<TEntity, bool>> predicate);
        
    }
}