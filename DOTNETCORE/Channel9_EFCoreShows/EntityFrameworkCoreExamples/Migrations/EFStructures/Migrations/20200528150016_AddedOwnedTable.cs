using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.EfStructures.Migrations
{
    public partial class AddedOwnedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CreditRisks_FirstName_LastName",
                schema: "Dbo",
                table: "CreditRisks");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Dbo",
                table: "Customers",
                newName: "PersonalInformation_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Dbo",
                table: "Customers",
                newName: "PersonalInformation_FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonalInformation_LastName",
                schema: "Dbo",
                table: "Customers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PersonalInformation_FirstName",
                schema: "Dbo",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRisks_FirstName_LastName",
                schema: "Dbo",
                table: "CreditRisks",
                columns: new[] { "FirstName", "LastName" },
                unique: true,
                filter: "[FirstName] IS NOT NULL AND [LastName] IS NOT NULL");
        }
    }
}
