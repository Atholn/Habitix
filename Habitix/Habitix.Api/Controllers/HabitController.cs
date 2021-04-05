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
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Habitix.Api.Wrappers;
using Habitix.Data.Identity;

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

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        [SwaggerOperation(Summary = "Retrieves all habits")]
        public ActionResult<HabitRepresentation> GetAll()
        {
            var habits = _habitService.GetAllHabits();
            if (habits == null)
            {
                return NotFound();
            }
            return Ok(habits);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.User)]
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

        [HttpGet("/UserHabits")]
        [Authorize(Roles = UserRoles.User)]
        [SwaggerOperation(Summary = "Retrieves a specific habit by User Id")]
        public ActionResult GetAllByUserId(long userId)
        {
            return Ok(_habitService.GetAllByUserId(userId));
        }

        [HttpGet("/UserId/{userId}")]
        [Authorize(Roles = UserRoles.User)]
        [SwaggerOperation(Summary = "Retrieves a specific habit by User Id")]
        public ActionResult GetAllByUserId(long userId)
        {
            return Ok(_habitService.GetAllByUserId(userId));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.User)]
        [SwaggerOperation(Summary = "Update a existing habit")]
        public async Task<ActionResult> Update([FromBody] HabitRepresentation habitRepresentation, long id)
        {
            var userOwnsHabit = await _habitService.UserOwnsHabitAsync(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!userOwnsHabit)
            {
                return BadRequest(new Response<bool>() { Succeeded = false, Message = "You do no own this habit." });
            }

            _habitService.Update(habitRepresentation, id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }

        [HttpPost]
        //[AllowAnonymous]
        [Authorize(Roles = UserRoles.User)]
        [SwaggerOperation(Summary = "Create new habit")]
        public ActionResult Create([FromBody] HabitRepresentation request)
        {
            _habitService.Create(request, User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Created($"api/[controller]", Ok());
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.AdminOrUser)]
        [SwaggerOperation(Summary = "Delete a existing habit")]
        public async Task<ActionResult> Delete(long id)
        {
            var userOwnsHabit = await _habitService.UserOwnsHabitAsync(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
            var isAdmin = User.IsInRole(UserRoles.Admin);

            if (!isAdmin && !userOwnsHabit)
            {
                return BadRequest(new Response<bool>() { Succeeded = false, Message = "You do no own this habit." });
            }

            _habitService.Delete(id);
            return NoContent();
        }
    }
}
