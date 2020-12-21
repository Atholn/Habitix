using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Repositories
{
    public class HabitixUserRepository :BaseRepository<HabitixUser>, IHabitixUserRepository
    {
        public HabitixUserRepository(BaseContext context) : base(context)
        {

        }
    }
}
