// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - FullSwaggerSupport - Values3Controller.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

namespace FullSwaggerSupport.Controllers;

[ApiVersion("3.0")]
//[ApiController]
public class Values3Controller : Values2Controller
{
    [HttpGet]
    public override string Get(ApiVersion apiVersion)
        => $"3 => Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet]
    [ApiVersion("3.0.Beta")]
    public string Get4(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

}