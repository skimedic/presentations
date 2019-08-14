using System;
using SpyStore.Dal.Initialization;
using SpyStore.Dal.Tests.Base;

namespace SpyStore.Dal.Tests.RepoTests.Base
{
  public class RepoTestsBase : TestBase
  {
    public RepoTestsBase()
    {
      CleanDatabase();
    }

    public override void Dispose()
    {
      CleanDatabase();
      base.Dispose();
    }

    protected void CleanDatabase()
    {
      SampleDataInitializer.ClearData(Context);
    }

    protected void LoadDatabase()
    {
      SampleDataInitializer.InitializeData(Context);
    }

    //protected IList<Product> CreateProducts()
    //{
    //    var prods = new List<Product>
    //    {
    //        new Product() {CurrentPrice = 12.99M, ModelName = "Product 1", ModelNumber = "P1"},
    //        new Product() {CurrentPrice = 9.99M, ModelName = "Product 2", ModelNumber = "P2"},
    //    };
    //    return prods;
    //}
  }
}