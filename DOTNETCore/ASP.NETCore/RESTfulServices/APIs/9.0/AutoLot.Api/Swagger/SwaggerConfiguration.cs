// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - SwaggerConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Swagger;

public static class SwaggerConfiguration
{
    public static void AddAndConfigureSwagger(
        this IServiceCollection services, IConfiguration config, string xmlPathAndFile)
    {
        services.Configure<SwaggerApplicationSettings>(
            config.GetSection(nameof(SwaggerApplicationSettings)));
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(c =>
        {
            c.DocumentFilter<HideInProductionFilter>();
            c.EnableAnnotations();
            c.OperationFilter<SwaggerDefaultValues>();
            c.IncludeXmlComments(xmlPathAndFile);
        });
    }
}