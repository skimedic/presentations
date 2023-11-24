// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Edit.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Pages.Cars;
public class EditModel : BasePageModel<Car,EditModel>
{
    private readonly IMakeRepo _makeRepo;
    public EditModel(IAppLogging<EditModel> appLogging, ICarRepo carRepo, 
        IMakeRepo makeRepo) : base(appLogging, carRepo, "Edit") => _makeRepo = makeRepo;
    public void OnGet(int id)
    {
        GetLookupValues();
        GetOne(id);
    }
    public IActionResult OnPost() => SaveWithLookup( BaseRepoInstance.Update);

    protected override void GetLookupValues()
    {
        LookupValues = new SelectList(_makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));
    }
}