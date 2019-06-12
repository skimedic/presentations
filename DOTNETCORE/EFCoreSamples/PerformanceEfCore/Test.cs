using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PerformanceEfCore.EfStructures;
using PerformanceEfCore.EfStructures.Context;
using PerformanceEfCore.EfStructures.Models;

namespace PerformanceEfCore
{
    public static class Test
    {
        public static void GetAllCustomers()
        {
            using (var db = new AdventureWorksContext())
            {
                db.Customers.ToList();
            }
        }

        public static void RunComplexQuery()
        {
            using (var db = new AdventureWorksContext())
            {
                Repo.GetComplexData(db);
            }

        }

        public static void AddRecordsAndSave()
        {
            using (var db = new AdventureWorksContext())
            {
                for (int i = 0; i < 1000; i++)
                {
                    db.ProductCategories.Add(new ProductCategory { Name = $"Test {Guid.NewGuid()}" });
                }
                db.SaveChanges();
            }
        }

        public static void ResetAndWarmUp()
        {
            using (var db = new AdventureWorksContext())
            {
                db.Database.ExecuteSqlCommand(@"DELETE FROM Production.ProductCategory WHERE Name LIKE 'Test %'");
                db.Customers.FirstOrDefault();
            }
        }
    }
}
