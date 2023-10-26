using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Application.Interfaces.Persistance.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(ulong id, CancellationToken cancellationToken = default(CancellationToken));
        Task<T> GetById(Guid id, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<T>> GetAllAsyncNoTracking(CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<T>> GetAllAsyncNoTracking(CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<T>> FindAsyncNoTracking(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<T>> FindAsyncNoTracking(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<T, object>>[] includes);

        Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
