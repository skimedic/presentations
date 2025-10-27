// Copyright Information
// ==================================
// Japikse_VersioningDocumentingAPIs - KitchenSink - Values3Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/25
// ==================================

namespace KitchenSink.Controllers;

[ApiVersion("3.0")]
public class Values3Controller : Values2Controller
{
    /// <summary>
    /// Show the version (3.0) and controller name
    /// </summary>
    /// <param name="apiVersion">The version of the API</param>
    /// <returns>Version and Controller Name</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [SwaggerResponse(200, "The execution was successful (3.0)")]
    [SwaggerResponse(400, "The request was invalid (3.0)")]
    [SwaggerResponse(401, "Unauthorized access attempted (3.0)")]
    [HttpGet]
    public override string Get(ApiVersion apiVersion)
        => $"3 => Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet]
    [ApiVersion("3.0-Beta")]
    public string GetBeta(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}