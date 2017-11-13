using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SpyStore_v20.Pages.Home
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; } = "Your contact page.";

        public void OnGet()
        {

        }
    }
}