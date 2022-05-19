namespace FullSwaggerSupport.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Route("api/v{version:apiVersion}/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";


}