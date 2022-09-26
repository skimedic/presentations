namespace FullSwaggerSupport.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Route("api/v{version:apiVersion}/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public virtual string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}

[ApiController]
[ApiVersion("4.0")]
[Route("api/[controller]")]
//[Route("api/v{version:apiVersion}/[controller]")]
public class Values4Controller : ValuesController
{
    [HttpGet("{id}/{name}")]
    [ApiVersion("4.0-beta")]
    public string Get(ApiVersion apiVersion, int id, string name )
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";
}
