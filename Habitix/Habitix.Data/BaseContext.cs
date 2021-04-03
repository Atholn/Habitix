using Habitix.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Habitix.Data.Identity;
using Habitix.Data.Services;

namespace Habitix.Data
{
    public  class BaseContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<HabitixUser> HabitixUsers { get; set; }
        public DbSet<Habit> Habits { get; set; }
        public DbSet<HabitDate> HabitsDates { get; set; }


        private readonly UserResloverService _userResloverService;
        public BaseContext (DbContextOptions<BaseContext> options, UserResloverService userResloverService):base (options)
        {
            _userResloverService = userResloverService;
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
