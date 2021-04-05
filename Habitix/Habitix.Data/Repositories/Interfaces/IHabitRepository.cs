using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Data.Repositories.Interfaces
{
    public interface IHabitRepository : IBaseRepository<Habit>
    {
        Task<IEnumerable<Habit>> GetAllByUserIdAsync(string id);
        Task<Habit> GetByIdAsync(long id);
        //-----------
        List<Habit> GetAllByHabitixUserId(long id);
    }
}
