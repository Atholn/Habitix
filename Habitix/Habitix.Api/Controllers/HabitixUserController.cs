using Habitix.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Habitix.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using Habitix.Api.Models;

namespace Habitix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitixUserController : ControllerBase
    {
        private readonly IHabitixUserService _habitixUserService;
            
        public HabitixUserController(IHabitixUserService habitixUserService)
        {
            _habitixUserService = habitixUserService;
        }

        [HttpGet("UserInfo")]
        [SwaggerOperation(Summary = "Retrieves habitix user info")]
        public async Task<ActionResult> GetHabitixUserInfo()
        {
            return Ok(new UserInfo() { UserName = User.FindFirstValue(ClaimTypes.Name), UserRole = User.FindFirstValue(ClaimTypes.Role)});
        }


        [HttpPost]
        [SwaggerOperation(Summary = "Create new HabitixUser")]
        public async Task<ActionResult> Create([FromBody] HabitixUserRepresentation request)
        {
            var result = await _habitixUserService.Create(request);
            return Ok(result); //: BadRequest(result.ErrorMessage);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves a specific User by unique id")]
        public async Task<ActionResult<HabitixUserRepresentation>> Get(long id) => Ok(await _habitixUserService.Get(id));

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves all Users")]
        public async Task<ActionResult<IEnumerable<HabitixUserRepresentation>>> GetList() => Ok(await _habitixUserService.GetList());

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete User")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            _habitixUserService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update User")]
        public async Task<ActionResult<HabitixUserRepresentation>> Update([FromBody] HabitixUserRepresentation request, long id)
        {
            var result = await _habitixUserService.Update(request, id);
            return Ok(result);
        }
    }
}
