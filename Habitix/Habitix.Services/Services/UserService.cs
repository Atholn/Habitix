using Habitix.Services.Models.JWTModels;
using Habitix.Data.Models;
using Habitix.Services.Services.Interfaces;
using Habitix.Data.Repositories.Interfaces;
using Habitix.Services.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IContextReturnable contextReturnable;
        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IContextReturnable contextReturnable)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.contextReturnable = contextReturnable;
        }

        public Task<bool> AssignUserToCompany(string userId, long companyId)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var user = await userManager.FindByNameAsync(request.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                return new LoginResponse
                {
                    IsSuccessful = true,
                    Id = user.Id,                   
                    Username = user.UserName,
                    Token = new TokenGenerator(configuration["Secret"]).Generate(userRoles, user)
                };
            }

            return new LoginResponse
            {
                IsSuccessful = false,
                ErrorMessage = "User with given username not found"
            };
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var userExists = await userManager.FindByNameAsync(request.Username);
            if (userExists != null)
                return new RegisterResponse
                {
                    ErrorMessage = "Conflict",
                };

            User user = new User()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.Username
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return new RegisterResponse
                {
                    ErrorMessage = "Internal server error"
                };

            return new RegisterResponse
            {
                IsSuccessful = true
            };
        }
    }
}
