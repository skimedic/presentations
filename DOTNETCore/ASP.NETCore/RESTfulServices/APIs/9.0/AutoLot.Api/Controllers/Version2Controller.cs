// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - Version2Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Controllers;

[ApiVersion("2.0")]
public class Version2Controller : Version1Controller
{
    [HttpGet]
    public override string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
    [HttpGet("{id}")]
    public override string Get(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        var newLine = Environment.NewLine;
        return $"Controller = {GetType().Name}{newLine}Version = {version}{newLine}id = {id}";
    }
}