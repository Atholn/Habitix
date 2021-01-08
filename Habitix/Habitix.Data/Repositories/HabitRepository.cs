﻿using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Habitix.Data.Repositories
{
    public class HabitRepository : BaseRepository<Habit>, IHabitRepository
    {
        public HabitRepository(BaseContext context) : base(context)
        {

        }

        public IEnumerable<Habit> GetAllByUserId(long id)
        {
            return  context.Habits
                    .Include(h => h.HabitixUserId == id)
                    .AsEnumerable();
             
        }
    }
}
