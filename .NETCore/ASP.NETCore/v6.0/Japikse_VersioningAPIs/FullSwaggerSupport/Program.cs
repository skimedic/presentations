using System.Reflection;
using AutoLot.Api.Swagger;
using FullSwaggerSupport.SwaggerInfrastructure.Models;

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
builder.Services.Configure<SwaggerApplicationSettings>(builder.Configuration.GetSection(nameof(SwaggerApplicationSettings)));
builder.Services.AddAndConfigureSwagger(
    Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"),
    false);
var defaultApiVersion = new ApiVersion(2, 0); 
builder.Services.AddApiVersioning(options =>
{
    // reporting api versions will return the headers "api-supported-versions"
    // and "api-deprecated-versions"
    options.ReportApiVersions = true;
    //Only version [ApiController] defaults to true in 3.1+
    options.UseApiBehavior = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = defaultApiVersion;
    //This sets the default svc? api-version = 2.0 and svc?v = 2.0
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
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
        options.DefaultApiVersion = defaultApiVersion;
        options.AssumeDefaultVersionWhenUnspecified = true;
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
