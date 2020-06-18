using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        public AuthController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            try
            {
                UserToSaveDto userDto = new UserToSaveDto { Username = "sysadmin", Name = "System Administrator", IsActive = true, UserRole = new System.Collections.Generic.List<int> { 1 } };
                var id = await _serviceManager.User.Add(userDto);
                if (id > 0)
                {
                    var user = await _serviceManager.User.Get(id);
                    return Ok(user);
                }
                return BadRequest(); ;
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _serviceManager.User.Login(userLoginDto.Username.ToLower(), userLoginDto.Password);

            if (user == null)
                return Unauthorized();

            JwtSecurityTokenHandler tokenHandler;
            SecurityToken token;

            GetToken(user, out tokenHandler, out token);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                isPasswordChanged = user.PasswordChangedCount != 0
            });
        }

        private void GetToken(UserDto user, out JwtSecurityTokenHandler tokenHandler, out SecurityToken token)
        {
            var userRoles = string.Join(",", user.UserRole);

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, userRoles),
                new Claim(ClaimTypes.GivenName, user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            tokenHandler = new JwtSecurityTokenHandler();
            token = tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}