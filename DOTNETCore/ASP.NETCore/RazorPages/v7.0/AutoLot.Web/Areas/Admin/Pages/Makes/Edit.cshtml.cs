// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class EditModel : BasePageModel<Make,EditModel>
{
    public EditModel(IAppLogging<EditModel> appLogging, IMakeRepo repo) 
        : base(appLogging, repo, "Edit") { }
    public void OnGet(int? id) => GetOne(id);

    public IActionResult OnPost() => SaveOne(BaseRepoInstance.Update);
}