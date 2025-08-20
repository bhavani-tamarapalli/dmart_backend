//using Dmart_web.Core.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Dmart_web.Data.Context
//{
//    public class DmartContext : DbContext
//    {
//        public DmartContext(DbContextOptions<DmartContext> options) : base(options) { }

//        public DbSet<Category> Categories { get; set; }
//        public DbSet<SubCategory> SubCategories { get; set; }
//        public DbSet<Product> Products { get; set; }
//        public DbSet<Cart> Carts { get; set; }
//        public DbSet<CartItem> CartItems { get; set; }
//        //public DbSet<Customer> Customers { get; set; }

//        public DbSet<User> Users { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // Category → SubCategory
//            modelBuilder.Entity<Category>()
//                .HasMany(c => c.SubCategories)
//                .WithOne(sc => sc.Category)
//                .HasForeignKey(sc => sc.CategoryId);

//            // SubCategory → Product
//            modelBuilder.Entity<SubCategory>()
//                .HasMany(sc => sc.Products)
//                .WithOne(p => p.SubCategory)
//                .HasForeignKey(p => p.SubCategoryId);

//            // Cart → CartItems
//            modelBuilder.Entity<Cart>()
//                .HasMany(c => c.CartItems)
//                .WithOne(ci => ci.Cart)
//                .HasForeignKey(ci => ci.CartId);
//        }
//    }
//}



//using Dmart_web.Core.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Dmart_web.Data.Context
//{
//    public class DmartContext : DbContext
//    {
//        public DmartContext(DbContextOptions<DmartContext> options) : base(options) { }

//        public DbSet<Category> Categories { get; set; }
//        public DbSet<SubCategory> SubCategories { get; set; }
//        public DbSet<Product> Products { get; set; }
//        public DbSet<Cart> Carts { get; set; }
//        public DbSet<CartItem> CartItems { get; set; }
//        public DbSet<User> Users { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // User entity configuration
//            modelBuilder.Entity<User>(entity =>
//            {
//                entity.HasIndex(u => u.Username).IsUnique();
//                entity.HasIndex(u => u.Email).IsUnique();
//                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
//                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
//            });

//            // Category → SubCategory
//            modelBuilder.Entity<Category>()
//                .HasMany(c => c.SubCategories)
//                .WithOne(sc => sc.Category)
//                .HasForeignKey(sc => sc.CategoryId);

//            // SubCategory → Product
//            modelBuilder.Entity<SubCategory>()
//                .HasMany(sc => sc.Products)
//                .WithOne(p => p.SubCategory)
//                .HasForeignKey(p => p.SubCategoryId);

//            // Cart → CartItems
//            modelBuilder.Entity<Cart>()
//                .HasMany(c => c.CartItems)
//                .WithOne(ci => ci.Cart)
//                .HasForeignKey(ci => ci.CartId);
//        }
//    }
//}



using Dmart_web.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Dmart_web.Data.Context
{
    public class DmartContext : DbContext
    {
        public DmartContext(DbContextOptions<DmartContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User entity configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Username).IsUnique();
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
            });

            // Category → SubCategory
            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(sc => sc.Category)
                .HasForeignKey(sc => sc.CategoryId);

            // SubCategory → Product
            modelBuilder.Entity<SubCategory>()
                .HasMany(sc => sc.Products)
                .WithOne(p => p.SubCategory)
                .HasForeignKey(p => p.SubCategoryId);

            // Cart → CartItems
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartItems)
                .WithOne(ci => ci.Cart)
                .HasForeignKey(ci => ci.CartId);
        }
    }
}