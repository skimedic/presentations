using TechTalk.SpecFlow;
using BookShop.AcceptanceTests.Drivers.BookDetails;

namespace BookShop.AcceptanceTests.StepDefinitions
{
    [Binding]
    public class BookSteps
    {
        private readonly BookDetailsDriver _driver;

        public BookSteps(BookDetailsDriver driver)
        {
            _driver = driver;
        }

        [Given(@"the following books")]
        public void GivenTheFollowingBooks(Table givenBooks)
        {
            _driver.AddToDatabase(givenBooks);
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOfBook(string bookId)
        {
            _driver.OpenBookDetails(bookId);
        }

        [Then(@"the book details should show")]
        public void ThenTheBookDetailsShouldShow(Table expectedBookDetails)
        {
            _driver.ShowsBookDetails(expectedBookDetails);
        }
    }
}
