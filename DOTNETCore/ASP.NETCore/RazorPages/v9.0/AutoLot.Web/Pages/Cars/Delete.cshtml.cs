// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

namespace AutoLot.Web.Pages.Cars;
public class DeleteModel(IAppLogging<DeleteModel> appLogging, ICarRepo repo)
    : BasePageModel<Car, DeleteModel>(appLogging, repo, "Delete")
{
    public void OnGet(int? id)
    {
        if (!id.HasValue)
        {
            Error = "Invalid request";
            Entity = null;
            return;
        }
        GetOne(id);
    }
    public IActionResult OnPost(int id) => DeleteOne(id);
}