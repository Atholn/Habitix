using Habitix.Core.Models;
using Habitix.Services.Base.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habitix.Api.Controllers
{
    [Route("api/controller")]
    [EnableCors]
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitService _habitService;

        public HabitController(IHabitService habitService)
        {
            _habitService = habitService;
        }

        [HttpPost]
        public ActionResult Create([FromBody] HabitRepresentation request)
        {
            _habitService.Create(request);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Created($"api/[controller]", Ok());
        }

        [HttpGet("{id}")]
        public ActionResult<HabitRepresentation> Get(long id)
        {
            var habit = _habitService.Get(id);
            if (habit == null)
            {
                return NotFound();
            }
            return Ok(habit);
        }

        [HttpGet("userId")]
        public ActionResult GetAllByUserId(long userId)
        {
            return Ok(_habitService.GetAllByUserId(userId));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(long id)
        {
            _habitService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] HabitRepresentation habitRepresentation, long id)
        {
            _habitService.Update(habitRepresentation, id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }


    }
}
