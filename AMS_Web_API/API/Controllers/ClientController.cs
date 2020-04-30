using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos;
using Service_Layer.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseApiController
    {
        public ClientController(IServiceManager service, IConfiguration config) : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Clients = await _serviceManager.Client.GetAll();

                if (Clients != null)
                    return Ok(Clients);

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
                var Client = await _serviceManager.Client.Get(id);

                if (Client != null)
                    return Ok(Client);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientToSaveDto ClientDto)
        {
            try
            {
                if (await _serviceManager.Client.Add(ClientDto))
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
        public async Task<IActionResult> Patch(int id, ClientToEditDto ClientDto)
        {
            try
            {
                if (!await _serviceManager.Client.Update(id, ClientDto))
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
                if (await _serviceManager.Client.SoftDelete(id))
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