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
    public class OrderRepo : RepoBase<Order>,IOrderRepo
    {
        private readonly IOrderDetailRepo _orderDetailRepo;

        public OrderRepo(
            StoreContext context, 
            IOrderDetailRepo orderDetailRepo) : base(context)
        {
            _orderDetailRepo = orderDetailRepo;
        }

        internal OrderRepo(DbContextOptions<StoreContext> options) : base(options)
        {
            _orderDetailRepo = new OrderDetailRepo(Context);
        }

        public override void Dispose()
        {
            _orderDetailRepo.Dispose();
            base.Dispose();
        }

        public IList<Order> GetOrderHistory() => 
            GetAll(x => x.OrderDate).ToList();

        public OrderWithDetailsAndProductInfo GetOneWithDetails(int orderId)
        {
            var order = Table.IgnoreQueryFilters().Include(x=>x.CustomerNavigation)
                .FirstOrDefault(x => x.Id == orderId);
            if (order == null)
            {
                return null;
            }
            var orderDetailsWithProductInfoForOrder = _orderDetailRepo.GetOrderDetailsWithProductInfoForOrder(order.Id);
            var orderWithDetailsAndProductInfo = OrderWithDetailsAndProductInfo.Create(order,order.CustomerNavigation, orderDetailsWithProductInfoForOrder);
            return orderWithDetailsAndProductInfo;
        }
    }
}
