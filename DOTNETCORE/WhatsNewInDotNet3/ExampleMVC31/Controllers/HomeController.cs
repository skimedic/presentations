using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExampleMVC31.Models;

namespace ExampleMVC31.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Http2()
        {
            //var client = new HttpClient() {BaseAddress = new Uri("https://localhost:5001")};

            var client = new HttpClient() { 
                BaseAddress = new Uri("https://localhost:5001"), 
                DefaultRequestVersion = new Version(2, 0) 
            };

            // HTTP/1.1 request
            //using (var response = await client.GetAsync("/WeatherForecast"))
            //{
            //    Console.WriteLine(response.Content);
            //}

            // HTTP/2 request
            using var request = new HttpRequestMessage(HttpMethod.Get, "/WeatherForecast");
            //{
            //    Version = new Version(2, 0)
            //};
            using var response = await client.SendAsync(request);

            return View();
        }

        public IActionResult SignalR()
        {
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}