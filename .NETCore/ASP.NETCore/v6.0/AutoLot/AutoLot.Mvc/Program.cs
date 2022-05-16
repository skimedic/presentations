var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseWebRoot("wwwroot").ConfigureAppConfiguration((builderContext, config) =>
{
    config.AddJsonFile("appsettings.json").AddJsonFile($@"appsettings.{builder.Environment.EnvironmentName}.json");
});
builder.Host.UseDefaultServiceProvider(o =>
{
    o.ValidateOnBuild = true;
    o.ValidateScopes = true;
});


//Configure logging
builder.ConfigureSerilog();
builder.Services.RegisterLoggingInterfaces();

builder.Host.UseDefaultServiceProvider(o =>
{
    o.ValidateOnBuild = true;
    o.ValidateScopes = true;
});

//Enable CSS isolation in a non-deployed non-dev session
if (!builder.Environment.IsDevelopment())
{
    builder.WebHost.UseWebRoot("wwwroot");
    builder.WebHost.UseStaticWebAssets();
}

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is
    // needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
// The TempData provider cookie is not essential. Make it essential
// so TempData is functional when tracking is disabled.
builder.Services.Configure<CookieTempDataProviderOptions>(options => { options.Cookie.IsEssential = true; });
builder.Services.AddSession(options => { options.Cookie.IsEssential = true; });

builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

if (builder.Environment.IsDevelopment())
{
    //builder.Services.AddWebOptimizer(false,false);
    builder.Services.AddWebOptimizer(options =>
    {
        options.MinifyCssFiles("AutoLot.Mvc.styles.css");
        options.MinifyCssFiles("/css/site.css"); 
        options.MinifyJsFiles("/js/site.js"); 

        //options.AddJavaScriptBundle("/js/validationCode.js", "/js/validations/**/*.js");
        options.AddJavaScriptBundle("/js/validationCode.js", "js/validations/validators.js", "js/validations/errorFormatting.js");
    });
}
else
{
    builder.Services.AddWebOptimizer(options =>
    {
        //options.MinifyCssFiles(); //Minifies all CSS files
        //options.MinifyJsFiles(); //Minifies all JS files
        //options.MinifyCssFiles("css/site.cs"); //Minifies the site.css file
        //options.MinifyCssFiles("lib/**/*.cs"); //Minifies all CSS files
        //options.MinifyJsFiles("js/site.js"); //Minifies the site.js file
        //options.MinifyJsFiles("lib/**/*.js"); //Minifies all JavaScript file under the wwwroot/lib directory
        
        //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/**/*.js");
        //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/validators.js", "js/validations/errorFormatting.js");

        options.MinifyCssFiles("AutoLot.Mvc.styles.css");
        options.MinifyCssFiles("cs/site.cs");
        options.MinifyJsFiles("js/site.js");

        //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/**/*.js");
        //options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/validators.js", "js/validations/errorFormatting.js");
    });
}

var connectionString = builder.Configuration.GetConnectionString("AutoLot");
builder.Services.AddDbContextPool<ApplicationDbContext>(
    options => options.UseSqlServer(connectionString,
        sqlOptions => sqlOptions.EnableRetryOnFailure().CommandTimeout(60)));

builder.Services.AddRepositories();
builder.Services.AddDataServices(builder.Configuration);
builder.Services.Configure<DealerInfo>(builder.Configuration.GetSection(nameof(DealerInfo)));

builder.Services.ConfigureApiServiceWrapper(builder.Configuration);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //Initialize the database
    if (app.Configuration.GetValue<bool>("RebuildDataBase"))
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        SampleDataInitializer.ClearAndReseedDatabase(dbContext);
    }
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseWebOptimizer();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
//app.MapAreaControllerRoute(
//    name: "AdminArea",
//    areaName:"Admin",
//    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
//);

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
