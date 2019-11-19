#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - 20191004031037_TSQL.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using Microsoft.EntityFrameworkCore.Migrations;
using SpyStore.Dal.EfStructures.MigrationHelpers;

namespace SpyStore.Dal.EfStructures.Migrations
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