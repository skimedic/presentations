// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Create.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class CreateModel : BasePageModel<Car,CreateModel>
{
    private readonly IMakeRepo _makeRepo;
    public CreateModel(IAppLogging<CreateModel> appLogging, ICarRepo carRepo, 
        IMakeRepo makeRepo) : base(appLogging, carRepo, "Create") => _makeRepo = makeRepo;

    public void OnGet()
    {
        Entity = new Car();
        GetLookupValues();
    }
    public IActionResult OnPostCreateNewCar() => SaveWithLookup( BaseRepoInstance.Add);

    protected override void GetLookupValues()
    {
        LookupValues = new SelectList(_makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));
    }
}