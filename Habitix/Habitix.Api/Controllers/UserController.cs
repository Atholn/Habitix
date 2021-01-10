using AutoMapper;
using Habitix.Core.Models.JWTModels;
using Habitix.Data.Models;
using Habitix.Data.Repositories.Interfaces;
using Habitix.Services.Services;
using Habitix.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habitix.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUserService userService;

        public UserController(IMapper mapper, IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IContextReturnable contextReturnable)
        {
            this.mapper = mapper;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
            userService = new UserService(userManager, roleManager, configuration, contextReturnable);            
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var result = await userService.Login(request);
            return result.IsSuccessful ? Ok(result) : Unauthorized(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
        {
            var result = await userService.Register(request);
            return result.IsSuccessful ? Ok(result) : BadRequest(result);
        }
    }
}
