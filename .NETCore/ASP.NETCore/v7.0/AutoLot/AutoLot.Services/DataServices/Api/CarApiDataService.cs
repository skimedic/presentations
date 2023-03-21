// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Services - CarApiDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2022/11/26
// ==================================

namespace AutoLot.Services.DataServices.Api;

public class CarApiDataService : ApiDataServiceBase<Car, CarApiDataService>, ICarDataService
{
    public CarApiDataService(
        IAppLogging<CarApiDataService> appLogging, ICarApiServiceWrapper serviceWrapper)
        : base(appLogging, serviceWrapper)
    {
    }

    public async Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId)
        => makeId.HasValue
            ? await ((ICarApiServiceWrapper)ServiceWrapper).GetCarsByMakeAsync(makeId.Value)
            : await GetAllAsync();
}