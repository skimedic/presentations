namespace AutoLot.Api.Controllers;

[AllowAnonymous]
[ApiVersion("0.5", Deprecated = true)]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    //[HttpGet("{id}")]
    //[ApiVersion("2.0")]
    ////[MapToApiVersion("2.0")]
    //public IActionResult Get(int id)
    //{
    //    return Ok(new[] { "value1", "value2" });
    //}

    /// <summary>
    /// This is an example Get method returning JSON
    /// </summary>
    /// <remarks>This is one of several examples for returning JSON:
    /// <pre>
    /// [
    ///   "value1",
    ///   "value2"
    /// ]
    /// </pre>
    /// </remarks>
    /// <returns>List of strings</returns>
    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    public IActionResult Get()
    {
        return Ok(new string[] { "value1", "value2" });
    }

    [HttpGet("one")]
    public IEnumerable<string> Get1()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("two")]
    public ActionResult<IEnumerable<string>> Get2()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("three")]
    public string[] Get3()
    {
        return new string[] { "value1", "value2" };
    }

    [HttpGet("four")]
    public IActionResult Get4()
    {
        return new JsonResult(new string[] { "value1", "value2" });
    }

    [HttpPost]
    public IActionResult BadBindingExample(WeatherForecast forecast)
    {
        //return Ok(forecast);
        return ModelState.IsValid ? Ok(forecast) : ValidationProblem(ModelState);
    }

    [HttpGet("error")]
    public IActionResult Error()
    {
        return NotFound();
    }
}