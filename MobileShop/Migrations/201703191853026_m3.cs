namespace MobileShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GoodsImages", "Big", c => c.String());
            AddColumn("dbo.GoodsImages", "Medium", c => c.String());
            AddColumn("dbo.GoodsImages", "Small", c => c.String());
            DropColumn("dbo.GoodsImages", "ImagePath");
            DropColumn("dbo.GoodsImages", "ThumbnailPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GoodsImages", "ThumbnailPath", c => c.String());
            AddColumn("dbo.GoodsImages", "ImagePath", c => c.String());
            DropColumn("dbo.GoodsImages", "Small");
            DropColumn("dbo.GoodsImages", "Medium");
            DropColumn("dbo.GoodsImages", "Big");
        }
    }
}
