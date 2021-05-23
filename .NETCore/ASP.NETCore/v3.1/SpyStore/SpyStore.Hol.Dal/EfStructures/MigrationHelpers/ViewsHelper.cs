using Microsoft.EntityFrameworkCore.Migrations;

namespace SpyStore.Hol.Dal.EfStructures.MigrationHelpers
{
    /*
protected override void Up(MigrationBuilder migrationBuilder)
{
  ViewsHelper.CreateOrderDetailWithProductInfoView(migrationBuilder);
  ViewsHelper.CreateCartRecordWithProductInfoView(migrationBuilder);
  FunctionsHelper.CreateOrderTotalFunction(migrationBuilder);
  SprocsHelper.CreatePurchaseSproc(migrationBuilder);
}
protected override void Down(MigrationBuilder migrationBuilder)
{
  ViewsHelper.DropOrderDetailWithProductInfoView(migrationBuilder);
  ViewsHelper.DropCartRecordWithProductInfoView(migrationBuilder);
  FunctionsHelper.DropOrderTotalFunction(migrationBuilder);
  SprocsHelper.DropPurchaseSproc(migrationBuilder);
}

     */
    public static class ViewsHelper
    {
        public static void CreateOrderDetailWithProductInfoView(MigrationBuilder builder)
        {
            builder.Sql(@"
CREATE VIEW [Store].[OrderDetailWithProductInfo]
AS
SELECT        
  od.Id, od.TimeStamp, od.OrderId, od.ProductId, od.Quantity, od.UnitCost, 
  od.Quantity * od.UnitCost AS LineItemTotal, 
  p.ModelName, p.Description, p.ModelNumber, p.ProductImage, p.ProductImageLarge, 
  p.ProductImageThumb, p.CategoryId, p.UnitsInStock, p.CurrentPrice, c.CategoryName
FROM  Store.OrderDetails od INNER JOIN Store.Orders o ON o.Id = od.OrderId
INNER JOIN Store.Products AS p ON od.ProductId = p.Id INNER JOIN
 Store.Categories AS c ON p.CategoryId = c.id");
        }
        public static void CreateCartRecordWithProductInfoView(MigrationBuilder builder)
        {
            builder.Sql(@"
CREATE VIEW [Store].[CartRecordWithProductInfo]
AS
SELECT scr.Id, scr.TimeStamp, scr.DateCreated, scr.CustomerId, scr.Quantity,
        scr.LineItemTotal,
       scr.ProductId, p.ModelName, p.Description,
        p.ModelNumber, p.ProductImage, 
        p.ProductImageLarge, p.ProductImageThumb, 
        p.CategoryId, p.UnitsInStock, p.CurrentPrice, c.CategoryName 
FROM Store.ShoppingCartRecords scr 
	INNER JOIN Store.Products p ON p.Id = scr.ProductId
	INNER JOIN Store.Categories c ON c.Id = p.CategoryId");
        }

        public static void DropOrderDetailWithProductInfoView(MigrationBuilder builder)
        {
            builder.Sql("drop view [Store].[OrderDetailWithProductInfo]");
        }

        public static void DropCartRecordWithProductInfoView(MigrationBuilder builder)
        {
            builder.Sql("drop view [Store].[CartRecordWithProductInfo]");
        }

    }
}
