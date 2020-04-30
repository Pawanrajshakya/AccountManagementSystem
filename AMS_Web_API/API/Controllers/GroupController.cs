using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : BaseApiController
    {
        public GroupController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Groups = await _serviceManager.Group.GetAll();

                if (Groups != null)
                    return Ok(Groups);

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
                var Group = await _serviceManager.Group.Get(id);

                if (Group != null)
                    return Ok(Group);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(GroupToSaveDto GroupDto)
        {
            try
            {
                if (await _serviceManager.Group.Add(GroupDto))
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
        public async Task<IActionResult> Patch(int id, GroupToEditDto GroupDto)
        {
            try
            {
                if (!await _serviceManager.Group.Update(id, GroupDto))
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
                if (await _serviceManager.Group.SoftDelete(id))
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