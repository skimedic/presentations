// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - NamedUsageWithIHttpClientFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Services.DataServices.Api.Examples;

public class NamedUsageWithIHttpClientFactory
{
    public const string API_NAME = "AutoLotApi";
    private readonly IHttpClientFactory _clientFactory;

    public NamedUsageWithIHttpClientFactory(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task DoSomethingAsync()
    {
        var client = _clientFactory.CreateClient(API_NAME);
        //do something interesting with the client
    }
}