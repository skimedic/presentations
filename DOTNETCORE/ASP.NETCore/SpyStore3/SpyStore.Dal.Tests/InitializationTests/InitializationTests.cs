using System.Linq;
using SpyStore.Dal.Initialization;
using SpyStore.Dal.Tests.Base;
using Xunit;

namespace SpyStore.Dal.Tests.InitializationTests
{
  [Collection("SpyStore.Dal")]
  public class InitializationTests : TestBase
  {
    [Fact(Skip = "Destructive Test")]
    public void ShouldDropAndCreateDatabase()
    {
      SampleDataInitializer.DropAndCreateDatabase(Context);
      Assert.Empty(Context.Categories.ToList());
      Assert.Empty(Context.Products.ToList());
    }

    [Fact(Skip = "Destructive Test")]
    public void ShouldLoadCategoriesAndProducts()
    {
      SampleDataInitializer.DropAndCreateDatabase(Context);
      SampleDataInitializer.InitializeData(Context);
      Assert.Equal(7, Context.Categories.Count());
      Assert.Equal(41, Context.Products.Count());
      Assert.Equal(1, Context.Customers.Count());
      Context.CustomerId = Context.Customers.First().Id;
      Assert.Equal(1, Context.Orders.Count());
      Assert.Equal(3, Context.OrderDetails.Count());
      Assert.Equal(1, Context.ShoppingCartRecords.Count());
      SampleDataInitializer.DropAndCreateDatabase(Context);
    }
  }
}