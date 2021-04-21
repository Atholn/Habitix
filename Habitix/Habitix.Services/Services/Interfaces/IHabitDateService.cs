using Habitix.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Services.Interfaces
{
    public interface IHabitDateService
    {
        Task<IEnumerable<HabitDateRepresentation>> GetAllByHabitId(long id);
        Task<HabitDateRepresentation> GetLastByHabitId(long id);
        Task CreateByHabitId(HabitDateRepresentation habitDateRepresentation);
        Task Update(HabitDateRepresentation habitDateRepresentation);
    }
}
