// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - CarsController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2021/11/13
// ==================================

namespace AutoLot.Mvc.Controllers;

public class CarsController : BaseCrudController<Car,CarsController>
{
    private readonly IMakeDataService _makeDataService;
    public CarsController(IAppLogging<CarsController> logging, ICarDataService dataService, IMakeDataService makeDataService) :base(logging,dataService)
    {
        _makeDataService = makeDataService;
    }
    protected override async Task<SelectList> GetLookupValuesAsync()
            => new SelectList(await _makeDataService.GetAllAsync(), nameof(Make.Id), nameof(Make.Name));


    [HttpGet("{makeId}/{makeName}")]
    public async Task<IActionResult> ByMakeAsync(int makeId, string makeName)
    {
        ViewBag.MakeName = makeName;
        return View(await ((ICarDataService)MainDataService).GetAllByMakeIdAsync(makeId));
    }
}