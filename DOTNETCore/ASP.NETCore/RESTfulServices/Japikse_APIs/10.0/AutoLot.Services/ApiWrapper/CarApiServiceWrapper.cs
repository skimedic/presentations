// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - CarApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.ApiWrapper;

public class CarApiServiceWrapper(
    HttpClient client,
    IOptionsMonitor<ApiServiceSettings> apiSettingsMonitor)
    : ApiServiceWrapperBase<Car>(client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.CarBaseUri), 
        ICarApiServiceWrapper
{
    public async Task<IList<Car>> GetCarsByMakeAsync(int id)
    {
        var response = await
            Client.GetAsync($"{ApiSettings.Uri}{ApiSettings.CarBaseUri}/bymake/{id}?v={ApiVersion}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<IList<Car>>();
        return result;
    }
}