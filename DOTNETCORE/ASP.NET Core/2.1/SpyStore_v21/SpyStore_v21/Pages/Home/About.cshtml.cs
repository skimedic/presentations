using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SpyStore_v21.Models;

namespace SpyStore_v21.Pages.Home
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }
        public string Settings1 { get; set; }
        public int Settings2 { get; set; }

        public void OnGet([FromServices]IOptionsSnapshot<CustomSettings> settings)
        {
            Settings1 = settings.Value.MySetting1;
            Settings2 = settings.Value.MySetting2;

            Message = "Your application description page.";
        }
    }
}