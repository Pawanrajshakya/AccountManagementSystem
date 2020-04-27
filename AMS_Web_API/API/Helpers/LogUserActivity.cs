using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Service_Layer.Interface;
using Microsoft.Extensions.DependencyInjection;
using Service_Layer.Helpers;

namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userName = context.HttpContext.User.Identity.Name;
            if (userName != null)
            {
                var service = context.HttpContext.RequestServices.GetService<IServiceManager>();
                var userDto = await service.User.FindBy(userName);
                CurrentUser.User = userDto;
            }
            await next();

        }
    }
}