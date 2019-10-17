using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;

namespace WebRequest.Specs.Drivers
{
    public class WebDriver
    {
        private HttpClient _httpClient;
        private HttpResponseMessage _httpResponseMessage;

        public void InitializeHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task HttpClientGet(string url)
        {
           _httpResponseMessage = await _httpClient.GetAsync(url);
        }

        public void CheckResponseStatusCode(int expectedStatusCode)
        {
            _httpResponseMessage.StatusCode.Should().Be(expectedStatusCode);
        }
    }
}
