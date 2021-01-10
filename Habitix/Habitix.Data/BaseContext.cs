using Habitix.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data
{
    public  class BaseContext : IdentityDbContext<User>
    {
        public DbSet<HabitixUser> HabitixUsers { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitDate> HabitsDates { get; set; }

        public BaseContext (DbContextOptions options ):base (options)
        {
            var temp = Database;
            Database.Migrate();          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HabitixUser>()
                .HasMany(hs => hs.Habits)
                .WithOne(h => h.HabitixUser);

            modelBuilder.Entity<Habit>()
                .HasMany(h => h.HabitDates)
                .WithOne(hd => hd.Habit);
        }
    }
}
