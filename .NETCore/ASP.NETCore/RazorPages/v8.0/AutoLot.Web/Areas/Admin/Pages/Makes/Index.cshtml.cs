// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Areas.Admin.Pages.Makes;
public class IndexModel : PageModel
{
    private readonly IAppLogging<IndexModel> _appLogging;
    private readonly IMakeRepo _makeRepo;
    [ViewData]
    public string Title => "Makes";
    public IndexModel(IAppLogging<IndexModel> appLogging, IMakeRepo repo)
    {
        _appLogging = appLogging;
        _makeRepo = repo;
    }
    public IEnumerable<Make> MakeRecords { get; set; }
    public void OnGet() => MakeRecords = _makeRepo.GetAllIgnoreQueryFilters();
}