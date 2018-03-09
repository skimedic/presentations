using System;
using System.IO;
using System.Net;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpyStore_v21.Models;

namespace SpyStore_v21
{
    public static class WebHostBuilderExtensionMethods
    {
        //loads everything from CreateDefaultBuilder except Kestrel & IIS
        public static IWebHostBuilder UseCompressionAndCaching(this IWebHostBuilder builder) => builder
            .ConfigureServices((context, services) =>
            {
                //Response Caching - can also be configured in Main
                services.AddResponseCaching();
                //services.AddResponseCaching(options =>
                //{
                //    options.MaximumBodySize = 1024;
                //    options.UseCaseSensitivePaths = true;
                //});

                //Response Compression - can also be configured in Main
                services.AddResponseCompression();
                //services.AddResponseCompression(options => options.Providers.Add<GzipCompressionProvider>());
                //services.Configure<GzipCompressionProviderOptions>(
                //    options => options.Level = CompressionLevel.Fastest);
                //services.AddResponseCompression(options =>
                //{
                //    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml", "image/png" });
                //    options.Providers.Add<GzipCompressionProvider>();
                //});
            })
            .Configure(app =>
            {
                //response caching middleware - can also be configures in Main
                app.UseResponseCaching();

                //response compression middleware - can also be configures in Main
                //Turn off to use compression as filter
                app.UseResponseCompression();
            });

        public static IWebHostBuilder UseKestrelWithHttps(this IWebHostBuilder builder)
        {
            int sslPort = 0;
            int regPort = 0;
            return builder
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile(@"Properties/launchSettings.json", optional: false, reloadOnChange: true);
                    var builtConfig = config.Build();
                    sslPort = builtConfig.GetValue<int>("iisSettings:iisExpress:sslPort");
                    var url = builtConfig.GetValue<string>("profiles:SpyStore_v20:applicationUrl");
                    regPort = int.Parse(url.Replace("http://localhost:", "").Replace("/", ""));
                })
                .UseKestrel(options =>
                {
                    // Easy mode (http only)
                    options.Listen(IPAddress.Any, regPort);

                    // Verbose
                    options.Listen(IPAddress.Any, sslPort, listenOptions =>
                    {
                        // Enable https
                        listenOptions.UseHttps(
                            Path.Combine(Directory.GetCurrentDirectory(), "PfjEnterprises.pfx"), Secrets.PASSWORD);
                    });
                });
        }

        public static IWebHostBuilder UseKestrelWithHttpsForDocker(this IWebHostBuilder builder) =>
            builder
            .UseLaunchSettingsConfig()
                .UseKestrel(options =>
                {
                    // Easy mode (http only)
                    options.Listen(IPAddress.Any, 80);

                    // Verbose
                    options.Listen(IPAddress.Any, 443, listenOptions =>
                    {
                        // Enable https
                        listenOptions.UseHttps(
                            Path.Combine(Directory.GetCurrentDirectory(), "PfjEnterprises.pfx"), Secrets.PASSWORD);
                    });
                });

        public static IWebHostBuilder UseNoServerBuilderOptions(this IWebHostBuilder builder, string[] args) =>
            builder.UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(
                    (Action<WebHostBuilderContext, IConfigurationBuilder>) ((hostingContext, config) =>
                    {
                        IHostingEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
                        config.AddJsonFile("appsettings.json", true, true).AddJsonFile(
                            string.Format("appsettings.{0}.json", (object) hostingEnvironment.EnvironmentName), true,
                            true);
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
                .UseDefaultServiceProvider(
                    (Action<WebHostBuilderContext, ServiceProviderOptions>) ((context, options) =>
                        options.ValidateScopes = context.HostingEnvironment.IsDevelopment()));

        public static IWebHostBuilder UseMyKeyVault(this IWebHostBuilder builder) =>
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var builtConfig = config.Build();

                config.AddAzureKeyVault(
                    $"https://{builtConfig["Vault"]}.vault.azure.net/",
                    builtConfig["ClientId"],
                    builtConfig["ClientSecret"]);
            });

        public static IWebHostBuilder UseAzureAppServiceLogging(this IWebHostBuilder builder) =>
            builder.UseAzureAppServices()
                .ConfigureLogging((context, logger) => { logger.AddAzureWebAppDiagnostics(); });

        public static IWebHostBuilder UseLaunchSettingsConfig(this IWebHostBuilder builder) =>
            builder
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile(@"Properties/launchSettings.json", optional: false, reloadOnChange: true);
                    var builtConfig = config.Build();
                });
    }
}