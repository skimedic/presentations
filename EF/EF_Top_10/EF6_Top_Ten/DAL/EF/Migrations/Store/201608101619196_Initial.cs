#region copyright
// // Copyright Information
// // ==============================
// // DAL - 201608101619196_Initial.cs
// // All samples copyright Philip Japikse 
// // http://www.skimedic.com 2016/08/10
// // See License.txt for more information
// // ==============================
#endregion
namespace DAL.EF.Migrations.Store
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.String(),
                        Balance = c.Double(nullable: false),
                        IsChanged = c.Boolean(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountTransactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountID = c.Int(),
                        Amount = c.Double(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        IsChanged = c.Boolean(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountID)
                .Index(t => t.AccountID);
            
            CreateTable(
                "Catalog.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 100),
                        CategoryId = c.Int(),
                        IsChanged = c.Boolean(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Catalog.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelNumber = c.String(nullable: false, maxLength: 50),
                        ModelName = c.String(nullable: false, maxLength: 150),
                        UnitCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        Description = c.String(),
                        UnitsInStock = c.Int(nullable: false),
                        ProductPhotoId = c.Int(),
                        IsChanged = c.Boolean(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Catalog.Category", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                        IsChanged = c.Boolean(),
                        Timestamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPhotoes", "Id", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "Catalog.Category");
            DropForeignKey("Catalog.Category", "CategoryId", "Catalog.Category");
            DropForeignKey("dbo.AccountTransactions", "AccountID", "dbo.Accounts");
            DropIndex("dbo.ProductPhotoes", new[] { "Id" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("Catalog.Category", new[] { "CategoryId" });
            DropIndex("dbo.AccountTransactions", new[] { "AccountID" });
            DropTable("dbo.ProductPhotoes");
            DropTable("dbo.Products");
            DropTable("Catalog.Category");
            DropTable("dbo.AccountTransactions");
            DropTable("dbo.Accounts");
        }
    }
}
