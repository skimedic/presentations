using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SampleWebApp.InjectableTypes.Classes;
using SampleWebApp.InjectableTypes.Interfaces;
using SampleWebApp.Models;

namespace SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepo<Customer> _repo;

        public HomeController(IRepo<Customer> repo)
        {
            _repo = repo;
        }

        public IActionResult Index([FromServices]IOptionsSnapshot<CustomSettings> customSettings)
        {
            ViewBag.Setting1 = customSettings.Value.MySetting1;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
