using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore.Dal.Tests.Base;
using SpyStore.Models.Entities;
using Xunit;

namespace SpyStore.Dal.Tests.RepoTests.BaseTests
{
  [Collection("SpyStore.Dal")]
  public class RepoBaseTests : TestBase
  {
    public RepoBaseTests()
    {
      //SampleDataInitializer.ClearData(Context);
    }

    [Fact]
    public void ShouldBeDirtyWhenRecordsAdded()
    {
      var cat = new Category {CategoryName = "Foo"};
      var repo = new TestRepo(Context);
      repo.Add(cat, false);
      Assert.True(repo.HasChanges);
    }

    [Fact]
    public void ShouldBeDirtyWhenRecordsDeleted()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        var repo = new TestRepo(Context);
        var cat = repo.Find(1);
        repo.Delete(cat, false);
        Assert.True(repo.HasChanges);
      }
    }

    [Fact]
    public void ShouldBeDirtyWhenRecordsUpdated()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        var repo = new TestRepo(Context);
        var cat = Context.Categories.First();
        cat.CategoryName = "Bar";
        Assert.True(repo.HasChanges);
      }
    }
  }
}