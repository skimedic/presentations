using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpyStore_HOL.DAL.EF.Migrations
{
    public partial class TSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"CREATE FUNCTION Store.GetOrderTotal ( @OrderId INT )
                         RETURNS MONEY WITH SCHEMABINDING 
                         BEGIN 
                         DECLARE @Result MONEY; 
                         SELECT @Result = SUM([Quantity]*[UnitCost]) FROM Store.OrderDetails 
                         WHERE OrderId = @OrderId; RETURN @Result END";
            migrationBuilder.Sql(sql);

            //sql = "CREATE PROCEDURE [Store].[PurchaseItemsInCart](@customerId INT = 0, @orderId INT OUTPUT) AS BEGIN " +
            //      " SET NOCOUNT ON; " +
            //      " INSERT INTO Store.Orders (CustomerId, OrderDate, ShipDate) " +
            //      "    VALUES(@customerId, GETDATE(), GETDATE()); " +
            //      " SET @orderId = SCOPE_IDENTITY(); " +
            //      " DECLARE @TranName VARCHAR(20);SELECT @TranName = 'CommitOrder'; " +
            //      "   BEGIN TRANSACTION @TranName; " +
            //      "   BEGIN TRY " +
            //      "       INSERT INTO Store.OrderDetails (OrderId, ProductId, Quantity, UnitCost) " +
            //      "       SELECT @orderId, ProductId, Quantity, p.CurrentPrice " +
            //      "       FROM Store.ShoppingCartRecords scr " +
            //      "          INNER JOIN Store.Products p ON p.Id = scr.ProductId " +
            //      "       WHERE CustomerId = @customerId; " +
            //      "       DELETE FROM Store.ShoppingCartRecords WHERE CustomerId = @customerId; " +
            //      "       COMMIT TRANSACTION @TranName; " +
            //      "   END TRY " +
            //      "   BEGIN CATCH " +
            //      "       ROLLBACK TRANSACTION @TranName; " +
            //      "       SET @OrderId = -1; " +
            //      "   END CATCH; " +
            //      "END;";
            //migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [Store].[GetOrderTotal]");
            //migrationBuilder.Sql("DROP PROCEDURE [Store].[PurchaseItemsInCart]");
        }
    }
}
