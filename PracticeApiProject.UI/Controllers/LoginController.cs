using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PracticeApiProject.Services.EmployeeService.Dto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PracticeApiProject.UI.Controllers
{
    public class LoginController : BaseController
    {
        private IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GenerateJSONWebToken(LoginDto userInfo, string roleName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            List<Claim> claimList = new List<Claim>()
            {
                //new Claim("UserId", "1"),
                new Claim(ClaimTypes.Role, roleName)
            };

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], 
                   audience: _configuration["Jwt:Issuer"], 
                   claims: claimList,
                    null,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //private async Task<LoginDto> AuthenticateUser(LoginDto login)
        //{
        //    LoginDto user = null;

        //    if (login.UserName == "admin")
        //    {
        //        user = new LoginDto { UserName = "admin", Password = "1234" };
        //    }

        //    return user;
        //}
        private bool AuthenticateUser(LoginDto login, out string roleName)
        {
            bool validUser = false;
            roleName = string.Empty;

            if (login.UserName == "admin" && login.Password == "1234")
            {
                roleName = "Admin";

                validUser = true;
            }
            else if (login.UserName == "dogan" && login.Password == "1234")
            {
                roleName = "User";

                validUser = true;
            }

            return validUser;
            
        }

        //[AllowAnonymous]
        //[HttpPost(nameof(Login))]
        //public async Task<IActionResult> Login([FromBody] LoginDto data)
        //{
        //    IActionResult response = Unauthorized();

        //    var user = await AuthenticateUser(data);

        //    if (data != null)
        //    {
        //        var tokenString = GenerateJSONWebToken(user);
        //        response = Ok(new { Token = tokenString, Message = "Success" });
        //    }

        //    return response;
        //}

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public IActionResult Login([FromBody] LoginDto data)
        {
            if(data == null)
            {
                return Unauthorized();
            }

            string tokenString = string.Empty;
            string roleName = string.Empty;
            bool validUser = AuthenticateUser(data, out roleName);
            if (validUser)
            {
                tokenString = GenerateJSONWebToken(data, roleName);
            }
            else
            {
                return Unauthorized();
            }

            return Ok(new { Token = tokenString });
        }

        [HttpGet(nameof(Get))]
        public async Task<IEnumerable<string>> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return new string[] { accessToken };
        }

    }
}
