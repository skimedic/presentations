using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SpyStore_HOL.DAL.EfStructures;

namespace SpyStore_HOL.DAL.Initialization
{
    public static class StoreDataInitializer
    {
        public static void InitializeData(StoreContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }
        public static void ClearData(StoreContext context)
        {
            ExecuteDeleteSql(context, "Categories");
            ExecuteDeleteSql(context, "Customers");
            ResetIdentity(context);
        }
        internal static void ExecuteDeleteSql(StoreContext context, string tableName)
        {
            var rawSqlString = $"Delete from Store.{tableName}";
#pragma warning disable EF1000 // Possible SQL injection vulnerability.
            context.Database.ExecuteSqlCommand(rawSqlString);
#pragma warning restore EF1000 // Possible SQL injection vulnerability.
        }
        internal static void ResetIdentity(StoreContext context)
        {
            var tables = new[] {"Categories","Customers",
                "OrderDetails","Orders","Products","ShoppingCartRecords"};
            foreach (var itm in tables)
            {
                var rawSqlString = $"DBCC CHECKIDENT (\"Store.{itm}\", RESEED, -1);";
#pragma warning disable EF1000 // Possible SQL injection vulnerability.
                context.Database.ExecuteSqlCommand(rawSqlString);
#pragma warning restore EF1000 // Possible SQL injection vulnerability.
            }
        }

        internal static void SeedData(StoreContext context)
        {
            try
            {
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(StoreSampleData.GetCategories());
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    context.Products.AddRange(StoreSampleData.GetProducts(context.Categories.ToList()));
                    context.SaveChanges();
                }
                if (!context.Customers.Any())
                {
                    context.Customers.AddRange(StoreSampleData.GetAllCustomerRecords(context));
                    context.SaveChanges();
                }
                var customer = context.Customers.FirstOrDefault();
                if (!context.Orders.Any())
                {
                    context.Orders.AddRange(StoreSampleData.GetOrders(customer, context));
                    context.SaveChanges();
                }
                if (!context.OrderDetails.Any())
                {
                    var order = context.Orders.First();
                    context.OrderDetails.AddRange(StoreSampleData.GetOrderDetails(order, context));
                    context.SaveChanges();
                }
                if (!context.ShoppingCartRecords.Any())
                {
                    context.ShoppingCartRecords.AddRange(StoreSampleData.GetCart(customer, context));
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


    }
}