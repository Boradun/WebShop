namespace DBRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductAddCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductCategory", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductCategory");
        }
    }
}
