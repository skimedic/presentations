// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Web - Consent.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/27
// ==================================

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