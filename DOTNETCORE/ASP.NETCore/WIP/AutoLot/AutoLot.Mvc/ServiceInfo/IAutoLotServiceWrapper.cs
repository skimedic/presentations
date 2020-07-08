using System.Collections.Generic;
using System.Threading.Tasks;
using AutoLot.Dal.Models.Entities;
using AutoLot.Dal.Models.Entities.Base;

namespace AutoLot.Mvc.ServiceInfo
{
    public interface IAutoLotServiceWrapper
    {
        Task<List<Car>> GetCarsByMakeAsync(int makeId);
        Task<List<T>> GetAllAsync<T>() where T : BaseEntity, new();
        Task<T> GetOneAsync<T>(int id) where T : BaseEntity, new();
        Task<T> UpdateOneAsync<T>(T entity) where T : BaseEntity, new();
        Task<T> AddOneAsync<T>(T entity) where T : BaseEntity, new();
        Task DeleteOneAsync<T>(T entity) where T : BaseEntity, new();
    }
}