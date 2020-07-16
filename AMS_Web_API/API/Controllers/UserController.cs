using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Helpers;
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
        public async Task<IActionResult> Get([FromQuery] Param parameter)
        {
            try
            {
                var users = await _serviceManager.User.Get(parameter);
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

                return BadRequest("Not Found");
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

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                var user = await this._serviceManager.User.Login(changePasswordDto.Username, changePasswordDto.OldPassword);

                if (user == null)
                    return BadRequest("Username or password does not matched.");

                var result = await this._serviceManager.User.SetPassword(user.Id, changePasswordDto.NewPassword);

                if (result)
                    return Ok();

                return BadRequest("Internal Error. Unable to change your password.");
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

    }
}