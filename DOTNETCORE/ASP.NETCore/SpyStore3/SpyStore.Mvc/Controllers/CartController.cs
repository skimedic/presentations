using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Models.Entities;
using SpyStore.Models.Entities.Base;
using SpyStore.Models.ViewModels;
using SpyStore.Mvc.Controllers.Base;
using SpyStore.Mvc.Models.ViewModels;

namespace SpyStore.Mvc.Controllers
{
    //Demo: Routing
    [Route("[controller]/[action]")]
    //[Route("Cart/[action]")]
    //[Route("/")]
    public class CartController : BaseController
    {
        private readonly IShoppingCartRepo _shoppingCartRepo;
        readonly MapperConfiguration _config = null;
        public CartController(IShoppingCartRepo shoppingCartRepo)
        {
            _shoppingCartRepo = shoppingCartRepo;
            _config = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<AddToCartViewModel, ShoppingCartRecord>()
                        .AfterMap((s, t) =>
                        {
                            t.Id = 0;
                            t.TimeStamp = null;
                        });
                    cfg.CreateMap<CartRecordWithProductInfo, CartRecordViewModel>();
                    cfg.CreateMap<Product, AddToCartViewModel>()
                        .ForMember(x => x.Description, x => x.MapFrom(src => src.Details.Description))
                        .ForMember(x => x.ModelName, x => x.MapFrom(src => src.Details.ModelName))
                        .ForMember(x => x.ModelNumber, x => x.MapFrom(src => src.Details.ModelNumber))
                        .ForMember(x => x.ProductImage, x => x.MapFrom(src => src.Details.ProductImage))
                        .ForMember(x => x.ProductImageLarge, x => x.MapFrom(src => src.Details.ProductImageLarge))
                        .ForMember(x => x.ProductImageThumb, x => x.MapFrom(src => src.Details.ProductImageThumb));
                });

        }

        [HttpGet]
        public IActionResult Index([FromServices] ICustomerRepo customerRepo)
        {
            ViewBag.Title = "Cart";
            ViewBag.Header = "Cart";
            IEnumerable<CartRecordWithProductInfo> cartItems = 
                _shoppingCartRepo.GetShoppingCartRecords(ViewBag.CustomerId);
            var customer = customerRepo.Find(ViewBag.CustomerId);
            var mapper = _config.CreateMapper();
            var viewModel = new CartViewModel
            {
                Customer = customer,
                CartRecords = mapper.Map<IList<CartRecordViewModel>>(cartItems)
            };
            return View(viewModel);
        }
        //[Route("/{productId}")]
        [HttpGet("{productId}")]
        public IActionResult AddToCart([FromServices] IProductRepo productRepo,
            int productId, bool cameFromProducts = false)
        {
            ViewBag.CameFromProducts = cameFromProducts;
            ViewBag.Title = "Add to Cart";
            ViewBag.Header = "Add to Cart";
            ViewBag.ShowCategory = true;
            var prod = productRepo.GetOneWithCategoryName(productId);
            if (prod == null) return NotFound();
            var mapper = _config.CreateMapper();
            AddToCartViewModel cartRecord = mapper.Map<AddToCartViewModel>(prod);
            cartRecord.Quantity = 1;
            return View(cartRecord);
        }
        //Demo: model binding
        [HttpPost("{productId}"), ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId, AddToCartViewModel item)
        {
            //var foo = await TryUpdateModelAsync(item);
            if (!ModelState.IsValid)
            {
                ViewBag.CameFromProducts = false;
                ViewBag.Title = "Add to Cart";
                ViewBag.Header = "Add to Cart";
                ViewBag.ShowCategory = true;
                return View(item);
            }
            //Do work
            //Recheck model
            //var isValid = TryValidateModel(item);
            try
            {
                var mapper = _config.CreateMapper();
                var cartRecord = mapper.Map<ShoppingCartRecord>(item);
                cartRecord.DateCreated = DateTime.Now;
                _shoppingCartRepo.Context.CustomerId = ViewBag.CustomerId;
                _shoppingCartRepo.Add(cartRecord);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "There was an error adding the item to the cart.");
                return View(item);
            }
            return RedirectToAction(nameof(CartController.Index));
        }
        [HttpPost("{id}"), ValidateAntiForgeryToken]
        public IActionResult Update(ShoppingCartRecordBase record)
        {
            _shoppingCartRepo.Context.CustomerId = ViewBag.CustomerId;
            ShoppingCartRecord dbItem = _shoppingCartRepo.Find(record.Id);
            var mapper = _config.CreateMapper();
            if (record.TimeStamp != null && dbItem.TimeStamp.SequenceEqual(record.TimeStamp))
            {
                dbItem.Quantity = record.Quantity;
                dbItem.DateCreated = DateTime.Now;
                try
                {
                    _shoppingCartRepo.Update(dbItem);
                    var updatedItem = _shoppingCartRepo.GetShoppingCartRecord(dbItem.Id);
                    CartRecordViewModel newItem = mapper.Map<CartRecordViewModel>(updatedItem);
                    return PartialView(newItem);
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "An error occurred updating the cart.  Please reload the page and try again.");
                    var updatedItem = _shoppingCartRepo.GetShoppingCartRecord(dbItem.ProductId);
                    CartRecordViewModel newItem = mapper.Map<CartRecordViewModel>(updatedItem);
                    return PartialView(newItem);
                }
            }
            ModelState.AddModelError("", "Another user has updated the record.");
            var item = _shoppingCartRepo.GetShoppingCartRecord(dbItem.ProductId);
            CartRecordViewModel vm = mapper.Map<CartRecordViewModel>(dbItem);
            return PartialView(vm);

        }
        [HttpPost("{id}"), ValidateAntiForgeryToken]
        public IActionResult Delete(int customerId, int id, ShoppingCartRecord item)
        {
            _shoppingCartRepo.Context.CustomerId = ViewBag.CustomerId;
            _shoppingCartRepo.Delete(item);
            return RedirectToAction(nameof(Index), new { customerId });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy()
        {
            int orderId = _shoppingCartRepo.Purchase(ViewBag.CustomerId);
            //Demo: Redirect to action
            return RedirectToAction(
                nameof(OrdersController.Details),
                nameof(OrdersController).Replace("Controller", ""),
                new { orderId });
        }

    }
}
