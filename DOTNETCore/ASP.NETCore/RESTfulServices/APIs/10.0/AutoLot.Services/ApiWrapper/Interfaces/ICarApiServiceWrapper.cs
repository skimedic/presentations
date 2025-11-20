// Copyright Information
// ==================================
// AutoLot - AutoLot.Services - ICarApiServiceWrapper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/13
// ==================================

namespace AutoLot.Services.ApiWrapper.Interfaces;

public interface ICarApiServiceWrapper : IApiServiceWrapperBase<Car>
{
    Task<IList<Car>> GetCarsByMakeAsync(int id);
}