#region copyright
// // Copyright Information
// // ==============================
// // EFCore_Top_Ten - 20160810005702_Initial.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCore_Top_Ten.EF.Migrations.Annotations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Data");

            migrationBuilder.CreateTable(
                name: "OurBooks",
                schema: "Data",
                columns: table => new
                {
                    ISBN_ID_NUMBER = table.Column<string>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurBooks", x => x.ISBN_ID_NUMBER);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 25, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    ReadISBN = table.Column<string>(nullable: true),
                    ReviewedISBN = table.Column<string>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    WrittenISBN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_OurBooks_ReadISBN",
                        column: x => x.ReadISBN,
                        principalSchema: "Data",
                        principalTable: "OurBooks",
                        principalColumn: "ISBN_ID_NUMBER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_OurBooks_ReviewedISBN",
                        column: x => x.ReviewedISBN,
                        principalSchema: "Data",
                        principalTable: "OurBooks",
                        principalColumn: "ISBN_ID_NUMBER",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_OurBooks_WrittenISBN",
                        column: x => x.WrittenISBN,
                        principalSchema: "Data",
                        principalTable: "OurBooks",
                        principalColumn: "ISBN_ID_NUMBER",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Poster",
                columns: table => new
                {
                    ISBN = table.Column<string>(nullable: false),
                    PosterDescription = table.Column<string>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poster", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Poster_OurBooks_ISBN",
                        column: x => x.ISBN,
                        principalSchema: "Data",
                        principalTable: "OurBooks",
                        principalColumn: "ISBN_ID_NUMBER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Thingies",
                columns: table => new
                {
                    FirstKey = table.Column<string>(nullable: false),
                    SecondKey = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MyBookISBN = table.Column<string>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Thingies", x => new { x.FirstKey, x.SecondKey });
                    table.ForeignKey(
                        name: "FK_Thingies_OurBooks_MyBookISBN",
                        column: x => x.MyBookISBN,
                        principalSchema: "Data",
                        principalTable: "OurBooks",
                        principalColumn: "ISBN_ID_NUMBER",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OurBooks_Title",
                schema: "Data",
                table: "OurBooks",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_ReadISBN",
                table: "People",
                column: "ReadISBN");

            migrationBuilder.CreateIndex(
                name: "IX_People_ReviewedISBN",
                table: "People",
                column: "ReviewedISBN");

            migrationBuilder.CreateIndex(
                name: "IX_People_WrittenISBN",
                table: "People",
                column: "WrittenISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Poster_ISBN",
                table: "Poster",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Thingies_MyBookISBN",
                table: "Thingies",
                column: "MyBookISBN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Poster");

            migrationBuilder.DropTable(
                name: "Thingies");

            migrationBuilder.DropTable(
                name: "OurBooks",
                schema: "Data");
        }
    }
}
