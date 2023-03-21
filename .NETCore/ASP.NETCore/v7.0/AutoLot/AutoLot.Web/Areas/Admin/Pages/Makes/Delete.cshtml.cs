namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class DeleteModel : BasePageModel<Make,DeleteModel>
{
    public DeleteModel(
        IAppLogging<DeleteModel> appLogging, 
        IMakeDataService makeService) : base(appLogging, makeService, "Delete")
    {
    }

    public async Task OnGetAsync(int? id)
    {
        await GetOneAsync(id);
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        return await DeleteOneAsync(id);
    }
}