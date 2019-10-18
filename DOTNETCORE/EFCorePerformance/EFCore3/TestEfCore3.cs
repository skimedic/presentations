#region copyright

// Copyright Information
// ==================================
// EFPerformance - EFCore3 - TestEfCore3.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/18
// See License.txt for more information
// ==================================

#endregion

using System;
using System.Linq;
using EFCore3.EfStructures;
using EFCore3.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore3
{
    public static class TestEfCore3
    {
        public static void GetAllCustomers()
        {
            using (var db = new AW2016Context())
            {
                var foo = db.Customer.ToList();
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
                db.Database.ExecuteSqlCommand(@"DELETE FROM Production.ProductCategory WHERE Name LIKE 'Test %'");
                db.Customer.FirstOrDefault();
            }
        }
    }
}