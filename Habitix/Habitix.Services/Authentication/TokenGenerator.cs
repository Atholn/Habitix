using Habitix.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Habitix.Services.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly string _secret;

        public TokenGenerator(string secret)
        {
            _secret = secret;
        }

        public string Generate(ICollection<string> roles, User user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim("id", user.Id),                  
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                audience: "Manage",
                issuer: "Manage"
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
