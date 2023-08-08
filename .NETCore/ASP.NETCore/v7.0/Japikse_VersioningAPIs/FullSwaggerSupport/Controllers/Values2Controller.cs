namespace FullSwaggerSupport.Controllers;

[ApiController]
[ApiVersion("2.0")]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class Values2Controller : ValuesController
{
    [HttpGet]
    public override string Get(ApiVersion apiVersion)
        => $"Foo => Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    [ApiVersion("2.0")]
    public string Get2(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        return $"Controller = {GetType().Name}{Environment.NewLine}Version = {version}{Environment.NewLine}id = {id}";
    }

    //[HttpGet]
    //[ApiVersion("1.5", Deprecated = true)]
    //public string Get2(ApiVersion apiVersion)
    //    => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet]
    [MapToApiVersion("3.0")]
    public string Get3(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet]
    [ApiVersion("3.0.Beta")]
    public string Get4(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

}