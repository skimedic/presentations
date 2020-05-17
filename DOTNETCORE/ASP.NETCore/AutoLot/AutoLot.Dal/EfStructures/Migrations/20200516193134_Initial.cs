using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLot.Dal.EfStructures.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Dbo");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Make = table.Column<string>(maxLength: 50, nullable: true),
                    Color = table.Column<string>(maxLength: 50, nullable: true),
                    PetName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Inventory",
                        column: x => x.CarId,
                        principalSchema: "Dbo",
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers",
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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                schema: "Dbo",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "Dbo",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditRisks",
                schema: "Dbo");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Dbo");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "Dbo");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "Dbo");
        }
    }
}
