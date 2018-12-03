using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using SpyStore_HOL.MVC;
using Xunit;

namespace SpyStore_HOL.Tests.WebTests
{
    public class SimpleIntegrationTests :
        IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private readonly HttpClient _client;

        public SimpleIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Products")]
        [InlineData("/Products/Index")]
        //[InlineData("/Home/About")]
        //[InlineData("/Home/Privacy")]
        //[InlineData("/Home/Contact")]
        public async Task GetHomePage(string url)
        {
            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

    }
}
