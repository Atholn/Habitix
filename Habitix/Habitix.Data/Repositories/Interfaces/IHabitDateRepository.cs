using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Data.Repositories.Interfaces
{
    public interface IHabitDateRepository : IBaseRepositoryAsync<HabitDate>
    {
        Task<IEnumerable<HabitDate>> GetAllByHabitId(long id);
        Task<HabitDate> GetLastByHabitId(long id);
        Task CreateByHabitId(HabitDate habitDate);
    }
}
