namespace AutoLot.Services.DataServices.Dal;

public class MakeDalDataService : DalDataServiceBase<Make,MakeDalDataService>,IMakeDataService
{

    public MakeDalDataService(IAppLogging<MakeDalDataService> appLogging, IMakeRepo repo):base(appLogging, repo)
    {
    }
}