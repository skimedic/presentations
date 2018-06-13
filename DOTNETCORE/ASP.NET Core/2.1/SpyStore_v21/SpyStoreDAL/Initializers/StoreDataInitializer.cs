using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SpyStoreDAL.EfStructures;

namespace SpyStoreDAL.Initializers
{
    public static class StoreDataInitializer
    {
        public static void InitializeData(ApplicationDbContext context)
        {
            context.Database.Migrate();
            ClearData(context);
            SeedData(context);
        }
        public static void ClearData(ApplicationDbContext context)
        {
            ExecuteDeleteSQL(context, "OrderDetails");
            ExecuteDeleteSQL(context, "Orders");
            ExecuteDeleteSQL(context, "Categories");
            ResetIdentity(context);
        }
        public static void ExecuteDeleteSQL(ApplicationDbContext context, string tableName)
        {
            //Changed in 2.0 - string interpolation now makes parameterized queries
            var rawSqlString = $"Delete from Store.{tableName}";
            context.Database.ExecuteSqlCommand(rawSqlString);
        }
        public static void ResetIdentity(ApplicationDbContext context)
        {
            var tables = new[] {"Categories","OrderDetails","Orders","Products","ShoppingCartRecords"};
            foreach (var itm in tables)
            {
                //Changed in 2.0 - string interpolation now makes parameterized queries
                var rawSqlString = $"DBCC CHECKIDENT (\"Store.{itm}\", RESEED, -1);";
                context.Database.ExecuteSqlCommand(rawSqlString);
            }
        }

        public static void SeedData(ApplicationDbContext context)
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
                    context.Products.AddRange(
                        StoreSampleData.GetProducts(context.Categories.ToList()));
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
