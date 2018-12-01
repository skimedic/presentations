using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.MVC.Controllers.Base;
using SpyStore_HOL.MVC.Support;

namespace SpyStore_HOL.MVC.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepo _productRepo;
        private readonly CustomSettings _settings;
        private ILogger Logger { get; }

        public ProductsController(
            IProductRepo productRepo,
            IOptionsSnapshot<CustomSettings> settings,
            ILogger<ProductsController> logger)
        {
            _settings = settings.Value;
            _productRepo = productRepo;
            Logger = logger;
        }
        [HttpGet]
        public ActionResult Error()
        {
            var foo = _settings.MySetting1;
            return View();
        }
        [HttpGet]
        public ActionResult Index()
        {
            Logger.LogInformation(1, "Enter About");
            return RedirectToAction(nameof(Featured));
        }
        public ActionResult Details(int id)
        {
            return RedirectToAction(nameof(CartController.AddToCart),
                nameof(CartController).Replace("Controller", ""),
                new
                {
                    customerId = ViewBag.CustomerId,
                    productId = id,
                    cameFromProducts = true
                });
        }
        [HttpGet]
        public IActionResult Featured()
        {
            ViewBag.Title = "Featured Products";
            ViewBag.Header = "Featured Products";
            ViewBag.ShowCategory = true;
            ViewBag.Featured = true;
            return View("ProductList", _productRepo.GetFeaturedWithCategoryName());
        }
        [HttpGet]
        public IActionResult ProductList([FromServices]ICategoryRepo categoryRepo, int id)
        {
            var cat = categoryRepo.Find(id);
            ViewBag.Title = cat?.CategoryName;
            ViewBag.Header = cat?.CategoryName;
            ViewBag.ShowCategory = false;
            ViewBag.Featured = false;
            return View(_productRepo.GetProductsForCategory(id));
        }
        [Route("[controller]/[action]")]
        [HttpPost("{searchString}")]
        public IActionResult Search(string searchString)
        {
            ViewBag.Title = "Search Results";
            ViewBag.Header = "Search Results";
            ViewBag.ShowCategory = true;
            ViewBag.Featured = false;
            return View("ProductList", _productRepo.Search(searchString));
        }

    }
}