namespace FullSwaggerSupport.Controllers;

//It is not recommended to have multiple versions on the same
// controller-this is demo code
//[ApiVersion("1.0")]
//[ApiVersion("2.0")]
[ApiController]
[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class Values1Controller : ValuesController
{
    ////[MapToApiVersion("2.0")]
    ////[ApiVersion("1.0")]
    ////[ApiVersion("2.0")]
    [ApiVersion("3.0")]
    ////[ApiVersionNeutral]
    [HttpGet]
    public string Get(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet("{id}")]
    public string Get2(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        return $"Controller = {GetType().Name}{Environment.NewLine}Version = {version}{Environment.NewLine}id = {id}";
    }

    [HttpGet]
    [ApiVersion("1.5", Deprecated = true)]
    public string Get2(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet]
    //[ApiVersion("1.5")] //This indeprecates v1.5
    [MapToApiVersion("3.0")] 
    public string Get3(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [HttpGet]
    [ApiVersion("3.0.Beta")]
    public string Get4(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

}
//[ApiVersion("2.0")]