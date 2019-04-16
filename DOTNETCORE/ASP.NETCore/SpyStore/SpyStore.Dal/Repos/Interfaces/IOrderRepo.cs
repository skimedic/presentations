using System.Collections.Generic;
using SpyStore.Dal.Repos.Base;
using SpyStore.Models.Entities;
using SpyStore.Models.ViewModels;

namespace SpyStore.Dal.Repos.Interfaces
{
    public interface IOrderRepo : IRepo<Order>
    {
        IList<Order> GetOrderHistory();
        OrderWithDetailsAndProductInfo GetOneWithDetails(int orderId);
    }
}