// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Api - Program.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureSerilog();
builder.Services.RegisterLoggingInterfaces();

// Add services to the container.
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


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", pb =>
    {
        pb
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});


var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
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