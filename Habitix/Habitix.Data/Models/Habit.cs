using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Habitix.Data.Models
{
    public class Habit : BaseEntity
    {
        public string HabitName { get; set; }
        public string HabitDescription { get; set; }
        public DateTime StartDateHabit { get; set; }

        public virtual List<HabitDate> HabitDates { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserId { get; set; }


        public virtual HabitixUser HabitixUser { get; set; }
        public long HabitixUserId { get; set; }       
    }
}
