// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Web - RazorSyntax.cshtml.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Web.Pages;

public class RazorSyntaxModel : PageModel
{
    private ICarRepo _repo;

    [ViewData]
    public SelectList LookupValues { get; set; }
    [ViewData]
    public string Title => "Razor Syntax";
    [BindProperty]
    public Car Entity { get; set; }
    public RazorSyntaxModel(ICarRepo repo, IMakeRepo makeRepo)
    {
        _repo = repo;
        LookupValues = new SelectList(makeRepo.GetAll(), nameof(Make.Id), nameof(Make.Name));
    }

    public IActionResult OnGet()
    {
        Entity = _repo.Find(6);
        return Page();
    }
}