#region copyright
// // Copyright Information
// // ==============================
// // DAL - 201608101619444_UseSprocs.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
namespace DAL.EF.Migrations.Store
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UseSprocs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Widgets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IsChanged = c.Boolean(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.Widget_Insert",
                p => new
                    {
                        Description = p.String(),
                        IsChanged = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[Widgets]([Description], [IsChanged])
                      VALUES (@Description, @IsChanged)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Widgets]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id], t0.[Timestamp]
                      FROM [dbo].[Widgets] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Widget_Update",
                p => new
                    {
                        Id = p.Int(),
                        Description = p.String(),
                        IsChanged = p.Boolean(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"UPDATE [dbo].[Widgets]
                      SET [Description] = @Description, [IsChanged] = @IsChanged
                      WHERE (([Id] = @Id) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))
                      
                      SELECT t0.[Timestamp]
                      FROM [dbo].[Widgets] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Widget_Delete",
                p => new
                    {
                        Id = p.Int(),
                        Timestamp_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [dbo].[Widgets]
                      WHERE (([Id] = @Id) AND (([Timestamp] = @Timestamp_Original) OR ([Timestamp] IS NULL AND @Timestamp_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Widget_Delete");
            DropStoredProcedure("dbo.Widget_Update");
            DropStoredProcedure("dbo.Widget_Insert");
            DropTable("dbo.Widgets");
        }
    }
}
