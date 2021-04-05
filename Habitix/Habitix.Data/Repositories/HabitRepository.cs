using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Data.Repositories
{
    public class HabitRepository : BaseRepository<Habit>, IHabitRepository
    {
        public HabitRepository(BaseContext context) : base(context)
        {

        }

        public List<Habit> GetAllByHabitixUserId(long id)
        {
            return  _context.Habits
                    .Where(h => h.HabitixUserId == id)
                    .ToList();            
        }

        public async Task<IEnumerable<Habit>> GetAllByUserIdAsync(string id)
        {
            return await _context.Habits
                  .Where(x => x.UserId.Contains(id))
                  .ToListAsync();
        }

        public async Task<Habit> GetByIdAsync(long id)
        {
            return await _context.Habits.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
