using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SpyStore_v21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static IWebHostBuilder CreateDefaultBuilder(string[] args)
        {
            IWebHostBuilder hostBuilder =
                new WebHostBuilder()
                    .UseKestrel((Action<WebHostBuilderContext, KestrelServerOptions>)
                        ((builderContext, options) =>
                            options
                                .Configure((IConfiguration) builderContext
                                    .Configuration.GetSection("Kestrel"))))
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .ConfigureAppConfiguration((Action<WebHostBuilderContext, IConfigurationBuilder>)
                        ((hostingContext, config) =>
                        {
                            IHostingEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
                            config
                                .AddJsonFile("appsettings.json", true, true)
                                .AddJsonFile(string.Format("appsettings.{0}.json",
                                    (object) hostingEnvironment.EnvironmentName), true, true);
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
                    .ConfigureLogging((Action<WebHostBuilderContext, ILoggingBuilder>)
                        ((hostingContext, logging) =>
                        {
                            logging.AddConfiguration(
                                (IConfiguration) hostingContext.Configuration.GetSection("Logging"));
                            logging.AddConsole();
                            logging.AddDebug();
                        }))
                    .UseIISIntegration()
                    .UseDefaultServiceProvider((Action<WebHostBuilderContext, ServiceProviderOptions>)
                        ((context, options) =>
                            options.ValidateScopes = context.HostingEnvironment.IsDevelopment()));
            if (args != null)
                hostBuilder.UseConfiguration((IConfiguration) new ConfigurationBuilder().AddCommandLine(args).Build());
            return hostBuilder;
        }
    }
}