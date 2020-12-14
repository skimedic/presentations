// Copyright Information
// ==================================
// AutoLot - AutoLot.Api - ValuesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("test1")]
        public IActionResult Get1()
        {
            return Ok(new string[] { "value1", "value2" });
        }
        [HttpGet("test2")]
        public string[] Get2()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("test3")]
        public IActionResult Get3()
        {
            return new JsonResult(new string[] { "value1", "value2" });
        }

    }
}