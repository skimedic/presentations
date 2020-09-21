using System;
using System.IO;
using System.Reflection;
using AutoLot.Api.Filters;
using AutoLot.Dal.EfStructures;
using AutoLot.Dal.Initialization;
using AutoLot.Dal.Repos;
using AutoLot.Dal.Repos.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AutoLot.API
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
            services.AddControllers(
                    config => config.Filters.Add(new CustomExceptionFilter(_env))
                    )
                .ConfigureApiBehaviorOptions(options =>
                {
                    //options.SuppressConsumesConstraintForFormFileParameters = true;
                    //options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    //options.SuppressMapClientErrors = true;
                    //options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.WriteIndented = true;
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
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<ICreditRiskRepo, CreditRiskRepo>();
            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IMakeRepo, MakeRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "AutoLot Service",
                        Version = "v1",
                        Description = "Service to support the AutoLot dealer site",
                        License = new OpenApiLicense
                        {
                            Name = "Apress Publishing",
                            Url = new Uri("http://www.Apress.com")
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
                //Initialize the database
                if (Configuration.GetValue<bool>("RebuildDataBase"))
                {
                    SampleDataInitializer.InitializeData(context);
                }
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AutoLot Service v1");
            });

            //redirect http traffic to https
            app.UseHttpsRedirection();
            //opt-in to routing
            app.UseRouting();

            //Add CORS Policy
            app.UseCors("AllowAll");

            //enable authorization checks
            app.UseAuthorization();
            //opt-in to using endpoint routing
            app.UseEndpoints(endpoints =>
            {
                //use attribute routing on controllers
                endpoints.MapControllers();
            });
        }
    }
}
