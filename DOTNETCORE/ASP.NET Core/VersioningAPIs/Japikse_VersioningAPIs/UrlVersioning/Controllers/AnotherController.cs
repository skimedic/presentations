using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UrlVersioning.Controllers
{
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AnotherController : Controller
    {
        /// <summary>
        /// Old version
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1v3", "value2v3" };
        }
    }
}