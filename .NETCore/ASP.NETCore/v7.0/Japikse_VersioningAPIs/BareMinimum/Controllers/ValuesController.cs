namespace BareMinimum.Controllers;

//[ApiVersion("1.0")]
//[ApiVersion("1.5", Deprecated = true)]
[ApiVersion("2.0")]
[ApiController]
//[Route("api/[controller]")]
[Route("api/v{version:apiVersion}/[controller]")]
public class Values11Controller : ControllerBase
{
    [ApiVersion("1.0")]
    [HttpGet]
    public string Get([FromServices]ApiVersion apiVersion) 
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    [ApiVersion("1.5",Deprecated=true)]
    [HttpGet("{id}")]
    public string Get2(int id)
    {
        ApiVersion version = HttpContext.GetRequestedApiVersion();
        return $"Controller = {GetType().Name}{Environment.NewLine}Version = {version}{Environment.NewLine}id = {id}";
    }

    [HttpGet]
    //[ApiVersion("1.5")]
    public string Get2(ApiVersion apiVersion)
        => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

    //[HttpGet]
    //[MapToApiVersion("3.0")]
    //public string Get3(ApiVersion apiVersion)
    //    => $"Controller = {GetType().Name}{Environment.NewLine}Version = {apiVersion}";

}