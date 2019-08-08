using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerIntegration.Controllers
{
    //This blows up swagger
    //[ApiVersion("3.0-RC")]
    //[Route("api/values")]
    //[ApiController]
    //public class Values3Controller : Values2Controller
    //{
    //    [HttpGet, MapToApiVersion("3.0-RC")]
    //    public ActionResult<IEnumerable<string>> GetV3()
    //    {
    //        return new string[] { "value1v2", "value2v2" };
    //    }
    //}

    //HACK: DONT DO THIS IRL Keep the versions concise per controller
    [ApiVersion("2.0")]
    [ApiVersion("2.5", Deprecated = true)]
    [ApiVersion("3.0")]
    [ApiVersion("3.0-RC")]
    [Route("api/values")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        /// <summary>
        /// Gets the API Version.
        /// </summary>
        /// <returns>The JSON - controller name and version information.</returns>
        /// <response code="200">The values were successfully retrieved.</response>
        /// <response code="404">Not found.</response>
        [HttpGet]
        public string Get(ApiVersion apiVersion) 
            => $"Controller = {GetType().Name}\nVersion = {apiVersion}";

        [HttpGet, MapToApiVersion("3.0-RC")]
        public string GetV3(ApiVersion apiVersion) 
            => $"Controller = {GetType().Name}\nVersion = {apiVersion}";


    }
}
