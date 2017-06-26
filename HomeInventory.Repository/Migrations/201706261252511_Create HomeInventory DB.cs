namespace HomeInventory.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHomeInventoryDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Home",
                c => new
                    {
                        HomeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.HomeId);
            
            CreateTable(
                "dbo.InventoryItem",
                c => new
                    {
                        InventoryItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        SerialNumber = c.String(),
                        ModelNumber = c.String(),
                        DatePurchased = c.DateTime(nullable: false, storeType: "date"),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        HomeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryItemId)
                .ForeignKey("dbo.Home", t => t.HomeId, cascadeDelete: true)
                .Index(t => t.HomeId);
            
            CreateTable(
                "dbo.InventoryItemAttachments",
                c => new
                    {
                        InventoryItemAttachmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        FileLocation = c.String(),
                        InventoryItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryItemAttachmentId)
                .ForeignKey("dbo.InventoryItem", t => t.InventoryItemId, cascadeDelete: true)
                .Index(t => t.InventoryItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryItemAttachments", "InventoryItemId", "dbo.InventoryItem");
            DropForeignKey("dbo.InventoryItem", "HomeId", "dbo.Home");
            DropIndex("dbo.InventoryItemAttachments", new[] { "InventoryItemId" });
            DropIndex("dbo.InventoryItem", new[] { "HomeId" });
            DropTable("dbo.InventoryItemAttachments");
            DropTable("dbo.InventoryItem");
            DropTable("dbo.Home");
        }
    }
}
