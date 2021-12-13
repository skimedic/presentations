namespace AutoLot.Services.ApiWrapper;

public class CarApiServiceWrapper : ApiServiceWrapperBase<Car>, ICarApiServiceWrapper
{
    public CarApiServiceWrapper(HttpClient client, IOptionsMonitor<ApiServiceSettings> apiSettingsMonitor) 
        : base(client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.CarBaseUri)
    {
    }

    public async Task<IList<Car>> GetCarsByMakeAsync(int id)
    {
        var response = await Client.GetAsync($"{ApiSettings.Uri}{ApiSettings.CarBaseUri}/bymake/{id}?v={ApiVersion}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<IList<Car>>();
        return result;
    }
}