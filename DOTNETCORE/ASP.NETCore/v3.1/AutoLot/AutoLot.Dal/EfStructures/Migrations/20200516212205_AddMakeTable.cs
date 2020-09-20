using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLot.Dal.EfStructures.Migrations
{
    public partial class AddMakeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Make",
                schema: "Dbo",
                table: "Inventory");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                schema: "Dbo",
                table: "Inventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Makes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_MakeId",
                schema: "Dbo",
                table: "Inventory",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Make_Inventory",
                schema: "Dbo",
                table: "Inventory",
                column: "MakeId",
                principalSchema: "dbo",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Make_Inventory",
                schema: "Dbo",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Makes",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_MakeId",
                schema: "Dbo",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "MakeId",
                schema: "Dbo",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "Make",
                schema: "Dbo",
                table: "Inventory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
