namespace WSR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCourierNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Сourier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Status = c.String(),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Сourier", "UserId", "dbo.Users");
            DropForeignKey("dbo.Сourier", "OrderId", "dbo.Orders");
            DropIndex("dbo.Сourier", new[] { "OrderId" });
            DropIndex("dbo.Сourier", new[] { "UserId" });
            DropTable("dbo.Сourier");
        }
    }
}
