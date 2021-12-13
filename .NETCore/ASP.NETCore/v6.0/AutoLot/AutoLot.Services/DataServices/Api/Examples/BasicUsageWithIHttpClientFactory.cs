namespace AutoLot.Services.DataServices.Api.Examples;

public class BasicUsageWithIHttpClientFactory
{
    private readonly IHttpClientFactory _clientFactory;

    public BasicUsageWithIHttpClientFactory(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task DoSomethingAsync()
    {
        var client = _clientFactory.CreateClient();
        //do something interesting with the client
    }
}