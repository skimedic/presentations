#region copyright
// // Copyright Information
// // ==============================
// // DAL - 201608101617586_Initial.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
namespace DAL.EF.Migrations.Annotations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Data.OurBooks",
                c => new
                    {
                        ISBN_ID_NUMBER = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 8000, unicode: false),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ISBN_ID_NUMBER)
                .ForeignKey("dbo.Posters", t => t.ISBN_ID_NUMBER)
                .Index(t => t.ISBN_ID_NUMBER)
                .Index(t => t.Title, unique: true, name: "Title");
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Address_Street = c.String(),
                        Address_City = c.String(),
                        Address_State = c.String(),
                        WrittenISBN = c.String(maxLength: 128),
                        ReviewedISBN = c.String(maxLength: 128),
                        ReadISBN = c.String(maxLength: 128),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Data.OurBooks", t => t.ReadISBN)
                .ForeignKey("Data.OurBooks", t => t.ReviewedISBN)
                .ForeignKey("Data.OurBooks", t => t.WrittenISBN)
                .Index(t => t.WrittenISBN)
                .Index(t => t.ReviewedISBN)
                .Index(t => t.ReadISBN);
            
            CreateTable(
                "dbo.Posters",
                c => new
                    {
                        ISBN = c.String(nullable: false, maxLength: 128),
                        PosterDescription = c.String(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ISBN);
            
            CreateTable(
                "dbo.Thingies",
                c => new
                    {
                        FirstKey = c.String(nullable: false, maxLength: 128),
                        SecondKey = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        MyBook_ISBN = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FirstKey, t.SecondKey })
                .ForeignKey("Data.OurBooks", t => t.MyBook_ISBN)
                .Index(t => t.MyBook_ISBN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Thingies", "MyBook_ISBN", "Data.OurBooks");
            DropForeignKey("Data.OurBooks", "ISBN_ID_NUMBER", "dbo.Posters");
            DropForeignKey("dbo.People", "WrittenISBN", "Data.OurBooks");
            DropForeignKey("dbo.People", "ReviewedISBN", "Data.OurBooks");
            DropForeignKey("dbo.People", "ReadISBN", "Data.OurBooks");
            DropIndex("dbo.Thingies", new[] { "MyBook_ISBN" });
            DropIndex("dbo.People", new[] { "ReadISBN" });
            DropIndex("dbo.People", new[] { "ReviewedISBN" });
            DropIndex("dbo.People", new[] { "WrittenISBN" });
            DropIndex("Data.OurBooks", "Title");
            DropIndex("Data.OurBooks", new[] { "ISBN_ID_NUMBER" });
            DropTable("dbo.Thingies");
            DropTable("dbo.Posters");
            DropTable("dbo.People");
            DropTable("Data.OurBooks");
        }
    }
}
