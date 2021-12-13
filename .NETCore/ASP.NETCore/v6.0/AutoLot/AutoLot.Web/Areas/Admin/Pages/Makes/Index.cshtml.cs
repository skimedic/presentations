namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class IndexModel : PageModel
{
    private readonly IAppLogging<IndexModel> _appLogging;
    private readonly IMakeDataService _makeService;

    [ViewData]
    public string Title => "Makes";

    public IndexModel(IAppLogging<IndexModel> appLogging, IMakeDataService carService)
    {
        _appLogging = appLogging;
        _makeService = carService;
    }

    public IEnumerable<Make> MakeRecords { get; set; }
    public async Task OnGetAsync()
    {
        MakeRecords = await _makeService.GetAllAsync();
    }
}