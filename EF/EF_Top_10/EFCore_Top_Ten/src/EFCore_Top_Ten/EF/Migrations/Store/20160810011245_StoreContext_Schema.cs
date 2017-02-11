#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - 20160810011245_StoreContext_Schema.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore_Top_Ten.EF.Migrations.Store
{
    public partial class StoreContext_Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Store");

            migrationBuilder.RenameTable(
                name: "Widgets",
                newSchema: "Store");

            migrationBuilder.RenameTable(
                name: "ProductPhotos",
                newSchema: "Store");

            migrationBuilder.RenameTable(
                name: "Products",
                newSchema: "Store");

            migrationBuilder.RenameTable(
                name: "Category",
                newSchema: "Store");

            migrationBuilder.RenameTable(
                name: "AccountTransactions",
                newSchema: "Store");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newSchema: "Store");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Widgets",
                schema: "Store");

            migrationBuilder.RenameTable(
                name: "ProductPhotos",
                schema: "Store");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Store");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "Store");

            migrationBuilder.RenameTable(
                name: "AccountTransactions",
                schema: "Store");

            migrationBuilder.RenameTable(
                name: "Accounts",
                schema: "Store");
        }
    }
}
