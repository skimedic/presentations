// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - FolderVersioning - ValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

using Microsoft.AspNetCore.Mvc;

namespace FolderVersioning.Controllers.V3;

//HACK: This is an example of what NOT to do
[ApiController]
//[ApiVersion("3.0")]
[Route("api/[controller]")]
[Route("api/api-version{version:apiVersion}/[controller]")]
public class ValuesController : ControllerBase
{
    //http://localhost:61528/api/api-version3.0/values
    // GET api/values
    [HttpGet]
    public string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}