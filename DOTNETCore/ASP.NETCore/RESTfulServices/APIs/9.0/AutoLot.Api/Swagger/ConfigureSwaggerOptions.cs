// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - ConfigureSwaggerOptions.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Swagger;

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
        var versionDesc =
            settings.Descriptions.FirstOrDefault(x =>
                x.MajorVersion == (description.ApiVersion.MajorVersion ?? 0)
                && x.MinorVersion == (description.ApiVersion.MinorVersion ?? 0)
                && (string.IsNullOrEmpty(description.ApiVersion.Status) ||
                    x.Status == description.ApiVersion.Status));
        var info = new OpenApiInfo()
        {
            Title = settings.Title,
            Version = description.ApiVersion.ToString(),
            Description = $"{versionDesc?.Description}",
            Contact = new OpenApiContact() { Name = settings.ContactName, Email = settings.ContactEmail },
            TermsOfService = new System.Uri("https://www.linktotermsofservice.com"),
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("https://opensource.org/licenses/MIT")
            }
        };
        if (description.IsDeprecated)
        {
            info.Description += "<p><font color='red'>This API version has been deprecated.</font></p>";
        }

        return info;
    }
}