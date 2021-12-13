namespace AutoLot.Services.DataServices.Api;

public class MakeApiDataService : ApiDataServiceBase<Make,MakeApiDataService>, IMakeDataService
{
    public MakeApiDataService(IAppLogging<MakeApiDataService> appLogging, IMakeApiServiceWrapper serviceWrapper) : base(appLogging, serviceWrapper)
    {
    }
}