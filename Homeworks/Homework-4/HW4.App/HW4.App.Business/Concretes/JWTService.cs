using HW4.App.Business.Abstracts;
using HW4.App.Business.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace HW4.App.Business.Concretes
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration configuration;
        private readonly IUserService userService;
        public JWTService(IConfiguration configuration, IUserService userService)
        {
            this.configuration = configuration;
            this.userService = userService;
        }

        public TokenDto Authenticate(UserDto user)
        {
            // Get all Username & Pasword information 
            // Check the existence of records in Database
            var users = userService.GetUsers();
            if (!users.Any(x => x.Username == user.Name && x.Password == user.Password))
            {
                return null;
            }

            // Else: Generate the JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, user.Name)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDto
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}