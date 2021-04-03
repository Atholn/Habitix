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
        protected readonly BaseContext context;

        public BaseRepository(BaseContext context)
        {
            this.context = context;
        }

        #region Base repository methods
        public void Delete(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");

            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public T Get(long id)
        {
            return context.Set<T>().SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsEnumerable();
        }

        public void Insert(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");

            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity is null)
                throw new ArgumentNullException($"Entity is null {nameof(entity)}");
            entity.UpdatedAt = DateTime.UtcNow;
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
        #endregion

        public BaseContext GetContext()
        {
            return context;
        }
    }
}
