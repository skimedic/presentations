using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpyStoreDAL.Repos.Interfaces;
using SpyStoreModels.ViewModels.Base;
using SpyStore_v20.Models.CustomViewModels;

namespace SpyStore_v20.Controllers
{
    //[MiddlewareFilter(typeof(MyMiddleWareItem))]
    public class ProductsController : Controller
    {
        private readonly IProductRepo _productRepo;
        readonly MapperConfiguration _config = null;

        public ProductsController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
            _config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<ProductAndCategoryBase, AddToCartViewModel>();
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
        public IActionResult ProductList(
            [FromServices]ICategoryRepo categoryRepo, int id)
        {
            var cat = categoryRepo.Find(id);
            ViewBag.Title = cat?.CategoryName;
            ViewBag.Header = cat?.CategoryName;
            ViewBag.ShowCategory = false;
            ViewBag.Featured = false;
            return View(_productRepo.GetProductsForCategory(id));
        }
        [Route("[controller]/[action]/{productId}")]
        public IActionResult Details(int productId)
        {
            ViewBag.Title = "Details";
            ViewBag.Header = "Details";
            ViewBag.ShowCategory = true;
            var prod = _productRepo.GetOneWithCategoryName(productId);
            if (prod == null) return NotFound();
            var mapper = _config.CreateMapper();
            var cartRecord = mapper.Map<AddToCartViewModel>(prod);
            return View(cartRecord);
        }

    }
}
