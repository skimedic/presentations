using Microsoft.AspNetCore.Mvc;

namespace SwaggerIntegration.Controllers
{
    [ApiVersion("3.0-RC")]
    [Route("api/values")]
    [ApiController]
    public class Values3Controller : Values2Controller
    {
        [HttpGet("{id}")]
        public ActionResult<string> GetV3(ApiVersion apiVersion, int id)
            => $"Controller = {GetType().Name}\nVersion = {apiVersion}";
    }
}