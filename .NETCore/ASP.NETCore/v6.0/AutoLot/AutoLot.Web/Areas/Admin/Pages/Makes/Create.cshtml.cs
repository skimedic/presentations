namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class CreateModel : BasePageModel<Make,CreateModel>
{
    private readonly IMakeDataService _makeService;

    public CreateModel(
        IAppLogging<CreateModel> appLogging, 
        IMakeDataService makeService) : base(appLogging, makeService, "Create")
    {
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        return await SaveOneAsync(DataService.AddAsync);
    }
}