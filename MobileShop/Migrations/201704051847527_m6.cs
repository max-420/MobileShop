namespace MobileShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Goods", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Goods", "Discriminator", c => c.String(maxLength: 128));
        }
    }
}
