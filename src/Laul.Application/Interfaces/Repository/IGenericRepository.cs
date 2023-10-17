using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Application.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GeyById(int id); 
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
