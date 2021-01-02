using Habitix.Services.Base.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habitix.Api.Controllers
{
    [Route("api/habitixUser/{habitixUserId}/habit")]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitixUserService _habitixUserService;

        public HabitController(IHabitixUserService habitixUserService)
        {
            _habitixUserService = habitixUserService;
        }

    }
}
