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
            var orders = context.CustomerOrderViewModels.ToList();
            foreach (var order in orders)
            {
                Console.WriteLine(order.ToString());
            }
        }
    }
}