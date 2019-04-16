using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUglify.Css;
using SpyStore_HOL.DAL.EfStructures;
using SpyStore_HOL.DAL.Initialization;
using SpyStore_HOL.DAL.Repos;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.MVC.Support;

namespace SpyStore_HOL.MVC
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

#if SQL2017
            var connectionString = Configuration.GetConnectionString("SpyStore2017");
            if (_env.IsDevelopment())
            {
                var path = Environment.GetEnvironmentVariable("APPDATA");
                connectionString = connectionString.Replace("{path}", path);
            }
#else
            var connectionString = Configuration.GetConnectionString("SpyStore");
#endif

            services.AddDbContextPool<StoreContext>(options => options
                .UseSqlServer(connectionString, o => o.EnableRetryOnFailure())
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning)));

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.Configure<CustomSettings>(Configuration.GetSection("CustomSettings"));
            services.AddWebOptimizer();
            //if (_env.IsDevelopment())
            //{
            //    services.AddWebOptimizer(options =>
            //    {
            //        options.MinifyCssFiles("foo.css");
            //        options.MinifyJsFiles("foo.js");
            //    });
            //}
            //else
            //{
            //    services.AddWebOptimizer(options =>
            //    {
            //        //Globbing is not working in the current released version, so this is a work around:
            //        var fileArray = Directory.GetFiles(@"wwwroot\js\validations", "*.js", SearchOption.AllDirectories);
            //        var jsAppFilenames = fileArray.Select(s => s.Replace(@"wwwroot\", "")).ToArray();

            //        options.MinifyCssFiles(); //Minifies all CSS files
            //        //options.MinifyJsFiles(); //Minifies all JS files
            //        options.MinifyJsFiles("js/site.js");
            //        //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/*.js");
            //        //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/validators.js", "js/validations/errorFormatting.js");
            //        options.AddJavaScriptBundle("js/validations/validationCode.js", jsAppFilenames);
            //    });
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    StoreDataInitializer
                        .InitializeData(serviceScope.ServiceProvider.GetRequiredService<StoreContext>());
                }
            }
            else
            {
                app.UseExceptionHandler("/Products/Error");
            }

            app.UseWebOptimizer();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Products}/{action=Index}/{id?}");
            });
        }
    }
}