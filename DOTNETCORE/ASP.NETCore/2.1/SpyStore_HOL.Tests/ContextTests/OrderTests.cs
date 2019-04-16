using System;
using System.Linq;
using SpyStore_HOL.DAL.EfStructures;
using SpyStore_HOL.DAL.Initialization;
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
            var storeContextFactory = new StoreContextFactory();
            StoreDataInitializer.InitializeData(storeContextFactory.CreateDbContext(new string[0]));
            _db = storeContextFactory.CreateDbContext(new string[0]);
            
        }

        public void Dispose()
        {
            StoreDataInitializer.ClearData(_db);
            _db.Dispose();
        }

        [Fact]
        public void ShouldGetOrderTotal()
        {
            var orders = _db.Orders.ToList();
            Assert.Single(orders);
            Assert.Equal(4424.90M, orders[0].OrderTotal ?? 0);
        }

        [Fact]
        public void ShouldGetOrderTotalWithFunction()
        {
            var order = _db.Orders.First(x => StoreContext.GetOrderTotal(x.Id) == 4424.90M);
            Assert.NotNull(order);
            Assert.Equal(4424.90M, order.OrderTotal ?? 0);
        }

        [Fact]
        public void ShouldUpdateAnOrder()
        {
            var order = _db.Orders.First();
            order.ShipDate = DateTime.Now;
            _db.SaveChanges();
            order = _db.Orders.First();
            Assert.Equal(DateTime.Now.ToString("d"),order.ShipDate.ToString("d"));
        }


        [Fact]
        public void ShouldGetOrderTotalAfterAddingAnOrderDetail()
        {
            var order = _db.Orders.FirstOrDefault();
            var orderDetail = new OrderDetail() { OrderId = order.Id, ProductId = 2, Quantity = 5, UnitCost = 100M };
            _db.OrderDetails.Add(orderDetail);
            _db.SaveChanges();

            //Need to use a new DbContext to get the updated value
            order = new StoreContextFactory().CreateDbContext(new string[0]).Orders.FirstOrDefault();
            //order = _db.Orders.FirstOrDefault();
            Assert.Equal(4924.90M, order.OrderTotal);
        }
    }
}
