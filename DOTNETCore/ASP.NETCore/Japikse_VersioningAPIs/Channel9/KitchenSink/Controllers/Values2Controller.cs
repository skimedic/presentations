// Copyright Information
// ==================================
// Japikse_VersioningDocumentingAPIs - KitchenSink - Values2Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/25
// ==================================

namespace KitchenSink.Controllers;

[ApiVersion("2.0")]
public class Values2Controller : Values1Controller
{
        /// <summary>
    /// Show the version (2.0) and controller name
    /// </summary>
    /// <param name="apiVersion">The version of the API</param>
    /// <returns>Version and Controller Name</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful (2.0)")]
    [SwaggerResponse(400, "The request was invalid (2.0)")]
    [SwaggerResponse(401, "Unauthorized access attempted (2.0)")]
[HttpGet]
    public override string Get(ApiVersion apiVersion)
        => $"2 => Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet]
    [ApiVersion(2.5,Deprecated = true)]
    public string GetOld(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    public override string Get(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        return $"Controller = {GetType().Name}{Environment.NewLine}Version = {version}{Environment.NewLine}id = {id}";
    }
}