// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - FolderVersioning - ValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

namespace FolderVersioning.Controllers.V1._1;

[ApiController]
[Obsolete("Please use another version")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ValuesController : ControllerBase
{
    // GET api/values
    [HttpGet]
    public string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}