// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - CarDalDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.DataServices.Dal;

public class CarDalDataService(IAppLogging appLogging, ICarRepo repo)
  : DalDataServiceBase<Car>(appLogging, repo), ICarDataService
{
  public Task<IEnumerable<Car>> GetAllByMakeIdAsync(int? makeId) 
    =>  Task.FromResult(makeId.HasValue
    ? repo.GetAllBy(makeId.Value) 
                        : MainRepo.GetAllIgnoreQueryFilters());
}