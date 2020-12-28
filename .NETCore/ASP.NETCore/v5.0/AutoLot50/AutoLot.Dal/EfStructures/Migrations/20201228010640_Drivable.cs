using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoLot.Dal.EfStructures.Migrations
{
    public partial class Drivable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDriveable",
                schema: "Dbo",
                table: "Inventory",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDriveable",
                schema: "Dbo",
                table: "Inventory");
        }
    }
}
