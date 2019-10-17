using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WebRequest.Specs.Drivers;

namespace WebRequest.Specs.StepDefinitions
{
    [Binding]
    public class WebSteps
    {
        private readonly WebDriver _webDriver;

        public WebSteps(WebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        [Given(@"I have a web client")]
        public void GivenIHaveAWebClient()
        {
            _webDriver.InitializeHttpClient();
        }

        [When(@"I want to get the web page '(.*)'")]
        public async Task WhenIWantToGetTheWebPage(string url)
        {
            await _webDriver.HttpClientGet(url);
        }

        [Then(@"the result should have status code '(.*)'")]
        public void ThenTheResultShouldHaveStatusCode(int expectedStatusCode)
        {
            _webDriver.CheckResponseStatusCode(expectedStatusCode);
        }
    }
}
