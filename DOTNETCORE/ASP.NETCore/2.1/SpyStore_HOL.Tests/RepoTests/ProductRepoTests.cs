using System;
using System.Linq;
using SpyStore_HOL.DAL.Initialization;
using SpyStore_HOL.DAL.Repos;
using Xunit;

namespace SpyStore_HOL.Tests.RepoTests
{
    [Collection("SpyStore.DAL")]
    public class ProductRepoTests : IDisposable
    {
        private readonly ProductRepo _repo;

        public ProductRepoTests()
        {
            _repo = new ProductRepo();
            StoreDataInitializer.InitializeData(_repo.Context);

        }
        public void Dispose()
        {
            StoreDataInitializer.ClearData(_repo.Context);
            _repo.Dispose();
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(1, 5)]
        [InlineData(2, 6)]
        [InlineData(3, 6)]
        [InlineData(4, 3)]
        [InlineData(5, 7)]
        [InlineData(6, 9)]
        public void ShouldGetAllProductsForACategory(int catId, int productCount)
        {
            var prods = _repo.GetProductsForCategory(catId).ToList();
            Assert.Equal(productCount,prods.Count());
        }
    }
}
