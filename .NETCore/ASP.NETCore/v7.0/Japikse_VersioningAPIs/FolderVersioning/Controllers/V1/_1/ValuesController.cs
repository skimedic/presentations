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