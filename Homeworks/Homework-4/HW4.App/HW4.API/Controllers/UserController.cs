using HW4.App.Models;
using HW4.App.Business.Abstracts;
using HW4.App.Business.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HW4.App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJWTService jwtService;

        public UserController(IJWTService jwtService)
        {
            this.jwtService = jwtService;
        }

        [Route("Users")]
        [HttpGet]
        public IActionResult Get()
        {
            var users = new List<string>
            {
                "John Doe",
                "Samet Kayıkcı",
                "Bill Gates",
                "Meleknur Yazlamaz"
            };
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(UserResponseModel model)
        {
            var token = jwtService.Authenticate(
                new UserDto
                {
                    Name = model.Name,
                    Password = model.Password
                });

            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}