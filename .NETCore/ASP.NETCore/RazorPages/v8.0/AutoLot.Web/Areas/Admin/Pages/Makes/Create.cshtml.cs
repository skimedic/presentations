// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class CreateModel : BasePageModel<Make, CreateModel>
{
    public CreateModel(IAppLogging<CreateModel> appLogging, IMakeRepo makeRepo)
        : base(appLogging, makeRepo, "Create") { }
    public void OnGet() => Entity = new Make();
    public IActionResult OnPost() => SaveOne(BaseRepoInstance.Add);
}