using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite.Internal.PatternSegments;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpyStore_v20.Models;

namespace SpyStore_v20
{
    public class Program
    {
        //This is the method provided by the default template
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void Main(string[] args)
        {
            IWebHost host = null;
            //Default template setup
            host = BuildWebHost(args);

            //Kestrel & IIS - No SSL
            //host = CreateBaseBuilder(args)
            //    .UseCompressionAndCaching()
                //.UseMyKeyVault()
                //.UseAzureAppServiceLogging()
            //    .Build();

            //Kestel - SSL
            //host = new WebHostBuilder()
            //    .UseNoServerBuilderOptions(args)
            //    .UseCompressionAndCaching()
            //    //.UseKestrelWithHttps()
            //    .UseKestrelWithHttpsForDocker()
            //    .UseIISIntegration()
            //    .UseStartup<Startup>().Build();

            //host = new WebHostBuilder()
            //    .UseNoServerBuilderOptions(args)
            //    .UseHttpSys(options =>
            //    {
            //        options.Authentication.Schemes = AuthenticationSchemes.None;
            //        options.Authentication.AllowAnonymous = true;
            //        options.MaxConnections = 100;
            //        options.MaxRequestBodySize = 30000000;
            //    })
            //    .UseStartup<Startup>()
            //    .Build();

            host.Run();
        }


        public static IWebHostBuilder CreateBaseBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder().UseStartup<Startup>();
        }

        //This is the functionality of the CreateDefaultBuilderMethod
        public static IWebHostBuilder CreateDefaultBuilderExploded(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(
                    (Action<WebHostBuilderContext, IConfigurationBuilder>) ((hostingContext, config) =>
                    {
                        IHostingEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
                        config.AddJsonFile("appsettings.json", true, true)
                            .AddJsonFile(
                                string.Format("appsettings.{0}.json", (object) hostingEnvironment.EnvironmentName),
                                true, true);
                        if (hostingEnvironment.IsDevelopment())
                        {
                            Assembly assembly = Assembly.Load(new AssemblyName(hostingEnvironment.ApplicationName));
                            if (assembly != (Assembly) null)
                                config.AddUserSecrets(assembly, true);
                        }
                        config.AddEnvironmentVariables();
                        if (args == null)
                            return;
                        config.AddCommandLine(args);
                    }))
                .ConfigureLogging((Action<WebHostBuilderContext, ILoggingBuilder>) ((hostingContext, logging) =>
                {
                    logging.AddConfiguration((IConfiguration) hostingContext.Configuration.GetSection("Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                }))
                .UseIISIntegration()
                .UseDefaultServiceProvider(
                    (Action<WebHostBuilderContext, ServiceProviderOptions>) ((context, options) =>
                        options.ValidateScopes = context.HostingEnvironment.IsDevelopment()));
        }
    }
}