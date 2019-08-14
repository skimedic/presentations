using SpyStore.Dal.Repos;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Dal.Tests.RepoTests.Base;
using SpyStore.Models.Entities;
using Xunit;

namespace SpyStore.Dal.Tests.RepoTests
{
    [Collection("SpyStore.Dal")]
    public class CategoryRepoGetTests : RepoTestsBase
    {
        private readonly ICategoryRepo _repo;

        public CategoryRepoGetTests()
        {
            _repo = new CategoryRepo(Context);
        }
        public override void Dispose()
        {
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetACategoryWithProductInfo()
        {
            var category = new Category { CategoryName = "Foo" };
            _repo.Add(category, true);
            //var cat = _repo.GetOneWithProducts(2);
            //Assert.Equal(2, cat.Products.Count());
        }

        [Fact]
        public void ShouldGetCategory()
        {
            var category = new Category { CategoryName = "Foo" };
            _repo.Add(category);
            _repo.Find(category.Id);
        }
    }

}
