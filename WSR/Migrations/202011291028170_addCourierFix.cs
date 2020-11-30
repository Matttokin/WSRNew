namespace WSR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCourierFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Сourier", "OrderId", "dbo.Orders");
            DropIndex("dbo.Сourier", new[] { "OrderId" });
            AlterColumn("dbo.Сourier", "OrderId", c => c.Int());
            CreateIndex("dbo.Сourier", "OrderId");
            AddForeignKey("dbo.Сourier", "OrderId", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Сourier", "OrderId", "dbo.Orders");
            DropIndex("dbo.Сourier", new[] { "OrderId" });
            AlterColumn("dbo.Сourier", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Сourier", "OrderId");
            AddForeignKey("dbo.Сourier", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
