using Microsoft.AspNetCore.Authorization;

namespace AutoLot.Mvc.Controllers;

[Route("[controller]/[action]")]
public class HomeController : Controller
{
    private readonly IAppLogging<HomeController> _logger;

    public HomeController(IAppLogging<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/")]
    [Route("/[controller]")]
    [Route("/[controller]/[action]")]
    public IActionResult Index([FromServices] IOptionsMonitor<DealerInfo> dealerMonitor)
    {
        //_logger.LogAppError("Test error");
        var vm = dealerMonitor.CurrentValue;
        //return PartialView(vm);
        return View(vm);
    }

    [HttpGet]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult GrantConsent()
    {
        HttpContext.Features.Get<ITrackingConsentFeature>().GrantConsent();
        return RedirectToAction(nameof(Index), nameof(HomeController).RemoveControllerSuffix(),
            new { area = "" });
    }

    [HttpGet]
    [AllowAnonymous]
    public string GrantConsentFromAjax()
    {
        HttpContext.Features.Get<ITrackingConsentFeature>().GrantConsent();
        return "Success";
    }

    [HttpGet]
    public IActionResult WithdrawConsent()
    {
        HttpContext.Features.Get<ITrackingConsentFeature>().WithdrawConsent();
        return RedirectToAction(nameof(Index), nameof(HomeController).RemoveControllerSuffix(),
            new { area = "" });
    }

    [HttpGet]
    public async Task<IActionResult> RazorSyntaxAsync([FromServices]ICarDataService dataService)
    {
        var car = await dataService.FindAsync(6);
        return View(car);
    }

    [HttpGet]
    public IActionResult Validation()
    {
        var vm = new AddToCartViewModel
        {
            Id = 1,
            ItemId = 1,
            StockQuantity = 2,
            Quantity = 0
        };
        return View(vm);
    }

    [HttpPost]
    public IActionResult Validation(AddToCartViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        return RedirectToAction(nameof(Validation));
    }
}