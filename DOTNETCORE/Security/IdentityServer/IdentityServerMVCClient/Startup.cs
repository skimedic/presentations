using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServerClient
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
            services.AddMvc();
            //allows sub (human) and idp (identity server) claims to flow through
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.SignInScheme = "Cookies";

                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;

                    options.ClientId = "MVCSample";
                    options.SaveTokens = true;

                    //Add Hybrid Flow
                    options.ClientSecret = "secret";
                    options.ResponseType = "code id_token";
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.Scope.Add("myApi");
                    options.Scope.Add("offline_access");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "Role",
                    };
                })
                .AddJwtBearer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseAuthentication();

            app.Use((context, next) =>
            {
                var token = context.GetTokenAsync("access_token").GetAwaiter().GetResult();
                if (token == null)
                {
                    return next();
                }
                var jwtToken = new JwtSecurityToken(token);
                var claims = jwtToken.Claims;
                ((ClaimsIdentity)context.User.Identity).AddClaims(claims);
                return next();
            });

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
