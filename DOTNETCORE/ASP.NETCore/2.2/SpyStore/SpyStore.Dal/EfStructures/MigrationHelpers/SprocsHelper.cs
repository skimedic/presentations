using Microsoft.EntityFrameworkCore.Migrations;

namespace SpyStore.Dal.EfStructures.MigrationHelpers
{
    public static class SprocsHelper
    {
        public static void CreatePurchaseSproc(MigrationBuilder migrationBuilder)
        {
            var sql = @"
    CREATE PROCEDURE [Store].[PurchaseItemsInCart](@customerId INT = 0, @orderId INT OUTPUT) AS 
    BEGIN 
      SET NOCOUNT ON; 
      INSERT INTO Store.Orders (CustomerId, OrderDate, ShipDate) 
        VALUES(@customerId, GETDATE(), GETDATE()); 
      SET @orderId = SCOPE_IDENTITY(); 
      DECLARE @TranName VARCHAR(20);SELECT @TranName = 'CommitOrder'; 
      BEGIN TRANSACTION @TranName; 
      BEGIN TRY 
       INSERT INTO Store.OrderDetails (OrderId, ProductId, Quantity, UnitCost) 
       SELECT @orderId, scr.ProductId, scr.Quantity, p.CurrentPrice 
       FROM Store.ShoppingCartRecords scr 
         INNER JOIN Store.Products p ON p.Id = scr.ProductId 
       WHERE scr.CustomerId = @customerId; 
       DELETE FROM Store.ShoppingCartRecords WHERE CustomerId = @customerId; 
       COMMIT TRANSACTION @TranName; 
      END TRY 
      BEGIN CATCH 
        ROLLBACK TRANSACTION @TranName; 
        SET @OrderId = -1; 
      END CATCH; 
    END;";
            migrationBuilder.Sql(sql);
        }

        public static void DropPurchaseSproc(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [Store].[PurchaseItemsInCart]");
        }

    }
}
