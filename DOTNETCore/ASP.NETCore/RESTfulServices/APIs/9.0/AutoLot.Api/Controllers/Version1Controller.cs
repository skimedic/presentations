// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - Version1Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class Version1Controller : ControllerBase
{
    [HttpGet]
    public virtual string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
    
    [HttpGet("{id}")]
    public virtual string Get(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        var newLine = Environment.NewLine;
        return $"Controller = {GetType().Name}{newLine}Version = {version}{newLine}id = {id}";
    }
}