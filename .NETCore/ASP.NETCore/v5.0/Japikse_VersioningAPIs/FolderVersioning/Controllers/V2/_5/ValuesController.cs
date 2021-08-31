
using Microsoft.AspNetCore.Mvc;

namespace FolderVersioning.Controllers.V2_5
{
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get(ApiVersion apiVersion)
            => $"Controller = {GetType().Name}\nVersion = {apiVersion}";
    }
}
