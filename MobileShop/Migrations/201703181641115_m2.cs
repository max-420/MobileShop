namespace MobileShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Phones", "Camera_HasCamera", c => c.Boolean());
            AddColumn("dbo.Phones", "Camera_CameraResolution", c => c.Int());
            AddColumn("dbo.Phones", "Camera_CameraVideoResolution", c => c.Int());
            AddColumn("dbo.Phones", "Camera_CameraOpticalStabilization", c => c.Boolean());
            AddColumn("dbo.Phones", "Camera_SecondaryCamera", c => c.Boolean());
            AddColumn("dbo.Phones", "Camera_SecondaryCameraResolution", c => c.Int());
            AddColumn("dbo.Phones", "Camera_SecondaryCameraVideoResolution", c => c.Int());
            AddColumn("dbo.Phones", "Camera_Flash", c => c.Boolean());
            AddColumn("dbo.Phones", "Camera_FlashType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phones", "Camera_FlashType");
            DropColumn("dbo.Phones", "Camera_Flash");
            DropColumn("dbo.Phones", "Camera_SecondaryCameraVideoResolution");
            DropColumn("dbo.Phones", "Camera_SecondaryCameraResolution");
            DropColumn("dbo.Phones", "Camera_SecondaryCamera");
            DropColumn("dbo.Phones", "Camera_CameraOpticalStabilization");
            DropColumn("dbo.Phones", "Camera_CameraVideoResolution");
            DropColumn("dbo.Phones", "Camera_CameraResolution");
            DropColumn("dbo.Phones", "Camera_HasCamera");
        }
    }
}
