using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore.Dal.Tests.Base;
using Xunit;

namespace SpyStore.Dal.Tests.CrudTests
{
  [Collection("SpyStore.Dal")]
  public class DeleteTests : TestBase
  {
    [Fact]
    public void ShouldDeleteRecords()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        var cat = Context.Categories.First();
        Context.Categories.Remove(cat);
        Assert.Equal(EntityState.Deleted, Context.Entry(cat).State);
        Context.SaveChanges();
        Assert.Equal(EntityState.Detached, Context.Entry(cat).State);
      }
    }

    [Fact]
    public void ShouldThrowConcurrencyException()
    {
      var (context1, context2) = GetTwoContextsWithSharedConnection();
      var strategy = context1.Database.CreateExecutionStrategy();
      strategy.Execute(() =>
      {
        using (var trans = context1.Database.BeginTransaction())
        {
          CreateCategoryAndProducts(context1);
          //Create a new Context Instance to clear the entries
          context2.Database.UseTransaction(trans.GetDbTransaction());
          var cat1 = context1.Categories.First();
          var cat2 = context2.Categories.First();
          cat1.CategoryName = "First In";
          context1.SaveChanges();
          context2.Categories.Remove(cat2);
          var ex = Assert.Throws<DbUpdateConcurrencyException>(() => context2.SaveChanges());
          var entry = ex.Entries[0];
          PropertyValues originalProps = entry.OriginalValues;
          PropertyValues currentProps = entry.CurrentValues;
          //This needs another database call
          PropertyValues databaseProps = entry.GetDatabaseValues();
          trans.Rollback();
        }
      });
    }
  }
}