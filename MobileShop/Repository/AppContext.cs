using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MobileShop.Models;

namespace MobileShop.Repository
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<GoodsImage> PhoneImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public ApplicationContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>()
                .Map<Phone>(m =>
                {
                    m.ToTable("Phones");
                });
            modelBuilder.Entity<Order>()
                .HasMany(o => o.Goods)
                .WithMany()
                .Map(cs =>
                {
                    cs.MapLeftKey("Order_Id");
                    cs.MapRightKey("Phone_Id");
                    cs.ToTable("PhoneOrders");
                });
            modelBuilder.Entity<User>()
                .HasMany(u => u.Basket)
                .WithMany()
                .Map(cs =>
                {
                    cs.MapLeftKey("User_Id");
                    cs.MapRightKey("Phone_Id");
                    cs.ToTable("Baskets");
                });
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
