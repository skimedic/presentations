using System;
using System.Linq;
using SpyStore_HOL.DAL.EF.Initialization;
using SpyStore_HOL.DAL.Repos;
using Xunit;

namespace SpyStore_HOL.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class OrderRepoTests : IDisposable
    {
        private readonly OrderRepo _repo;

        public OrderRepoTests()
        {
            _repo = new OrderRepo(new OrderDetailRepo());
            StoreDataInitializer.ClearData(_repo.Context);
            StoreDataInitializer.InitializeData(_repo.Context);

        }
        public void Dispose()
        {
            StoreDataInitializer.ClearData(_repo.Context);
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetAllOrders()
        {
            var orders = _repo.GetAll().ToList();
            Assert.Equal(1,orders.Count());
        }
    }
}
