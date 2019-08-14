using System;
using System.Linq;
using SpyStore.Dal.Initialization;
using SpyStore.Dal.Repos;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Dal.Tests.RepoTests.Base;
using SpyStore.Models.Entities;
using Xunit;

namespace SpyStore.Dal.Tests.RepoTests
{
    [Collection("SpyStore.Dal")]
    public class OrderRepoTests : RepoTestsBase
    {
        private readonly IOrderRepo _repo;

        public OrderRepoTests()
        {
            _repo = new OrderRepo(Context,new OrderDetailRepo(Context));
            Context.CustomerId = 1;
            LoadDatabase();
        }
        public override void Dispose()
        {
            _repo.Dispose();
            base.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrders()
        {
            var orders = _repo.GetAll().ToList();
            Assert.Single(orders);
        }

        [Fact]
        public void ShouldGetOrderWithDetails()
        {
          ExecuteInATransaction(RunTheTest);
          void RunTheTest()
          {
            ResetContext();
            SampleDataInitializer.ClearData(Context);
            CreateCategoryAndProducts();
            var cust = new Customer()
            {
              EmailAddress = "foo@bar.com",
              FullName = "Ful Name",
              Password = "password"
            };
            var order = new Order
            {
              OrderDate = DateTime.Now,
              ShipDate = DateTime.Now
            };
            var product = Context.Products.FirstOrDefault();
            var orderDetail = new OrderDetail
            {
              ProductNavigation = product,
              UnitCost = 12.99M,
              Quantity = 1
            };
            order.OrderDetails.Add(orderDetail);
            cust.Orders.Add(order);
            ICustomerRepo custRepo = new CustomerRepo(Context);
            custRepo.Add(cust);
            Context.CustomerId = cust.Id;
            Assert.NotNull(Context.Customers.FirstOrDefault());
            Assert.NotNull(Context.Orders.FirstOrDefault());
            Assert.NotNull(Context.OrderDetails.FirstOrDefault());

            var orderRepo = new OrderRepo(Context, new OrderDetailRepo(Context));
            var record = orderRepo.GetOneWithDetails(1);
            var foo = "foo";
          }
        }

    }
}
