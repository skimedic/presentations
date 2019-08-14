using SpyStore.Dal.Initialization;
using SpyStore.Dal.Repos;
using SpyStore.Dal.Repos.Interfaces;
using SpyStore.Dal.Tests.Base;
using Xunit;

namespace SpyStore.Dal.Tests.RepoTests
{
    [Collection("SpyStore.Dal")]
    public class CategoryRepoTests : TestBase
    {
        private readonly ICategoryRepo _repo;

        public CategoryRepoTests()
        {
            _repo = new CategoryRepo(Context);
            SampleDataInitializer.ClearData(Context);
        }
        public override void Dispose()
        {
            SampleDataInitializer.ClearData(Context);
            _repo.Dispose();
        }

        [Fact]
        public void ShouldGetTableAndSchemaName()
        {
            var (schema, tableName) = _repo.TableSchemaAndName;
            Assert.Equal("Store",schema);
            Assert.Equal("Categories",tableName);
        }
    }
}