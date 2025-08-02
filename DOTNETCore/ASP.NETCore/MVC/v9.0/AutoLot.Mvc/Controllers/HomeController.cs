// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Mvc - HomeController.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/07/31
// ==================================

namespace AutoLot.Mvc.Controllers;

[Route("[controller]/[action]")]
//[Route("Home/[action]")]
public class HomeController(
    IAppLogging<HomeController> logger,
    [FromKeyedServices(nameof(SimpleServiceTwo))] ISimpleService service) 
    : Controller
{
    //[Route("/MyHomePage")]
    [Route("/")]
    [Route("/[controller]")]
    [Route("/[controller]/[action]")]
    [HttpGet]
    public IActionResult Index(
        [FromServices] IOptionsMonitor<DealerInfo> dealerOptionsMonitor)
    {
        logger.LogAppError("Test error");
        return View(dealerOptionsMonitor.CurrentValue);
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
    public IActionResult GetServiceOne([FromKeyedServices(nameof(SimpleServiceOne))] ISimpleService service)
    {
        return View("SimpleService",service.SayHello());
    }

    [HttpGet]
    public IActionResult GetServiceTwo()
    {
        return View("SimpleService",service.SayHello());
    }

    [HttpGet]
    public IActionResult GrantConsent()
    {
        HttpContext.Features.Get<ITrackingConsentFeature>().GrantConsent();
        return RedirectToAction(nameof(Index), nameof(HomeController).RemoveController(),
            new {area = ""});
    }
    [HttpGet]
    public IActionResult WithdrawConsent()
    {
        HttpContext.Features.Get<ITrackingConsentFeature>().WithdrawConsent();
        return RedirectToAction(nameof(Index), nameof(HomeController).RemoveController(),
            new {area = ""});
    }
    [HttpGet]
    public IActionResult RazorSyntax([FromServices] ICarRepo carRepo)
    {
        var car = carRepo.Find(1);
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

}