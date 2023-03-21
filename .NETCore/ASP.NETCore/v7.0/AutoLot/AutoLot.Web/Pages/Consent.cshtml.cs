
namespace AutoLot.Web.Pages;

public class ConsentModel : PageModel
{
    public IActionResult OnGetGrantConsent()
    {
        HttpContext.Features.Get<ITrackingConsentFeature>()?.GrantConsent();
        return RedirectToPage("./Index");
    }

    public IActionResult OnGetWithdrawConsent()
    {
        HttpContext.Features.Get<ITrackingConsentFeature>()?.WithdrawConsent();
        return RedirectToPage("./Index");
    }
}