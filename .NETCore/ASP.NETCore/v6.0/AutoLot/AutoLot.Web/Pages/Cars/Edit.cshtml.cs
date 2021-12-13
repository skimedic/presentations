namespace AutoLot.Web.Pages.Cars;

public class EditModel : BasePageModel<Car,EditModel>
{
    private readonly IMakeDataService _makeService;

    public EditModel(IAppLogging<EditModel> appLogging, 
        ICarDataService carService, 
        IMakeDataService makeService) 
        : base(appLogging, carService, "Edit")
    {
        _makeService = makeService;
    }
    
    public async Task OnGetAsync(int? id)
    {
        await GetLookupValuesAsync(_makeService, nameof(Make.Id), nameof(Make.Name));
        await GetOneAsync(id);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        return await SaveWithLookupAsync(
            DataService.UpdateAsync,
            _makeService, 
            nameof(Make.Id),
            nameof(Make.Name));

    }
}