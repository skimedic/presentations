// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - FullSwaggerSupport - Values1Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================


namespace FullSwaggerSupport.Controllers;

[ControllerName("Values")]
[ApiVersion("1.0")]
//[ApiController]
public class Values1Controller : BaseValuesController
{
    /// <summary>
    /// Show the version (1.0) and controller name
    /// </summary>
    /// <param name="apiVersion">The version of the API</param>
    /// <returns>Version and Controller Name</returns>
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful")]
    [SwaggerResponse(400, "The request was invalid")]
    [SwaggerResponse(401, "Unauthorized access attempted")]
    [HttpGet]
    public virtual string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    public virtual string Get(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        return $"Controller = {GetType().Name}{Environment.NewLine}Version = {version}{Environment.NewLine}id = {id}";
    }

    [HttpGet("/problem")]
    public IActionResult Problem()
    {
        return NotFound();
    }

    [HttpGet("{id}")]
    [ApiVersion("1.5", Deprecated = true)]
    public virtual string Get(int id, ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}
