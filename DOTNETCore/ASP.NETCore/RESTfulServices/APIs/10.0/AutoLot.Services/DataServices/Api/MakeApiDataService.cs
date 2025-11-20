// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - MakeApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class MakeApiDataService(
    IAppLogging appLogging, IMakeApiServiceWrapper serviceWrapper)
    : ApiDataServiceBase<Make>(appLogging, serviceWrapper), IMakeDataService;