using Habitix.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Habitix.Services.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] HabitixUserRepresentation request)
        {
            var result = await _habitixUserService.Create(request);
            return Ok(result); //: BadRequest(result.ErrorMessage);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HabitixUserRepresentation>> Get(long id) => Ok(await _habitixUserService.Get(id));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabitixUserRepresentation>>> GetList() => Ok(await _habitixUserService.GetList());

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            _habitixUserService.Delete(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<HabitixUserRepresentation>> Update([FromBody] HabitixUserRepresentation request, long id)
        {
            var result = await _habitixUserService.Update(request, id);
            return Ok(result);
        }
    }
}
