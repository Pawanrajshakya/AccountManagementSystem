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

        // public string CurrentClaims
        // {
        //     get
        //     {
        //         ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
        //         var claims = new StringBuilder();
        //         if (null != principal)
        //         {
        //             foreach (Claim claim in principal.Claims)
        //             {
        //                 claims.Append("CLAIM TYPE: " + claim.Type + "; CLAIM VALUE: " + claim.Value + "</br>");
        //             }
        //         }
        //         return claims.ToString();
        //         // //_serviceManager.User.FindBy(UserClaim.Identity.Name).Result.Id;
        //         // var userid = _serviceManager.User.FindBy(UserClaim.Identity.Name).Result.Id;
        //         // var user = _serviceManager.User.Get(1).Result;
        //         // return 1;
        //     }
        //}

        public BaseApiController(IServiceManager service, IConfiguration config)
        {
            _config = config;
            _serviceManager = service;
            //_serviceManager.UserId = GetCurrentUserId().Result;
        }

        public async Task<int> GetCurrentUserId()
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var user = await _serviceManager.User.FindBy(principal.Identity.Name);
            return user.Id;
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


        protected IActionResult HandleException(Exception exception)
        {
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
            return BadRequest(exception.Message);
        }

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