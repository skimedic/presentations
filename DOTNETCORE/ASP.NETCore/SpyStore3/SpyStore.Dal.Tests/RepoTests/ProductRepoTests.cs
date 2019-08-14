using System.Linq;
using SpyStore.Dal.Repos;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Dal.Tests.RepoTests.Base;
using Xunit;

namespace SpyStore.Dal.Tests.RepoTests
{
    [Collection("SpyStore.Dal")]
    public class ProductRepoTests : RepoTestsBase
    {
        private readonly IProductRepo _repo;

        public ProductRepoTests()
        {
            _repo = new ProductRepo(Context);
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
