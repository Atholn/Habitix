using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Models.JWTModels
{
    public class RegisterResponse : BaseResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
