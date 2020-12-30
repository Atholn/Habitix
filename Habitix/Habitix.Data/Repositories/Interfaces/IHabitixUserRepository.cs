using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Repositories.Interfaces
{
    public interface IHabitixUserRepository : IBaseRepository<HabitixUser>
    {
        HabitixUser GetHabitixUser(long Id);
        IEnumerable<HabitixUser> GetList();
    }
}
