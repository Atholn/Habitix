using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Data.Repositories.Interfaces
{
    public interface IBaseRepositoryAsync<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(long id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
