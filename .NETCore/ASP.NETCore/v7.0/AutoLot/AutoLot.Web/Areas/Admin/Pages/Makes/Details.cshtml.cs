namespace AutoLot.Web.Areas.Admin.Pages.Makes;

public class DetailsModel : BasePageModel<Make,DetailsModel>
{

    public DetailsModel(
        IAppLogging<DetailsModel> appLogging, 
        IMakeDataService makeService) : base(appLogging, makeService,"Details")
    {
    }

    public async Task OnGetAsync(int? id)
    {
        await GetOneAsync(id);
    }
}