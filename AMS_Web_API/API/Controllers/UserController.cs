using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserController : BaseApiController
    {
        public UserController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Service_Layer.Helpers.UserParam userParam)
        {
            try
            {
                var users = await _serviceManager.User.GetAll(userParam);
                if (users != null)
                {
                    Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);
                    return Ok(users);
                }
                return NotFound();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _serviceManager.User.Get(id);
                if (user != null)
                    return Ok(user);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserToSaveDto userDto)
        {
            try
            {
                var id = await _serviceManager.User.Add(userDto);
                if (id > 0)
                {
                    var user = await _serviceManager.User.Get(id);
                    return Ok(user);
                }
                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, UserToEditDto userDto)
        {
            try
            {
                if (!await _serviceManager.User.Update(id, userDto))
                    return BadRequest();

                return Ok();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _serviceManager.User.SoftDelete(id))
                    return Ok();

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            try
            {
                UserToSaveDto userDto = new UserToSaveDto { Username = "pawanshakya", Password = "password", Name = "Sys Admin", UserRole = new System.Collections.Generic.List<int> { 1, 2 } };
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
        [AllowAnonymous]
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
                token = tokenHandler.WriteToken(token)
            });
        }

        private void GetToken(UserDto user, out JwtSecurityTokenHandler tokenHandler, out SecurityToken token)
        {
            var userRoles = string.Join(",", user.UserRole);

            var claims = new[]{
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, userRoles)
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