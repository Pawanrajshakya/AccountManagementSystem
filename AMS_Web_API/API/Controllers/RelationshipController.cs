using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationshipController : BaseApiController
    {
        public RelationshipController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Relationships = await _serviceManager.Relationship.GetAll();

                if (Relationships != null)
                    return Ok(Relationships);

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
                var Relationship = await _serviceManager.Relationship.Get(id);

                if (Relationship != null)
                    return Ok(Relationship);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(RelationshipToSaveDto RelationshipDto)
        {
            try
            {
                if (await _serviceManager.Relationship.Add(RelationshipDto))
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
        public async Task<IActionResult> Patch(int id, RelationshipToEditDto RelationshipDto)
        {
            try
            {
                if (!await _serviceManager.Relationship.Update(id, RelationshipDto))
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
                if (await _serviceManager.Relationship.SoftDelete(id))
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