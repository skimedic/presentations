// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - MakeApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Services.ApiWrapper;

public class MakeApiServiceWrapper : ApiServiceWrapperBase<Make>, IMakeApiServiceWrapper
{
    public MakeApiServiceWrapper(HttpClient client, IOptionsMonitor<ApiServiceSettings> apiSettingsMonitor) 
        : base(client, apiSettingsMonitor, apiSettingsMonitor.CurrentValue.MakeBaseUri)
    {
    }
}