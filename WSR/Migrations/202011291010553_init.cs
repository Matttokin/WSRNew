namespace WSR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nomenclatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderNoms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        NomenclatureId = c.Int(nullable: false),
                        CountInOrder = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Nomenclatures", t => t.NomenclatureId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.NomenclatureId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Adres = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Password = c.String(),
                        RoleId = c.Int(nullable: false),
                        FIO = c.String(),
                        Token = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.OrderNoms", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderNoms", "NomenclatureId", "dbo.Nomenclatures");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.OrderNoms", new[] { "NomenclatureId" });
            DropIndex("dbo.OrderNoms", new[] { "OrderId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderNoms");
            DropTable("dbo.Nomenclatures");
        }
    }
}
