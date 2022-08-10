// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - MakeApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/08/09
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class MakeApiDataService : ApiDataServiceBase<Make,MakeApiDataService>, IMakeDataService
{
    public MakeApiDataService(IAppLogging<MakeApiDataService> appLogging, IMakeApiServiceWrapper serviceWrapper) : base(appLogging, serviceWrapper)
    {
    }
}