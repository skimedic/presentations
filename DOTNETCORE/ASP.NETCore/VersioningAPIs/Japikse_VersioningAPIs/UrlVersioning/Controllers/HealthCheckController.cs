using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrlVersioning.Controllers
{
    [ApiVersionNeutral]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class HealthCheckController : Controller
    {
        // OPTIONS ~/api/myservice?api-version=[1.0|2.0|3.0]
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