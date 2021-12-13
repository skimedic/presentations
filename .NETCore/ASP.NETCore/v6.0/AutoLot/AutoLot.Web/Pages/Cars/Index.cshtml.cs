namespace AutoLot.Web.Pages.Cars;

public class IndexModel : PageModel
{
    private readonly IAppLogging<IndexModel> _appLogging;
    private readonly ICarDataService _carService;

    [ViewData]
    public string Title => "Inventory";

    public IndexModel(IAppLogging<IndexModel> appLogging, ICarDataService carService)
    {
        _appLogging = appLogging;
        _carService = carService;
    }

    public string MakeName { get; set; }
    public int? MakeId { get; set; }
    public IEnumerable<Car> CarRecords { get; set; }
    public async Task OnGetAsync(int? makeId, string makeName)
    {
        MakeId = makeId;
        MakeName = makeName;
        CarRecords = await _carService.GetAllByMakeIdAsync(makeId);
    }
}