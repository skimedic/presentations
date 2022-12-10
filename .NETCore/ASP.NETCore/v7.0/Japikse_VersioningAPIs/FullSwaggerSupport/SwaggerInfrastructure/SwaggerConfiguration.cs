namespace FullSwaggerSupport.SwaggerInfrastructure;

public static class SwaggerConfiguration
{
    public static void AddAndConfigureSwagger(
        this IServiceCollection services, 
        string xmlPathAndFile,
        bool addBasicSecurity)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.OperationFilter<SwaggerDefaultValues>();
            c.IncludeXmlComments(xmlPathAndFile);
            c.ResolveConflictingActions(c=>c.First());
            if (!addBasicSecurity)
            {
                return;
            }
            c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                In = ParameterLocation.Header,
                Description = "Basic Authorization header using the Bearer scheme."
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "basic"
                        }
                    },
                    new List<string> {}
                }
            });

        });
    }

}