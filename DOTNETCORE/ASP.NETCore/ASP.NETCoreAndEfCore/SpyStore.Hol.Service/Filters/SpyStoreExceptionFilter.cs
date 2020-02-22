using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SpyStore.Hol.Dal.Exceptions;

namespace SpyStore.Hol.Service.Filters
{
    public class SpyStoreExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public SpyStoreExceptionFilter(
            IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public override void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            string stackTrace = _hostEnvironment.IsDevelopment() ? context.Exception.StackTrace : string.Empty;
            string message = ex.Message;
            string error;
            IActionResult actionResult;
            switch (ex)
            {
                case SpyStoreInvalidQuantityException iqe:
                    //Returns a 400
                    error = "Invalid quantity request.";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace });
                    break;
                case DbUpdateConcurrencyException ce:
                    //Returns a 400
                    error = "Concurrency Issue.";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace });
                    break;
                case SpyStoreInvalidProductException ipe:
                    //Returns a 400
                    error = "Invalid Product Id.";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace });
                    break;
                case SpyStoreInvalidCustomerException ice:
                    //Returns a 400
                    error = "Invalid Customer Id.";
                    actionResult = new BadRequestObjectResult(new { Error = error, Message = message, StackTrace = stackTrace });
                    break;
                default:
                    error = "General Error.";
                    actionResult = new ObjectResult(new { Error = error, Message = message, StackTrace = stackTrace })
                    {
                        StatusCode = 500
                    };
                    break;
            }
            //context.ExceptionHandled = true; //If this is uncommented, the exception is swallowed
            context.Result = actionResult;
        }
    }
}
