using System;
using System.Collections.Generic;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.Repos.Interfaces
{
    public interface IOrderRepo : IRepo<Order>
    {
        IList<Order> GetOrderHistory();
        OrderWithDetailsAndProductInfo GetOneWithDetails(int orderId);
    }
}