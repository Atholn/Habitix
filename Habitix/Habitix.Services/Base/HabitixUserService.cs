using AutoMapper;
using Habitix.Core.Models;
using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using Habitix.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Base
{
    public class HabitixUserService : IHabitixUserService
    {
        private readonly IHabitixUserRepository _habitixUserRepository;
        private readonly IMapper _mapper;

        public HabitixUserService(IHabitixUserRepository habitixUserRepository, IMapper mapper)
        {
            _habitixUserRepository = habitixUserRepository;
            _mapper = mapper;
        }

        public async Task<HabitixUserRepresentation> Create(HabitixUserRepresentation habitixUserRepresentation)
        {
            if (habitixUserRepresentation == null)
            {
                throw new Exception("User is null!");
            }

            HabitixUser habitixUser = _mapper.Map<HabitixUser>(habitixUserRepresentation);
            _habitixUserRepository.Insert(habitixUser);

            return new HabitixUserRepresentation
            {
                Name = habitixUser.Name,
                LastName = habitixUser.LastName,
                //Habits = _mapper.Map<List<HabitRepresentation>> (habitixUser.Habits)
            };
        }

        public async Task<HabitixUserRepresentation> Get(long id)
        {
            var habitixUser = _habitixUserRepository.GetHabitixUser(id);

            return await Task.Run(() =>
            {
               return habitixUser?.Id == id ? _mapper.Map<HabitixUserRepresentation>(habitixUser) : null;
            });
        }

        public async Task<IEnumerable<HabitixUserRepresentation>> GetList()
        {
            return await Task.Run(() =>
            {
                return _mapper.Map<IEnumerable<HabitixUserRepresentation>>(_habitixUserRepository.GetAll());
            });
        }
    }
}
