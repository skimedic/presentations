using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FolderVersioning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddApiVersioning(options =>
            {
                // reporting api versions will return the headers "api-supported-versions"
                // and "api-deprecated-versions"
                options.ReportApiVersions = true;
                //Only version [ApiController] defaults to true in 3.1+
                options.UseApiBehavior = true;

                // automatically applies an api version based on the name of the defining controller's namespace
                options.Conventions.Add(new VersionByNamespaceConvention());

                //Set version information in Code
                //options.Conventions.Controller<VersioningOptions.Controllers.ValuesController>()
                //    .HasDeprecatedApiVersion(0, 5)
                //    .HasApiVersion(4, 0)
                //    .Action(c => c.Get(default)).MapToApiVersion(2, 5);
                //Affects clients and incoming calls
                options.AssumeDefaultVersionWhenUnspecified = true;
                //The ApiVersionSelector determines default version
                //uses the default process
                //options.ApiVersionSelector = new DefaultApiVersionSelector(options);
                //options.ApiVersionSelector = new ConstantApiVersionSelector(new ApiVersion(new DateTime( 2021, 08, 1 ),1,5));
                //greatest non alpha/rc/etc
                 //options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options); 
                //lowest - those without a date are considered lower than those with a date
                //options.ApiVersionSelector = new LowestImplementedApiVersionSelector(options);
                //Affects controllers that are not versioned - Defaults to 1.0
                //options.DefaultApiVersion = new ApiVersion(new DateTime(2021, 08, 1), 2, 0, "Beta");
                options.DefaultApiVersion = new ApiVersion(1,5);

                //This sets the default svc? api-version = 2.0 and svc?v = 2.0
                options.ApiVersionReader = ApiVersionReader.Combine(
                new QueryStringApiVersionReader(), //defaults to "api-version"
                new QueryStringApiVersionReader("v"),
                new HeaderApiVersionReader("api-version"),
                new HeaderApiVersionReader("v"),
                new MediaTypeApiVersionReader(), //defaults to "v"
                new MediaTypeApiVersionReader("api-version"));

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider versionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FullSwaggerSupport v1"));
            app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in versionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                                description.GroupName.ToUpperInvariant());
                    }
                });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
