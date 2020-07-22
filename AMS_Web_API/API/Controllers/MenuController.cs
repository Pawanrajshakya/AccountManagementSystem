using System.Threading.Tasks;
using API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Dtos.Menu;
using Service_Layer.Helpers;
using Service_Layer.Interface;

namespace API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController : BaseApiController
    {
        public MenuController(IServiceManager service, IConfiguration config)
        : base(service, config)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Param paramerters)
        {
            try
            {
                var menus = await _serviceManager.Menu.Get(paramerters);

                if (menus != null)
                {
                    Response.AddPaginationHeader(menus.CurrentPage,
                    menus.PageSize,
                    menus.TotalCount,
                    menus.TotalPages);
                    return Ok(menus);
                }

                return NotFound();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            try
            {
                var menus = _serviceManager.Menu.Get();
                return Ok(menus);
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
                var menu = await _serviceManager.Menu.Get(id);

                if (menu != null)
                    return Ok(menu);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpGet("MainMenus/{id}")]
        public IActionResult GetMainMenus(int id)
        {
            try
            {
                var menus = _serviceManager.Menu.GetMainMenus(id);

                if (menus != null)
                    return Ok(menus);

                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(MenuToSaveDto menuToSaveDto)
        {
            try
            {
                var id = await _serviceManager.Menu.Add(menuToSaveDto);
                if (id > 0)
                {
                    var role = await _serviceManager.Menu.Get(id);
                    return Ok(role);
                }
                return BadRequest();
            }
            catch (System.Exception e)
            {
                return HandleException(e);
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, MenuToEditDto menuToEditDto)
        {
            try
            {
                if (!await _serviceManager.Menu.Update(id, menuToEditDto))
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
                if (await _serviceManager.Menu.SoftDelete(id))
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