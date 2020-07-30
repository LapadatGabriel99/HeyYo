using HeyYo.Web.DataAccess.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HeyYo.Web.Server.Authentication.Jwt
{
    public static class JwtExtensionMethods
    {
        public static string GenerateToken(this ApplicationUser user, IConfiguration configuration)
        {
            var claims = new[]
            {                
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),                
                
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                
                new Claim(ClaimTypes.NameIdentifier, user.Id),

                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
            };

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMonths(6),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
