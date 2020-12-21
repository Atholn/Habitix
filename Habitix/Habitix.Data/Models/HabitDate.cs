using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Models
{
    public class HabitDate : BaseEntity
    {
        public virtual Habit Habit { get; set; }
        public long HabitId { get; set; }
    }
}
