using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.Entities.Base;
using SpyStore.Hol.Mvc.Models;

namespace SpyStore.Hol.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("/Home")]
        [Route("/Home/Index")]
        public IActionResult Index()
        {
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

        public IActionResult RazorSyntax()
        {
            var prod = new Product
            {
                Id = 1,
                CategoryId = 1,
                Details = new ProductDetails
                {
                    Description = "A Product",
                    ModelName = "Model Name",
                    ModelNumber = "Model Number"
                }
            };
            return View(prod);
        }
    }
}
