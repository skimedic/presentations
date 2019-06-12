using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SpyStore.Hol.Mvc.Support;

namespace SpyStore.Hol.Mvc
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
            services.Configure<ServiceSettings>(Configuration.GetSection("ServiceSettings"));
            services.AddHttpClient<SpyStoreServiceWrapper>();
            if (_env.IsDevelopment() || _env.EnvironmentName == "Local")
            {
                //services.AddWebOptimizer(false,false);
                services.AddWebOptimizer(options =>
                {
                    options.MinifyCssFiles(); //Minifies all CSS files
                    //options.MinifyJsFiles(); //Minifies all JS files
                    options.MinifyJsFiles("js/site.js");
                    options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/**/*.js");
                    //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/validators.js", "js/validations/errorFormatting.js");
                });
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
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
