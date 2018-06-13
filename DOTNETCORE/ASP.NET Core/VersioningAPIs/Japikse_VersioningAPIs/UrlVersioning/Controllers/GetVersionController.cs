using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace UrlVersioning.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class DifferentVersionsController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        [HttpGet]
        public string RequestedApiVersion() => JsonConvert.SerializeObject(HttpContext.GetRequestedApiVersion());
    }

}