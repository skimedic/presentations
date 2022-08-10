// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class DeleteModel : BasePageModel<Car,DeleteModel>
{
    public DeleteModel(
        IAppLogging<DeleteModel> appLogging, 
        ICarDataService carService) : base(appLogging, carService, "Delete")
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