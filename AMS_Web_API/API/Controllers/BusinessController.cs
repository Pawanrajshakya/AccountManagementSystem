using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : BaseApiController
    {
        public BusinessController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var businesses = await _serviceManager.Business.GetAll();

                if (businesses != null)
                    return Ok(businesses);

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
                var business = await _serviceManager.Business.Get(id);

                if (business != null)
                    return Ok(business);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessToSaveDto businessDto)
        {
            try
            {
                if (await _serviceManager.Business.Add(businessDto))
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
        public async Task<IActionResult> Patch(int id, BusinessToEditDto businessDto)
        {
            try
            {
                if (!await _serviceManager.Business.Update(id, businessDto))
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
                if (await _serviceManager.Business.SoftDelete(id))
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