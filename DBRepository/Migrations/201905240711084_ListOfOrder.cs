namespace DBRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ListOfOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        NameOfProductList = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductOrderLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductQuantity = c.Int(nullable: false),
                        NameOfList = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "ProductImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductImage");
            DropTable("dbo.ProductOrderLists");
            DropTable("dbo.Orders");
        }
    }
}
