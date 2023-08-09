// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - FullSwaggerSupport - Values2Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

namespace FullSwaggerSupport.Controllers;

[ApiVersion("2.0")]
//[ApiController]
public class Values2Controller : Values1Controller
{
    [HttpGet]
    public override string Get(ApiVersion apiVersion)
        => $"2 => Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    [ApiVersion("2.0")]
    public string Get2(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        return $"Controller = {GetType().Name}{Environment.NewLine}Version = {version}{Environment.NewLine}id = {id}";
    }
}