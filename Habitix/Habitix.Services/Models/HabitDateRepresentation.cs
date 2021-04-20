﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Models
{
   public class HabitDateRepresentation
    {
        public long Id { get; set; }
        public bool IfHabitDone { get; set; }
        public DateTime DateOfHabit { get; set; }

        public long HabitId { get; set; }
    }
}
