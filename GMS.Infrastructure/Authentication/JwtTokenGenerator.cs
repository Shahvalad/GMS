using GMS.Application.Common.Interfaces.Authentication;
using GMS.Domain.Entites;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {

        public string GenerateToken(User user)
        {

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")), //16 simvol olmalıdır
                SecurityAlgorithms.HmacSha256
                );

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sid, user.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: "GMS",
                expires: DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: signingCredentials,
                audience : "GMS"
                );

            return new JwtSecurityTokenHandler().WriteToken( securityToken );
        }
    }
}
