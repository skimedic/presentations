using System;
using System.Linq;
using SpyStore_HOL.DAL.EF;
using SpyStore_HOL.DAL.EF.Initialization;
using SpyStore_HOL.Models.Entities;
using Xunit;

namespace SpyStore_HOL.Tests.ContextTests
{
    [Collection("SpyStore.DAL")]
    public class OrderTests : IDisposable
    {
        private readonly StoreContext _db;

        public OrderTests()
        {
            _db = new StoreContext();
            StoreDataInitializer.InitializeData(new StoreContext());
        }

        public void Dispose()
        {
            //StoreDataInitializer.ClearData(new StoreContext());
            _db.Dispose();
        }

        [Fact]
        public void ShouldGetOrderTotal()
        {
            var orders = _db.Orders.ToList();
            Assert.Equal(4424.90M, orders[0].OrderTotal.Value);
        }

        [Fact]
        public void ShouldUpdateAnOrder()
        {
            var order = _db.Orders.FirstOrDefault();
            order.ShipDate = DateTime.Now;
            _db.SaveChanges();
            order = _db.Orders.FirstOrDefault();
            Assert.Equal(DateTime.Now.ToString("d"),
                order.ShipDate.ToString("d"));
        }


        [Fact]
        public void ShouldGetOrderTotalAfterAddingAnOrderDetail()
        {
            var order = _db.Orders.FirstOrDefault();
            var orderDetail = new OrderDetail() { OrderId = order.Id, ProductId = 2, Quantity = 5, UnitCost = 100M };
            _db.OrderDetails.Add(orderDetail);
            _db.SaveChanges();

            //Need to use a new DbContext to get the updated value
            order = new StoreContext().Orders.FirstOrDefault();
            //order = _db.Orders.FirstOrDefault();
            Assert.Equal(4924.90M, order.OrderTotal);
        }
    }
}
