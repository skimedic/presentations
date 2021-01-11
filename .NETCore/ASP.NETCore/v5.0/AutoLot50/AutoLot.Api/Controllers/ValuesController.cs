using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AutoLot.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// This is an example Get method returning JSON
        /// </summary>
        /// <remarks>This is one of several examples for returning JSON:
        /// <pre>
        /// [
        ///   "value1",
        ///   "value2"
        /// ]
        /// </pre>
        /// </remarks>
        /// <returns>List of strings</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(200, "The execution was successful")]
        [SwaggerResponse(400, "The request was invalid")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"value1", "value2"};
        }

        [HttpGet("test1")]
        public IActionResult Get1()
        {
            return Ok(new string[] {"value1", "value2"});
        }

        [HttpGet("test2")]
        public string[] Get2()
        {
            return new string[] {"value1", "value2"};
        }

        [HttpGet("test3")]
        public IActionResult Get3()
        {
            return new JsonResult(new string[] {"value1", "value2"});
        }

        [HttpGet("error")]
        public IActionResult Error()
        {
            return NotFound();
        }
    }
}