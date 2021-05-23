using Microsoft.EntityFrameworkCore.Migrations;
using SpyStore.Hol.Dal.EfStructures.MigrationHelpers;

namespace SpyStore.Hol.Dal.EfStructures.Migrations
{
    public partial class TSQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            ViewsHelper.CreateOrderDetailWithProductInfoView(migrationBuilder);
            ViewsHelper.CreateCartRecordWithProductInfoView(migrationBuilder);
            FunctionsHelper.CreateOrderTotalFunction(migrationBuilder);
            SprocsHelper.CreatePurchaseSproc(migrationBuilder);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            ViewsHelper.DropOrderDetailWithProductInfoView(migrationBuilder);
            ViewsHelper.DropCartRecordWithProductInfoView(migrationBuilder);
            FunctionsHelper.DropOrderTotalFunction(migrationBuilder);
            SprocsHelper.DropPurchaseSproc(migrationBuilder);
        }
    }
}
