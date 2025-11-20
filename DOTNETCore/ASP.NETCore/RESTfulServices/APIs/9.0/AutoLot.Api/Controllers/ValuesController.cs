// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - ValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersionNeutral]
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ValuesController(IAppLogging logger) : ControllerBase
{
    [HttpGet("problem")]
    public IActionResult Problem() => NotFound();

    [HttpGet("logging")]
    public IActionResult TestLogging()
    {
        logger.LogAppError("Test error");
        return Ok();
    }

    [HttpGet("error")]
    public IActionResult TestExceptionHandling()
    {
        throw new Exception("Test Exception");
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpGet("hidden/{id?}")]
    public string HiddenEndPoint(int? id, ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}