// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoLot.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IAppLogging<IndexModel> _logger;
    public DealerInfo Entity { get; set; }
    public IndexModel(IAppLogging<IndexModel> logger, 
        IOptionsMonitor<DealerInfo> dealerOptionsMonitor)
    {
        _logger = logger;
        Entity = dealerOptionsMonitor.CurrentValue;
    }
    public void OnGet()
    {
        _logger.LogAppError("Test Error");
    }
}
