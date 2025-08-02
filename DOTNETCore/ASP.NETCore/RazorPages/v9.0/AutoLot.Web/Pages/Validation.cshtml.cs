// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Web - Validation.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

namespace AutoLot.Web.Pages;
public class ValidationModel : PageModel
{
    [ViewData]
    public string Title => "Validation Example";
    [BindProperty]
    public AddToCartViewModelRp Entity { get; set; }
    public void OnGet()
    {
        Entity = new AddToCartViewModelRp { Id = 1, ItemId = 1, StockQuantity = 2, Quantity = 0 };
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await Task.Delay(5000);

        return RedirectToPage("Validation");
    }
}