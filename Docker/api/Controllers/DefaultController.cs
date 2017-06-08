using Kcdc.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kcdc.Api.Controllers
{
  public class DefaultController : Controller
  {
    private string appHref;
    private readonly KcdcContext context;

    public DefaultController(KcdcContext context)
    {
      this.context = context;
      appHref = "http://localhost:5000/api/";
    }
    // GET api
    [HttpGet]
    public IActionResult Get()
    {
      var rootData = new
      {
        Api = "KCDC API (Running in Container - But the files are local)",
        Version = 1,
        Href = "http://kcdc.info/api",
        Speakers = new
        {
          Href = $"{this.appHref}speakers"
        },
        Sessions = new
        {
          Href = $"{this.appHref}sessions"
        },
        Sponsors = new
        {
          Href = $"{this.appHref}sponsors"
        },
        Registration = new
        {
          Href = $"{this.appHref}register"
        }
      };
      return Ok(rootData);
    }
  }
}