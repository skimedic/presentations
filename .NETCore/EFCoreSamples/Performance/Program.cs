using System;
using System.Diagnostics;
using System.Linq;
using PerformanceEf6;
using PerformanceEfCore;

namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            ResetAndWarmup();
            RunToListTest();
            RunToListTestUnTracked();
            RunToListTestQueryType();
            RunComplexQueryTest();
            RunComplexQueryTest2();
            RunAddAndSaveChangesTest();
            //RunAddAndSaveChangesTestNoBatching();
            Console.WriteLine("Demo complete");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void RunToListTest()
        {
            Console.WriteLine("Query 19K ToList");
            RunTest(
                ef6Test: TestEf6.GetAllCustomers,
                ef7Test: TestEfCore.GetAllCustomers
                );
        }
        private static void RunToListTestUnTracked()
        {
            Console.WriteLine("Query 19K ToList UnTracked");
            RunTest(
                ef6Test: TestEf6.GetAllCustomers,
                ef7Test: TestEfCore.GetAllCustomersAsNoTracking
                );
        }
        private static void RunToListTestQueryType()
        {
            Console.WriteLine("Query 19K ToList Query Type v UnTracked");
            RunTest(
                ef6Test: TestEfCore.GetAllCustomersQueryType,
                firstLabel:"Query Type",
                ef7Test: TestEfCore.GetAllCustomersAsNoTracking,
                secondLabel:"No Tracking");
        }
        private static void RunComplexQueryTest()
        {
            Console.WriteLine("Query Complex");
            RunTest(
                ef6Test: TestEf6.RunComplexQuery,
                ef7Test: TestEfCore.RunComplexQuery
                );
        }
        private static void RunComplexQueryTest2()
        {
            Console.WriteLine("Split Query (Core vs Core)");
            RunTest(
                ef6Test: TestEfCore.RunNonSplitQuery,
                ef7Test: TestEfCore.RunSplitQuery,
                "NonSplit","Split"
                );
        }
        private static void RunAddAndSaveChangesTest()
        {
            Console.WriteLine("Add 1K & SaveChanges");
            RunTest(
                TestEf6.AddRecordsAndSave,
                TestEfCore.AddRecordsAndSave
                );
        }

        private static void RunAddAndSaveChangesTestNoBatching()
        {
            Console.WriteLine("Add 1K & SaveChanges");
            RunTest(
                TestEf6.AddRecordsAndSave,
                TestEfCore.AddRecordsAndSaveNoBatching
            );
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
            }
        }

        private static void ResetAndWarmup()
        {
            TestEf6.ResetAndWarmUp();
            TestEfCore.ResetAndWarmUp();
        }
    }
}
