using CantinaFacil.Shared.Kernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CantinaFacil.Shared.Kernel.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entity);

        Task<T?> GetByIdAsync(params object[] ids);

        Task<IEnumerable<T>> GetAllAsync();

        void Update(T entity);

        void Update(T current, T updated);

        void UpdateRange(IEnumerable<T> entity);        

        Task RemoveAsync(params object[] ids);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
