using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Initialization;
using SpyStore.Dal.Repos;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Mvc.Support;

namespace SpyStore.Mvc
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            _env = env;
            Configuration = configuration;
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var connectionString = Configuration.GetConnectionString("SpyStore");
#if SQL2017
            //use sqllocaldb to update/create localdb instances
            var path = Environment.GetEnvironmentVariable("APPDATA");
            connectionString =
                $@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SpyStoreHOL;Trusted_Connection=True;MultipleActiveResultSets=true;AttachDbFileName={path}\SpyStoreHOL.mdf;";
#endif
            services.AddDbContextPool<StoreContext>(options => options
                .UseSqlServer(connectionString, o => o.EnableRetryOnFailure())
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning)));
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
            services.Configure<CustomSettings>(Configuration.GetSection("CustomSettings"));
            if (_env.IsDevelopment() || _env.EnvironmentName == "Local")
            {
                services.AddWebOptimizer(options =>
                {
                    options.MinifyCssFiles(); //Minifies all CSS files
                    //options.MinifyJsFiles(); //Minifies all JS files
                    options.MinifyJsFiles("js/site.js");
                    options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/**/*.js");
                    //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/validators.js", "js/validations/errorFormatting.js");
                });
                //services.AddWebOptimizer(false,false);
            }
            else
            {
                services.AddWebOptimizer(options =>
                {
                    options.MinifyCssFiles(); //Minifies all CSS files
                    //options.MinifyJsFiles(); //Minifies all JS files
                    options.MinifyJsFiles("js/site.js");
                    options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/**/*.js");
                    //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/validators.js", "js/validations/errorFormatting.js");
                });
            }

        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    SampleDataInitializer
                        .InitializeData(serviceScope.ServiceProvider.GetRequiredService<StoreContext>());
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseWebOptimizer();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            //Demo: Route Table
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                 routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
               routes.MapRoute(
                    name: "default",
                    template: "{controller=Products}/{action=Index}/{id?}");

            });
        }
    }
}
