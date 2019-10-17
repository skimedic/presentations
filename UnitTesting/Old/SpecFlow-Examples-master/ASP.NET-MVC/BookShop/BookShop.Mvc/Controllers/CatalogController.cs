using System.Linq;
using System.Web.Mvc;
using BookShop.Mvc.Models;
using LinqKit;

namespace BookShop.Mvc.Controllers
{
    public class CatalogController : Controller
    {
        public ActionResult Search(string searchTerm)
        {
            using (var db = new DatabaseContext())
            {
                var terms = searchTerm?.Split(' ') ?? new string[0];
                var predicate = terms.Aggregate(
                    PredicateBuilder.New<Book>(string.IsNullOrEmpty(searchTerm)),
                    (acc, term) => acc.Or(b => b.Title.Contains(term))
                                      .Or(b => b.Author.Contains(term)));

                var books = db.Books.AsExpandable()
                                    .Where(predicate)
                                    .OrderBy(b => b.Title)
                                    .ToArray();

                return View("List", books);
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new DatabaseContext())
            {
                var book = db.Books.First(b => b.Id == id);
                return View(book);
            }
        }
    }
}