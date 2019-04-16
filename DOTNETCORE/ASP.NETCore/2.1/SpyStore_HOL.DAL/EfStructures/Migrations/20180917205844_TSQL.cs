using Microsoft.EntityFrameworkCore.Migrations;

namespace SpyStore_HOL.DAL.EfStructures.Migrations
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION [Store].[GetOrderTotal]");
        }
    }
}