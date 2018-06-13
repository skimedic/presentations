using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UrlVersioning.Controllers
{
    //[ApiVersionNeutral]
    //[Route("api/[controller]/[action]")]
    //public class HealthController : Controller
    //{
    //    [HttpGet]
    //    public IActionResult Ping() => Ok();
    //}

    [ApiVersionNeutral]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class HealthController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Ping() => "Ok";
    }
}