// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - ServiceConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoLot.Services.ApiWrapper
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureApiServiceWrapper(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ApiServiceSettings>(config.GetSection(nameof(ApiServiceSettings)));
            services.AddHttpClient<IApiServiceWrapper,ApiServiceWrapper>();
            return services;
        }
    }
}
