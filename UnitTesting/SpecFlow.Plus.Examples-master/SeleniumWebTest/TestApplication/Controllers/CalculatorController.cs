using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApplication.Controllers
{
    public class CalculatorController : Controller
    {
        //
        // GET: /Calculator/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int summandOne, int summandTwo)
        {
            return View(summandOne + summandTwo);
        }

    }
}
