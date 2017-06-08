using Kcdc.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Kcdc.Api
{
    public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
          .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();

      var connectionString = Configuration.GetConnectionString("DataAccessPostgreSqlProvider");
      services
        .AddEntityFrameworkNpgsql()
        .AddDbContext<KcdcContext>(
            opts => opts.UseNpgsql(connectionString)
        );

      // Add framework services.
      services.AddMvc().AddJsonOptions(options =>
      {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      app.UseCors(builder => builder.WithOrigins("http://localhost:3000"));

      app.UseMvc(routes =>
      {
        routes.MapRoute(
            name: "default",
            template: "api/{controller=Default}/{action=Get}/{id?}"
        );
      });

      Seeder.SeedSpeakers(app.ApplicationServices);
    }
  }
}
