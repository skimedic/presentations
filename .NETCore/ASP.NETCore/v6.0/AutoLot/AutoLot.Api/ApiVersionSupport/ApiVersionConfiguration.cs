namespace AutoLot.Api.ApiVersionSupport;

public static class ApiVersionConfiguration
{
    public static IServiceCollection AddAutoLotApiVersionConfiguration(
        this IServiceCollection services, ApiVersion defaultVersion = null)
    {
        defaultVersion ??= ApiVersion.Default;

        //services.AddApiVersioning();
        services.AddApiVersioning(
            options =>
            {
                //Set Default version
                options.DefaultApiVersion = defaultVersion;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.UseApiBehavior = true;
                // reporting api versions will return the headers "api-supported-versions"
                // and "api-deprecated-versions"
                options.ReportApiVersions = true;
                //This combines all of the avalialbe option as well as 
                // allows for using "v" or "api-version" as options for
                // query string, header, or media type versioning
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new QueryStringApiVersionReader(), //defaults to "api-version"
                    new QueryStringApiVersionReader("v"),
                    new HeaderApiVersionReader("api-version"),
                    new HeaderApiVersionReader("v"),
                    new MediaTypeApiVersionReader(), //defaults to "v"
                    new MediaTypeApiVersionReader("api-version")
                );
            });
        // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
        services.AddVersionedApiExplorer(
            options =>
            {
                options.DefaultApiVersion = defaultVersion;
                options.AssumeDefaultVersionWhenUnspecified = true;
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });
        return services;
    }
}
