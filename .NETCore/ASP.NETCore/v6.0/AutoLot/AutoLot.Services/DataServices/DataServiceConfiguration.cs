namespace AutoLot.Services.DataServices;

public static class DataServiceConfiguration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICarDriverRepo, CarDriverRepo>();
        services.AddScoped<ICarRepo, CarRepo>();
        services.AddScoped<ICreditRiskRepo, CreditRiskRepo>();
        services.AddScoped<ICustomerOrderViewModelRepo, CustomerOrderViewModelRepo>();
        services.AddScoped<ICustomerRepo, CustomerRepo>();
        services.AddScoped<IDriverRepo, DriverRepo>();
        services.AddScoped<IMakeRepo, MakeRepo>();
        services.AddScoped<IOrderRepo, OrderRepo>();
        services.AddScoped<IRadioRepo, RadioRepo>();
        return services;
    }
	
    public static IServiceCollection AddDataServices(
        this IServiceCollection services,
        ConfigurationManager config)
    {
        if (config.GetValue<bool>("UseApi"))
        {
            services.AddScoped<ICarDataService, CarApiDataService>();
            services.AddScoped<IMakeDataService, MakeApiDataService>();
        }
        else
        {
            services.AddScoped<ICarDataService, CarDalDataService>();
            services.AddScoped<IMakeDataService, MakeDalDataService>();
        }
        return services;
    }
}