using System;
using System.Diagnostics;
using System.Linq;
using System.Data.Entity;
using PerformanceEfCore.EFCore;

namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            ResetAndWarmup();
            RunToListTest();
            RunToListTestUntracked();
            RunToListTestQueryType();
            RunToListTestCoreVsQueryType();
            RunToListTestCoreVsQueryTypeAsView();
            RunComplexQueryTest();
            RunComplexQueryTestCorevsCore();
            RunAddAndSaveChangesTest();
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
                    using (var db = new PerformanceEf6.EF6.Context.AdventureWorksContext())
                    {
                        db.Customers.ToList();
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context
                        .AdventureWorksContext())
                    {
                        db.Customers.ToList();
                    }
                });
        }
        private static void RunToListTestUntracked()
        {
            Console.WriteLine("Query 19K ToList UnTracked");
            RunTest(
                ef6Test: () =>
                {
                    using (var db = new PerformanceEf6.EF6.Context.AdventureWorksContext())
                    {
                        db.Customers.ToList();
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context
                        .AdventureWorksContext())
                    {
                        db.Customers.AsNoTracking().ToList();
                    }
                });
        }

        private static void RunToListTestQueryType()
        {
            Console.WriteLine("Query 19K ToList Query Type");
            RunTest(
                ef6Test: () =>
                {
                    using (var db = new PerformanceEf6.EF6.Context.AdventureWorksContext())
                    {
                        db.Customers.ToList();
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context
                        .AdventureWorksContext())
                    {
                        db.CustomersQuery.ToList();
                    }
                });
        }
        private static void RunToListTestCoreVsQueryType()
        {
            Console.WriteLine("Query 19K ToList UnTracked vs QueryType");
            RunTest(
                ef6Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context
                        .AdventureWorksContext())
                    {
                        db.Customers.AsNoTracking().ToList();
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context
                        .AdventureWorksContext())
                    {
                        db.CustomersQuery.ToList();
                    }
                },
                firstLabel: "-  Untracked",
                secondLabel: "- QueryType");
        }

        private static void RunToListTestCoreVsQueryTypeAsView()
        {
            Console.WriteLine("Query 19K ToList Query Type vs QueryType From View");
            RunTest(
                ef6Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context
                        .AdventureWorksContext())
                    {
                        db.CustomersQuery.ToList();
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context
                        .AdventureWorksContext())
                    {
                        db.CustomersView.ToList();
                    }
                },
                firstLabel: "-  QueryType",
                secondLabel: "- QueryTypeAsView");
        }

        private static void RunComplexQueryTest()
        {
            Console.WriteLine("Query Complex");
            RunTest(
                ef6Test: () =>
                {
                    using (var db = new PerformanceEf6.EF6.Context.AdventureWorksContext())
                    {
                        var l = db.Products
                            .Include(x => x.TransactionHistories)
                            .Include(x => x.ProductSubcategory)
                            .Include(x => x.ProductSubcategory.ProductCategory)
                            .Include(x => x.ProductReviews)
                            .Select(x => new PerformanceEf6.EF6.ModelForTesting()
                            {
                                ProductId = x.ProductID,
                                Class = x.Class,
                                ModifiedDate = x.TransactionHistories.Select(th => th.ModifiedDate).FirstOrDefault(),
                                CategoryName = x.ProductSubcategory.ProductCategory.Name,
                                Email = x.ProductReviews.Select(pr => pr.EmailAddress).FirstOrDefault()
                            })
                            .Take(100).ToList();
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context.AdventureWorksContext())
                    {


                        var el = Repo.GetComplexData(db);
                        //var el = Repo.CompiledQuery(db).ToList();
                        //var el = Repo.GetComplexDataQueryType(db).ToList();
                    }
                });
        }
        private static void RunComplexQueryTestCorevsCore()
        {
            Console.WriteLine("Query Complex Core vs Core");
            RunTest(
                ef6Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context.AdventureWorksContext())
                    {
                        var el = Repo.GetComplexData(db);
                    }
                },
                ef7Test: () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context.AdventureWorksContext())
                    {
                        //var el = Repo.CompiledQuery(db).ToList();
                        var el = Repo.GetComplexDataQueryType(db).ToList();
                    }
                },
                firstLabel:"-  FromSQL",
                secondLabel:"- Compiled");
        }

        private static void RunAddAndSaveChangesTest()
        {
            Console.WriteLine("Add 1K & SaveChanges");
            RunTest(
                () =>
                {
                    using (var db = new PerformanceEf6.EF6.Context.AdventureWorksContext())
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            db.ProductCategories.Add(new PerformanceEf6.EF6.Models.ProductCategory { Name = $"Test {Guid.NewGuid()}" });
                        }
                        db.SaveChanges();
                    }
                },
                () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context.AdventureWorksContext())
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            db.ProductCategories.Add(new PerformanceEfCore.EFCore.Models.ProductCategory { Name = $"Test {Guid.NewGuid()}" });
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
                    using (var db = new PerformanceEf6.EF6.Context.AdventureWorksContext())
                    {
                        db.Configuration.AutoDetectChangesEnabled = false;
                        var categories = new PerformanceEf6.EF6.Models.ProductCategory[1000];
                        for (int i = 0; i < 1000; i++)
                        {
                            categories[i] = new PerformanceEf6.EF6.Models.ProductCategory { Name = $"Test {Guid.NewGuid()}" };
                        }
                        db.ProductCategories.AddRange(categories);
                        db.SaveChanges();
                    }
                },
                () =>
                {
                    using (var db = new PerformanceEfCore.EFCore.Context.AdventureWorksContext())
                    {
                        for (int i = 0; i < 1000; i++)
                        {
                            db.ProductCategories.Add(new PerformanceEfCore.EFCore.Models.ProductCategory { Name = $"Test {Guid.NewGuid()}" });
                        }
                        db.SaveChanges();
                    }
                });
        }

        private static void RunTest(Action ef6Test, Action ef7Test, 
            string firstLabel = "  - EF6.x", string secondLabel = "  - EF Core")
        {
            var stopwatch = new Stopwatch();
            for (int iteration = 0; iteration < 3; iteration++)
            {
                Console.WriteLine($" Iteration {iteration}");

                stopwatch.Restart();
                ef6Test();
                stopwatch.Stop();
                var ef6 = stopwatch.ElapsedMilliseconds;
                Console.WriteLine($"{firstLabel}:      {ef6.ToString().PadLeft(4)}ms");

                stopwatch.Restart();
                ef7Test();
                stopwatch.Stop();
                var efCore = stopwatch.ElapsedMilliseconds;
                Console.Write($"{secondLabel}:    {efCore.ToString().PadLeft(4)}ms");

                var result = (ef6 - efCore) / (double)ef6;
                Console.WriteLine($"  - Improvement: {result.ToString("P0")}");
                Console.WriteLine();
                //return;
            }
        }

        private static void ResetAndWarmup()
        {
            using (var db = new PerformanceEf6.EF6.Context.AdventureWorksContext())
            {
                db.Database.ExecuteSqlCommand(@"DELETE FROM Production.ProductCategory WHERE Name LIKE 'Test %'");
                db.Customers.FirstOrDefault();
            }

            using (var db = new PerformanceEfCore.EFCore.Context.AdventureWorksContext())
            {
                db.Customers.FirstOrDefault();
            }
        }
    }
}
