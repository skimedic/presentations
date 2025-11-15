// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - CarApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class CarApiDataService(
    IAppLogging appLogging, ICarApiServiceWrapper serviceWrapper)
    : ApiDataServiceBase<Car>(appLogging, serviceWrapper), ICarDataService
{
    public async Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId)
        => makeId.HasValue
            ? await ((ICarApiServiceWrapper)ServiceWrapper).GetCarsByMakeAsync(makeId.Value)
            : await GetAllAsync();
}