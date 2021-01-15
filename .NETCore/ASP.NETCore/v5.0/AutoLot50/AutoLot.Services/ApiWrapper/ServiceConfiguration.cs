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
