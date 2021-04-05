using Habitix.Services.Models;
using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Base.Interfaces
{
    public interface IHabitService
    {
        void Create(HabitRepresentation habitRepresentation, string userId);
        HabitRepresentation Get(long id);
        List<HabitRepresentation> GetAllHabits();
        List<HabitRepresentation> GetAllByHabitixUserId(long id);
        Task<IEnumerable<HabitRepresentation>> GetAllByUserId(string id);        
        public void Delete(long id);
        HabitRepresentation Update(HabitRepresentation habitRepresentation, long id);
        Task<bool> UserOwnsHabitAsync(long postId, string userId);
    }
}
