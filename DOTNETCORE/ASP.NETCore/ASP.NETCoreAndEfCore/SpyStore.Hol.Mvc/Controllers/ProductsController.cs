using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpyStore.Hol.Mvc.Controllers.Base;
using SpyStore.Hol.Mvc.Support;

namespace SpyStore.Hol.Mvc.Controllers
{
    [Route("[controller]/[action]")]
    public class ProductsController : BaseController
    {
        private readonly SpyStoreServiceWrapper _serviceWrapper;
        public ProductsController(SpyStoreServiceWrapper serviceWrapper, IConfiguration configuration) : base(configuration)
        {
            _serviceWrapper = serviceWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> Featured()
        {
            ViewBag.Title = "Featured Products";
            ViewBag.Header = "Featured Products";
            ViewBag.ShowCategory = true;
            ViewBag.Featured = true;
            return View("ProductList", await _serviceWrapper.GetFeaturedProductsAsync());
        }

        [Route("/")]
        [Route("/Products")]
        [Route("/Products/Index")]
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

        [HttpGet]
        public async Task<IActionResult> ProductList(int id)
        {
            var cat = await _serviceWrapper.GetCategoryAsync(id);
            ViewBag.Title = cat?.CategoryName;
            ViewBag.Header = cat?.CategoryName;
            ViewBag.ShowCategory = false;
            ViewBag.Featured = false;
            return View(await _serviceWrapper.GetProductsForACategoryAsync(id));
        }

        [Route("[controller]/[action]")]
        [HttpPost("{searchString}")]
        public async Task<IActionResult> Search(string searchString)
        {
            ViewBag.Title = "Search Results";
            ViewBag.Header = "Search Results";
            ViewBag.ShowCategory = true;
            ViewBag.Featured = false;
            return View("ProductList", await _serviceWrapper.SearchAsync(searchString));
        }
    }
}
