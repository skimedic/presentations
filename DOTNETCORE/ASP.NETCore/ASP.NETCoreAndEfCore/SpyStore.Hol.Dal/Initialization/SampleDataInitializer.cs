using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SpyStore.Hol.Dal.EfStructures;
using SpyStore.Hol.Models.Entities;

namespace SpyStore.Hol.Dal.Initialization
{
    public static class SampleDataInitializer
    {
        public static void DropAndCreateDatabase(StoreContext context)
        {
            context.Database.EnsureDeleted();
            //This doesn't run the migrations, so SQL objects will be missing
            //DON'T USE THIS => context.Database.EnsureCreated();
            context.Database.Migrate();
        }

        internal static void ResetIdentity(StoreContext context)
        {
            var tables = new[]
            {
                "Categories", "Customers",
                "OrderDetails", "Orders", "Products", "ShoppingCartRecords"
            };
            foreach (var itm in tables)
            {
                var rawSqlString = $"DBCC CHECKIDENT (\"Store.{itm}\", RESEED, 0);";
                context.Database.ExecuteSqlRaw(rawSqlString);
            }
        }

        public static void ClearData(StoreContext context)
        {
            context.Database.Migrate();
            context.Database.ExecuteSqlRaw("Delete from Store.Categories");
            context.Database.ExecuteSqlRaw("Delete from Store.Customers");
            ResetIdentity(context);
        }


        internal static void SeedData(StoreContext context)
        {
            try
            {
                var cust = new Customer()
                {
                    Id = 1,
                    EmailAddress = "spy@secrets.com",
                    Password = "Foo",
                    FullName = "Super Spy",
                };
                if (!context.Customers.Any())
                {
                    IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
                    strategy.Execute(() =>
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Store.Customers', RESEED, 0);");
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.Customers" + " ON");
                            context.Customers.Add(cust);
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.Customers" + " OFF");
                            transaction.Commit();
                        }
                    });
                }

                if (!context.Categories.Any())
                {
                    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Store.Categories', RESEED, 0);");
                    IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
                    strategy.Execute(() =>
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.Categories" + " ON");
                            context.Categories.AddRange(SampleData.GetCategories());
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.Categories" + " OFF");
                            transaction.Commit();
                        }
                    });
                }

                if (!context.Products.Any())
                {
                    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Store.Products', RESEED, 0);");
                    IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
                    strategy.Execute(() =>
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.Products" + " ON");
                            context.Products.AddRange(SampleData.GetProducts());
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.Products" + " OFF");
                            transaction.Commit();
                        }
                    });
                }

                if (!context.Orders.Any())
                {
                    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Store.Orders', RESEED, 0);");
                    IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
                    strategy.Execute(() =>
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.Orders" + " ON");
                            context.Orders.AddRange(SampleData.GetOrders());
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.Orders" + " OFF");
                            transaction.Commit();
                        }
                    });
                }

                if (!context.OrderDetails.Any())
                {
                    var products = new List<Product>
                    {
                        context.Categories
                            .Include(c => c.Products).FirstOrDefault()?
                            .Products.Skip(3).FirstOrDefault(),
                        context.Categories.Skip(2)
                            .Include(c => c.Products).FirstOrDefault()?
                            .Products.Skip(2).FirstOrDefault(),
                        context.Categories.Skip(5)
                            .Include(c => c.Products).FirstOrDefault()?
                            .Products.Skip(1).FirstOrDefault(),
                    };
                    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Store.OrderDetails', RESEED, 0);");
                    IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
                    strategy.Execute(() =>
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.OrderDetails" + " ON");
                            context.OrderDetails.AddRange(SampleData.GetOrderDetails(products));
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.OrderDetails" + " OFF");
                            transaction.Commit();
                        }
                    });
                }

                if (!context.ShoppingCartRecords.Any())
                {
                    var products = new List<Product>
                    {
                        context.Categories.Skip(2)
                            .Include(c => c.Products).FirstOrDefault()?
                            .Products.Skip(1).FirstOrDefault()
                    };
                    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Store.ShoppingCartRecords', RESEED, 0);");
                    IExecutionStrategy strategy = context.Database.CreateExecutionStrategy();
                    strategy.Execute(() =>
                    {
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.ShoppingCartRecords" + " ON");
                            context.ShoppingCartRecords.AddRange(SampleData.GetCart(products));
                            context.SaveChanges();
                            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Store.ShoppingCartRecords" + " OFF");
                            transaction.Commit();
                        }
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public static void InitializeData(StoreContext context)
        {
            //Ensure the database exists and is up to date
            //context.Database.EnsureDeleted();
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }
    }
}