using AutoMapper;
using Habitix.Services.Models;
using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Mappers
{
    public class HabitixProfile : Profile
    {
        public HabitixProfile()
        {
            CreateMap<HabitixUser, HabitixUserRepresentation>()
                .ReverseMap();
            CreateMap<Habit, HabitRepresentation>()
                .ReverseMap();
            CreateMap<HabitDate, HabitDateRepresentation>()
                .ReverseMap();
        }
    }
}
