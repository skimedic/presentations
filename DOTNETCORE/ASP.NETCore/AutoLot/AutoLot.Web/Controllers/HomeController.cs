using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AutoLot.Web.Models;
using Microsoft.AspNetCore.Http.Features;

namespace AutoLot.Web.Controllers
{
    [Route("[controller]/[action]")]
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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GrantConsent()
        {
            HttpContext.Features.Get<ITrackingConsentFeature>().GrantConsent();
            return RedirectToAction(nameof(Index), nameof(HomeController).RemoveController(),
                new {area = ""});
        }

        public IActionResult WithdrawConsent()
        {
            HttpContext.Features.Get<ITrackingConsentFeature>().WithdrawConsent();
            return RedirectToAction(nameof(Index), nameof(HomeController).RemoveController(),
                new {area = ""});
        }

        public IActionResult RazorSyntax([FromServices]ICarRepo carRepo)
        {
            return View(carRepo.Find(1));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
