namespace AutoLot.Web.Pages;

public class RazorSyntaxModel : PageModel
{
    private readonly ICarDataService _carDataService;

    [ViewData]
    public string Title => "Razor Syntax";

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
}