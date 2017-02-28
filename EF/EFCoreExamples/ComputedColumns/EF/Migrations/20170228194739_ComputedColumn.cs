using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputedColumns.EF.Migrations
{
    public partial class ComputedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderTotal",
                schema: "Store",
                table: "Orders",
                type: "money",
                nullable: true,
                computedColumnSql: "Store.GetOrderTotal([Id])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotal",
                schema: "Store",
                table: "Orders");
        }
    }
}
