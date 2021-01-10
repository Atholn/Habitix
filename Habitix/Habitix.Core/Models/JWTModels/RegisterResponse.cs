using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Core.Models.JWTModels
{
    public class RegisterResponse : BaseResponse
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
