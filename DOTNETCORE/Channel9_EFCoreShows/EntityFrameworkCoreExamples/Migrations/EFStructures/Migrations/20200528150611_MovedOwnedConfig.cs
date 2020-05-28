using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.EfStructures.Migrations
{
    public partial class MovedOwnedConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "Dbo",
                table: "CreditRisks",
                newName: "PersonalInformation_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "Dbo",
                table: "CreditRisks",
                newName: "PersonalInformation_FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "PersonalInformation_LastName",
                schema: "Dbo",
                table: "CreditRisks",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "PersonalInformation_FirstName",
                schema: "Dbo",
                table: "CreditRisks",
                newName: "FirstName");
        }
    }
}
