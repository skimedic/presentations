namespace AutoLot.Services.ApiWrapper;

public class MakeApiServiceWrapper : ApiServiceWrapperBase<Make>, IMakeApiServiceWrapper
{
    public MakeApiServiceWrapper(HttpClient client, IOptionsMonitor<ApiServiceSettings> apiSettingsMonitor) 
        : base(client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.MakeBaseUri)
    {
    }
}