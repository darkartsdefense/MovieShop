using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    //Base CRUD operations that can be used across multiple repositories
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> ListAllAsync();

        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);

        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}