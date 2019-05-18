using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BasicSetup
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
            //services.AddApiVersioning();
            services.AddApiVersioning(o=>
            {
                //Set Default version
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                //Only version [ApiController] - false in 3.0, true in 3.1
                o.UseApiBehavior = true;
                // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                o.ReportApiVersions = true;

                //Set the header name for version - there isn't a default value
                //o.ApiVersionReader = new HeaderApiVersionReader("api-version");

                //Change the query string values
                // This sets the default svc?api-version=2.0
                //o.ApiVersionReader = new QueryStringApiVersionReader();
                // svc?v=2.0
                //o.ApiVersionReader = new QueryStringApiVersionReader("v");
                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader(),
                    new QueryStringApiVersionReader("v"));

                //These are not considered compliant to the MS REST guidelines,
                // Content-Type: application/json;v=2.0
                //o.ApiVersionReader = new MediaTypeApiVersionReader();
                // Content-Type: application/json;version=2.0
                //o.ApiVersionReader = new MediaTypeApiVersionReader("version");

                //These handle requests where client doesn't request a version
                //o.ApiVersionSelector = new DefaultApiVersionSelector(o); //uses the default process
                //o.ApiVersionSelector = new ConstantApiVersionSelector(new ApiVersion(2, 0));
                //o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o); //greatest non alpha/rc/etc
                //o.ApiVersionSelector = new LowestImplementedApiVersionSelector(o); //lowest


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
