using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Habitix.Data.Repositories
{
    public class BaseRepository<T> : IContextReturnable, IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BaseContext _context;

        public BaseRepository(BaseContext context)
        {
            _context = context;
        }

        #region Base repository methods
        public void Delete(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");

            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T Get(long id)
        {
            return _context.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");

            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");
            entity.UpdatedAt = DateTime.UtcNow;
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
        #endregion

        public BaseContext GetContext()
        {
            return _context;
        }
    }
}
