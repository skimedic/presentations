namespace AutoLot.Api.Filters;

public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IWebHostEnvironment _hostEnvironment;

    public CustomExceptionFilterAttribute(IWebHostEnvironment hostEnvironment)
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
            case DbUpdateConcurrencyException ce:
                //Returns a 400
                error = "Concurrency Issue.";
                actionResult = new BadRequestObjectResult(
                    new { Error = error, Message = message, StackTrace = stackTrace });
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
