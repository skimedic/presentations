using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore.Dal.Tests.Base;
using SpyStore.Models.Entities;
using Xunit;

namespace SpyStore.Dal.Tests.CrudTests
{
  [Collection("SpyStore.Dal")]
  public class UpdateTests : TestBase
  {
    [Fact]
    public void ShouldUpdateARecord()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        var cat = Context.Categories.First();
        Assert.NotNull(cat);
        Assert.Equal(EntityState.Unchanged, Context.Entry(cat).State);
        cat.CategoryName = "Changed";
        Assert.Equal(EntityState.Modified, Context.Entry(cat).State);
        Context.SaveChanges();
        Assert.Equal(EntityState.Unchanged, Context.Entry(cat).State);
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
          cat2.CategoryName = "Last in";
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

    [Fact]
    public void ShouldSetEntityStateForAnObjectGraph()
    {
      var prod1 = new Product
      {
        CurrentPrice = 12.99M,
        UnitCost = 10.99M,
        UnitsInStock = 5,
      };
      var prod2 = new Product
      {
        Id = 500,
        CurrentPrice = 12.99M,
        UnitCost = 10.99M,
        UnitsInStock = 5,
      };
      var cat = new Category {CategoryName = "Cat1Name"};
      cat.Products.AddRange(new List<Product> {prod1, prod2});
      var strategy = Context.Database.CreateExecutionStrategy();
      strategy.Execute(() =>
      {
        using (var trans = Context.Database.BeginTransaction())
        {
          Assert.Equal(EntityState.Detached, Context.Entry(cat).State);
          Assert.Equal(EntityState.Detached, Context.Entry(prod1).State);
          Assert.Equal(EntityState.Detached, Context.Entry(prod2).State);
          Context.Categories.Attach(cat);
          Assert.Equal(EntityState.Added, Context.Entry(cat).State);
          Assert.Equal(EntityState.Added, Context.Entry(prod1).State);
          Assert.Equal(EntityState.Unchanged, Context.Entry(prod2).State);
          //Context.SaveChanges();
          //Assert.Equal(EntityState.Unchanged, Context.Entry(cat).State);
          trans.Rollback();
        }
      });
    }
  }
}