using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Domian.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Any(Expression<Func<TEntity, bool>> where);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> list);
        Task Delete(object id);

        void Delete(TEntity entity);

        Task Delete(Expression<Func<TEntity, bool>> where);

        void RemoveRange(IEnumerable<TEntity> list);

        Task<TEntity> GetById(object id);

        IEnumerable<TEntity> GetSome(Expression<Func<TEntity, bool>> where);

        IEnumerable<TEntity> GetAll();
        void Update(TEntity entity);

    }
        
}
