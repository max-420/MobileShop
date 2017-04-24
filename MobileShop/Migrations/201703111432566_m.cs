namespace MobileShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Vendor = c.String(),
                        Price = c.Int(nullable: false),
                        AvgRating = c.Double(nullable: false),
                        OrdersCount = c.Int(nullable: false),
                        Description = c.String(),
                        Type = c.String(),
                        Discriminator = c.String(maxLength: 128),
                        MainImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GoodsImages", t => t.MainImage_Id)
                .Index(t => t.MainImage_Id);
            
            CreateTable(
                "dbo.GoodsImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ThumbnailPath = c.String(),
                        Goods_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.Goods_Id, cascadeDelete: true)
                .Index(t => t.Goods_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        OrderTime = c.DateTime(nullable: false),
                        Status = c.String(),
                        Address = c.String(nullable: false, maxLength: 50),
                        ContactPhoneNumber = c.String(nullable: false, maxLength: 15),
                        Comment = c.String(maxLength: 500),
                        Goods_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Goods", t => t.Goods_Id)
                .Index(t => t.UserId)
                .Index(t => t.Goods_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoodsId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        SendingTime = c.DateTime(nullable: false),
                        Rating = c.Int(nullable: false),
                        Text = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.GoodsId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GoodsId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.PhoneOrders",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Phone_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Phone_Id })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Goods", t => t.Phone_Id, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => t.Phone_Id);
            
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Phone_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Phone_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Goods", t => t.Phone_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Phone_Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Type = c.String(),
                        OS = c.String(),
                        ReleaseDate = c.DateTime(),
                        ProcessorModel = c.String(),
                        ProcessorCoreCount = c.Int(),
                        ProcessorBitWidth = c.Int(),
                        ProcessorFrequency = c.Int(),
                        GPUModel = c.String(),
                        RAM = c.Int(),
                        MemoryCards = c.Boolean(),
                        MemoryCardsTypes = c.String(),
                        InternalMemory = c.Int(),
                        Camera = c.Boolean(),
                        CameraResolution = c.Int(),
                        CameraVideoResolution = c.Int(),
                        CameraOpticalStabilization = c.Boolean(),
                        SecondaryCamera = c.Boolean(),
                        SecondaryCameraResolution = c.Int(),
                        SecondaryCameraVideoResolution = c.Int(),
                        Flash = c.Boolean(),
                        FlashType = c.String(),
                        DisplayTechnology = c.String(),
                        DisplayColorsNumber = c.Int(),
                        DisplayDiagonal = c.Int(),
                        DisplayPixelDensity = c.Int(),
                        DisplayTouchscreen = c.Boolean(),
                        DisplayTouchscreenType = c.String(),
                        DisplayTouchscreenMultitouch = c.Boolean(),
                        DisplayProtection = c.Boolean(),
                        DisplayProtectionType = c.String(),
                        DisplayForceSensor = c.Boolean(),
                        FormFactor = c.String(),
                        CaseMaterial = c.String(),
                        StereoSpeakers = c.Boolean(),
                        WaterDustProtection = c.Boolean(),
                        WaterDustProtectionType = c.String(),
                        PhisicalQWERTYKeyboard = c.Boolean(),
                        SIMCount = c.Int(),
                        SIMFormat = c.String(),
                        Accelerometer = c.Boolean(),
                        Gyroscope = c.Boolean(),
                        LigthSensor = c.Boolean(),
                        FingerPrintSensor = c.Boolean(),
                        Barometer = c.Boolean(),
                        EDGE = c.Boolean(),
                        HSPA = c.Boolean(),
                        HSPAPlus = c.Boolean(),
                        HSUPA = c.Boolean(),
                        HSDPA = c.Boolean(),
                        LTE = c.Boolean(),
                        WiFi = c.Boolean(),
                        WiFiTypes = c.String(),
                        Bluetooth = c.Boolean(),
                        BluetoothVersion = c.String(),
                        IrDA = c.Boolean(),
                        DisplayResolution_X = c.Int(),
                        DisplayResolution_Y = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goods", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "Id", "dbo.Goods");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Reviews", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "GoodsId", "dbo.Goods");
            DropForeignKey("dbo.Orders", "Goods_Id", "dbo.Goods");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Baskets", "Phone_Id", "dbo.Goods");
            DropForeignKey("dbo.Baskets", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PhoneOrders", "Phone_Id", "dbo.Goods");
            DropForeignKey("dbo.PhoneOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Goods", "MainImage_Id", "dbo.GoodsImages");
            DropForeignKey("dbo.GoodsImages", "Goods_Id", "dbo.Goods");
            DropIndex("dbo.Phones", new[] { "Id" });
            DropIndex("dbo.Baskets", new[] { "Phone_Id" });
            DropIndex("dbo.Baskets", new[] { "User_Id" });
            DropIndex("dbo.PhoneOrders", new[] { "Phone_Id" });
            DropIndex("dbo.PhoneOrders", new[] { "Order_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Reviews", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "GoodsId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Orders", new[] { "Goods_Id" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.GoodsImages", new[] { "Goods_Id" });
            DropIndex("dbo.Goods", new[] { "MainImage_Id" });
            DropTable("dbo.Phones");
            DropTable("dbo.Baskets");
            DropTable("dbo.PhoneOrders");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Reviews");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Orders");
            DropTable("dbo.GoodsImages");
            DropTable("dbo.Goods");
        }
    }
}
