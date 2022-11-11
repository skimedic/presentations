// Copyright Information
// ==================================
// AutoLot - AutoLot.Web - RazorSyntax.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AutoLot.Web.Pages;

public class RazorSyntaxModel : PageModel
{
    private readonly ICarDataService _carDataService;

    [ViewData]
    public string Title => "Razor Syntax";

    [BindProperty]
    public Car Entity { get; set; }

    public RazorSyntaxModel(ICarDataService carDataService)
    {
        _carDataService = carDataService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        Entity = await _carDataService.FindAsync(6);
        return Page();
    }

    //public async Task<IActionResult> OnPostAsync(Car entity)
    //{
    //    return RedirectToPage("Index");
    //}
    //public async Task<IActionResult> OnPostAsync()
    //{
    //    var newCar = new Car();

    //    if (await TryUpdateModelAsync(newCar, "Entity",
    //            c => c.Id,
    //            c => c.TimeStamp,
    //            c => c.PetName,
    //            c => c.Color,
    //            c => c.IsDrivable,
    //            c => c.MakeId,
    //            c => c.Price
    //        ))
    //    {
    //        //Do something interesting
    //    }

    //    return RedirectToPage("Index");
    //}
    public async Task<IActionResult> OnPostAsync()
    {
        //Do something with the Entity instance
        //await _carDataService.UpdateAsync(Entity);
        return RedirectToPage("Index");
    }
}
