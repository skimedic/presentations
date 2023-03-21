// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Services - MakeApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/26
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class MakeApiDataService : ApiDataServiceBase<Make, MakeApiDataService>, IMakeDataService
{
    public MakeApiDataService(
        IAppLogging<MakeApiDataService> appLogging, IMakeApiServiceWrapper serviceWrapper)
        : base(appLogging, serviceWrapper)
    {
    }
}