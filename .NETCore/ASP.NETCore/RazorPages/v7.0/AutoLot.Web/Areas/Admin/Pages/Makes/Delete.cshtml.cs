// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Delete.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class DeleteModel : BasePageModel<Make,DeleteModel>
{
    public DeleteModel(IAppLogging<DeleteModel> appLogging, IMakeRepo repo) 
        : base(appLogging, repo, "Delete")
    {
    }
    public void OnGet(int? id) => GetOne(id);

    public IActionResult OnPost(int id) => DeleteOne(id);
}