using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SpyStore_HOL.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
				//Use the port from launchSettings.json
                .UseUrls("http://*:55876/")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
