using System;
using System.Linq;
using SpyStore_HOL.DAL.Initialization;
using SpyStore_HOL.DAL.Repos;
using Xunit;

namespace SpyStore_HOL.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class OrderDetailRepoTests : IDisposable
    {
        private readonly OrderDetailRepo _repo;

        public OrderDetailRepoTests()
        {
            _repo = new OrderDetailRepo();
            StoreDataInitializer.InitializeData(_repo.Context);

        }
        public void Dispose()
        {
            StoreDataInitializer.ClearData(_repo.Context);
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrderDetails()
        {
            var orders = _repo.GetAll().ToList();
            Assert.Equal(_repo.Count,orders.Count());
        }

        [Fact]
        public void ShouldGetLineItemTotal()
        {
            var orderDetails = _repo.GetAll().ToList();
            var orderDetail = orderDetails[0];
            Assert.Equal(1799.9700M, orderDetail.LineItemTotal);
        }

    }
}
