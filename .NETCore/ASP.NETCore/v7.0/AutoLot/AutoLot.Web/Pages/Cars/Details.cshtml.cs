namespace AutoLot.Web.Pages.Cars;

public class DetailsModel : BasePageModel<Car,DetailsModel>
{

    public DetailsModel(
        IAppLogging<DetailsModel> appLogging, 
        ICarDataService carService) : base(appLogging, carService,"Details")
    {
    }

    public async Task OnGetAsync(int? id)
    {
        await GetOneAsync(id);
    }
}