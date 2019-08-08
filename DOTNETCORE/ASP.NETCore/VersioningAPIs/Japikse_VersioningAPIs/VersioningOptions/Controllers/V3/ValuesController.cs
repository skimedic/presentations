using Microsoft.AspNetCore.Mvc;

namespace VersioningOptions.Controllers.V3
{
    //HACK: This is an example of what NOT to do
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/api-version{version:apiVersion}/[controller]")]
    public class ValuesController : ControllerBase
    {
        //http://localhost:61528/api/api-version3.0/values
        // GET api/values
        [HttpGet]
        public string Get(ApiVersion apiVersion) 
            => $"Controller = {GetType().Name}\nVersion = {apiVersion}";
    }
}
