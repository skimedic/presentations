// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - Program.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/12
// ==================================

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureSerilog();
builder.Services.RegisterLoggingInterfaces();

var connectionString = builder.Configuration.GetConnectionString("AutoLot");
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
{
    options.ConfigureWarnings(wc => wc.Ignore(RelationalEventId.BoolWithDefaultWarning));
    options.UseSqlServer(connectionString,
        sqlOptions => sqlOptions.EnableRetryOnFailure().CommandTimeout(60));
});

builder.Services.AddScoped<ICarDriverRepo, CarDriverRepo>();
builder.Services.AddScoped<ICarRepo, CarRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<IMakeRepo, MakeRepo>();
builder.Services.AddScoped<IRadioRepo, RadioRepo>();
builder.Services.AddScoped(typeof(IDataShaper<>), typeof(DataShaper<>));

builder.Services.AddControllers(config =>
    {
        config.Filters.Add(new CustomExceptionFilterAttribute(builder.Environment));
        //config.ReturnHttpNotAcceptable = true;
        config.RespectBrowserAcceptHeader = true;
        config.OutputFormatters.Add(new CustomCsvOutputFormatter());
    })
    .AddControllersAsServices()
    .AddXmlSerializerFormatters()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    })
    .ConfigureApiBehaviorOptions(options =>
    {
        //suppress automatic model state binding errors
        options.SuppressModelStateInvalidFilter = true;
        //suppress all binding inference
        //options.SuppressInferBindingSourcesForParameters= true;
        //suppress multipart/form-data content type inference
        //options.SuppressConsumesConstraintForFormFileParameters = true;
        //Don't create a problem details error object if set to true
        options.SuppressMapClientErrors = false;
        options.ClientErrorMapping[StatusCodes.Status404NotFound].Link = "https://httpstatuses.com/404";
        options.ClientErrorMapping[StatusCodes.Status404NotFound].Title = "Invalid location";
    });

builder.Host.UseDefaultServiceProvider(o =>
{
    o.ValidateOnBuild = true;
    o.ValidateScopes = true;
});

builder.Services.AddProblemDetails();
var defaultVersion = ApiVersion.Default;
builder.Services.AddApiVersioning(options =>
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
}).AddApiExplorer(options =>
{
    options.DefaultApiVersion = ApiVersion.Default;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", pb =>
    {
        pb
            .AllowAnyHeader()
            .AllowAnyMethod()
            //.AllowCredentials()
            .AllowAnyOrigin();
    });
});
builder.Services.AddOpenApi("v1", options =>
{
    options.AddDocumentTransformer((
        document,
        context,
        cancellationToken) =>
    {
        document.Info = BuildDocumentInfo("v1", false);
        return Task.CompletedTask;
    });
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
    options.ShouldInclude = (
        description) => description.GroupName == null || description.GroupName == options.DocumentName;
    //options.ShouldInclude = (
    //    description) => description.GroupName == options.DocumentName;
});
builder.Services.AddOpenApi("v1.5", options =>
{
    options.AddDocumentTransformer((
        document,
        context,
        cancellationToken) =>
    {
        document.Info = BuildDocumentInfo("v1.5",true);
        return Task.CompletedTask;
    });
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
    options.ShouldInclude = (
        description) => description.GroupName == options.DocumentName;
});
builder.Services.AddOpenApi("v2", options =>
{
    options.AddDocumentTransformer((
        document,
        context,
        cancellationToken) =>
    {
        document.Info = BuildDocumentInfo("v2", false);
        return Task.CompletedTask;
    });
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
    options.ShouldInclude = (
        description) => description.GroupName == options.DocumentName;
});
builder.Services.AddOpenApi("v3", options =>
{
    options.AddDocumentTransformer((
        document,
        context,
        cancellationToken) =>
    {
        document.Info = BuildDocumentInfo("v3", false);
        return Task.CompletedTask;
    });
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
    options.ShouldInclude = (
        description) => description.GroupName == options.DocumentName;
});
builder.Services.AddOpenApi("v3.0-Beta", options =>
{
    options.AddDocumentTransformer((
        document,
        context,
        cancellationToken) =>
    {
        document.Info = BuildDocumentInfo("v3.0-Beta", false);
        return Task.CompletedTask;
    });
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
    options.ShouldInclude = (
        description) => description.GroupName == options.DocumentName;
});
builder.Services.AddOpenApi("v2.5-Beta", options =>
{
    options.AddDocumentTransformer((
        document,
        context,
        cancellationToken) =>
    {
        document.Info = BuildDocumentInfo("v2.5-Beta", false);
        return Task.CompletedTask;
    });
    options.OpenApiVersion = OpenApiSpecVersion.OpenApi3_1;
    options.ShouldInclude = (
        description) => description.GroupName == options.DocumentName;
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors("AllowAll");

app.MapOpenApi();
app.UseSwaggerUI(options =>
{
    //options.SwaggerEndpoint("/openapi/v1.json", "v1");
    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var description in provider.ApiVersionDescriptions)
    {
        var url = $"/openapi/{description.GroupName}.json";
        var name = $"AutoLot API: {description.GroupName}";
        options.SwaggerEndpoint(url, name);
    }
});
//var provider = app.Services.GetRequiredService<IOpenApiDocumentProvider>();
//var document = await provider.GetOpenApiDocumentAsync("v1");

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    //Initialize the database
    if (app.Configuration.GetValue<bool>("RebuildDataBase"))
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        SampleDataInitializer.ClearAndReseedDatabase(dbContext);
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

OpenApiInfo BuildDocumentInfo(string version,bool isDeprecated)
{
    var description = "API for AutoLot Car Dealership.";
    if (isDeprecated)
    {
        description += "<p><font color='red'>This API version has been deprecated.</font></p>";
    }
    return new()
    {
        Title = "AutoLot API",
        Version = version,
        Description = description,
        Contact = new OpenApiContact() { Name = "Phil Japikse", Email = "skimedic@outlook.com" },
        TermsOfService = new System.Uri("https://www.linktotermsofservice.com"),
        License = new OpenApiLicense()
        {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT")
        }

    };
}