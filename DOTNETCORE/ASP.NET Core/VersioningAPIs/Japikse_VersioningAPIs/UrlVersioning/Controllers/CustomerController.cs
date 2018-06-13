using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UrlVersioning.Controllers
{

    //[ApiVersion("3.0")]
    [ApiVersion("1.1", Deprecated = true)]
    [Route("api/v{version:apiVersion}/Customer")]
    public class CustomerController : Controller
    {
        /// <summary>
        /// Old version
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1v2", "value2v2" };
        }
        ///// <summary>
        ///// New version
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, MapToApiVersion("3.0")]
        //public ActionResult<IEnumerable<string>> GetV3()
        //{
        //    return new string[] { "value1v2", "value2v2" };
        //}

    }
}