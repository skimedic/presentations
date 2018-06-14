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
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

/*
    public static IWebHostBuilder CreateDefaultBuilder(string[] args)
    {
      IWebHostBuilder hostBuilder = new WebHostBuilder()
      .UseKestrel((Action<WebHostBuilderContext, KestrelServerOptions>) ((builderContext, options) => options.Configure((IConfiguration) builderContext.Configuration.GetSection("Kestrel")))).UseContentRoot(Directory.GetCurrentDirectory()).ConfigureAppConfiguration((Action<WebHostBuilderContext, IConfigurationBuilder>) ((hostingContext, config) =>
      {
        IHostingEnvironment hostingEnvironment = hostingContext.HostingEnvironment;
        config
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile(string.Format("appsettings.{0}.json", (object) hostingEnvironment.EnvironmentName), true, true);
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
      })).ConfigureLogging((Action<WebHostBuilderContext, ILoggingBuilder>) ((hostingContext, logging) =>
      {
        logging.AddConfiguration((IConfiguration) hostingContext.Configuration.GetSection("Logging"));
        logging.AddConsole();
        logging.AddDebug();
      })).ConfigureServices((Action<WebHostBuilderContext, IServiceCollection>) ((hostingContext, services) =>
      {
        services.PostConfigure<HostFilteringOptions>((Action<HostFilteringOptions>) (options =>
        {
          if (options.AllowedHosts != null && options.AllowedHosts.Count != 0)
            return;
          string str = hostingContext.Configuration["AllowedHosts"];
          string[] strArray1;
          if (str == null)
            strArray1 = (string[]) null;
          else
            strArray1 = str.Split(new char[1]{ ';' }, StringSplitOptions.RemoveEmptyEntries);
          string[] strArray2 = strArray1;
          HostFilteringOptions filteringOptions = options;
          string[] strArray3;
          if (strArray2 == null || strArray2.Length == 0)
            strArray3 = new string[1]{ "*" };
          else
            strArray3 = strArray2;
          filteringOptions.AllowedHosts = (IList<string>) strArray3;
        }));
        services.AddSingleton<IOptionsChangeTokenSource<HostFilteringOptions>>((IOptionsChangeTokenSource<HostFilteringOptions>) new ConfigurationChangeTokenSource<HostFilteringOptions>(hostingContext.Configuration));
        services.AddTransient<IStartupFilter, HostFilteringStartupFilter>();
      })).UseIISIntegration().UseDefaultServiceProvider((Action<WebHostBuilderContext, ServiceProviderOptions>) ((context, options) => options.ValidateScopes = context.HostingEnvironment.IsDevelopment()));
      if (args != null)
        hostBuilder.UseConfiguration((IConfiguration) new ConfigurationBuilder().AddCommandLine(args).Build());
      return hostBuilder;
    }
*/