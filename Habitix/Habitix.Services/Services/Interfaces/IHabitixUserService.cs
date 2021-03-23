using Habitix.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Base.Interfaces
{
    public interface IHabitixUserService
    {
        Task<HabitixUserRepresentation> Create(HabitixUserRepresentation habitixUserRepresentation);
        Task<HabitixUserRepresentation> Get(long id);
        Task<IEnumerable<HabitixUserRepresentation>> GetList();
        public void Delete(long id);
        Task<HabitixUserRepresentation> Update(HabitixUserRepresentation request, long Id);
    }
}
