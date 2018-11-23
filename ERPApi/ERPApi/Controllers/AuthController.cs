using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Contracts;
using Entities.ExtendedModels;
using Entities.Response;
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
        IRepositoryWrapper _repo;

        public AuthController(IConfiguration config, IRepositoryWrapper repo)
        {
            _config = config;
            _repo = repo;
        }

        [AllowAnonymous]
        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] Entities.Request.LoginRequest login)
        {
            IActionResult response = Unauthorized();

            var loginResponse = AuthenticateUser(login);

            if (loginResponse.User.Id > 0)
            {
                var tokenString = GenerateJSONWebToken(loginResponse.User);

                response = Ok(new { token = tokenString, response = loginResponse });
            }

            return response;
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                new List<Claim> { new Claim("username", userInfo.LoginName) },
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private LoginResponse AuthenticateUser(Entities.Request.LoginRequest login)
        {
            var response = _repo.User.Login(login.UserName, login.Password);
            return response;
        }
    }
}