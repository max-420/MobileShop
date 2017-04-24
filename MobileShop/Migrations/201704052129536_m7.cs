namespace MobileShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goods", "Discriminator", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goods", "Discriminator");
        }
    }
}
