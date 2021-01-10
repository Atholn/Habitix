using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Habitix.Core.Models.JWTModels
{
    public class BaseResponse
    {
        [JsonIgnore]
        public bool IsSuccessful { get; set; }
        [JsonIgnore]
        public string ErrorMessage { get; set; }
    }
}
