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
    public class HabitDateRepository : BaseRepositoryAsync<HabitDate>, IHabitDateRepository
    {
        public HabitDateRepository(BaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<HabitDate>> GetAllByHabitId(long id)
        {
                    return await _context.HabitsDates
                        .Where(x => x.HabitId == id)
                        .ToListAsync();
        }

        public async Task<HabitDate> GetLastByHabitId(long id)
        {
            return await _context.HabitsDates
                        .Where(
                        x => x.HabitId == id 
                        && x.DateOfHabit.Date == DateTime.UtcNow.Date
                        )
                        .FirstOrDefaultAsync();
        }

        public async Task CreateByHabitId(HabitDate habitDate)
        {
            if (habitDate is null)
                throw new ArgumentNullException($"Entity is null {nameof(habitDate)}");

            await _context.HabitsDates.AddAsync(habitDate);
            await _context.SaveChangesAsync();
        }
    }
}
