namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_UstCategory_To_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "UstCategoryID", c => c.Int());
            AddColumn("dbo.Categories", "UstCategory_CategoryID", c => c.Int());
            CreateIndex("dbo.Categories", "UstCategory_CategoryID");
            AddForeignKey("dbo.Categories", "UstCategory_CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "UstCategory_CategoryID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "UstCategory_CategoryID" });
            DropColumn("dbo.Categories", "UstCategory_CategoryID");
            DropColumn("dbo.Categories", "UstCategoryID");
        }
    }
}
