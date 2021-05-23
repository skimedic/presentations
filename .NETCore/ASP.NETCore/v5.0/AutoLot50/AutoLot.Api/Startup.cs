using System;
using System.IO;
using System.Reflection;
using AutoLot.Api.Filters;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Initialization;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using AutoLot.Services.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AutoLot.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();
            services.AddControllers(
                   config => config.Filters.Add(new CustomExceptionFilter(_env))
                )
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    //options.SuppressModelStateInvalidFilter = true;
                    //options.SuppressInferBindingSourcesForParameters = true;
                    //options.SuppressConsumesConstraintForFormFileParameters = true;
                    //options.SuppressMapClientErrors = true;
                    //options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
                });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
            var connectionString = Configuration.GetConnectionString("AutoLot");
            services.AddDbContextPool<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString,
                    sqlOptions => sqlOptions.EnableRetryOnFailure().CommandTimeout(60)));
            services.AddScoped(typeof(IAppLogging<>), typeof(AppLogging<>));
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<ICreditRiskRepo, CreditRiskRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IMakeRepo, MakeRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            //Original code
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AutoLot.Api", Version = "v1" });
            //});
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "AutoLot Service",
                        Version = "v1",
                        Description = "Service to support the AutoLot dealer site",
                        License = new OpenApiLicense
                        {
                            Name = "Skimedic Inc",
                            Url = new Uri("http://www.skimedic.com")
                        }
                    });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context)
        {
            if (env.IsDevelopment())
            {
                //If in development environment, display debug info
                app.UseDeveloperExceptionPage();
                //Original code
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoLot.Api v1"));
                //Initialize the database
                if (Configuration.GetValue<bool>("RebuildDataBase"))
                {
                    SampleDataInitializer.ClearAndReseedDatabase(context);
                }
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoLot Service v1"); });

            //redirect http traffic to https
            app.UseHttpsRedirection();
            //opt-in to routing
            app.UseRouting();

            //Add CORS Policy
            app.UseCors("AllowAll");

            //enable authorization checks
            app.UseAuthorization();
            //opt-in to using endpoint routing
            //use attribute routing on controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}