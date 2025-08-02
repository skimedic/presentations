// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Web.Pages.Cars;
public class EditModel(IAppLogging<EditModel> appLogging, ICarRepo carRepo, IMakeRepo makeRepo)
    : BasePageModel<Car, EditModel>(appLogging, carRepo, "Edit")
{
    public void OnGet(int id)
    {
        GetLookupValues();
        GetOne(id);
    }

    public IActionResult OnPost()
    {
        return SaveWithLookup(BaseRepoInstance.Update);
    }

    protected override void GetLookupValues()
    {
        LookupValues = new SelectList(makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));
    }
}