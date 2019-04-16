using System.Collections.Generic;
using SpyStore_HOL.DAL.Repos.Base;
using SpyStore_HOL.Models.Entities;
using SpyStore_HOL.Models.ViewModels;

namespace SpyStore_HOL.DAL.Repos.Interfaces
{
    public interface IOrderRepo : IRepo<Order>
    {
        IList<Order> GetOrderHistory(int customerId);
        OrderWithDetailsAndProductInfo GetOneWithDetails(int customerId, int orderId);
    }
}