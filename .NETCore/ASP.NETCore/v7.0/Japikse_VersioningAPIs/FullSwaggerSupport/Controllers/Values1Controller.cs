// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - FullSwaggerSupport - Values1Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

using Microsoft.AspNetCore.Authorization;

namespace FullSwaggerSupport.Controllers;

[ApiVersion("1.0")]
//[ApiController]
public class Values1Controller : BaseValuesController
{
    [HttpGet]
    public virtual string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    public virtual string Get(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        return $"Controller = {GetType().Name}{Environment.NewLine}Version = {version}{Environment.NewLine}id = {id}";
    }

    [HttpGet("{id}")]
    [ApiVersion("1.5", Deprecated = true)]
    public virtual string Get(int id, ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}
