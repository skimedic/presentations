using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Mvc.Controllers.Base;
using SpyStore.Mvc.Support;

namespace SpyStore.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductsController : BaseController
    {
        private readonly IProductRepo _productRepo;
        private readonly CustomSettings _settings;

        public ProductsController(
            IProductRepo productRepo,
            IOptionsSnapshot<CustomSettings> settings)
        {
            _settings = settings.Value;
            _productRepo = productRepo;
        }
        [HttpGet]
        public IActionResult Featured()
        {
            ViewBag.Foo = _settings.MySetting1;
            ViewBag.Title = "Featured Products";
            ViewBag.Header = "Featured Products";
            ViewBag.ShowCategory = true;
            ViewBag.Featured = true;
            return View("ProductList", _productRepo.GetFeaturedWithCategoryName());
        }

        [Route("/")]
        [Route("/[controller]")]
        [Route("/[controller]/[action]")]
        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Featured));
        }
        public ActionResult Details(int id)
        {
            return RedirectToAction(nameof(CartController.AddToCart),
                nameof(CartController).Replace("Controller", ""),
                new
                {
                    productId = id,
                    cameFromProducts = true
                });
        }
        [HttpGet("{id}")]
        public IActionResult ProductList([FromServices]ICategoryRepo categoryRepo, int id)
        {
            var cat = categoryRepo.Find(id);
            ViewBag.Title = cat?.CategoryName;
            ViewBag.Header = cat?.CategoryName;
            ViewBag.ShowCategory = false;
            ViewBag.Featured = false;
            return View(_productRepo.GetProductsForCategory(id));
        }

        //[Route("[controller]/[action]/{searchString}")]
        //[HttpPost]
        [Route("/[controller]/[action]")]
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
