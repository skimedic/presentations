using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.EfStructures.Migrations
{
    public partial class AddCreditRisk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditRisks",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditRisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditRisks_Customers",
                        column: x => x.CustomerId,
                        principalSchema: "Dbo",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditRisks_CustomerId",
                schema: "Dbo",
                table: "CreditRisks",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRisks_FirstName_LastName",
                schema: "Dbo",
                table: "CreditRisks",
                columns: new[] { "FirstName", "LastName" },
                unique: true,
                filter: "[FirstName] IS NOT NULL AND [LastName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditRisks",
                schema: "Dbo");
        }
    }
}
