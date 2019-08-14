using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.Initialization;
using SpyStore.Dal.Tests.Base;
using SpyStore.Models.Entities;

namespace SpyStore.Dal.Tests.CrudTests
{
  [Collection("SpyStore.Dal")]
  public class CreationTests : TestBase
  {
    [Fact]
    public void ShouldAddNewCategoryRecord()
    {
      var cat = new Category {CategoryName = "CatName"};
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        SampleDataInitializer.ClearData(Context);
        Context.Categories.Add(cat);
        Context.SaveChanges();
        Assert.Single(Context.Categories.ToList());
      }
    }

    [Fact]
    public void ShouldAddListOfNewCategoryRecords()
    {
      var cats = new List<Category>
      {
        new Category {CategoryName = "Cat1Name"},
        new Category {CategoryName = "Cat2Name"},
        new Category {CategoryName = "Cat3Name"},
      };
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        SampleDataInitializer.ClearData(Context);
        Context.Categories.AddRange(cats);
        Context.SaveChanges();
        Assert.Equal(3, Context.Categories.Count());
      }
    }

    [Fact]
    public void ShouldSetServerSideProperties()
    {
      var cat = new Category {CategoryName = "CatName"};
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        SampleDataInitializer.ClearData(Context);
        Assert.Equal(0, cat.Id);
        Assert.Null(cat.TimeStamp);
        Context.Categories.Add(cat);
        Assert.True(cat.Id == 0);
        Assert.Null(cat.TimeStamp);
        Context.SaveChanges();
        Assert.Single(Context.Categories.ToList());
        Assert.True(cat.Id > 0);
        Assert.NotNull(cat.TimeStamp);
      }
    }

    [Fact]
    public void ShouldAddAnObjectGraph()
    {
      var prod = new Product
      {
        CurrentPrice = 12.99M,
        UnitCost = 10.99M,
        UnitsInStock = 5,
      };
      var cat = new Category {CategoryName = "CatName"};
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        SampleDataInitializer.ClearData(Context);
        cat.Products.Add(prod);
        Assert.Equal(0, cat.Id);
        Assert.Equal(0, prod.CategoryId);
        Assert.Equal(0, prod.Id);
        Context.Categories.Add(cat);
        Assert.True(cat.Id == 0);
        Assert.True(prod.CategoryId == 0);
        Assert.Equal(cat.Id, prod.CategoryId);
        Context.SaveChanges();
        Assert.Single(Context.Categories);
        Assert.Single(Context.Products);
        Assert.True(cat.Id > 0);
        Assert.True(prod.Id > 0);
        Assert.Equal(cat.Id, prod.CategoryId);
      }
    }

    [Fact]
    public void ShouldSetEntityState()
    {
      var cat1 = new Category {CategoryName = "Cat1Name"};
      var cat2 = new Category {Id = 500, CategoryName = "Cat2Name"};
      ExecuteInATransaction(RunTheTest);

      void RunTheTest()
      {
        Assert.Equal(EntityState.Detached, Context.Entry(cat1).State);
        Assert.Equal(EntityState.Detached, Context.Entry(cat2).State);
        Context.Categories.Add(cat1);
        Context.Categories.Add(cat2);
        Assert.Equal(EntityState.Added, Context.Entry(cat1).State);
        Assert.Equal(EntityState.Added, Context.Entry(cat2).State);
        //Must remove cat2 since ID is an identity column
        Context.Categories.Remove(cat2);
        Context.SaveChanges();
        Assert.Equal(EntityState.Unchanged, Context.Entry(cat1).State);
      }
    }
  }
}