using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace AutoLot.Api.Controllers
{
    public class Test : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
