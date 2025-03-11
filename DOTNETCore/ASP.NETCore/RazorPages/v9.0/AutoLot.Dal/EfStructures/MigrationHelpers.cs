// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - MigrationHelpers.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/29
// ==================================

namespace AutoLot.Dal.EfStructures;

/*
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        MigrationHelpers.CreateSproc(migrationBuilder);
        MigrationHelpers.CreateFunctions(migrationBuilder);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        MigrationHelpers.DropSproc(migrationBuilder);
        MigrationHelpers.DropFunctions(migrationBuilder);
    }

 */
public static class MigrationHelpers
{

    public static void CreateSproc(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"exec (N' 
                CREATE PROCEDURE [dbo].[GetPetName]
                    @carID int,
                    @petName nvarchar(50) output
                AS
                    SELECT @petName = PetName from dbo.Inventory where Id = @carID')");
    }
    public static void DropSproc(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("EXEC (N' DROP PROCEDURE [dbo].[GetPetName]')");
    }
    public static void CreateFunctions(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql(@"exec (N'
                CREATE FUNCTION [dbo].[udtf_GetCarsForMake] ( @makeId int )
                RETURNS TABLE 
                AS
                RETURN 
                (
                    SELECT Id, IsDrivable, DateBuilt, Color, PetName, MakeId, TimeStamp, Display, Price
                    FROM Inventory WHERE MakeId = @makeId
                )')");
        migrationBuilder.Sql(@"exec (N'
                CREATE FUNCTION [dbo].[udf_CountOfMakes] ( @makeid int )
                RETURNS int
                AS
                BEGIN
                    DECLARE @Result int
                    SELECT @Result = COUNT(makeid) FROM dbo.Inventory WHERE makeid = @makeid
                    RETURN @Result
                END')");
    }
    public static void DropFunctions(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.Sql("EXEC (N' DROP FUNCTION [dbo].[udtf_GetCarsForMake]')");
        migrationBuilder.Sql("EXEC (N' DROP FUNCTION [dbo].[udf_CountOfMakes]')");
    }
}