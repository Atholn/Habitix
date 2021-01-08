using AutoMapper;
using Habitix.Core.Models;
using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using Habitix.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Services
{
    public class HabitService : IHabitService
    {
        private readonly IHabitRepository _habitRepository;
        private readonly IMapper _mapper;
        public HabitService(IHabitRepository habitService, IMapper mapper)
        {
            _habitRepository = habitService;
            _mapper = mapper;
        }

        public void Create(HabitRepresentation habitRepresentation)
        {
            if(habitRepresentation == null)
            {
                throw new Exception($"No habit");
            }

            Habit habit = _mapper.Map<Habit>(habitRepresentation);
            _habitRepository.Insert(habit);             
        }

        public void Delete(long id)
        {
            var habit = _habitRepository.Get(id);
            if (habit == null)
            {
                throw new Exception($"There is no User with this ID");
            }
            _habitRepository.Delete(habit);
        }

        public HabitRepresentation Get(long id)
        {
            var habit = _habitRepository.Get(id);
            return _mapper.Map<HabitRepresentation>(habit);
        }

        public List<HabitRepresentation> GetAllByUserId(long id)
        {
            return _mapper.Map<List<HabitRepresentation>>(_habitRepository.GetAllByUserId(id));
        }

        public HabitRepresentation Update(HabitRepresentation habitRepresentation, long id)
        {
            var habit = _habitRepository.Get(id);
            if (habit == null)
            {
                throw new Exception($"There is no User with this ID");
            }

            habit.UpdatedAt = DateTime.Now;

            if (habit.HabitName != habitRepresentation.HabitName)
                habit.HabitName = habitRepresentation.HabitName;

            if (habit.HabitDescription != habitRepresentation.HabitDescription)
                habit.HabitDescription = habitRepresentation.HabitDescription;

            if (habit.StartDateHabit != habitRepresentation.StartDateHabit)
                habit.StartDateHabit = habitRepresentation.StartDateHabit;

            _habitRepository.Update(habit);

            return _mapper.Map<HabitRepresentation>(habit);
        }
    }
}
