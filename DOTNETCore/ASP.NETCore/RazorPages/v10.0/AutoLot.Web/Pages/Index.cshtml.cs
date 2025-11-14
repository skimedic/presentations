// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Web - Index.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Web.Pages;

public class IndexModel(
    IAppLogging logger,
    IOptionsMonitor<DealerInfo> dealerOptionsMonitor) : PageModel
{
    [BindProperty]
    public DealerInfo Entity { get; } = dealerOptionsMonitor.CurrentValue;

    public void OnGet()
    {
        logger.LogAppError("Test Error");
    }
}
