using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            ResetAndWarmup();

            //RunToListTest();
            RunComplexQueryTest();
            //RunAddAndSaveChangesTest();
            //RunAddAndSaveChangesOptimizedTest();
            Console.WriteLine("Demo complete");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void RunToListTest()
        {
            Console.WriteLine("Query 19K ToList");
            RunTest(
                ef6Test: () =>
                {
                    using (var db = new EF6.Context.AdventureWorksContext())
                    {
                        db.Customers.ToList();
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new EFCore.Context.AdventureWorksContext())
                    {
                        db.Customers.ToList();
                    }
                });
        }

        private static void RunComplexQueryTest()
        {
            /*
             *             var brownies = from r in dc.Recipes
                           where r.Title.Contains("Brownie")
                           select new
                           {
                               r.Title,
                               Categories = r.RecipeCategories.Select(rc => rc.Category.Description),
                               Ingredients = r.Ingredients.OrderBy(i => i.SortOrder),
                               Directions = r.Directions.OrderBy(d => d.LineNumber).Select(d => d.Description)
                           };
*/
            Console.WriteLine("Query Complex");
            RunTest(
                ef6Test: () =>
                {
                    using (var db = new EF6.Context.AdventureWorksContext())
                    {
                        var l = db.Products
                            .Include(x => x.TransactionHistories)
                            .Include(x => x.ProductSubcategory)
                            .Include(x => x.ProductSubcategory.ProductCategory)
                            .Include(x => x.ProductReviews)
                            .Select(x => new
                            {
                                Class = x.Class,
                                ModifiedDate = x.TransactionHistories.Select(th => th.ModifiedDate),
                                CategoryName = x.ProductSubcategory.ProductCategory.Name,
                                Email = x.ProductReviews.Select(pr => pr.EmailAddress)
                            })
                            .Take(100).ToList();

                        //db.Customers
                        //    .Where(c => !c.AccountNumber.EndsWith("1"))
                        //    .OrderBy(c => c.AccountNumber)
                        //    .ThenBy(c => c.ModifiedDate)
                        //    .Skip(100)
                        //    .GroupBy(c => c.TerritoryID)
                        //    .ToList();
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new EFCore.Context.AdventureWorksContext())
                    {
                        var el = db.Product
                            //.Include(x => x.TransactionHistory)
                            //.Include(x => x.ProductSubcategory)
                            //.Include(x => x.ProductSubcategory.ProductCategory)
                            //.Include(x => x.ProductReview)
                            .Select(x => new
                            {
                                Class = x.Class,
                                ModifiedDate = x.TransactionHistory.Select(th => th.ModifiedDate),
                                CategoryName = x.ProductSubcategory.ProductCategory.Name,
                                Email = x.ProductReview.Select(pr => pr.EmailAddress)
                            })
                            .Take(100).ToList();
                        //db.Customers
                        //    .Where(c => !c.AccountNumber.EndsWith("1"))
                        //    .OrderBy(c => c.AccountNumber)
                        //    .ThenBy(c => c.ModifiedDate)
                        //    .Skip(100)
                        //    .GroupBy(c => c.TerritoryID)
                        //    .ToList();
                    }
                });
        }

        private static void RunAddAndSaveChangesTest()
        {
            Console.WriteLine("Add 1K & SaveChanges");
            RunTest(
                () =>
                {
                    using (var db = new EF6.Context.AdventureWorksContext())
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            db.ProductCategories.Add(new EF6.Models.ProductCategory {Name = $"Test {Guid.NewGuid()}"});
                        }
                        db.SaveChanges();
                    }
                },
                () =>
                {
                    using (var db = new EFCore.Context.AdventureWorksContext())
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            db.ProductCategories.Add(new EFCore.Models.ProductCategory {Name = $"Test {Guid.NewGuid()}"});
                        }
                        db.SaveChanges();
                    }
                });
        }

        private static void RunAddAndSaveChangesOptimizedTest()
        {
            Console.WriteLine("Add 1K & SaveChanges (EF6 Optimized)");
            RunTest(
                () =>
                {
                    using (var db = new EF6.Context.AdventureWorksContext())
                    {
                        db.Configuration.AutoDetectChangesEnabled = false;
                        var categories = new EF6.Models.ProductCategory[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            categories[i] = new EF6.Models.ProductCategory {Name = $"Test {Guid.NewGuid()}"};
                        }
                        db.ProductCategories.AddRange(categories);
                        db.SaveChanges();
                    }
                },
                () =>
                {
                    using (var db = new EFCore.Context.AdventureWorksContext())
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            db.ProductCategories.Add(new EFCore.Models.ProductCategory {Name = $"Test {Guid.NewGuid()}"});
                        }
                        db.SaveChanges();
                    }
                });
        }

        private static void RunTest(Action ef6Test, Action ef7Test)
        {
            var stopwatch = new Stopwatch();
            for (int iteration = 0; iteration < 3; iteration++)
            {
                Console.WriteLine($" Iteration {iteration}");

                //stopwatch.Restart();
                //ef6Test();
                //stopwatch.Stop();
                //var ef6 = stopwatch.ElapsedMilliseconds;
                //Console.WriteLine($"  - EF6.x:      {ef6.ToString().PadLeft(4)}ms");

                stopwatch.Restart();
                ef7Test();
                stopwatch.Stop();
                var efCore = stopwatch.ElapsedMilliseconds;
                Console.WriteLine($"  - EF Core:    {efCore.ToString().PadLeft(4)}ms");

                //var result = (ef6 - efCore) / (double) ef6;
                //Console.WriteLine($"  - Improvement: {result.ToString("P0")}");
                //Console.WriteLine();
                return;
            }
        }

        private static void ResetAndWarmup()
        {
            using (var db = new EF6.Context.AdventureWorksContext())
            {
                db.Database.ExecuteSqlCommand(@"DELETE FROM Production.ProductCategory WHERE Name LIKE 'Test %'");
                db.Customers.FirstOrDefault();
            }

            using (var db = new EFCore.Context.AdventureWorksContext())
            {
                db.Customers.FirstOrDefault();
            }
        }
    }
}