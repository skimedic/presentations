using BookShop.AcceptanceTests.Drivers.ShoppingCart;
using TechTalk.SpecFlow;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class ShoppingCartSteps
    {
        private readonly ShoppingCartDriver _driver;

        public ShoppingCartSteps(ShoppingCartDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I have a shopping cart with: '(.*)'")]
        public void GivenIHaveAShoppingCartWith(string bookIds)
        {
            _driver.SetShoppingCart(bookIds);
        }

        [When(@"I place '(.*)' into the shopping cart")]
        public void WhenIPlaceIntoTheShoppingCart(string bookId)
        {
            _driver.Place(bookId);
        }

        [When(@"I delete '(.*)' from the shopping cart")]
        public void WhenIDeleteFromTheShoppingCart(string bookId)
        {
            _driver.Delete(bookId);
        }

        [When(@"I change the quantity of '(.*)' to (\d+)")]
        public void WhenIChangeTheQuantityOfTo(string bookId, int quantity)
        {
            _driver.SetQuantity(bookId, quantity);
        }

        [Then(@"my shopping cart should be empty")]
        public void ThenMyShoppingCartShouldBeEmpty()
        {
            _driver.ContainsTypesOfItems(0);
        }

        [Then(@"my shopping cart should contain (\d+) types? of items?")]
        public void ThenMyShoppingCartShouldContainTypesOfItems(int expectedItemTypeCount)
        {
            _driver.ContainsTypesOfItems(expectedItemTypeCount);
        }

        [Then(@"my shopping cart should contain (\d+) cop(?:y|ies) of '(.*)'")]
        public void ThenMyShoppingCartShouldContainCopiesOf(int expectedQuantity, string expectedBookId)
        {
            _driver.ContainsCopiesOf(expectedBookId, expectedQuantity);
        }

        [Then(@"my shopping cart should contain (\d+) items in total")]
        public void ThenMyShoppingCartShouldContainItemsInTotal(int expectedQuantity)
        {
            _driver.ContainsTotalItems(expectedQuantity);
        }

        [Then(@"my shopping cart should show a total price of (.*)")]
        public void ThenMyShoppingCartShouldShowATotalPriceOf(decimal expectedTotalPrice)
        {
            _driver.ShowsTotalPriceOf(expectedTotalPrice);       
        }
    }
}
