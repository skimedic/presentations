using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.EfStructures.Migrations
{
    public partial class AddedUniqueIndexToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                schema: "Dbo",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId_CarId",
                schema: "Dbo",
                table: "Orders",
                columns: new[] { "CustomerId", "CarId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId_CarId",
                schema: "Dbo",
                table: "Orders");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Dbo",
                table: "Orders",
                column: "CustomerId");
        }
    }
}
