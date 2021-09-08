using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using dotnet_basic.Models;

namespace dotnet_basic.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T> GetById(Guid id);
        Task Add(T entity);
        Task Update(Guid id, T entity);
        Task Remove(Guid id);
        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
    }
}