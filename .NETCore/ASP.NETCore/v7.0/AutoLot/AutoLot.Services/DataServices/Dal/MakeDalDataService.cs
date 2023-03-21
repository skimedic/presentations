// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Services - MakeDalDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/25
// ==================================

namespace AutoLot.Services.DataServices.Dal;

public class MakeDalDataService : DalDataServiceBase<Make,MakeDalDataService>,IMakeDataService
{
    public MakeDalDataService(
        IAppLogging<MakeDalDataService> appLogging, IMakeRepo repo):base(appLogging, repo) { }
}