namespace ProductsShop.Data
{    
    using System;
    using System.Data.Entity;
    using System.Linq;
    using PoductsShop.Models;

    public class ProductsShopEntities : DbContext
    {
        public ProductsShopEntities()
            : base("name=ProductsShopEntities")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });
        }
    }
}