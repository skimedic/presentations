using System.Net;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc;

namespace FullSwaggerSupport.Controllers
{
    //Demo: 1B. Version Neutral
    [ApiVersionNeutral]
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    public class HealthCheckController : Controller
    {
        // OPTIONS ~/api/myservice?api-version=[1.0|1.5|2.0|3.0]
        [HttpOptions]
        public IActionResult Options()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(string.Empty);
            response.Content.Headers.Add("Allow", new[] { "GET", "POST", "OPTIONS" });
            response.Content.Headers.ContentType = null;
            return Ok(response);
        }
    }
}