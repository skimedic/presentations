using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicSetup.Controllers
{
    [ApiVersion("2.0")]
    [ApiVersion("2.5")]
    [ApiVersion("3.0")]
    [ApiVersion("2019-05-20.3.0-RC")]
    [Route("api/values")]
    [ApiController]
    public class Values2Controller : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public string Get(ApiVersion apiVersion) 
            => $"Controller = {GetType().Name}\nVersion = {apiVersion}";

        [HttpGet("{id}"), MapToApiVersion("3.0")]
        public string GetV3(ApiVersion apiVersion) 
            => $"Controller = {GetType().Name}\nVersion = {apiVersion}";
    }
}
