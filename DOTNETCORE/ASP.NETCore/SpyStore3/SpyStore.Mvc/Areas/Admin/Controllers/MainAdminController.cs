using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SpyStore.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class MainAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}