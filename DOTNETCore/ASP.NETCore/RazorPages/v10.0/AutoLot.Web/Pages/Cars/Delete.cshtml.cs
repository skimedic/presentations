// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/10
// ==================================

namespace AutoLot.Web.Pages.Cars;
public class DeleteModel(IAppLogging appLogging, ICarRepo repo)
    : BasePageModel<Car>(appLogging, repo, "Delete")
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