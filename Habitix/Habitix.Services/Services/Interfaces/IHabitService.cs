using Habitix.Services.Models;
using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Base.Interfaces
{
    public interface IHabitService
    {
        void Create(HabitRepresentation habitRepresentation);
        HabitRepresentation Get(long id);
        List<HabitRepresentation> GetAllByUserId(long id);        
        public void Delete(long id);
        HabitRepresentation Update(HabitRepresentation habitRepresentation, long id);
    }
}
