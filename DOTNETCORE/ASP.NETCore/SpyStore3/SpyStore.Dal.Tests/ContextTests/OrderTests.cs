using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Initialization;
using SpyStore.Models.Entities;
using Xunit;

namespace SpyStore.Dal.Tests.ContextTests
{
    [Collection("SpyStore.Dal")]
    public class OrderTests : IDisposable
    {
        private readonly StoreContext _db;

        public OrderTests()
        {
            _db = new StoreContextFactory().CreateDbContext(new string[0]);
            _db.CustomerId = 1;
            //Have to load database with different context, OR call reload on each entity
            SampleDataInitializer.InitializeData(new StoreContextFactory().CreateDbContext(new string[0]));
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        [Fact]
        public void ShouldGetOrderTotal()
        {
            var order = _db.Orders.IgnoreQueryFilters().FirstOrDefault(x => x.Id == 1);
            var orders = _db.Orders.ToList();
            Assert.Single(orders);
            Assert.Equal(4414.90M, orders[0].OrderTotal);
        }

        [Fact]
        public void ShouldGetOrderTotalWithFunction()
        {
            var order = _db.Orders.First(x => StoreContext.GetOrderTotal(x.Id) == 4414.90M);
            Assert.NotNull(order);
            Assert.Equal(4414.90M, order.OrderTotal);
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
            var storeContext = new StoreContextFactory().CreateDbContext(new string[0]);
            storeContext.CustomerId = 1;
            order = storeContext.Orders.First();
            //order = _db.Orders.FirstOrDefault();
            Assert.Equal(4914.90M, order.OrderTotal);
        }
    }
}
