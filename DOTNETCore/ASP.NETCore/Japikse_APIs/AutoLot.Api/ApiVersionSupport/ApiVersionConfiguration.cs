// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - ApiVersionConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Api.ApiVersionSupport;

public static class ApiVersionConfiguration
{
    public static IServiceCollection AddAutoLotApiVersionConfiguration(
        this IServiceCollection services, ApiVersion defaultVersion = null)
    {
        services.AddProblemDetails();
        defaultVersion ??= ApiVersion.Default;
        services.AddApiVersioning(options =>
            {
                //Set Default version
                options.DefaultApiVersion = defaultVersion;
                options.AssumeDefaultVersionWhenUnspecified = true;
                // reporting api versions will return the headers "api-supported-versions"
                // and "api-deprecated-versions"
                options.ReportApiVersions = true;
                //This combines all available option and adds "v" and "api-version"
                // for query string, header, or media type versioning
                // NOTE: In a real application, pick one method, not all of them
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader(), //defaults to "api-version"
                    new QueryStringApiVersionReader("v"),
                    new HeaderApiVersionReader("api-version"),
                    new HeaderApiVersionReader("v"),
                    new MediaTypeApiVersionReader(), //defaults to "v"
                    new MediaTypeApiVersionReader("api-version")
                );
            })
            .AddMvc()
            .AddApiExplorer(options =>
            {
                options.DefaultApiVersion = defaultVersion;
                options.AssumeDefaultVersionWhenUnspecified = true;
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";
                // note: this option is only necessary when versioning by url segment. 
                // the SubstitutionFormat can also be used to control the format of the 
                // API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });
        //Only apply versioning to [ApiController] controllers
        services.TryAddEnumerable(
            ServiceDescriptor.Transient<IApiControllerSpecification, ApiBehaviorSpecification>());

        return services;
    }
}