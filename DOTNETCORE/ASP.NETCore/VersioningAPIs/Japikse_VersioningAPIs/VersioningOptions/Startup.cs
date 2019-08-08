using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace VersioningOptions
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddApiVersioning(options =>
            {
                //report headers "api-supported-versions" and "api-deprecated-versions"
                options.ReportApiVersions = true;

                //on by default for version >= 3.1. Adds versioning to anything with [ApiController] 
                options.UseApiBehavior = true;

                //Demo: 2A. Version by Namespace
                // automatically applies an api version based on the name of the defining controller's namespace
                options.Conventions.Add(new VersionByNamespaceConvention());

                //Demo: 2B. Version with conventions
                //Set version information in Code
                //options.Conventions.Controller<VersioningOptions.Controllers.ValuesController>()
                //    .HasDeprecatedApiVersion(0,5)
                //    .HasApiVersion(4,0)
                //    .Action(c => c.Get2(default)).MapToApiVersion(2,5);

                //Demo: 2C. Default versions for requests
                //Affects clients and incoming calls
                options.AssumeDefaultVersionWhenUnspecified = true;
                //The ApiVersionSelector determines default version
                //uses the default process
                options.ApiVersionSelector = new DefaultApiVersionSelector(options);
                //options.ApiVersionSelector = new ConstantApiVersionSelector(new ApiVersion(new DateTime( 2019, 08, 1 ),1,5));
                //greatest non alpha/rc/etc
                //options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options); 
                //lowest - those without a date are considered lower than those with a date
                //options.ApiVersionSelector = new LowestImplementedApiVersionSelector(options);

                //http://localhost:5000/api/values

                //Demo: 2D. Defaults for controllers
                //Affects controllers that are not versioned - Defaults to 1.0
                options.DefaultApiVersion = new ApiVersion(new DateTime(2019, 10, 1), 2, 0, "Beta");
                //options.DefaultApiVersion = new ApiVersion( new DateTime( 2019, 10, 1 ),2,0 );
                //http://localhost:5000/api/v2019-10-01.2.Beta/values


                //Demo: 2E. Version Reader
                //QueryStringVersion Reader changes the query string parameters
                // This sets the default svc?api-version=2.0
                //options.ApiVersionReader = new QueryStringApiVersionReader();
                // svc?v=2.0
                //options.ApiVersionReader = new QueryStringApiVersionReader("v");
                //Content-Type: application/json;v=3.0
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader(), //defaults to "api-version"
                    new QueryStringApiVersionReader("v"),
                    new QueryStringApiVersionReader("foo"),
                    new HeaderApiVersionReader("api-version"),
                    new HeaderApiVersionReader("v"),
                    new MediaTypeApiVersionReader(), //defaults to "v"
                    new MediaTypeApiVersionReader("api-version"));

                //These are not considered compliant to the MS REST guidelines,
                // Content-Type: application/json;v=2.0
                //options.ApiVersionReader = new MediaTypeApiVersionReader();
                // Content-Type: application/json;version=2.0
                //options.ApiVersionReader = new MediaTypeApiVersionReader("version");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}