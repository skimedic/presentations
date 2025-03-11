// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

namespace AutoLot.Web.Pages.Cars;
public class CreateModel(IAppLogging<CreateModel> appLogging,ICarRepo carRepo,IMakeRepo makeRepo)
    : BasePageModel<Car, CreateModel>(appLogging, carRepo, "Create")
{
    public void OnGet()
    {
        GetLookupValues();
        Entity = new Car { IsDrivable = true };
    }
    public IActionResult OnPostCreateNewCar() => SaveWithLookup( BaseRepoInstance.Add);
    protected override void GetLookupValues()
    {
        LookupValues = new SelectList(makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));
    }
}
