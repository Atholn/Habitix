using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Data.Repositories.Interfaces
{
    public interface IHabitRepository : IBaseRepository<Habit>
    {
        Task<IEnumerable<Habit>> GetByUserIdAsync(string id);
        Task<Habit> GetByIdAsync(long id);
        //-----------
        List<Habit> GetAllByUserId(long id);
    }
}
