using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Web.ConfigSettings;
using AutoLot.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoLot.Web.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Options;

namespace AutoLot.Web.Controllers
{
    [Route("[controller]/[action]")]
    //[Route("Home/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("/")]
        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        [HttpGet]
        public IActionResult Index([FromServices] IOptionsMonitor<DealerInfo> dealerMonitor)
        {
            var vm = dealerMonitor.CurrentValue;
            return View(vm);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}