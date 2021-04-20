using Habitix.Services.Models;
using Habitix.Services.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habitix.Api.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class HabitDateController : ControllerBase
    {
        private readonly IHabitDateService _habitDateService;

        public HabitDateController(IHabitDateService habitDateService)
        {
            _habitDateService = habitDateService;
        }


        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves a specific habit date by habit ID")]
        public async Task<ActionResult> GetAllByHabitId(long id)
        {
            return Ok(await _habitDateService.GetAllByHabitId(id));
        }

        [HttpGet("Today/{id}")]
        [SwaggerOperation(Summary = "Retrieves a specific habit date by habit ID today")]
        public async Task<ActionResult> GetAllByHabitIdToday(long id)
        {
            return Ok(await _habitDateService.GetAllByHabitId(id));
        }


        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Create new habit Date")]
        public async Task<ActionResult> Create([FromBody] HabitDateRepresentation request)
        {
            await _habitDateService.CreateByHabitId(request);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Created($"api/[controller]", Ok());
        }


    }
}
