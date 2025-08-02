// Copyright Information
// ==================================
// Japikse_VersioningAPIs_7.0 - FullSwaggerSupport - ConfigureSwaggerOptions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/09
// ==================================

namespace KitchenSink.SwaggerInfrastructure;

public class ConfigureSwaggerOptions(
    IApiVersionDescriptionProvider provider,
    IOptionsMonitor<SwaggerApplicationSettings> settingsMonitor)
    : IConfigureOptions<SwaggerGenOptions>
{
    private readonly SwaggerApplicationSettings _settings = settingsMonitor.CurrentValue;

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description, _settings));
        }
    }

    internal static OpenApiInfo CreateInfoForApiVersion(
        ApiVersionDescription description, 
        SwaggerApplicationSettings settings)
    {

        SwaggerVersionDescription versionDesc =
            settings.Descriptions.FirstOrDefault(x => 
                x.MajorVersion == (description.ApiVersion.MajorVersion??0) 
                && x.MinorVersion == (description.ApiVersion.MinorVersion??0));
        var info = new OpenApiInfo()
        {
            Title = settings.Title,
            Version = description.ApiVersion.ToString(),
            Description = $"A sample application with Swagger, Swashbuckle, and API versioning. {versionDesc?.Description}",
            Contact = new OpenApiContact() { Name = settings.ContactName, Email = settings.ContactEmail },
            TermsOfService = new System.Uri("https://www.linktotermsofservice.com"),
            License = new OpenApiLicense() { Name = "MIT", Url = new System.Uri("https://opensource.org/licenses/MIT") }
        };
        if (description.IsDeprecated)
        {
            info.Description += "<p><font color='red'>This API version has been deprecated.</font></p>";
        }

        return info;
    }
}