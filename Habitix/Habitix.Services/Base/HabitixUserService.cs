using AutoMapper;
using Habitix.Core.Models;
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
        public long Create(HabitixUserRepresentation habitixUserRepresentation)
        {
            throw new NotImplementedException();
        }

        public Task<HabitixUserRepresentation> Get(long id)
        {
            return await Task.Run(() =>
           {
               return 
           });
        }
    }
}
