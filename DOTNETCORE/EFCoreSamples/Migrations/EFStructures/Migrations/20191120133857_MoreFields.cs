using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.EFStructures.Migrations
{
    public partial class MoreFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogType",
                table: "Blogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReaderCount",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordCount",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogType",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "ReaderCount",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "RecordCount",
                table: "Blogs");
        }
    }
}
