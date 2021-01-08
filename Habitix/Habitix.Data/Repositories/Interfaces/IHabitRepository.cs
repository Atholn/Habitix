using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Repositories.Interfaces
{
    public interface IHabitRepository : IBaseRepository<Habit>
    {
        List<Habit> GetAllByUserId(long id);
    }
}
