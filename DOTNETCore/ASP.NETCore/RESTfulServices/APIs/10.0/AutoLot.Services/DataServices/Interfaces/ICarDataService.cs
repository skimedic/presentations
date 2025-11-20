// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - ICarDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.DataServices.Interfaces;

public interface ICarDataService : IDataServiceBase<Car>
{
    Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId);
}