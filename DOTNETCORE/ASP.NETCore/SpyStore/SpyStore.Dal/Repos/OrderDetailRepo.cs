using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Repos.Base;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Models.Entities;
using SpyStore.Models.ViewModels;

namespace SpyStore.Dal.Repos
{
    public class OrderDetailRepo : RepoBase<OrderDetail>, IOrderDetailRepo
    {
        public OrderDetailRepo(StoreContext context) : base(context)
        {
        }

        internal OrderDetailRepo(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public IEnumerable<OrderDetailWithProductInfo> GetOrderDetailsWithProductInfoForOrder(int orderId)
            => Context
                .OrderDetailWithProductInfos
                .Where(x => x.OrderId == orderId)
                .OrderBy(x => x.ModelName);
    }
}
