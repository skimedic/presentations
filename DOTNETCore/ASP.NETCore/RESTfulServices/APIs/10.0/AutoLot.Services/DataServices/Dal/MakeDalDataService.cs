// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - MakeDalDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.DataServices.Dal;

public class MakeDalDataService(IAppLogging appLogging, IMakeRepo repo)
    : DalDataServiceBase<Make>(appLogging, repo), IMakeDataService;