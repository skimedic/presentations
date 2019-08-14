using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SpyStore.Dal.EfStructures;
using SpyStore.Dal.Initialization;
using SpyStore.Models.Entities;

namespace SpyStore.Dal.Tests.Base
{
    public class TestBase : IDisposable
    {
        protected StoreContext Context;

        public TestBase()
        {
            ResetContext();
        }
        public virtual void Dispose()
        {
            Context.Dispose();
        }

        protected void ResetContext()
        {
            Context = new StoreContextFactory().CreateDbContext(null);
        }

        protected void CreateCategoryAndProducts()
        {
            CreateCategoryAndProducts(Context);
        }

        protected void CreateCategoryAndProducts(StoreContext context)
        {
            SampleDataInitializer.ClearData(context);
            var prod1 = new Product
            {
                CurrentPrice = 12.99M, UnitCost = 10.99M, UnitsInStock = 5, Details = {ModelName = "Product 1"},
            };
            var prod2 = new Product
            {
                CurrentPrice = 99.99M, UnitCost = 89.99M, UnitsInStock = 2, Details = {ModelName = "Product 2"}
            };
            var cat = new Category {CategoryName = "CatName"};
            cat.Products.AddRange(new List<Product> {prod1,prod2});
            context.Categories.Add(cat);
            context.SaveChanges();
        }

        protected (StoreContext context1, StoreContext context2) GetTwoContextsWithSharedConnection()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            var connectionString =
                @"Server=.,9433;Database=SpyStoreHol30;User ID=sa;Password=P@ssw0rd;MultipleActiveResultSets=true;";
            optionsBuilder.UseSqlServer(new SqlConnection(connectionString),
                    options => options.EnableRetryOnFailure());
            var opt = optionsBuilder.Options;
            return (new StoreContext(opt), new StoreContext(opt));
        }
        protected void ExecuteInATransaction(Action actionToExecute)
        {
            var strategy = Context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using (var trans = Context.Database.BeginTransaction())
                {
                    actionToExecute();
                    trans.Rollback();
                }
            });

        }
    }
}