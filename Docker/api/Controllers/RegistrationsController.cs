using System.Threading.Tasks;
using Kcdc.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  public class RegistrationsController : Controller
  {
    private readonly KcdcContext context;
    public RegistrationsController(KcdcContext context)
    {
      this.context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var registrations = await context.Registrations.ToListAsync();
        return Ok(registrations);
    }
  }
}