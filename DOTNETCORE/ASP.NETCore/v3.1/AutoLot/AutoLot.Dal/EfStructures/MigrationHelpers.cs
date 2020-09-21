using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLot.Dal.EfStructures
{
    /*
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.CreateCustomerOrderView(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.DropCustomerOrderView(migrationBuilder);
        }

     */
    public static class MigrationHelpers
    {
        public static void CreateCustomerOrderView(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                CREATE VIEW [dbo].[CustomerOrderView]
                AS
                    SELECT dbo.Customers.FirstName, dbo.Customers.LastName, dbo.Inventory.Color, dbo.Inventory.PetName, dbo.Makes.Name AS Make
                    FROM   dbo.Orders 
                    INNER JOIN dbo.Customers ON dbo.Orders.CustomerId = dbo.Customers.Id 
                    INNER JOIN dbo.Inventory ON dbo.Orders.CarId = dbo.Inventory.Id
                    INNER JOIN dbo.Makes ON dbo.Makes.Id = dbo.Inventory.MakeId 
                ");
        }
        public static void DropCustomerOrderView(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[CustomerOrderView]");
        }
    }
}
