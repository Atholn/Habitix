using AutoMapper;
using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using Habitix.Services.Models;
using Habitix.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Services
{
    public class HabitDateService : IHabitDateService
    {
        private readonly IHabitDateRepository _habitDateRepository;
        private readonly IMapper _mapper;
        public HabitDateService(IHabitDateRepository habitDateRepository, IMapper mapper)
        {
            _habitDateRepository = habitDateRepository;
            _mapper = mapper;
        }

        public async Task CreateByHabitId(HabitDateRepresentation habitDateRepresentation)
        {
            if (habitDateRepresentation == null)
            {
                throw new Exception($"No habit");
            }

            HabitDate habitDate = _mapper.Map<HabitDate>(habitDateRepresentation);
            //habitDate.UserId = userId;
            await _habitDateRepository.CreateAsync(habitDate);

        }

        public async Task<IEnumerable<HabitDateRepresentation>> GetAllByHabitId(long id)
        {
            return _mapper.Map<List<HabitDateRepresentation>>(await _habitDateRepository.GetAllByHabitId(id));
        }

        public async Task<HabitDateRepresentation> GetLastByHabitId(long id)
        {
            return _mapper.Map<HabitDateRepresentation>(await _habitDateRepository.GetLastByHabitId(id));
        }
    }
}
