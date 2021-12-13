namespace AutoLot.Web.Pages.Cars;

public class CreateModel : BasePageModel<Car,CreateModel>
{
    private readonly IMakeDataService _makeService;

    public CreateModel(
        IAppLogging<CreateModel> appLogging, 
        ICarDataService carService, 
        IMakeDataService makeService) : base(appLogging, carService, "Create")
    {
        _makeService = makeService;
    }

    public async Task OnGetAsync()
    {
        await GetLookupValuesAsync(_makeService, nameof(Make.Id), nameof(Make.Name));
    }

    public async Task<IActionResult> OnPostCreateNewCarAsync()
    {
        return await SaveWithLookupAsync(
            DataService.AddAsync,
            _makeService, 
            nameof(Make.Id),
            nameof(Make.Name));
    }
}