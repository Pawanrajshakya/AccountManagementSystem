using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Service_Layer.Interface;
using Microsoft.Extensions.DependencyInjection;
using Service_Layer.Helpers;
using Service_Layer.Dtos;
using System;
using System.Text;

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
                UserActivityToSaveDto userActivityToSaveDto = new UserActivityToSaveDto();
                userActivityToSaveDto.ControllerName = context.Controller.ToString();
                userActivityToSaveDto.DateRequested = DateTime.Now;
                userActivityToSaveDto.UserId = userDto.Id;
                userActivityToSaveDto.ActionName = context.ActionDescriptor.DisplayName.ToString();
                var valuesString = new StringBuilder();
                foreach (var value in context.HttpContext.User.Claims)
                {
                    valuesString.Append(value.Type
                        + " : "
                        + value.Value
                        + "; ");
                }
                userActivityToSaveDto.Comment = valuesString.ToString();
                await service.UserActivity.Add(userActivityToSaveDto);
            }
            await next();

        }
    }
}