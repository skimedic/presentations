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
    //    [HttpGet]
    //    public override ActionResult<IEnumerable<string>> Get()
    //    {
    //        return base.Get();
    //    }
    //    [HttpGet("{id}")]
    //    public override ActionResult<IEnumerable<string>> Get(int id, ApiVersion version)
    //    {
    //        return base.Get(id, version);
    //    }
    //}

    //HACK: DONT DO THIS IRL Keep the versions concise per controller
    [ApiVersion("2.0")]
    [ApiVersion("2.5", Deprecated = true)]
    [ApiVersion("3.0")]
    [ApiVersion("3.0-RC")]
    [Route("api/values")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        /// <summary>
        /// Gets two values.
        /// </summary>
        /// <returns>The two strings.</returns>
        /// <response code="200">The values were successfully retrieved.</response>
        /// <response code="404">Not found.</response>
        [HttpGet]
        public virtual ActionResult<IEnumerable<string>> Get()
        {
            var version = HttpContext.GetRequestedApiVersion();
            return new string[] { "value1v2", "value2v2" };
        }

        [HttpGet, MapToApiVersion("3.0-RC")]
        public ActionResult<IEnumerable<string>> GetV3()
        {
            return new string[] { "value1v3RC", "value2v3RC" };
        }

        [HttpGet("{id}")]
        public virtual ActionResult<IEnumerable<string>> Get(int id, ApiVersion version)
        {
            var foo = "foo";
            return new string[] { "value1v2", "value2v2" };
        }

    }
}
