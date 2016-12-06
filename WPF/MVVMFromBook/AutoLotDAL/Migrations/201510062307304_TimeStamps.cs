namespace AutoLotDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
public partial class TimeStamps : DbMigration
{
    public override void Up()
    {
        AddColumn("dbo.CreditRisks", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        AddColumn("dbo.Customers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        AddColumn("dbo.Inventory", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        CreateIndex("dbo.CreditRisks", new[] { "LastName", "FirstName" }, unique: true, name: "IDX_CreditRisk_Name");
    }
        
    public override void Down()
    {
        DropIndex("dbo.CreditRisks", "IDX_CreditRisk_Name");
        DropColumn("dbo.Inventory", "Timestamp");
        DropColumn("dbo.Orders", "Timestamp");
        DropColumn("dbo.Customers", "Timestamp");
        DropColumn("dbo.CreditRisks", "Timestamp");
    }
}
}
