using AutoMapper;
using Habitix.Core.Models;
using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize() => new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Habit, HabitRepresentation>();
            cfg.CreateMap<HabitRepresentation, Habit>();

            cfg.CreateMap<HabitixUser, HabitixUserRepresentation>();
            cfg.CreateMap<HabitixUserRepresentation, HabitixUser>();

            cfg.CreateMap<HabitDate, HabitDateRepresentation>();
            cfg.CreateMap<HabitDateRepresentation, HabitDate>();
           

        }).CreateMapper();

    }
}
