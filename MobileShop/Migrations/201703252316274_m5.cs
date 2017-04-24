namespace MobileShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "CameraVideoResolution_X", c => c.Int());
            AddColumn("dbo.Phones", "CameraVideoResolution_Y", c => c.Int());
            AddColumn("dbo.Phones", "SecondaryCameraOpticalStabilization", c => c.Boolean());
            DropColumn("dbo.Phones", "CameraVideoResolution");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Phones", "CameraVideoResolution", c => c.Int());
            DropColumn("dbo.Phones", "SecondaryCameraOpticalStabilization");
            DropColumn("dbo.Phones", "CameraVideoResolution_Y");
            DropColumn("dbo.Phones", "CameraVideoResolution_X");
        }
    }
}
