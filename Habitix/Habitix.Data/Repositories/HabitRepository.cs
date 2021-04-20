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

        public async Task<IEnumerable<Habit>> GetAllByUserIdTodayAsync(string id, bool isDone)
        {
            return await _context.HabitsDates.Join(
                _context.Habits,
                habit => habit.HabitId,
                date => date.Id,
                (date, habit) => new
                {
                     Id = date.Id,
                     IfHabitDone = date.IfHabitDone,
                     DateOfHabit  = date.DateOfHabit,
                     Habit = habit,
                     HabitId = habit.Id
                })
                .Where(x=> x.IfHabitDone == isDone 
                && x.DateOfHabit.Date == DateTime.Now.Date
                && x.Habit.UserId.Contains(id)
                )      
                .Select(x=> new Habit
                {
                    Id = x.Id,
                    HabitName = x.Habit.HabitName,
                    HabitDescription = x.Habit.HabitDescription,
                    StartDateHabit = x.Habit.StartDateHabit,
                    CreatedAt = x.Habit.CreatedAt,
                    HabitDates = x.Habit.HabitDates,
                    HabitixUser = x.Habit.HabitixUser,
                    HabitixUserId = x.Habit.HabitixUserId,
                    UpdatedAt = x.Habit.UpdatedAt,
                    UserId = x.Habit.UserId, 
                })
                .ToListAsync(); 
        }

        public async Task<Habit> GetByIdAsync(long id)
        {
            return await _context.Habits.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
