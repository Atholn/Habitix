using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Models
{
    public class HabitRepresentation
    {
        public string HabitName { get; set; }
        public string HabitDescription { get; set; }
        public DateTime StartDateHabit { get; set; }

        public long HabitixUserId { get; set; }
        public virtual List<HabitDateRepresentation> HabitDates { get; set; }
    }
}
