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
        private readonly ICustomerRepo _customerRepo;
        private readonly IProductRepo _productRepo;
        readonly MapperConfiguration _config = null;
        public CartController(
            IShoppingCartRepo shoppingCartRepo,
            ICustomerRepo customerRepo,
            IProductRepo productRepo)
        {
            _shoppingCartRepo = shoppingCartRepo;
            _customerRepo = customerRepo;
            _productRepo = productRepo;
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
        public IActionResult Index(int customerId)
        {
            ViewBag.Title = "Cart";
            ViewBag.Header = "Cart";
            var cartItems = _shoppingCartRepo.GetShoppingCartRecords(customerId);
            var customer = _customerRepo.Find(customerId);
            var mapper = _config.CreateMapper();
            var viewModel = new CartViewModel
            {
                Customer = customer,
                CartRecords = mapper.Map<IList<CartRecordViewModel>>(cartItems)
            };
            return View(viewModel);
        }

        [HttpGet("{productId}")]
        public IActionResult AddToCart(int customerId, int productId, bool cameFromProducts = false)
        {
            ViewBag.CameFromProducts = cameFromProducts;
            ViewBag.Title = "Add to Cart";
            ViewBag.Header = "Add to Cart";
            ViewBag.ShowCategory = true;
            var prod = _productRepo.GetOneWithCategoryName(productId);
            if (prod == null) return NotFound();
            var mapper = _config.CreateMapper();
            var cartRecord = mapper.Map<AddToCartViewModel>(prod);
            cartRecord.Quantity = 1;
            return View(cartRecord);
        }

        [ActionName("AddToCart"),HttpPost("{productId}"),ValidateAntiForgeryToken]
        public IActionResult AddToCartPost(
            int customerId, int productId, AddToCartViewModel item)
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
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "There was an error adding the item to the cart.");
                return View(item);
            }
            return RedirectToAction(nameof(CartController.Index), new { customerId });
        }

        [HttpPost("{id}"),ValidateAntiForgeryToken]
        public IActionResult Update(int customerId, int id, 
            string timeStampString, CartRecordViewModel item)
        {
            item.TimeStamp = JsonConvert.DeserializeObject<byte[]>($"\"{timeStampString}\"");
            if (!ModelState.IsValid) return PartialView(item);
            var mapper = _config.CreateMapper();
            var newItem = mapper.Map<ShoppingCartRecord>(item);
            try
            {
                newItem.DateCreated = DateTime.Now;
                _shoppingCartRepo.Update(newItem);
                var updatedItem = _shoppingCartRepo.GetShoppingCartRecord(customerId, item.ProductId);
                item = mapper.Map<CartRecordViewModel>(updatedItem);
                return PartialView(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred updating the cart.  Please reload the page and try again.");
                return PartialView(item);
            }
        }

        [HttpPost("{id}"),ValidateAntiForgeryToken]
        public IActionResult Delete(int customerId, int id,
            ShoppingCartRecord item)
        {
            _shoppingCartRepo.Delete(id, item.TimeStamp);
            return RedirectToAction(nameof(Index), new { customerId });
        }

        //[HttpPost,ValidateAntiForgeryToken]
        //public IActionResult Buy(int customerId, Customer customer)
        //{
        //    int orderId = await _webApiCalls.PurchaseCartAsync(customer);
        //    return RedirectToAction(
        //        nameof(OrdersController.Details), 
        //        nameof(OrdersController).Replace("Controller",""),
        //        new { customerId, orderId });
        //}

    }
}
