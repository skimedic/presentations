using System.Threading.Tasks;
using Kcdc.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  public class SponsorsController : Controller
  {
    private readonly KcdcContext context;
    public SponsorsController(KcdcContext context)
    {
      this.context = context;
    }

    public async Task<IActionResult> Get()
    {
        return Ok(await context.Sponsors.ToListAsync());
    }
  }
}