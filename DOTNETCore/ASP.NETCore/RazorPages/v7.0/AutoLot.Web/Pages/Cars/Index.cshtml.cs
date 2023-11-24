// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Pages.Cars;

public class IndexModel : BasePageModel<Car,IndexModel>
{
    private readonly IAppLogging<IndexModel> _appLogging;
    private readonly ICarRepo _carRepo;
    public IndexModel(IAppLogging<IndexModel> appLogging, ICarRepo repo) 
        : base(appLogging, repo,"Inventory")
    {
        _appLogging = appLogging;
        _carRepo = repo;
    }
    public string MakeName { get; set; }
    public int? MakeId { get; set; }
    public IEnumerable<Car> CarRecords { get; set; }
    public void OnGet(int? makeId, string makeName)
    {
        if (!makeId.HasValue)
        {
            MakeName = "All Makes";
            CarRecords = _carRepo.GetAllIgnoreQueryFilters();
            return;
        }
        MakeId = makeId;
        MakeName = makeName;
        CarRecords =  _carRepo.GetAllBy(makeId.Value);
    }
}
