using Habitix.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Services.Authentication
{
    public interface ITokenGenerator
    {
        string Generate(ICollection<string> roles, User user);
    }
}
