using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Identity
{
    public static class UserRoles
    {
        public const string Creator = "Creator";
        public const string Admin = "Admin";
        public const string User = "User";
        public const string AdminOrUser = Admin + "," + User;
    }
}
