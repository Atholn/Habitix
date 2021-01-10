using Habitix.Core.Models.JWTModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);
        Task<bool> AssignUserToCompany(string userId, long companyId);
    }
}
