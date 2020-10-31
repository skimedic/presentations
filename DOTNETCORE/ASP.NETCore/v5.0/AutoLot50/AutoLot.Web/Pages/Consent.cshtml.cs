using System;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoLot.Web.Pages
{
    public class ConsentModel : PageModel
    {
        public IActionResult OnGet(string actionName)
        {
            if (actionName.Equals("grant", StringComparison.OrdinalIgnoreCase))
            {
                HttpContext.Features.Get<ITrackingConsentFeature>().GrantConsent();
            }
            else
            {
                HttpContext.Features.Get<ITrackingConsentFeature>().WithdrawConsent();
            }
            return RedirectToPage("./Index");
        }
    }
}
