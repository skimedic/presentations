using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BareMinimum.Controllers
{
    [ApiVersion("1.0")]
    //[ApiVersion("1.5",Deprecated=true)]
    //[ApiVersion("2.0")]
    [ApiController]
    //[Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get(ApiVersion apiVersion) 
            => $"Controller = {GetType().Name}\nVersion = {apiVersion}";

        [HttpGet("{id}")]
        public string Get2(int id)
        {
            ApiVersion version = HttpContext.GetRequestedApiVersion();
            return $"Controller = {GetType().Name}\nVersion = {version}";
        }

        //[HttpGet]
        //[ApiVersion("1.5")]
        //public string Get2(ApiVersion apiVersion)
        //    => $"Controller = {GetType().Name}\nVersion = {apiVersion}";

        //[HttpGet]
        //[MapToApiVersion("3.0")]
        //public string Get3(ApiVersion apiVersion)
        //    => $"Controller = {GetType().Name}\nVersion = {apiVersion}";

    }
}
