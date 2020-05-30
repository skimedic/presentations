using Microsoft.EntityFrameworkCore.Migrations;
using Migrations.EFStructures;

namespace Migrations.EfStructures.Migrations
{
    public partial class AddSproc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.CreateView(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            MigrationHelpers.DropView(migrationBuilder);
        }
    }
}
