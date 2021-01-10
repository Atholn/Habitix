using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Habitix.Api.Helpers.ExtensionsMethods
{
    public static class ClaimsPrincipalExtensions
    {
        public static string Id(this ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(c => c.Type == "id").Value;
        }
    }
}
