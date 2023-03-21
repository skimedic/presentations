using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Migrations.EFStructures;
using Migrations.Initialization;

namespace Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new ApplicationDbContextFactory().CreateDbContext(new string[0]);
            SampleDataInitializer.InitializeData(context);
            List<Task> ts = new List<Task>();
            //ts.Add(context.Cars.ToListAsync());
            //ts.Add(context.Cars.ToListAsync());
            //ts.Add(context.Cars.ToListAsync());
            //ts.Add(context.Cars.ToListAsync());
            //Task.WaitAll(ts.ToArray());
            var orders = context.CustomOrderViewModels.ToList();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }
    }
}