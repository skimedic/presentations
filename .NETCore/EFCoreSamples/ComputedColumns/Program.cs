using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ComputedColumns.Models;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;

namespace ComputedColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupDatabase();
            DisplayOrderAndDetails();
            UpdateRecords();
            DisplayOrderAndDetails();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void UpdateRecords()
        {
            using (var db = new StoreContext())
            {
                var orderDetails = db.OrderDetails.ToList();
                orderDetails.ForEach(x => x.Quantity++);
                db.SaveChanges();
            }
        }

        private static void DisplayOrderAndDetails()
        {
            using (var db = new StoreContext())
            {
                var order = db.Orders.FirstOrDefault();
                Console.WriteLine($"Order Total:{order.OrderTotal}");
                db.Entry(order).Collection(o => o.OrderDetails).Load();
                order.OrderDetails.ForEach(x =>
                {
                    Console.WriteLine($"Qty: {x.Quantity}, Cost: {x.UnitCost} = Total: {x.LineItemTotal}");
                });
            }
        }

        private static void SetupDatabase()
        {
            using (var db = new StoreContext())
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();
                var order = new Order
                {
                    CustomerId = 1,
                    OrderDate = DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0)),
                    ShipDate = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0)),
                };
                var details = new List<OrderDetail>
                {
                    new OrderDetail() {Order = order, Quantity = 3, UnitCost = 12.99M},
                    new OrderDetail() {Order = order, Quantity = 2, UnitCost = 39.99M},
                };
                order.OrderDetails = details;
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}