// Copyright Information
// ==================================
// AutoLot - AutoLot.Dal - MigrationHelpers.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLot.Dal.EfStructures
{
    /*
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.CreateSproc(migrationBuilder);
            MigrationHelpers.CreateCustomerOrderView(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.DropSproc(migrationBuilder);
            MigrationHelpers.DropCustomerOrderView(migrationBuilder);
        }

     */
    public static class MigrationHelpers
    {
        public static void CreateSproc(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                exec (N' 
                CREATE PROCEDURE [dbo].[GetPetName]
                    @carID int,
                    @petName nvarchar(50) output
                AS
                    SELECT @petName = PetName from dbo.Inventory where Id = @carID
                ')");
        }
        public static void DropSproc(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetPetName]");
        }
        public static void CreateCustomerOrderView(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"
                exec (N' 
                CREATE VIEW [dbo].[CustomerOrderView]
                AS
                    SELECT dbo.Customers.FirstName, dbo.Customers.LastName, dbo.Inventory.Color, dbo.Inventory.PetName,dbo.Inventory.IsDrivable, dbo.Makes.Name AS Make
                    FROM   dbo.Orders 
                    INNER JOIN dbo.Customers ON dbo.Orders.CustomerId = dbo.Customers.Id 
                    INNER JOIN dbo.Inventory ON dbo.Orders.CarId = dbo.Inventory.Id
                    INNER JOIN dbo.Makes ON dbo.Makes.Id = dbo.Inventory.MakeId
                ')");
        }

        public static void DropCustomerOrderView(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("EXEC (N' DROP VIEW [dbo].[CustomerOrderView] ')");
        }
    }
}
