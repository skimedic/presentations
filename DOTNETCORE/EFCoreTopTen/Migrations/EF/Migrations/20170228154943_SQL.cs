using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations.EF.Migrations
{
    public partial class SQL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var udf =
                @"CREATE FUNCTION [dbo].[SearchBlogs] (@term nvarchar(200)) 
                RETURNS TABLE AS 
                RETURN (SELECT * FROM dbo.Blogs WHERE Url LIKE '%' + @term + '%')";
            migrationBuilder.Sql(udf);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop function [dbo].[SeachBlogs]");
        }
    }
}
