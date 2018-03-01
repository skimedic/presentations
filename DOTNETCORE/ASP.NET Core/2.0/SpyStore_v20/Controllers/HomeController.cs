using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpyStore_v20.Models;

namespace SpyStore_v20.Controllers
{
    [ResponseCache(Duration = 30)]
    public class HomeController : Controller
    {
        private readonly CustomSettings _settings;

        public HomeController(IOptionsSnapshot<CustomSettings> settings, 
            ILogger<HomeController> logger)
        {
            _settings = settings.Value;
            Logger = logger;
        }

        public ILogger Logger { get; }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult About()
        //{
        //    Logger.LogInformation(1, "Enter About");
        //    ViewData["Message"] = "Your application description page.";
        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
