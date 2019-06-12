using System;
using System.Linq;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Dal.Initialization;
using SpyStore.Hol.Dal.Repos;
using SpyStore.Hol.Dal.Repos.Interfaces;
using SpyStore.Hol.Dal.Tests.RepoTests.Base;
using Xunit;

namespace SpyStore.Hol.Dal.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class OrderDetailRepoTests : RepoTestsBase
    {
        private readonly IOrderDetailRepo _repo;

        public OrderDetailRepoTests()
        {
            _repo = new OrderDetailRepo(Db);
            Db.CustomerId = 1;
            LoadDatabase();
        }
        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrderDetails()
        {
            var orders = _repo.GetAll().ToList();
            Assert.Equal(_repo.Table.Count(),orders.Count());
        }

        [Fact]
        public void ShouldGetLineItemTotal()
        {
            var orderDetails = _repo.GetOrderDetailsWithProductInfoForOrder(1).ToList();
            var orderDetail = orderDetails[0];
            Assert.Equal(1799.9700M, orderDetail.LineItemTotal);
        }

    }
}
