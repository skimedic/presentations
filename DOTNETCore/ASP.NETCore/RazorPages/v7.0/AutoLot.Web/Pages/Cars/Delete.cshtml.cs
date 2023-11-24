// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Pages.Cars;
public class DeleteModel : BasePageModel<Car, DeleteModel>
{
    public DeleteModel(IAppLogging<DeleteModel> appLogging, ICarRepo repo) : base(appLogging, repo, "Delete") { }
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