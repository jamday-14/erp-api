using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Entities.ExtendedModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ERPApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);

                response = Ok(new { token = tokenString });
            }

            return response;
        }

        private string GenerateJSONWebToken(LoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private LoginModel AuthenticateUser(LoginModel login)
        {
            // TODO: Implement user authentication
            LoginModel user = null;

            if (login.UserName == "jamday")
            {
                user = new LoginModel { UserName = "jamday" };
            }

            return user;
        }
    }
}