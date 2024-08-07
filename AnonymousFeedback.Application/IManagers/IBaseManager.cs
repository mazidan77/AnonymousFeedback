﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousFeedback.Domian.IManagers
{
    public interface IBaseManager<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> list);
        Task<int> AddWithComplete(TEntity entity);
        bool Any(Expression<Func<TEntity, bool>> any);
        Task Delete(Expression<Func<TEntity, bool>> where);
        Task Delete(object id);
        void Delete(TEntity entity);
        Task<int> DeleteWithComplete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetById(object id);
        Task<TEntity> GetBy(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetSome(Expression<Func<TEntity, bool>> where);
        void RemoveRange(IEnumerable<TEntity> list);
        void Update(TEntity entity);
        Task<int> UpdateWithComplete(TEntity entity);
    }
}
