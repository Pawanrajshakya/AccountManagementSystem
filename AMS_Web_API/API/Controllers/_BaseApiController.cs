using API.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service_Layer.Interface;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IServiceManager _serviceManager;
        protected readonly IConfiguration _config;

        // Summary:
        //     Gets the System.Security.Claims.ClaimsPrincipal for user associated with the
        //     executing action.
        protected ClaimsPrincipal UserClaim { get; }

        public BaseApiController(IServiceManager service, IConfiguration config)
        {
            _config = config;
            _serviceManager = service;
        }


        protected IActionResult GetModalStateMessage()
        {
            var error = ModelState.Values
                .SelectMany(x => x.Errors)
                .Select(x => x.ErrorMessage)
                .ToList();

            var stringBuilder = new StringBuilder();

            foreach (var e in error)
            {
                stringBuilder.Append(e + ",");
            };

            stringBuilder.Append("Invalid Request");

            return BadRequest(stringBuilder.ToString());
        }


        protected IActionResult HandleException(Exception exception) =>
            // if (exception.GetType().Name == "DbUpdateException")
            // {
            //     return BadRequest(exception.InnerException.InnerException);
            // }
            // else if (exception.GetType().Name == "DbEntityValidationException")
            // {
            //     var stringBuilder = new StringBuilder();

            //     var dbEntityValidationException = (DbEntityValidationException)exception;

            //     foreach (var entityValidationErrors in dbEntityValidationException.EntityValidationErrors)
            //     {
            //         foreach (var validationError in entityValidationErrors.ValidationErrors)
            //         {
            //             stringBuilder.Append("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage + ",");
            //         }
            //     }

            //     stringBuilder.Append("Invalid Request");

            //     return BadRequest(stringBuilder.ToString());
            // }
            // return InternalServerError(exception);
            
            BadRequest(new ErrorMessageDto { Message = exception.Message });

        protected static T GetSortBy<T>(string sortBy, T defaultSortBy)
        {
            T _SortBy = defaultSortBy;

            if (!string.IsNullOrEmpty(sortBy))
            {
                foreach (var item in Enum.GetValues(typeof(T)))
                {
                    if (((T)item).ToString().ToUpper() == sortBy.ToUpper())
                    {
                        _SortBy = ((T)item);
                    }
                }
            }

            return _SortBy;
        }
    }
}