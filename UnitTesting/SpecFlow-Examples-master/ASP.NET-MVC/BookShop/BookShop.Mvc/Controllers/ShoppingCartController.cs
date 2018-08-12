using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using BookShop.Mvc.Models;

namespace BookShop.Mvc.Controllers
{
    public class ShoppingCartController
        : Controller
    {
        public const string CartSessionKey = "CART";

        public ActionResult Index()
        {
            var shoppingCart = GetShoppingCart();
            return View(shoppingCart);
        }

        public ActionResult Add(int bookId)
        {
            using (var db = new DatabaseContext())
            {
                var shoppingCart = GetShoppingCart();

                var existingLine = shoppingCart.Lines.SingleOrDefault(l => l.Book.Id == bookId);
                if (existingLine != null)
                {
                    existingLine.Quantity++;
                }
                else
                {
                    var book = db.Books.First(b => b.Id == bookId);

                    var newOrderLine = new OrderLine
                    {
                        Book = book,
                        Quantity = 1
                    };

                    shoppingCart.AddLineItem(newOrderLine);
                }

                ViewData.Model = shoppingCart;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public ActionResult DeleteItem(int id)
        {
            var shoppingCart = GetShoppingCart();
            shoppingCart.RemoveLineItem(id);

            ViewData.Model = shoppingCart;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Edit(EditArguments editArgs)
        {
            if (!ModelState.IsValid)
            {
                return Index();
            }

            var shoppingCart = GetShoppingCart();
            int bookId = editArgs.BookId;
            int quantity = editArgs.Quantity;

            if (quantity > 0)
            {
                var existingLine = shoppingCart.Lines.Single(l => l.Book.Id == bookId);
                existingLine.Quantity = quantity;
            }
            else
            {
                shoppingCart.RemoveLineItem(bookId);
            }

            return RedirectToAction("Index");
        }

        private ShoppingCart GetShoppingCart()
        {
            if (HttpContext.Session[CartSessionKey] is ShoppingCart sc)
            {
                return sc;
            }

            var cart = new ShoppingCart();
            HttpContext.Session[CartSessionKey] = cart;
            return cart;
        }

        public class EditArguments
        {
            public int BookId { get; set; }

            [Range(0, 10)]
            public int Quantity { get; set; }
        }
    }
}