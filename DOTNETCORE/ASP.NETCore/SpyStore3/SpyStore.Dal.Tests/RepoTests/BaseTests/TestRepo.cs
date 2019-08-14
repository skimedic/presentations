using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Repos.Base;
using SpyStore.Models.Entities;

namespace SpyStore.Dal.Tests.RepoTests.BaseTests
{
  public class TestRepo : RepoBase<Category>, IRepo<Category>
  {
    public TestRepo(StoreContext context) : base(context)
    {
    }

    public TestRepo(DbContextOptions<StoreContext> options) : base(options)
    {
    }
  }
}