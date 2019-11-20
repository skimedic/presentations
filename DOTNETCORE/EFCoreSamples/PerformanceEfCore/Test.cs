using System;
using System.Linq;
using PerformanceEfCore;
using PerformanceEfCore.EfStructures;
using PerformanceEfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace PerformanceEfCore
{
    public static class TestEfCore
    {
        public static void GetAllCustomers()
        {
            using (var db = new AW2016Context())
            {
                db.Customer.ToList();
            }
        }
        public static void GetAllCustomersAsNoTracking()
        {
            using (var db = new AW2016Context())
            {
                db.Customer.AsNoTracking().ToList();
            }
        }

        public static void GetAllCustomersQueryType()
        {
            using (var db = new AW2016Context())
            {
                db.CustomerQuery.FromSqlRaw("Select * from Sales.Customer").ToList();
            }
        }
        public static void RunComplexQuery()
        {
            using (var db = new AW2016Context())
            {
                var l = db.Product
                    .Include(x => x.TransactionHistory)
                    .Include(x => x.ProductSubcategory)
                    .Include(x => x.ProductSubcategory.ProductCategory)
                    .Include(x => x.ProductReview)
                    .Select(x => new ModelForTesting()
                    {
                        ProductId = x.ProductId,
                        Class = x.Class,
                        ModifiedDate = x.TransactionHistory.Select(th => th.ModifiedDate).FirstOrDefault(),
                        CategoryName = x.ProductSubcategory.ProductCategory.Name,
                        Email = x.ProductReview.Select(pr => pr.EmailAddress).FirstOrDefault()
                    })
                    .Take(100).ToList();
            }

        }

        public static void AddRecordsAndSave()
        {
            using (var db = new AW2016Context())
            {
                for (int i = 0; i < 1000; i++)
                {
                    db.ProductCategory.Add(new ProductCategory { Name = $"Test {Guid.NewGuid()}" });
                }
                db.SaveChanges();
            }
        }

        public static void ResetAndWarmUp()
        {
            using (var db = new AW2016Context())
            {
                db.Database.ExecuteSqlRaw(@"DELETE FROM Production.ProductCategory WHERE Name LIKE 'Test %'");
                db.Customer.FirstOrDefault();
            }
        }
    }
}
