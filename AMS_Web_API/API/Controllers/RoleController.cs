using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : BaseApiController
    {
        public RoleController(IServiceManager service, IConfiguration config)
        : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var roles = await _serviceManager.Role.GetAll();

                if (roles != null)
                    return Ok(roles);

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
                var role = await _serviceManager.Role.Get(id);

                if (role != null)
                    return Ok(role);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoleToSaveDto roleDto)
        {
            try
            {
                if (await _serviceManager.Role.Add(roleDto))
                    return StatusCode(201);
                else
                    return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, RoleToEditDto roleDto)
        {
            try
            {
                if (!await _serviceManager.Role.Update(id, roleDto))
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
                if (await _serviceManager.Role.SoftDelete(id))
                    return Ok();

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }
    }
}