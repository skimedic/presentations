// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - TypedUsageWithIHttpClientFactory.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Services.DataServices.Api.Examples;

public interface IApiServiceWrapperExample
{
    //interesting methods places here
}

public class ApiServiceWrapperExample : IApiServiceWrapperExample
{
    protected readonly HttpClient Client;
    public ApiServiceWrapperExample(HttpClient client)
    {
        Client = client;
        //common client configuration goes here
    }
    //interesting methods implemented here
}

public class TypedUsageWithIHttpClientFactory
{
    private readonly IApiServiceWrapperExample _serviceWrapper;

    public TypedUsageWithIHttpClientFactory(IApiServiceWrapperExample serviceWrapper)
    {
        _serviceWrapper = serviceWrapper;
    }
    public async Task DoSomethingAsync()
    {
        //do something interesting with the service wrapper
    }
}

