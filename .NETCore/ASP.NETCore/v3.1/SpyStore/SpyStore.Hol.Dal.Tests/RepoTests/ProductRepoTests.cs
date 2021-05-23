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
    public class ProductRepoTests : RepoTestsBase
    {
        private readonly IProductRepo _repo;

        public ProductRepoTests()
        {
            _repo = new ProductRepo(Db);
            LoadDatabase();
        }
        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 5)]
        [InlineData(3, 6)]
        [InlineData(4, 6)]
        [InlineData(5, 3)]
        [InlineData(6, 7)]
        [InlineData(7, 9)]
        public void ShouldGetAllProductsForACategory(int catId, int productCount)
        {
            var prods = _repo.GetProductsForCategory(catId).ToList();
            Assert.Equal(productCount,prods.Count());
        }
    }
}
