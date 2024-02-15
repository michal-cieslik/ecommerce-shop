using ecommerce_shop.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_shop.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Orders)
                .WithOne(o => o.User);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Carts);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products);


        }
    }
}