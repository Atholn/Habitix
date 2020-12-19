using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Models
{
   public  class HabitixUser : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        
        public virtual List <Habit> Habits { get; set; }
    }
}
