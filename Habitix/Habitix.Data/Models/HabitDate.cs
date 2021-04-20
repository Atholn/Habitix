using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Models
{
    public class HabitDate : BaseEntity
    {
        public bool IfHabitDone { get; set; }
        public DateTime DateOfHabit { get; set; }

        public virtual Habit Habit { get; set; }
        public long HabitId { get; set; }

        public HabitDate()
        {
            IfHabitDone = false;
            DateOfHabit = DateTime.UtcNow;
        }
    }
}
