using BookShop.Mvc.Controllers;

namespace BookShop.AcceptanceTests.Drivers.Search
{
    public class SearchDriver
    {
        private readonly SearchResultState _state;

        public SearchDriver(SearchResultState state)
        {
            _state = state;
        }

        public void Search(string term)
        {
            var controller = new CatalogController();
            _state.ActionResult = controller.Search(term);
        }
    }
}
