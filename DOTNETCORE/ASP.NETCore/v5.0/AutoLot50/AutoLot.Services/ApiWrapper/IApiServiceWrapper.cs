using System.Collections.Generic;
using System.Threading.Tasks;
using AutoLot.Models.Entities;

namespace AutoLot.Services.ApiWrapper
{
    public interface IApiServiceWrapper
    {
        Task<IList<Car>> GetCarsAsync();
        Task<Car> GetCarAsync(int id);
        Task<Car> UpdateCar(int id, Car entity);
        Task<IList<Make>> GetMakesAsync();
    }
}