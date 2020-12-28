using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLot.Dal.EfStructures.Migrations
{
    public partial class Fullname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CarId",
                schema: "Dbo",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PersonalInformation_FullName",
                schema: "Dbo",
                table: "CreditRisks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                schema: "Dbo",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[LastName] + ', ' + [FirstName]");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                schema: "Dbo",
                table: "Orders",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Dbo",
                table: "Orders",
                column: "CustomerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Orders_CarId",
                schema: "Dbo",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                schema: "Dbo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FullName",
                schema: "Dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PersonalInformation_FullName",
                schema: "Dbo",
                table: "CreditRisks");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                schema: "Dbo",
                table: "Orders",
                column: "CarId");
        }
    }
}
