using Habitix.Services.Models;
using Habitix.Services.Base.Interfaces;
using Microsoft.AspNetCore.Cors;
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
    [ApiController]
    public class HabitController : ControllerBase
    {
        private readonly IHabitService _habitService;

        public HabitController(IHabitService habitService)
        {
            _habitService = habitService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create new habit")]
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
        [SwaggerOperation(Summary = "Retrieves a specific habit by unique id")]
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
        [SwaggerOperation(Summary = "Retrieves a specific habit by User Id")]
        public ActionResult GetAllByUserId(long userId)
        {
            return Ok(_habitService.GetAllByUserId(userId));
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a existing habit")]
        public ActionResult Delete(long id)
        {
            _habitService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a existing habit")]
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
