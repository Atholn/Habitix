using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Data.Repositories
{
    public class BaseRepositoryAsync<T> : IContextReturnable, IBaseRepositoryAsync<T> where T : BaseEntity
    {

        protected readonly BaseContext _context;

        public BaseRepositoryAsync(BaseContext context)
        {
            _context = context;
        }

        public async Task<T> GetAsync(long id)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public BaseContext GetContext()
        {
            throw new NotImplementedException();
        }
    }
}
