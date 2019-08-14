using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Tests.Base;
using SpyStore.Models.Entities.Base;
using Xunit;

namespace SpyStore.Dal.Tests.CrudTests
{
  [Collection("SpyStore.Dal")]
  public class ReadTests : TestBase
  {
    [Fact]
    public void ShouldConnectRelatedInstances()
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
          //Load products
          var products = context2.Products.ToList();
          var cat = context2.Categories.FirstOrDefault();
          Assert.Equal(2, cat.Products.Count);
          trans.Rollback();
        }
      });
    }

    [Fact]
    public void ShouldGetAllRecords()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        //No execution yet
        var products = Context.Products;
        //Execution happens
        var productList = products.ToList();
        //All functions are now LINQ to objects
        var count = productList.Count();
        Assert.Equal(2, count);
      }
    }

    [Fact]
    public void ShouldFilterAndSort()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        //No execution yet
        var query = Context.Products.Where(x => x.CurrentPrice > 10);
        //Add another where clause
        query = query.Where(x => x.CurrentPrice < 1000);
        //Add two order by clauses
        query = query
          .OrderBy(x => x.CurrentPrice)
          .ThenByDescending(x => x.Details.ModelName);
        //Execution happens
        var productList = query.ToList();
        //All functions are now LINQ to objects
        Assert.True(productList[0].CurrentPrice < productList[1].CurrentPrice);
        Assert.True(String.Compare(productList[0].Details.ModelName, productList[1].Details.ModelName,
                      StringComparison.OrdinalIgnoreCase) < 0);
      }
    }

    [Fact]
    public void ShouldFilterWithMappedFunction()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        //CreateCategoryAndProducts();
        //Execution happens
        Context.CustomerId = 1;
        var cats = Context.Orders
          .Where(x => x.OrderTotal > StoreContext.GetOrderTotal(4))
          .ToList();
      }
    }

    [Fact]
    public void ShouldEagerlyLoadRelatedData()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        //Execution happens
        var cats = Context.Categories
          .Include(x => x.Products)
          .ThenInclude(x => x.ShoppingCartRecords)
          .ToList();
        Assert.Equal(2, cats[0].Products.Count);
      }
    }

    [Fact]
    public void ShouldExplicitlyLoadRelatedCollectionData()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        //Get a Category instance
        var cat = Context.Categories.ToList()[0];
        //Get the related Products
        Context.Entry(cat).Collection(c => c.Products).Load();
        Assert.Equal(2, cat.Products.Count);
      }
    }

    [Fact]
    public void ShouldExplicitlyLoadRelatedParentData()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        //Get a Product instance
        var prod = Context.Products.ToList()[0];
        //Get the related Category
        Context.Entry(prod).Reference(c => c.CategoryNavigation).Load();
        Assert.NotNull(prod.CategoryNavigation);
      }
    }

    [Fact]
    public void ShouldTurnOffQueryFilters()
    {
      //Set the value used by the query filter
      Context.CustomerId = 1;
      //Get the order where CustomerId = 1
      var ordersWithFilter = Context.Orders.ToList();
      //Get all Orders records
      var ordersNoFilter = Context.Orders.IgnoreQueryFilters().ToList();
    }

    [Fact]
    public void ShouldNotTrackEntities()
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
          //Load products with tracking
          var products = context2.Products.ToList();
          //The two products are tracked
          Assert.Equal(2, context2.ChangeTracker.Entries<EntityBase>().Count());
          //Load the category without tracking
          var cat = context2.Categories.AsNoTracking().FirstOrDefault();
          //Still just the two products are tracked
          Assert.Equal(2, context2.ChangeTracker.Entries<EntityBase>().Count());
          trans.Rollback();
        }
      });
    }

    [Fact]
    public void ShouldNotTrackAnyEntitiesForContext()
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
          context2.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
          //Load products with no tracking
          var products = context2.Products.ToList();
          //The two products are not tracked
          Assert.Empty(context2.ChangeTracker.Entries<EntityBase>());
          trans.Rollback();
        }
      });
    }

    [Fact]
    public void ShouldGetDataWithFromSql()
    {
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        CreateCategoryAndProducts();
        //var products = Context.Products
        //    .FromSql("Select * from Store.Products")
        //    .OrderBy(x => x.Details.ModelName)
        //    .ToList();
        //var details = Context.OrderDetailWithProductInfos
        //    .FromSql("SELECT * FROM Store.OrderDetailWithProductInfo")
        //    .OrderBy(x => x.ModelName)
        //    .ToList();
        //Get related data
        var categories = Context.Categories
          .FromSqlRaw("Select * from Store.Categories")
          .Include(x => x.Products)
          //.OrderBy(x => x.Products)
          .ToList();
      }
    }
  }
}