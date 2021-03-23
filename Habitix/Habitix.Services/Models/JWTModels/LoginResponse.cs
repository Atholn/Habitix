using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Models.JWTModels
{
    public class LoginResponse : BaseResponse
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
