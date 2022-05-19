using System;

using Microsoft.AspNetCore.Mvc;

namespace FolderVersioning.Controllers.V2_1;

[ApiController]
[Obsolete("Use another version")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ValuesController : ControllerBase
{
    // GET api/values
    [HttpGet]
    public string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}