using System;
using System.Collections.Generic;
using System.Linq;
using PerformanceEfCore;
using PerformanceEfCore.EfStructures;
using PerformanceEfCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace PerformanceEfCore
{
    public static class TestEfCore
    {
        public static List<ProductViewModel> GetProductsFromSproc()
        {
            using (var db = new Aw2016Context())
            {
                return db.ProductViewModels.FromSqlRaw("dbo.uspGetAllProducts").ToList();
                //return db.ProductViewModels.FromSqlInterpolated($"update foo set name = 'bob' where id ={foo}").ToList();
            }
        }
        public static List<ProductViewModel> GetProductsFromSql()
        {
            using (var db = new Aw2016Context())
            {
                return db.ProductViewModels
                    .FromSqlInterpolated($@"Select p.* from Production.Product p inner join sales.salesorderdetail od on 
                                  p.ProductId = od.ProductId where od.ModifiedDate< {DateTime.Now}").ToList();
            }
        }
        public static void GetAllCustomers()
        {
            using (var db = new Aw2016Context())
            {
                db.Customer.ToList();
            }
        }
        public static void GetAllCustomersAsNoTracking()
        {
            using (var db = new Aw2016Context())
            {
                db.Customer.AsNoTracking().ToList();
            }
        }

        public static void GetAllCustomersQueryType()
        {
            using (var db = new Aw2016Context())
            {
                db.CustomerQuery.FromSqlRaw("Select * from Sales.Customer").ToList();
            }
        }
        public static void RunComplexQuery()
        {
            using (var db = new Aw2016Context())
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
            using (var db = new Aw2016Context())
            {
                for (int i = 0; i < 1000; i++)
                {
                    db.ProductCategory.Add(new ProductCategory { Name = $"Test {Guid.NewGuid()}" });
                }
                db.SaveChanges();
            }
        }

        public static void AddRecordsAndSaveNoBatching()
        {
            var builder = new DbContextOptionsBuilder<Aw2016Context>();
            var connectionString = @"server=.\dev2019;Database=Adventureworks2016;Trusted_Connection=True;";
            builder.UseSqlServer(connectionString,options => options.MaxBatchSize(1));

            using (var db = new Aw2016Context(builder.Options))
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
            using (var db = new Aw2016Context())
            {
                db.Database.ExecuteSqlRaw(@"DELETE FROM Production.ProductCategory WHERE Name LIKE 'Test %'");
                db.Customer.FirstOrDefault();
            }
        }
    }
}
