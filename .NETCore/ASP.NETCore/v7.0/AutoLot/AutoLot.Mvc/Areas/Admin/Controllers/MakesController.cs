// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - MakesController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2021/11/13
// ==================================

namespace AutoLot.Mvc.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]")]
public class MakesController : BaseCrudController<Make, MakesController>
{
    public MakesController(IAppLogging<MakesController> appLogging, IMakeDataService baseRepo) : base(appLogging, baseRepo)
    {
    }

    protected override async Task<SelectList> GetLookupValuesAsync()
    {
        return null;
    }

    // GET: Admin/Makes
    [Route("/Admin")]
    [Route("/Admin/[controller]")]
    [Route("/Admin/[controller]/[action]")]

    public override async Task<IActionResult> IndexAsync()
    {
        return await base.IndexAsync();
    }
}