using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace SpyStore.Hol.Mvc.Controllers.Base
{
    public class BaseController : Controller
    {
        private IConfiguration _configuration;

        public BaseController(IConfiguration configuration) => this._configuration = configuration;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.CustomerId = _configuration.GetValue<int>("CustomerId");
        }
    }
}
