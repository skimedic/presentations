using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicSetup.Controllers
{
    [ApiVersion("2.0")]
    //[ApiVersion("3.0")]
    [Route("api/values")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var version = HttpContext.GetRequestedApiVersion();
            return new string[] { "value1v2", "value2v2" };
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id, ApiVersion version)
        {
            var foo = "foo";
            return new string[] { "value1v2", "value2v2" };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
