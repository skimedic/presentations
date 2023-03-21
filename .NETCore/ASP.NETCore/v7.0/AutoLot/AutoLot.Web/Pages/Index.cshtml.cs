using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoLot.Web.Pages;

public class IndexModel : PageModel
{
    private readonly IAppLogging<IndexModel> _logger;

    public IndexModel(IAppLogging<IndexModel> logger, IOptionsMonitor<DealerInfo> dealerOptionsMonitor)
    {
        _logger = logger;
        Entity = dealerOptionsMonitor.CurrentValue;
    }

    public DealerInfo Entity { get; set; }
    
    public void OnGet()
    {
        //_logger.LogAppError("Test Error");
    }
}
