using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicSetup.Controllers
{
    [ApiVersionNeutral]
    [ApiController]
    [Route("api/[controller]")]
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