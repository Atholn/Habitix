using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Services
{
    public class UserResloverService
    {
        private readonly IHttpContextAccessor _contex;
        public UserResloverService(IHttpContextAccessor contex)
        {
            _contex = contex;
        }

        public string GetUser()
        {
            return _contex.HttpContext.User?.Identity?.Name;
        }
    }
}
