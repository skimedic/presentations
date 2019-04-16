using System.Collections.Generic;
using System.Linq;
using SpyStore_HOL.DAL.EfStructures;
using SpyStore_HOL.DAL.Repos.Base;
using SpyStore_HOL.DAL.Repos.Interfaces;
using SpyStore_HOL.Models.Entities;
using SpyStore_HOL.Models.ViewModels;

namespace SpyStore_HOL.DAL.Repos
{
    public class OrderRepo : RepoBase<Order>, IOrderRepo
    {
        private readonly IOrderDetailRepo _orderDetailRepo;
        public OrderRepo(IOrderDetailRepo orderDetailRepo)
        {
            _orderDetailRepo = orderDetailRepo;
        }
        public OrderRepo(StoreContext context, IOrderDetailRepo orderDetailRepo) : base(context)
        {
            _orderDetailRepo = orderDetailRepo;
        }
        public IList<Order> GetOrderHistory(int customerId)
            => Table.Where(x => x.CustomerId == customerId).ToList();
        public OrderWithDetailsAndProductInfo GetOneWithDetails(int customerId, int orderId)
            => Table
                .Where(x => x.CustomerId == customerId && x.Id == orderId)
                .Select(x => new OrderWithDetailsAndProductInfo
                {
                    Id = x.Id,
                    CustomerId = customerId,
                    OrderDate = x.OrderDate,
                    OrderTotal = x.OrderTotal,
                    ShipDate = x.ShipDate,
                    OrderDetails = _orderDetailRepo.GetSingleOrderWithDetails(orderId).ToList()
                })
                .FirstOrDefault();
    }
}