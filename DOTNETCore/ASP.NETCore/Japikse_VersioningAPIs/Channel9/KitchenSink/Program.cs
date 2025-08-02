// Copyright Information
// ==================================
// Japikse_VersioningDocumentingAPIs - KitchenSink - Program.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/25
// ==================================

using KitchenSink.SwaggerInfrastructure;
using KitchenSink.SwaggerInfrastructure.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.Configure<SwaggerApplicationSettings>(
    builder.Configuration.GetSection(nameof(SwaggerApplicationSettings)));

builder.Services.AddAndConfigureSwagger(
    Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"),
    true);

var defaultApiVersion = new ApiVersion(1, 0);
builder.Services.AddApiVersioning(options =>
    {
        // reporting api versions will return the headers "api-supported-versions"
        // and "api-deprecated-versions"
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = defaultApiVersion;
        //options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(new ApiVersioningOptions());
        //This sets the default svc? api-version = 2.0 and svc?v = 2.0
        options.ApiVersionReader = ApiVersionReader.Combine(
            new UrlSegmentApiVersionReader(),
            new QueryStringApiVersionReader(), //defaults to "api-version"
            new QueryStringApiVersionReader("v"),
            new HeaderApiVersionReader("api-version"),
            new HeaderApiVersionReader("v"),
            new MediaTypeApiVersionReader(), //defaults to "v"
            new MediaTypeApiVersionReader("api-version"));
    })
    .AddApiExplorer(
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

builder.Services.TryAddEnumerable(
    ServiceDescriptor.Transient<IApiControllerSpecification, ApiBehaviorSpecification>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            var descriptions = app.DescribeApiVersions();
            foreach (var description in app.DescribeApiVersions())
            {
                var url = $"/swagger/{description.GroupName}/swagger.json";
                var name = description.GroupName.ToUpperInvariant();
                options.SwaggerEndpoint(url, name);
            }
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();