﻿using Asil_Insaat.Core.Veris;
using Asil_Insaat.Entity.Entities;
using System.Linq.Expressions;

namespace Asil_Insaat.Data.Repostories.Abstractions
{
    public interface IRepository<T> where T : class, IVeriTabani, new()
    {
        Task AddAsync(T entity);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByGuidAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);
    }
}
