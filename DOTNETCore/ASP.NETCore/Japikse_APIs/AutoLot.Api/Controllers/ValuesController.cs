// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - ValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController(IAppLogging<ValuesController> logger) : ControllerBase
{
    [HttpGet("problem")]
    public IActionResult Problem() => NotFound();

    [HttpGet("logging")]
    public IActionResult TestLogging()
    {
        //logger.LogAppError("Test error");
        return Ok();
    }

    [HttpGet("error")]
    public IActionResult TestExceptionHandling()
    {
        throw new Exception("Test Exception");
    }
}
