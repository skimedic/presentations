// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

namespace AutoLot.Web.Pages;

public class IndexModel(IAppLogging<IndexModel> logger, IOptionsMonitor<DealerInfo> dealerOptionsMonitor) : PageModel
{
    [BindProperty]
    public DealerInfo Entity { get; } = dealerOptionsMonitor.CurrentValue;

    public void OnGet()
    {
        //logger.LogAppError("Test Error");
    }
}
