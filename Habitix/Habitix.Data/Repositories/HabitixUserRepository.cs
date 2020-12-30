using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Habitix.Data.Repositories
{
    public class HabitixUserRepository: BaseRepository<HabitixUser>, IHabitixUserRepository
    {
        public HabitixUserRepository(BaseContext context) : base(context)
        {
            
        }

        public HabitixUser GetHabitixUser(long Id)
        {
            return context.HabitixUsers
                .Include(x => x.Habits)
                .FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<HabitixUser> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
