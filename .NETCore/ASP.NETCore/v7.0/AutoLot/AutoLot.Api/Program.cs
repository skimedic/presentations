WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureSerilog();
builder.Services.RegisterLoggingInterfaces();

var connectionString = builder.Configuration.GetConnectionString("AutoLot");
builder.Services.AddDbContextPool<ApplicationDbContext>(
    options =>
    {
        options.ConfigureWarnings(wc => wc.Ignore(RelationalEventId.BoolWithDefaultWarning));
        options.UseSqlServer(connectionString,
            sqlOptions => sqlOptions.EnableRetryOnFailure().CommandTimeout(60));
    });

builder.Services.AddScoped<ICarDriverRepo, CarDriverRepo>();
builder.Services.AddScoped<ICarRepo, CarRepo>();
builder.Services.AddScoped<ICreditRiskRepo, CreditRiskRepo>();
builder.Services.AddScoped<ICustomerOrderViewModelRepo, CustomerOrderViewModelRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IDriverRepo, DriverRepo>();
builder.Services.AddScoped<IMakeRepo, MakeRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IRadioRepo, RadioRepo>();

builder.Services.AddAutoLotApiVersionConfiguration(new ApiVersion(1, 0));

builder.Services.AddControllers(
        config => config.Filters.Add(
            new CustomExceptionFilterAttribute(builder.Environment))
    )
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddAndConfigureSwagger(
    builder.Configuration,
    Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

WebApplication app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    //Initialize the database
    if (app.Configuration.GetValue<bool>("RebuildDataBase"))
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        SampleDataInitializer.ClearAndReseedDatabase(dbContext);
    }
}

app.UseSwagger();
app.UseSwaggerUI(
    options =>
    {
        using var scope = app.Services.CreateScope();
        var versionProvider = scope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
        // build a swagger endpoint for each discovered API version
        foreach (var description in versionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();