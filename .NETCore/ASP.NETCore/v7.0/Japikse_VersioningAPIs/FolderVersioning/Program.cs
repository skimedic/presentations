using System.Reflection;
using FolderVersioning.SwaggerInfrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.EnableAnnotations();
//    options.OperationFilter<SwaggerDefaultValues>();
//    options.ResolveConflictingActions(c => c.First());
//});
//builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.Configure<SwaggerApplicationSettings>(builder.Configuration.GetSection(nameof(SwaggerApplicationSettings)));
SwaggerConfiguration.AddAndConfigureSwagger(builder.Services, Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"),
    false);
builder.Services.AddApiVersioning(options =>
{
    // reporting api versions will return the headers "api-supported-versions"
    // and "api-deprecated-versions"
    options.ReportApiVersions = true;
    //Only version [ApiController] defaults to true in 3.1+
    options.UseApiBehavior = true;

    // automatically applies an api version based on the name of the defining controller's namespace
    options.Conventions.Add(new VersionByNamespaceConvention());

    //Set version information in Code
    //options.Conventions.Controller<VersioningOptions.Controllers.ValuesController>()
    //    .HasDeprecatedApiVersion(0, 5)
    //    .HasApiVersion(4, 0)
    //    .Action(c => c.Get(default)).MapToApiVersion(2, 5);
    //Affects clients and incoming calls
    options.AssumeDefaultVersionWhenUnspecified = true;
    //The ApiVersionSelector determines default version
    //uses the default process
    //options.ApiVersionSelector = new DefaultApiVersionSelector(options);
    //options.ApiVersionSelector = new ConstantApiVersionSelector(new ApiVersion(new DateTime( 2021, 08, 1 ),1,5));
    //greatest non alpha/rc/etc
    //options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options); 
    //lowest - those without a date are considered lower than those with a date
    //options.ApiVersionSelector = new LowestImplementedApiVersionSelector(options);
    //Affects controllers that are not versioned - Defaults to 1.0
    //options.DefaultApiVersion = new ApiVersion(new DateTime(2021, 08, 1), 2, 0, "Beta");
    options.DefaultApiVersion = new ApiVersion(1, 5);

    //This sets the default svc? api-version = 2.0 and svc?v = 2.0
    options.ApiVersionReader = ApiVersionReader.Combine(
    new QueryStringApiVersionReader(), //defaults to "api-version"
    new QueryStringApiVersionReader("v"),
    new HeaderApiVersionReader("api-version"),
    new HeaderApiVersionReader("v"),
    new MediaTypeApiVersionReader(), //defaults to "v"
    new MediaTypeApiVersionReader("api-version"));
});
builder.Services.AddVersionedApiExplorer(
            options =>
            {
                // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";
                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
                options.SubstituteApiVersionInUrl = true;
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    var versionProvider = app.Services.CreateScope().ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwaggerUI(
        options =>
        {
            // build a swagger endpoint for each discovered API version
            foreach (var description in versionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
