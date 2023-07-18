// 

using System;
using System.Linq;
using PerformanceEf6.Context;
using PerformanceEf6.Models;

namespace PerformanceEf6;

public static class TestEf6
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
            var foo = db.Products
                .Include("TransactionHistories")
                .Include("ProductSubcategory")
                .Include("ProductSubcategory.ProductCategory")
                .Include("ProductReviews")
                .Select(x => new ModelForTesting
                {
                    ProductId = x.ProductID,
                    Class = x.Class,
                    ModifiedDate = x.TransactionHistories.Select(th => th.ModifiedDate).FirstOrDefault(),
                    CategoryName = x.ProductSubcategory.ProductCategory.Name,
                    Email = x.ProductReviews.Select(pr => pr.EmailAddress).FirstOrDefault()
                })
                .Take(100).ToList();
            //var l = db.Products
            //    .Include(x => x.TransactionHistories)
            //    .Include(x => x.ProductSubcategory)
            //    .Include(x => x.ProductSubcategory.ProductCategory)
            //    .Include(x => x.ProductReviews)
            //    .Select(x => new ModelForTesting()
            //    {
            //        ProductId = x.ProductID,
            //        Class = x.Class,
            //        ModifiedDate = x.TransactionHistories.Select(th => th.ModifiedDate).FirstOrDefault(),
            //        CategoryName = x.ProductSubcategory.ProductCategory.Name,
            //        Email = x.ProductReviews.Select(pr => pr.EmailAddress).FirstOrDefault()
            //    })
            //    .Take(100).ToList();
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