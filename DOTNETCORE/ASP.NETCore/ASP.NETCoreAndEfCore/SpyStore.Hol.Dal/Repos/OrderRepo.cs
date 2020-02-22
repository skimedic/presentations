using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Repos.Base;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Models.Entities;
using SpyStore.Hol.Models.ViewModels;

namespace SpyStore.Hol.Dal.Repos
{
    public class OrderRepo : RepoBase<Order>,IOrderRepo
    {
        private bool _isDisposed;
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

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            } 
      
            if (disposing) {
                _orderDetailRepo.Dispose();
            }
      
            _isDisposed = true;
            // Call base class implementation.
            base.Dispose(disposing);
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
