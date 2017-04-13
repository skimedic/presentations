#region copyright
// // Copyright Information
// // ==============================
// // DAL - 201608101617252_Finale.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
namespace DAL.EF.Migrations.Conventions
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Finale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SampleEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RelatedClassId = c.Int(nullable: false),
                        Details_Foo = c.String(),
                        Details_Bar = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RelatedClasses", t => t.RelatedClassId, cascadeDelete: true)
                .Index(t => t.RelatedClassId);
            
            CreateTable(
                "dbo.RelatedClasses",
                c => new
                    {
                        RelatedClassId = c.Int(nullable: false, identity: true),
                        Foo = c.String(),
                        SampleEntityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelatedClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SampleEntities", "RelatedClassId", "dbo.RelatedClasses");
            DropIndex("dbo.SampleEntities", new[] { "RelatedClassId" });
            DropTable("dbo.RelatedClasses");
            DropTable("dbo.SampleEntities");
        }
    }
}
