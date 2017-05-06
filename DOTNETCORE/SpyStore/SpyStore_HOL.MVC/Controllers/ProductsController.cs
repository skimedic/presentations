using Microsoft.AspNetCore.Mvc;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.MVC.Controllers.Base;

namespace SpyStore_HOL.MVC.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepo _productRepo;
        private readonly ICategoryRepo _categoryRepo;

        public ProductsController(IProductRepo productRepo, ICategoryRepo categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public ActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return RedirectToAction(nameof(Featured));
        }

        public ActionResult Details(int id)
        {
            return RedirectToAction(nameof(CartController.AddToCart), nameof(CartController).Replace("Controller", ""), new { customerId = ViewBag.CustomerId, productId = id, cameFromProducts = true });
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
        public IActionResult ProductList(int id)
        {
            var cat = _categoryRepo.Find(id);
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
