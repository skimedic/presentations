using System;
using System.Collections.Generic;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.Repos.Interfaces
{
    public interface IOrderDetailRepo : IRepo<OrderDetail>
    {
        IEnumerable<OrderDetailWithProductInfo> GetOrderDetailsWithProductInfoForOrder(int orderId);
    }
}