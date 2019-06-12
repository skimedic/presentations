using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Initialization;
using SpyStore.Hol.Dal.Repos;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Service.Filters;
using Swashbuckle.AspNetCore.Swagger;

namespace SpyStore.Hol.Service
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvcCore(config =>
                    config.Filters.Add(new SpyStoreExceptionFilter(_env)))
                .AddJsonFormatters(j =>
                {
                    j.ContractResolver = new DefaultContractResolver();
                    j.Formatting = Formatting.Indented;
                });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                });
            });
            var connectionString = Configuration.GetConnectionString("SpyStore");
            services.AddDbContextPool<StoreContext>(
                options =>options.UseSqlServer(connectionString));
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IShoppingCartRepo, ShoppingCartRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IOrderDetailRepo, OrderDetailRepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", 
                    new Info
                    {
                        Title = "SpyStore Service",
                        Version = "v1",
                        Description = "Service to support the SpyStore sample eCommerce site",
                        TermsOfService = "None",
                        License = new License
                        {
                            Name = "Freeware",
                            //Url = "https://en.wikipedia.org/wiki/Freeware"
                            Url = "http://localhost:32080/LICENSE.txt"
                        }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetRequiredService<StoreContext>();
                    SampleDataInitializer.InitializeData(context);
                }
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","SpyStore Service v1");
            });
            app.UseStaticFiles();
            app.UseCors("AllowAll");  // has to go before UseMvc
            app.UseMvc();
        }
    }
}
