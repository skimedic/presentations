// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - Validation.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Web.Pages;
public class ValidationModel : PageModel
{
    [ViewData]
    public string Title => "Validation Example";

    [BindProperty]
    public AddToCartViewModel PropertyThatIsBoundInThePageModel { get; set; }
    //public AddToCartViewModel OnGet()
    //{
    //    return new AddToCartViewModel
    //    {
    //        Id = 1,
    //        ItemId = 1,
    //        StockQuantity = 2,
    //        Quantity = 0
    //    };
    //}
    public void OnGet()
    {
        PropertyThatIsBoundInThePageModel = new AddToCartViewModel
        {
            Id = 1,
            ItemId = 1,
            StockQuantity = 2,
            Quantity = 0
        };
    }

    //public IActionResult OnPost(AddToCartViewModel Entity)
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        return RedirectToPage("Validation");
    }
}


