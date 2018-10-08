using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.Models.Entities;
using SpyStore_HOL.Models.ViewModels;
using SpyStore_HOL.Models.ViewModels.Base;
using SpyStore_HOL.MVC.Controllers.Base;
using SpyStore_HOL.MVC.ViewModels;

namespace SpyStore_HOL.MVC.Controllers
{
    [Route("[controller]/[action]/{customerId}")]
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
                    cfg.CreateMap<CartRecordViewModel, ShoppingCartRecord>();
                    cfg.CreateMap<CartRecordWithProductInfo, CartRecordViewModel>();
                    cfg.CreateMap<ProductAndCategoryBase, AddToCartViewModel>();
                });
        }
        [HttpGet]
        public IActionResult Index([FromServices] ICustomerRepo customerRepo, int customerId)
        {
            ViewBag.Title = "Cart";
            ViewBag.Header = "Cart";
            var cartItems = _shoppingCartRepo.GetShoppingCartRecords(customerId);
            var customer = customerRepo.Find(customerId);
            var mapper = _config.CreateMapper();
            var viewModel = new CartViewModel
            {
                Customer = customer,
                CartRecords = mapper.Map<IList<CartRecordViewModel>>(cartItems)
            };
            return View(viewModel);
        }
        [HttpGet("{productId}")]
        public IActionResult AddToCart([FromServices] IProductRepo productRepo,
            int customerId, int productId, bool cameFromProducts = false)
        {
            ViewBag.CameFromProducts = cameFromProducts;
            ViewBag.Title = "Add to Cart";
            ViewBag.Header = "Add to Cart";
            ViewBag.ShowCategory = true;
            var prod = productRepo.GetOneWithCategoryName(productId);
            if (prod == null) return NotFound();
            var mapper = _config.CreateMapper();
            var cartRecord = mapper.Map<AddToCartViewModel>(prod);
            cartRecord.Quantity = 1;
            return View(cartRecord);
        }
        [HttpPost("{productId}"), ValidateAntiForgeryToken]
        public IActionResult AddToCart(int customerId, int productId, AddToCartViewModel item)
        {
            if (!ModelState.IsValid) return View(item);
            try
            {
                var mapper = _config.CreateMapper();
                var cartRecord = mapper.Map<ShoppingCartRecord>(item);
                cartRecord.DateCreated = DateTime.Now;
                cartRecord.CustomerId = item.CustomerId ?? 0;
                _shoppingCartRepo.Add(cartRecord);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "There was an error adding the item to the cart.");
                return View(item);
            }
            return RedirectToAction(nameof(CartController.Index), new { customerId });
        }
        [HttpPost("{id}"), ValidateAntiForgeryToken]
        public IActionResult Update(int customerId, int id, int quantity, string timeStampString)
        {
            ShoppingCartRecord item = _shoppingCartRepo.Find(id);
            item.TimeStamp = JsonConvert.DeserializeObject<byte[]>($"\"{timeStampString}\"");
            item.Quantity = quantity;
            var mapper = _config.CreateMapper();
            try
            {
                item.DateCreated = DateTime.Now;
                _shoppingCartRepo.Update(item);
                var updatedItem = _shoppingCartRepo.GetShoppingCartRecord(customerId, item.ProductId);
                var newItem = mapper.Map<CartRecordViewModel>(updatedItem);
                return PartialView(newItem);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred updating the cart.  Please reload the page and try again.");
                var updatedItem = _shoppingCartRepo.GetShoppingCartRecord(customerId, item.ProductId);
                var newItem = mapper.Map<CartRecordViewModel>(updatedItem);
                return PartialView(newItem);
            }
        }
        [HttpPost("{id}"), ValidateAntiForgeryToken]
        public IActionResult Delete(int customerId, int id, ShoppingCartRecord item)
        {
            _shoppingCartRepo.Delete(id, item.TimeStamp);
            return RedirectToAction(nameof(Index), new { customerId });
        }

    }
}