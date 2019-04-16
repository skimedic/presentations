using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Hol.Mvc.Models;
using SpyStore.Models.Entities;
using SpyStore.Models.Entities.Base;

namespace SpyStore.Hol.Mvc.Controllers
{
    public class HomeController : Controller
    {
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
            var p = new Product
            {
                Id = 1,
                Details = new ProductDetails
                {
                    Description = "Cool product",
                    ModelName = "PortableAC",
                    ModelNumber = "12345"
                },
            };
            return View(p);
        }
    }
}
